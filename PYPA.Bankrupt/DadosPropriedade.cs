using PYPA.Bankrupt.Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PYPA.Bankrupt
{
    class DadosPropriedade : IDadosPropriedade
    {
        public string Nome { get; set; }

        public int ValorDeVenda { get; set; }

        public int ValorDeAluguel { get; set; }

        public DadosPropriedade(int num, int valorVenda, int valorAluguel)
        {
            Nome = $"Propriedade {num}";
            DefinirVenda(valorVenda);
            DefinirAluguel(valorAluguel);
        }

        private void DefinirVenda(int venda)
        {
            if (venda < 0) throw new Exception("Valor de venda iválido");
            this.ValorDeVenda = venda;
        }
        private void DefinirAluguel(int aluguel)
        {
            if (aluguel < 0) throw new Exception("Valor de aluguel iválido");
            this.ValorDeAluguel = aluguel;
        }
    }
}
