using PYPA.Bankrupt.Game;
using PYPA.Bankrupt.Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PYPA.Bankrupt.IA.Personalidades
{
    class Cauteloso : PersonalidadeBase, IPlayerIA
    {
        protected override bool PodeComprar(IJogada jogada) {
            return jogada.Saldo - jogada.Propriedade.ValorDeVenda > 80;
        }
    }
}
