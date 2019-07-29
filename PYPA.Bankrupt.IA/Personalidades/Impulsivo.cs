using PYPA.Bankrupt.Game;
using PYPA.Bankrupt.Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PYPA.Bankrupt.IA.Personalidades
{
    class Impulsivo : PersonalidadeBase, IPlayerIA
    {
        protected override bool PodeComprar(IJogada jogada)
        {
            return true;
        }
    }
}
