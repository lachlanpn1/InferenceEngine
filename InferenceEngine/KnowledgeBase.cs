using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
