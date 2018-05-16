using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 * 
 *  Change Symbols to List<Sentence>
 * Add an entails, model 
 * 
 *
 *
 */

namespace InferenceEngine
{
     class KnowledgeBase
    {
        List<Sentence> _kb = new List<Sentence>();
        Sentence s;
        List<string> _symbols = new List<string>();

        public KnowledgeBase()
        {
        }

        public void Add(List<Sentence> sentences)
        {
            _kb = sentences;
            Console.WriteLine("b");
        }

        public List<Sentence> KB
        {
            get
            {
                return _kb;
            }
            set
            {
                _kb = value;
            }
        }

        public Sentence Sentence
        {
            get
            {
                return s;
            }
            set
            {
                s = value;
            }
        }

        public List<string> GetSymbols()
        {
            foreach(Sentence s in _kb)
            {
                List<String> temp = s.GetSymbols();
                foreach(string symbol in temp)
                {
                    if (!_symbols.Contains(symbol))
                    {
                        _symbols.Add(symbol);
                    }
                }
            }
            return _symbols;
        }

        public List<SimpleSentence> currentlyTrue()
        {
            List<SimpleSentence> currentlyTrue = new List<SimpleSentence>();
            foreach(Sentence s in _kb)
            {
                if(s is SimpleSentence)
                {
                    if (s.isFalse == false) currentlyTrue.Add(((SimpleSentence)s));
                }
            }
            return currentlyTrue;
        }
        
        public bool CheckAll(Model model)
        {
            bool isTrue = true;
            foreach(Sentence s in _kb)
            {
                if(s is ComplexSentence)
                {
                    isTrue = ((ComplexSentence)s).Entails(model);
                }
                if(s is SimpleSentence)
                {
                    // do not check
                    //isTrue = model.Contains(((SimpleSentence)s).GetSymbols()[0]);
                }

            }
            return isTrue;
        }

        public bool Entails(Model model)
        {
            bool value = true;
            foreach(Sentence s in _kb)
            {
                if(value)
                {
                    if (s is ComplexSentence) value = s.Entails(model);
                    if (s is SimpleSentence) value = s.Entails(model);
                }
            }
            return value;   
        }

        public bool CheckAll(Sentence a, Model model)
        {
            bool isTrue = true;
            if(a is ComplexSentence)
            {
                isTrue = ((ComplexSentence)a).Entails(model);
            } else if (a is SimpleSentence)
            {
                // do not check
                //isTrue = model.Contains(((SimpleSentence)a).GetSymbols()[0]);
            }
            return isTrue;
        }

        public Sentence ConcatenateSentences()
        {
            if (_kb.Count > 1)
            {
                List<Sentence> temp = _kb;
                ComplexSentence complex = new ComplexSentence(temp[0], (SimpleSentence)temp[1], false, Connective.AND);
                temp.RemoveAt(0);
                temp.RemoveAt(0);
                while (temp.Count - 1 != 0)
                {
                    complex = new ComplexSentence(complex, (SimpleSentence)temp[0], false, Connective.AND);
                    temp.RemoveAt(0);
                }
                return complex;
            } else
            {
                return _kb[0];
            }
        }
    }
}
