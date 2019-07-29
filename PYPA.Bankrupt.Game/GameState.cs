using PYPA.Bankrupt.Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PYPA.Bankrupt.Game
{
    class GameState
    {
        public Dictionary<int, Propriedade> Propriedades { get; set; }
        public int PlayersAtivos { get { return _players.Values.Count(p => !p.Carteira.Bankrupt); } }
        public IList<IPlayerGameState> PlayersRank { get { return _players.Values.OrderByDescending(p => p.Carteira.Coins).ToList<IPlayerGameState>(); } }

        private Dictionary<Guid, PlayerGameState> _players;
        private Dictionary<Ação, Action<PlayerGameState>> _jogarStrategy;
        private int _numPropriedades = 0;

        public GameState(List<IDadosPropriedade> propriedades, List<Player> players, int valorInicial)
        {
            DefinirPropriedades(propriedades);
            IniciarPlayers(players, valorInicial);
            _jogarStrategy = new Dictionary<Ação, Action<PlayerGameState>>();
            _jogarStrategy.Add(Ação.Comprar, Comprar);
            _jogarStrategy.Add(Ação.PagarAluguel, PagarAluguel);
            _jogarStrategy.Add(Ação.Passar, Passar);
        }

        public IPlayerGameState MoverPlayer(Guid player, int casas)
        {
            var playerState = _players[player];
            if (playerState.PosiçãoAtual + casas > _numPropriedades) playerState.AdicionaVolta();
            playerState.PosiçãoAtual = (playerState.PosiçãoAtual + casas) % _numPropriedades;
            return playerState;
        }
        public IPlayerGameState Jogar(Guid player, Ação ação)
        {
            var playerState = _players[player];
            _jogarStrategy[ação](playerState);
            return playerState;
        }

        public IPlayerGameState PlayerGameState(Guid playerId)
        {
            return _players[playerId];
        }


        private void Comprar(PlayerGameState player)
        {
            var propriedade = Propriedades[player.PosiçãoAtual];
            player.Carteira.Retirar(propriedade.ValorDeVenda);
            propriedade.Comprar(player.Player);
            VerificarFalência(player);
        }
        private void PagarAluguel(PlayerGameState player)
        {
            var propriedade = Propriedades[player.PosiçãoAtual];
            var dono = _players[propriedade.Dono];
            var valor = player.Carteira.Retirar(propriedade.ValorDeAluguel);
            dono.Carteira.Depositar(valor);
            VerificarFalência(player);
        }
        private void Passar(PlayerGameState player)
        {
        }

        private void VerificarFalência(PlayerGameState player)
        {
            if (!player.Carteira.Bankrupt) return;
            Propriedades.Values.ToList().ForEach(p =>
            {
                if (p.Dono == player.Player) p.Desapropriar();
            });
        }

        private void DefinirPropriedades(List<IDadosPropriedade> propriedades)
        {
            var index = 0;
            _numPropriedades = propriedades.Count();
            this.Propriedades = propriedades
                .Select(p => new Propriedade(p.Nome, p.ValorDeVenda, p.ValorDeAluguel))
                .ToDictionary(p => index++);
        }

        private void IniciarPlayers(List<Player> players, int valorInicial)
        {
            _players = new Dictionary<Guid, PlayerGameState>();
            players.ForEach(p => _players.Add(p.Id, new PlayerGameState(p, valorInicial)));

        }
    }
}
