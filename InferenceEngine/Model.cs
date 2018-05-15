using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InferenceEngine
{
    public class Model
    {
        private Dictionary<string, bool> _model = new Dictionary<string, bool>();
        public Model()
        {
        }

        public Model(Model m)
        {
            foreach (KeyValuePair<string, bool> proposition in m.getModel)
            {
                _model.Add(proposition.Key, proposition.Value);
            }
        }

        public Dictionary<string, bool> getModel
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
            }
        }

        public bool Contains(string proposition)
        {
            if (_model.ContainsKey(proposition))
            {
                return true;
            }
            return false;
        }

        public bool ContainsPositive(string proposition)
        {
            if (_model.ContainsKey(proposition))
            {
                if (_model[proposition] == true)
                {
                    return true;
                }
            }
            return false;
        }
        
        public void Add(string proposition, bool value)
        {
            if(!_model.ContainsKey(proposition))
            {
                _model.Add(proposition, value);
            }
        }
    }
}
