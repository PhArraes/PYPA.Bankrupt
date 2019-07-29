using System;
using System.Collections.Generic;
using System.Text;

namespace PYPA.Bankrupt.Game
{
   public class Carteira
    {
        public int Coins { get; private set; }
        public bool Bankrupt { get { return Coins < 1; } }

        Carteira(int valorInicial)
        {
            Coins = valorInicial;
        }

         int Retirar(int valor)
        {
            var saldoAtual = Coins;
            Coins -= valor;
            return Math.Min(saldoAtual, valor);
        }
         void Depositar(int valor)
        {
            Coins += valor;
        }
    }
}
