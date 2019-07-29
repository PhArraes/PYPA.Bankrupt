using PYPA.Bankrupt.Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PYPA.Bankrupt.Game
{
    class Propriedade : IPropriedade
    {
        public String Nome { get; private set; }
        public int ValorDeVenda { get; private set; }
        public int ValorDeAluguel { get; private set; }
        public Guid Dono { get; private set; }
        public bool TemDono { get { return Dono != Guid.Empty; } }

        public Propriedade(string nome, int valorDeVenda, int valorDeAluguel)
        {
            DefinirNome(nome);
            DefinirValorDeVenda(valorDeVenda);
            DefinirValorDeAluguel(valorDeAluguel);
        }

        public bool PodeComprar(PlayerGameState player)
        {
            return ValorDeVenda <= player.Carteira.Coins && !TemDono;
        }

        public bool Comprar(Guid player)
        {
            if (Dono != Guid.Empty) return false;
            Dono = player;
            return true;
        }
        public void Desapropriar()
        {
            Dono = Guid.Empty;
        }

        private void DefinirNome(string nome)
        {

            if (string.IsNullOrEmpty(nome)) throw new Exception($"Nome inválido de propriedade: {nome ?? "NUll"}");
            this.Nome = nome;
        }

        private void DefinirValorDeVenda(int valorDeVenda)
        {
            if (valorDeVenda < 0) throw new Exception($"Valor de venda de propriedade inválido: {valorDeVenda}");
            this.ValorDeVenda = valorDeVenda;
        }
        private void DefinirValorDeAluguel(int valorDeAluguel)
        {
            if (valorDeAluguel < 0) throw new Exception($"Valor de aluguel de propriedade inválido: {valorDeAluguel}");
            this.ValorDeAluguel = valorDeAluguel;
        }
    }
}
