using System;
using System.Collections.Generic;
using System.Text;

namespace InferenceEngine
{
    public abstract class Sentence
    {
        bool _isFalse;
        protected Sentence _head;

        public Sentence(bool isFalse)
        {
            _isFalse = isFalse;
        }

        public Sentence(bool isFalse, Sentence head)
        {
            _isFalse = isFalse;
            _head = head;
        }

        public virtual Sentence Head()
        {
            return _head;
        }

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
    }
}
