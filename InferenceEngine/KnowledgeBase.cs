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
    static class KnowledgeBase
    {
        static List<Sentence> _kb = new List<Sentence>();
        static List<string> _symbols = new List<string>();
        public static void Add(List<Sentence> sentences)
        {
            _kb = sentences;
            Console.WriteLine("b");
        }

        public static List<Sentence> KB
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

        public static List<string> Symbols
        {
            get
            {
                return getSymbols();
            }
        }

        private static List<string> getSymbols()
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

        public static List<String> currentlyTrue()
        {
            List<String> currentlyTrue = new List<String>();
            foreach(Sentence s in _kb)
            {
                if(s is SimpleSentence)
                {
                    currentlyTrue.Add(s.GetSymbols()[0]);
                }
            }
            return currentlyTrue;
        }
        
        public static bool CheckAll(Model model)
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
                    isTrue = model.Contains(((SimpleSentence)s).GetSymbols()[0]);
                }

            }
            return isTrue;
        }

        public static bool CheckAll(Sentence a, Model model)
        {
            bool isTrue = true;
            if(a is ComplexSentence)
            {
                isTrue = ((ComplexSentence)a).Entails(model);
            } else if (a is SimpleSentence)
            {
                isTrue = model.Contains(((SimpleSentence)a).GetSymbols()[0]);
            }
            return isTrue;
        }


    }
}
