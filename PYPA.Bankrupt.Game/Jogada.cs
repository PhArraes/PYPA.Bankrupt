using PYPA.Bankrupt.Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PYPA.Bankrupt.Game
{
    class Jogada : IJogada
    {
        public IPropriedade Propriedade { get;  set; }

        public int Dado { get;  set; }

        public int Saldo { get;  set; }

        public IList<Ação> AçõesPossíveis { get;  set; }
    }
}
