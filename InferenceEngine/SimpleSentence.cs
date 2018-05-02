using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InferenceEngine
{
    class SimpleSentence : Sentence
    {
        string _symbol;
        public SimpleSentence(string symbol)
        {
            _symbol = symbol;
        }

        string getSymbol
        {
            get
            {
                return _symbol;
            }
        }
    }
}
