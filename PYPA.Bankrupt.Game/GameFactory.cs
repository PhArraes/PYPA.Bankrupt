using PYPA.Bankrupt.Core;
using PYPA.Bankrupt.Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PYPA.Bankrupt.Game
{
    public class GameFactory
    {
        public IGame Create(List<IDadosPropriedade> propriedades, List<Player> players, IRoller roller, DateTime dataCriação)
        {
            return new Game(propriedades, players, roller, dataCriação);
        }
    }
}
