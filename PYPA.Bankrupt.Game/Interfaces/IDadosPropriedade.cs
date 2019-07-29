using System;
using System.Collections.Generic;
using System.Text;

namespace PYPA.Bankrupt.Game.Interfaces
{
    public interface IDadosPropriedade
    {
        String Nome { get; }
        int ValorDeVenda { get; }
        int ValorDeAluguel { get; }
    }
}
