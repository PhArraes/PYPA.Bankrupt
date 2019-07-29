using System;
using System.Collections.Generic;
using System.Text;
using PYPA.Bankrupt.Core;
using PYPA.Bankrupt.Game.Interfaces;

namespace PYPA.Bankrupt.IA.Personalidades
{
    class Aleatório : PersonalidadeBase, IPlayerIA
    {
        private Roller Roller { get; set; }
        public Aleatório()
        {
            Roller = new Roller();
        }
        protected override bool PodeComprar(IJogada jogada)
        {
            return Roller.RollInt(2) == 1;
        }
    }
}
