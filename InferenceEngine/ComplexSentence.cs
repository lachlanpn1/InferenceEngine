using System;
using System.Collections.Generic;
using System.Text;

namespace InferenceEngine
{
    class ComplexSentence : Sentence
    {
        Sentence _body;
        SimpleSentence _head;
        Connective _connective;

        public ComplexSentence(Sentence body, SimpleSentence head, bool isFalse, Connective connective) : base(isFalse)
        {
            _body = body;
            _head = head;
            _connective = connective;
        }

        public Sentence Body
        {
            get
            {
                return _body;
            }
        }

        public override SimpleSentence getHead()
        {
            return _head;
            
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
            temp = Head().GetSymbols();
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
            return symbols;
        }

        public override bool Entails(Model model)
        {
           if(_body is SimpleSentence)
            {
                if(_head is SimpleSentence)
                {
                    switch(_connective)
                    {
                        case Connective.AND:
                            if ((model.ContainsPositive(_body.GetSymbols()[0])) && (model.ContainsPositive(_head.GetSymbols()[0])))
                            {
                                return true;
                            }
                            return false;
                        case Connective.OR:
                            if ((model.ContainsPositive(_body.GetSymbols()[0])) || (model.ContainsPositive(_head.GetSymbols()[0])))
                            {
                                return true;
                            }
                            return false;
                        case Connective.IMPLICATION:
                            // BODY => HEAD
                            // Body Head Body=>Head
                            //  1     1     1
                            //  0     1     1
                            //  0     0     1
                            //  1     0     0
                            if (_body.Entails(model))
                            {
                                if (!_head.Entails(model))
                                {
                                    return false;
                                }
                            }
                            return true;
                        default:
                            // error
                            break;
                    }
                } else
                {
                    // break
                }
            } else
            {
                // body is a complex sentence
                // such as A&B=>C or A|B=>C
                switch (_connective)
                {
                    case Connective.AND:
                        if (_body.Entails(model))
                        {
                            if (_head.Entails(model))
                            {
                                return true;
                            }
                        }
                        return false;
                    case Connective.OR:
                        if ((_body.Entails(model)) || (_head.Entails(model)))
                        {
                            return true;
                        }
                        return false;
                    case Connective.IMPLICATION:
                        if (_body.Entails(model))
                        {
                            if(!_head.Entails(model))
                            {
                                return false;
                            }
                        }
                        return true;
                    default:
                        break;

                }
            }
            return false;

        }
    }
}
