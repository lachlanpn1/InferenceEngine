using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InferenceEngine
{
    class ComplexSentence : Sentence
    {
        List<Sentence> _symbols = new List<Sentence>();
        List<Connective> _connectives = new List<Connective>();
        public ComplexSentence(List<Sentence> sentences, List<Connective> connectives)
        {
            _symbols = sentences;
            _connectives = connectives; 
        }
    }
}
