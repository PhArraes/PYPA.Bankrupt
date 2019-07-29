using PYPA.Bankrupt.IA.Personalidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace PYPA.Bankrupt.IA
{
    public class IAFactory
    {

        private Dictionary<Personalidade, Func<IPlayerIA>> _IAStrategy;

        public IAFactory()
        {
            _IAStrategy = new Dictionary<Personalidade, Func<IPlayerIA>>();
            _IAStrategy.Add(Personalidade.Aleatório, CreateAleatório);
            _IAStrategy.Add(Personalidade.Cauteloso, CreateCauteloso);
            _IAStrategy.Add(Personalidade.Exigente, CreateExigente);
            _IAStrategy.Add(Personalidade.Impulsivo, CreateImpulsivo);
        }

        public IPlayerIA CreateIA(Personalidade personalidade)
        {
            return _IAStrategy[personalidade]();
        }

        private IPlayerIA CreateAleatório()
        {
            return new Aleatório();
        }
        private IPlayerIA CreateCauteloso()
        {
            return new Cauteloso();
        }
        private IPlayerIA CreateExigente()
        {
            return new Exigente();
        }
        private IPlayerIA CreateImpulsivo()
        {
            return new Impulsivo();
        }
    }
}
