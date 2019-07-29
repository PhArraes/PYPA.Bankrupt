using System;
using System.Collections.Generic;
using System.Text;

namespace PYPA.Bankrupt.Core
{
    public class DiceRoller : IRoller
    {
        public int Faces { get;  }
        private Roller Roller;

        public DiceRoller(int faces)
        {
            Faces = faces;
            Roller = new Roller();
        }

        public int Roll()
        {
            return Roller.RollInt(Faces);
        }
    }
}
