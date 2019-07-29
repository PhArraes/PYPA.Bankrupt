using PYPA.Bankrupt.Game;
using PYPA.Bankrupt.IA;
using System;
using System.Collections.Generic;
using System.Text;

namespace PYPA.Bankrupt
{
    class GameSimulationEngine
    {
        public List<Player> Players { get; set; }
        public Dictionary<Guid, IPlayerIA> PlayersIA { get; set; }

        public GameSimulationEngine()
        {
            var criação = DateTime.Now;
            IniciarPlayers(criação);
        }

        private void IniciarPlayers(DateTime criação)
        {
            PlayersIA = new Dictionary<Guid, IPlayerIA>();
            Players = new List<Player>();
            var IAFactory = new IAFactory();

            var player1 = new Player("impulsivo", criação);
            Players.Add(player1);
            PlayersIA.Add(player1.Id, IAFactory.CreateIA(Personalidade.Impulsivo));

            var player2 = new Player("exigente", criação);
            Players.Add(player2);
            PlayersIA.Add(player2.Id, IAFactory.CreateIA(Personalidade.Exigente));

            var player3 = new Player("cauteloso", criação);
            Players.Add(player3);
            PlayersIA.Add(player3.Id, IAFactory.CreateIA(Personalidade.Cauteloso));

            var player4 = new Player("aleatório", criação);
            Players.Add(player4);
            PlayersIA.Add(player4.Id, IAFactory.CreateIA(Personalidade.Aleatório));
        }
    }
}
