using System;
using System.Collections.Generic;
using System.Text;

namespace InferenceEngine
{
    public class SimpleSentence : Sentence
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

        public override bool Entails(Model m)
        {
            return m.ContainsPositive(_symbol);
        }

        public override Sentence Head()
        {
            return this;
        }

    }
}
