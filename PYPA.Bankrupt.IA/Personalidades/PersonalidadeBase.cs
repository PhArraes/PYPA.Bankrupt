using PYPA.Bankrupt.Game;
using PYPA.Bankrupt.Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PYPA.Bankrupt.IA.Personalidades
{
    abstract class PersonalidadeBase
    {
        public Ação Jogar(IJogada jogada)
        {
            if (jogada.AçõesPossíveis.Contains(Ação.Comprar) && TemDinheiroParaComprar(jogada) && PodeComprar(jogada))
                return Ação.Comprar;
            if (jogada.AçõesPossíveis.Contains(Ação.PagarAluguel))
                return Ação.PagarAluguel;
            return Ação.Passar;
        }

        public bool TemDinheiroParaComprar(IJogada jogada)
        {
            return jogada.Saldo >= jogada.Propriedade.ValorDeVenda;
        }

        protected abstract bool PodeComprar(IJogada jogada);
    }
}
