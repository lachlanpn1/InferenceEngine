using System;
using System.Collections.Generic;
using System.Text;

namespace InferenceEngine
{
    class SimpleSentence : Sentence
    {
        string _symbol;

        public SimpleSentence(string symbol, bool isFalse) : base(isFalse)
        {
            _symbol = symbol;
        }

        string Symbol
        {
            get
            {
                return _symbol;
            }
        }
    }
}
