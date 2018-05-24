using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InferenceEngine
{
    class ForwardChaining : Algorithm
    {
        Model Inferred;
        List<SimpleSentence> InferredList = new List<SimpleSentence>(); // for printing result.
        bool result;
        public ForwardChaining(string a, KnowledgeBase kBase)
        {
            Sentence q = SentenceParser.ParseSentence(a);
            Inferred = new Model(kBase.GetSymbols(), false);
            result = PL_FC_ENTAILS(kBase, q);
            Result();
        }

        public override string Result()
        {
            string temp = "";
            if (result)
            {
                temp += ("YES: ");
                foreach(SimpleSentence s in InferredList)
                {
                    temp += s.GetSymbols()[0];
                    temp += ", ";
                }
                temp = temp.TrimEnd();
                temp = temp.TrimEnd(',');
            }
            else
            {
                temp += ("NO");
            }
            return temp;
        }

        public bool PL_FC_ENTAILS(KnowledgeBase KB, Sentence q)
        {
            Dictionary<Sentence, int> Count = KB.getCount();
            Queue<SimpleSentence> agenda = new Queue<SimpleSentence>(KB.currentlyTrue());

            while (agenda.Count > 0)
            {
                SimpleSentence p = agenda.Dequeue();
                if (!p.isEqual(q))
                {
                    if (!Inferred.ContainsPositive(p))
                    {
                        Inferred.setTrue(p);
                        InferredList.Add(p);
                        foreach (Sentence c in KB.getSentencesWith(p))
                        {
                            Count[((ComplexSentence)c).Body]--;
                            if (Count[((ComplexSentence)c).Body] == 0)
                            {
                                agenda.Enqueue(c.getHead());
                            }
                        }
                    }
                }
                else
                {
                    Inferred.setTrue(p);
                    InferredList.Add(p);
                    return true;
                }
            }

            return false;
        }

    }
}
