using System;

namespace PYPA.Bankrupt.Game
{
    public interface IPlayerGameState
    {
        Carteira Carteira { get; }
        Guid Player { get; }
        int PosiçãoAtual { get; set; }
        int Voltas { get; }
    }
}