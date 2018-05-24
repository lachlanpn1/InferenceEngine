using System;
using System.Collections.Generic;
using System.Text;

namespace InferenceEngine
{
    public abstract class Sentence
    {
        bool _isFalse;

        public Sentence(bool isFalse)
        {
            _isFalse = isFalse;
        }

        public abstract SimpleSentence getHead();
  
        public bool isFalse
        {
            get
            {
                return _isFalse;
            }
            set
            {
                _isFalse = value;
            }
        }

        public abstract bool Entails(Model m);
        public abstract List<String> GetSymbols();
        public abstract int getCount();
        public abstract string SymbolsAsString();
    }
}
