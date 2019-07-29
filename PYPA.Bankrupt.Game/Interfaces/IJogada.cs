using System;
using System.Collections.Generic;
using System.Text;

namespace PYPA.Bankrupt.Game.Interfaces
{
    public interface IJogada
    {
        IPropriedade Propriedade { get; }
        int Dado { get; }
        int Saldo { get; }
        IList<Ação> AçõesPossíveis { get; }
    }
}
