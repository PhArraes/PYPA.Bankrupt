using PYPA.Bankrupt.Core;
using PYPA.Bankrupt.Game;
using PYPA.Bankrupt.Game.Interfaces;
using PYPA.Bankrupt.IA;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYPA.Bankrupt
{
    class GameSimulationEngine
    {
        public List<Player> Players { get; private set; }
        public Dictionary<Guid, IPlayerIA> PlayersIA { get; private set; }
        public List<IDadosPropriedade> Propriedades { get; private set; }
        public int NúmeroDeSimulações { get; private set; }
        public ConcurrentBag<IGame> Simulações { get; }
        public ConcurrentDictionary<string, int> VencedorCount { get; }
        public int NumSimulaçõesComTimeout { get { return Simulações.Count(s => s.Rodada >= GameConfig.MAX_RODADAS); } }
        public int MédiaDeDuraçãoDeSimulações { get { return Simulações.Sum(s => s.Rodada) / NúmeroDeSimulações; } }
        public List<string> VencedorPercentual
        {
            get
            {
                var listPerc = new List<string>();
                VencedorCount.OrderBy(i => i.Key).ToList()
                        .ForEach(c =>
                        {
                            var perc = (c.Value / (double)NúmeroDeSimulações) * 100;
                            listPerc.Add($"{c.Key} = {string.Format("{0:0.00}", perc)}%");
                        });
                return listPerc;
            }
        }
        public string MaiorVencedor
        {
            get
            {
                return VencedorCount.OrderByDescending(i => i.Value)
                        .FirstOrDefault().Key;
            }
        }
        private GameFactory _gameFactory;
        public GameSimulationEngine(List<IDadosPropriedade> propriedades, int numSimulações)
        {
            var criação = DateTime.Now;
            Propriedades = propriedades;
            Simulações = new ConcurrentBag<IGame>();
            VencedorCount = new ConcurrentDictionary<string, int>();
            NúmeroDeSimulações = numSimulações;
            _gameFactory = new GameFactory();
            IniciarPlayers(criação);
        }

        public void Executar()
        {

            List<Task<bool>> tasks = new List<Task<bool>>();
            for (int i = 0; i < NúmeroDeSimulações; i++)
            {
                tasks.Add(AdicionarSimulação());
            }
            bool[] res = Task.WhenAll(tasks).Result;
        }

        private Task<bool> AdicionarSimulação()
        {
            return Task.Factory.StartNew(() =>
            {
                var game = CreateGame();
                Simulações.Add(game);
                JogarPartida(game);
                VencedorCount[game.Vencendor.Name]++;
                return true;
            });
        }

        private void JogarPartida(IGame game)
        {
            while (!game.Terminou)
            {
                var jogador = game.JogadorDaRodada();
                var jogada = game.ComeçarRodada();
                game.Jogar(PlayersIA[jogador.Id].Jogar(jogada));
            }
        }

        private IGame CreateGame()
        {
            var Roller = new DiceRoller(6);
            return _gameFactory.Create(Propriedades, Players, Roller, DateTime.Now);
        }
        private void IniciarPlayers(DateTime criação)
        {
            PlayersIA = new Dictionary<Guid, IPlayerIA>();
            Players = new List<Player>();
            var IAFactory = new IAFactory();

            var player1 = new Player("impulsivo", criação);
            Players.Add(player1);
            PlayersIA.Add(player1.Id, IAFactory.CreateIA(Personalidade.Impulsivo));
            VencedorCount.GetOrAdd("impulsivo", 0);

            var player2 = new Player("exigente", criação);
            Players.Add(player2);
            PlayersIA.Add(player2.Id, IAFactory.CreateIA(Personalidade.Exigente));
            VencedorCount.GetOrAdd("exigente", 0);

            var player3 = new Player("cauteloso", criação);
            Players.Add(player3);
            PlayersIA.Add(player3.Id, IAFactory.CreateIA(Personalidade.Cauteloso));
            VencedorCount.GetOrAdd("cauteloso", 0);

            var player4 = new Player("aleatório", criação);
            Players.Add(player4);
            PlayersIA.Add(player4.Id, IAFactory.CreateIA(Personalidade.Aleatório));
            VencedorCount.GetOrAdd("aleatório", 0);
        }
    }
}
