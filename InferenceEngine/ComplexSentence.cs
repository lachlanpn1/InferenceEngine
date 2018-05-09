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

        public Sentence Head
        {
            get
            {
                return _head;
            }
        }

        public Sentence Body
        {
            get
            {
                return _body;
            }
        }

        public Connective Connective
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

        public bool Entails(List<String> known)
        {
            if(_body is SimpleSentence)
            {
                if(_head is SimpleSentence)
                {
                    switch (_connective)
                    {
                        case Connective.AND:
                            if((known.Contains(_body.GetSymbols()[0])) && (known.Contains(_head.GetSymbols()[0])))
                            {
                                return true;
                            }
                            return false;
                        case Connective.OR:
                            if ((known.Contains(_body.GetSymbols()[0])) || (known.Contains(_head.GetSymbols()[0])))
                            {
                                return true;
                            }
                            return false;
                        case Connective.IMPLICATION:
                            if (known.Contains(_body.GetSymbols()[0]))
                            {
                                known.Add(_head.GetSymbols()[0]);
                            }
                            break;
                        default:
                            // error
                            break;
                    }
                }
                if (((ComplexSentence)_head).Entails(known))
                {
                    return true;
                } else
                {
                    return false;
                }
            }
            if (((ComplexSentence)_body).Entails(known))
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
