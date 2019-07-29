using System;
using System.Collections.Generic;
using System.Text;

namespace PYPA.Bankrupt.Game.Interfaces
{
    public interface IPropriedade
    {
        String Nome { get; }
        int ValorDeVenda { get; }
        int ValorDeAluguel { get; }
        bool TemDono { get; }
    }
}
