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

        public SimpleSentence Head
        {
            get
            {
                return this;
            }
        }

        public override SimpleSentence getHead()
        {
            return this;
        }

        public override string SymbolsAsString()
        {
            return _symbol;
        }

        public override int getCount()
        {
            return 1;  // simple sentence always only has 1 symbol
        }

        public bool isEqual(Sentence p)
        {
            if(p is SimpleSentence)
            {
                return (this.GetSymbols()[0] == p.GetSymbols()[0]);
            }
            return false;
        }

    }
}
