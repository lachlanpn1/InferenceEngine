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
                temp += ("yes");
                temp += Inferred.getString();
            }
            else
            {
                temp += ("no");
            }
            return temp;
        }

        public bool PL_FC_ENTAILS(KnowledgeBase KB, Sentence q)
        {
            Dictionary<Sentence, int> Count = KB.getCount();
            Stack<SimpleSentence> agenda = new Stack<SimpleSentence>(KB.currentlyTrue());

            while (agenda.Count > 0)
            {
                SimpleSentence p = agenda.Pop();
                if (p == q)
                {
                    if (!Inferred.ContainsPositive(p))
                    {
                        Inferred.setTrue(p);
                        foreach (Sentence c in KB.getSentencesWith(p))
                        {
                            Count[c]--;
                            if (Count[c] == 0)
                            {
                                agenda.Push(c.Head());
                            }
                        }
                    }
                }
            }

            return false;
        }

    }
}

/*function PL-FC-ENTAILS? (KB, q) returns true or false
inputs: KB, the knowledge base, a set of proposition(a1 Honl clauses
q, the query, a proposition symbol
local variables: count, a table, indexed by clause, initially the number of premises
inferred, a table, indexed by symbol, each entry initially false
agenda, a list of symbols, initially the symbols known to be true in KB
while agenda is not empty do
p +- P~~(agenda)
if p = q then return true
unless inferred[p] do
inferred[p] + true
for each Horn clause c in whose premise p appears do
decrement count [c]
if count[c] = 0 then
PUSH(HEAD[~], agenda)
return false
*/