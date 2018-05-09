﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InferenceEngine
{
    class Model
    {
        Dictionary<string, bool> _model = new Dictionary<string, bool>();
        public Model(List<String> currentlyTrue)
        {
            //foreach(string s in currentlyTrue)
            //{
            //    _model.Add(s, true);
            //}
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

        public Model Extend(string proposition, bool value)
        {
            Model temp = this;
            temp.getModel.Add(proposition, value);
            return temp;
        }

        public bool Contains(string proposition)
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
        
        public void Add(string proposition)
        {
            _model.Add(proposition, true);
        }
    }
}