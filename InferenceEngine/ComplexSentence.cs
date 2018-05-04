using System;
using System.Collections.Generic;
using System.Text;

namespace InferenceEngine
{
    class ComplexSentence : Sentence
    {
        Sentence _head;
        Sentence _body;
        Connective _connective;

        public ComplexSentence(Sentence body, Sentence head, bool isFalse, Connective connective) : base(isFalse)
        {
            _head = head;
            _body = body;
            _connective = connective;
        }

        Sentence Head
        {
            get
            {
                return _head;
            }
        }

        Sentence Body
        {
            get
            {
                return _body;
            }
        }

        Connective Connective
        {
            get
            {
                return _connective;
            }
        }

        public override List<String> GetSymbols()
        {
            List<String> symbols = new List<String>();
            List<String> temp;
            // get symbols within head and body
            temp = Head.GetSymbols();
            foreach(string s in temp)
            {
                if (!symbols.Contains(s))
                {
                    symbols.Add(s);
                }
            }
            temp = Body.GetSymbols();
            foreach (string s in temp)
            {
                if (!symbols.Contains(s))
                {
                    symbols.Add(s);
                }
            }
            return temp;
        }
    }
}
