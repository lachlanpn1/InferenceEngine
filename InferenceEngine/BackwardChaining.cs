using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InferenceEngine
{
    class BackwardChaining : Algorithm
    {
        bool result;
        List<SimpleSentence> facts;
        List<SimpleSentence> mustBeTrue;

        public BackwardChaining(string a, KnowledgeBase KB)
        {
            mustBeTrue = new List<SimpleSentence>();
            Sentence q = SentenceParser.ParseSentence(a);
            facts = KB.currentlyTrue();
            mustBeTrue.Add((SimpleSentence)q);
            result = PL_BC_ENTAILS(KB, (SimpleSentence)(q));
            Result();
        }

        public override string Result()
        {
            string temp = "";
            if (result)
            {
                temp += "YES: ";
                for(int i = mustBeTrue.Count - 1; i > -1 ; i--)
                {
                    temp += (mustBeTrue[i].GetSymbols()[0]) + ", ";
                }
                temp = temp.TrimEnd(' ');
                temp = temp.TrimEnd(',');
            }
            else
            { 
                temp = "NO";
            }
            return temp;
        }

        public bool PL_BC_ENTAILS(KnowledgeBase KB, SimpleSentence q)
        {
            bool found = false;
            Queue<SimpleSentence> agenda = new Queue<SimpleSentence>();
            agenda.Enqueue(q);
            while (agenda.Count > 0)
            {
                SimpleSentence p = agenda.Dequeue();
                if (!ContainedInFacts(p, facts))
                {
                    List<SimpleSentence> temp = new List<SimpleSentence>(KB.getRulesWith(p));
                    foreach (SimpleSentence simp in temp)
                    {
                        agenda.Enqueue(simp);
                        mustBeTrue.Add(simp);
                    }
                }
                if (isAllTrue(agenda, facts))
                {
                    found = true;
                    List<SimpleSentence> temp = KB.getRulesWith(q);
                    foreach(SimpleSentence s in temp)
                    {
                        if (!mustBeTrue.Contains(s)) mustBeTrue.Add(s);
                    }
                }

            }
            return found;
        }

        public bool isAllTrue(Queue<SimpleSentence> agenda, List<SimpleSentence> facts)
        {
           if (agenda.Count == 0) return false;
           foreach(SimpleSentence s in agenda)
            {
                if (!ContainedInFacts(s, facts)) return false;
            }
            return true;
        }

        public bool ContainedInFacts(SimpleSentence s, List<SimpleSentence> facts)
        {
            string proposition = s.GetSymbols()[0];
            foreach(SimpleSentence f in facts)
            {
                string fact = f.GetSymbols()[0];
                if (fact == proposition) return true;
            }
            return false;
        }

      
    }
}

