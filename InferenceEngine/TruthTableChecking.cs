using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InferenceEngine
{
    class TruthTableChecking : Algorithm
    {
        int count = 0;
        int debugLoopCount = 0;

        public TruthTableChecking(string stringquery)
        {
            Sentence a = SentenceParser.ParseSentence(stringquery);
            Entails(a);
        }

        public int Count { get => count; set => count = value; }

        public override string Result()
        {
            return Count.ToString() + " " + debugLoopCount.ToString();
        }

        private int Entails(Sentence a)
        {
            List<String> symbols = KnowledgeBase.Symbols;
            Model model = new Model();

            symbols = AddQuery(symbols, a);
            CheckAll(a, symbols, model);
            return count;
        }

        private bool CheckAll(Sentence a, List<String> symbols, Model model)
        {
            debugLoopCount++;
            String p;
            List<String> rest = new List<string>();
            if (symbols.Count < 1)
            {
                if (PLTRUE(model))
                {
                    if (PLTRUE(model, a))
                    {
                        count++;
                        return true; 
                    }
                    return false;
                }

                else
                {
                    return true;
                }
            }

            else
            {
                p = symbols.First();
                rest = symbols;
                rest.Remove(symbols.First());

                CheckAll(a, rest, model.Extend(p, true));
                CheckAll(a, rest, model.Extend(p, false));
                return true;
            }
        }

        private bool PLTRUE(Model model, Sentence a)
        {
            if (KnowledgeBase.CheckAll(model))
            {
                if (KnowledgeBase.CheckAll(a, model))
                {
                    return true;
                } 
            }

            else
            {
                return true;
            }
            return false;
        }

        private bool PLTRUE(Model model)
        {
            if (KnowledgeBase.CheckAll(model))
            {
                return true;
            }
            return false;
        }

        private List<String> AddQuery(List<string> symbols, Sentence a)
        {
            List<string> result = symbols;
            foreach (string s in a.GetSymbols())
            {
                if (!result.Contains(s))
                {
                    result.Add(s);
                }
            }
            return result;
        }
    }
}
