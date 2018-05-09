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

        public TruthTableChecking(string stringquery)
        {
            Sentence a = SentenceParser.ParseSentence(stringquery);
            Entails(a);
        }

        public int Count { get => count; set => count = value; }

        public override string Result()
        {
            return Count.ToString();
        }

        private bool Entails(Sentence a)
        {
            List<String> symbols = KnowledgeBase.Symbols;
            Model model = new Model(KnowledgeBase.currentlyTrue());
            symbols.AddRange(a.GetSymbols());
            return CheckAll(a, symbols, model);
        }

        private bool CheckAll(Sentence a, List<String> symbols, Model model)
        {
            String p;
            List<String> rest = new List<string>();
            if (symbols.Count < 1)
            {
                if (PLTRUE(model))
                {
                    return PLTRUE(model, a);
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

                return ((CheckAll(a, rest, model.Extend(p, true))) && (CheckAll(a, rest, model.Extend(p, false))));
            }
        }

        private bool PLTRUE(Model model, Sentence a)
        {
            if (KnowledgeBase.CheckAll(model))
            {
                if (KnowledgeBase.CheckAll(a, model))
                {
                    Count++;
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
            return KnowledgeBase.CheckAll(model);
        }
    }
}
