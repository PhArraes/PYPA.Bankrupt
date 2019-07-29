using PYPA.Bankrupt.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PYPA.Bankrupt.Game
{
    public class Player : Entity
    {
        public String Name { get; private set; }

        public Player(String name, DateTime creationTime) : base(Guid.NewGuid(), creationTime)
        {
            this.Name = name;
        }

        public void DefineName(string name)
        {
            if (string.IsNullOrEmpty(name)) return;
            this.Name = name;
        }
    }
}
