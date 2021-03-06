﻿using System;
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

        public Model(List<String> symbol, bool value)
        {
            foreach(string s in symbol)
            {
                Add(s, false);
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

        public bool ContainsPositive(SimpleSentence s)
        {
            string proposition = s.GetSymbols()[0];
            return ContainsPositive(proposition);
        }
        
        public void Add(string proposition, bool value)
        {
            if(!_model.ContainsKey(proposition))
            {
                _model.Add(proposition, value);
            }
        }

        public void setTrue(SimpleSentence p)
        {
            _model[p.GetSymbols()[0]] = true;
        }

        public string getString()
        {
            string temp = "";

            foreach (KeyValuePair<string, bool> proposition in _model)
            {
                if (_model[proposition.Key])
                {
                    temp += proposition.Key + ", ";
                    temp = temp.Trim();
                    temp = temp.TrimEnd(',');
                }
               
            }
            return temp;
        }

        public bool isAllTrue(Queue<SimpleSentence> agenda)
        {
            foreach(SimpleSentence s in agenda)
            {
                if (_model[s.GetSymbols()[0]] == false) return false;
            }
            return true;
        }

        public void makeTrue(List<SimpleSentence> propositions)
        {
            foreach(SimpleSentence p in propositions)
            {
                setTrue(p);
            }
        }
        
    }
}
