using System;
using System.Collections.Generic;
using System.Text;

namespace PYPA.Bankrupt.Core
{
    public class Entity
    {
        public Guid Id { get;private set;}
        public DateTime DataCriação { get;private set;}
        public Boolean Ativo { get;private set;}

        public Entity(Guid id, DateTime dataCriação)
        {
            this.Id = id;
            this.DataCriação = dataCriação;
            Ativo = true;
        }

    }
}
