using System;
using System.Collections.Generic;
using System.Text;

namespace PYPA.Bankrupt.Game
{
    class PlayerGameState : IPlayerGameState
    {
        public Guid Player { get; }
        public Carteira Carteira { get; }
        public int PosiçãoAtual { get; set; }
        public int Voltas { get; private set; }

        public PlayerGameState(Player player, int valorInicial)
        {
            this.Player = player.Id;
            PosiçãoAtual = 0;
            Voltas = 0;
            Carteira = new Carteira(valorInicial);
        }

        public void AdicionaVolta()
        {
            Voltas++;
            Carteira.Depositar(GameConfig.BONUS_POR_VOLTA_TABULEIRO);
        }

    }
}
