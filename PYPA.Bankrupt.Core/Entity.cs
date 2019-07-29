using System;
using System.Collections.Generic;
using System.Text;

namespace PYPA.Bankrupt.Core
{
    public class Entity
    {
        public Guid Id { get;private set;}
        public DateTime CreationTime { get;private set;}
        public Boolean Active { get;private set;}

        public Entity(Guid id, DateTime creationTime)
        {
            this.Id = id;
            this.CreationTime = creationTime;
            Active = true;
        }

    }
}
