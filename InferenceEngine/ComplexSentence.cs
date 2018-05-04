using System;
using System.Collections.Generic;
using System.Text;

namespace InferenceEngine2
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
    }
}
