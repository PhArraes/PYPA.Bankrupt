using System;
using System.Collections.Generic;
using System.Text;

namespace PYPA.Bankrupt.Game
{
   public class Carteira
    {
        public int Coins { get; private set; }
        public bool Bankrupt { get { return Coins < 0; } }

       public  Carteira(int valorInicial)
        {
            Coins = valorInicial;
        }

        public int Retirar(int valor)
        {
            var saldoAtual = Coins;
            Coins -= valor;
            return Math.Min(saldoAtual, valor);
        }
        public void Depositar(int valor)
        {
            Coins += valor;
        }
    }
}
