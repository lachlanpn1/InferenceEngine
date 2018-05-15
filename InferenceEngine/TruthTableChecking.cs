using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InferenceEngine
{
    class TruthTableChecking : Algorithm
    {
        KnowledgeBase knoBase;

        int count = 0;
        int debugLoopCount = 0;
        List<Model> models = new List<Model>();
        List<Model> __truemodel__ = new List<Model>();

        public TruthTableChecking(string stringquery, KnowledgeBase aKnowledgeBase)
        {
            knoBase = aKnowledgeBase;
            Sentence a = SentenceParser.ParseSentence(stringquery);
            TT_ENTAILS(a, knoBase);
        }

        public int Count { get => count; set => count = value; }

        public override string Result()
        {
            return Count.ToString() + " " + debugLoopCount.ToString();
        }

        private bool TT_ENTAILS(Sentence a, KnowledgeBase kb)
        {

            List<String> symbols = kb.GetSymbols();
            Model model = new Model();
            symbols = AddQuery(symbols, a);
            return TT_CHECK_ALL(kb, a, symbols, model);
        }

        private bool TT_CHECK_ALL(KnowledgeBase kb, Sentence a, List<String> symbols, Model model)
        {
            debugLoopCount++;
            if (EMPTY(symbols))
            {
                if (PL_TRUE(model, kb))
                {
                    if (PL_TRUE(model, a))
                    {
                        count++;
                        __truemodel__.Add(model);
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
                String p = symbols.First();
                List<String> rest = new List<String>();
                for(int i = 1; i < symbols.Count;i++)
                {
                    rest.Add(symbols[i]);
                }
                
              
                Model true_model = Extend(model, p, true);
                Model false_model = Extend(model, p, false);

                models.Add(true_model);
                models.Add(false_model);
                return (TT_CHECK_ALL(kb, a, rest, true_model) &&
                TT_CHECK_ALL(kb, a, rest, false_model));
            }
        }

        private bool PL_TRUE(Model model, KnowledgeBase kb)
        {
            return kb.Entails(model);
        }

        private bool PL_TRUE(Model model, Sentence s)
        {
            return s.Entails(model);
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

        private bool EMPTY(List<String> aList)
        {
           if(aList.Count > 0)
            {
                return false;
            }
            return true;
        }

        public Model Extend(Model m, string proposition, bool value)
        {
            Model temp = new Model(m);
            if (!temp.getModel.ContainsKey(proposition))
            {
                temp.getModel.Add(proposition, value);
            }
            else
            {
                if (value != temp.getModel[proposition])
                {
                    temp.getModel[proposition] = value;
                }
            }
            return temp;
        }
    }
}
