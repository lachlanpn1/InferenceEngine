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

        public override List<String> GetSymbols()
        {
            List<String> temp = new List<String>();
            temp.Add(_symbol);
            return temp;
        }

    }
}
