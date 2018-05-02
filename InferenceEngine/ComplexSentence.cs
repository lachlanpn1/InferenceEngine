using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InferenceEngine
{
    class ComplexSentence : Sentence
    {
        List<SimpleSentence> _symbols = new List<SimpleSentence>();
        List<Connective> _connectives = new List<Connective>();
        public ComplexSentence(List<SimpleSentence> sentences, List<Connective> connectives)
        {
            _symbols = sentences;
            _connectives = connectives; 
        }
    }
}
