using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InferenceEngine
{
    class BackwardChaining : Algorithm
    {

        /*       private List<Substition> FOL_BC_ASK(KnowledgeBase KB, Sentence q)
               {
                   return FOL_BC_OR(KB, q, new Sentence(false));
               }

               private List<> FOL_BC_OR(KnowledgeBase KB, Sentence goal, Sentence theta)
               {
                   List<Subsitution> result = new List<Subsitution>();
                   foreach (rule r in KB.fetchRulesByGoal(goal))
                   {
                       List<Sentence> temp = STANDARDIZE_VARIABLES(lhs, rhs);
                       List<Sentence> lhs = temp;
                       List<Sentence> rhs = temp;
                       foreach (Sentence s in FOL_BC_AND(KB, lhs, UNIFY(rhs, goal, theta)))
                       {
                           result.Add(s);
                       }
                   }
                   return result;
               }

               private List<> FOL_BC_AND(KnowledgeBase KB, List<Sentence> goals, Sentence theta)
               {
                   List<Substitution> result = new List<Substitution>();
                   if (Failure(theta))
                   {
                       return;
                   }
                   else if (goals.Count() == 0)
                   {
                       return new List<Substitution> { theta };
                   }
                   else
                   {
                       Sentence first = goals.First();
                       List<Sentence> rest = goals;
                       rest.Remove(first);

                       foreach (Sentence s in FOL_BC_OR(KB, (/*subst(theta, first)), theta)
                       {
                           foreach (Sentence s2 in FOL_BC_AND(KB, rest, s))
                           {
                               result.Add(s2);
                           }
                       }
                   }
                   return result;
               }


               private ComplexSentence STANDARDIZE_VARIABLES(ComplexSentence rule)
               {

               }

               private ComplexSentence UNIFY()*/
        Model Inferred;

        public BackwardChaining(string a, KnowledgeBase KB)
        {
            Sentence q = SentenceParser.ParseSentence(a);
            Inferred = new Model(KB.GetSymbols(), false);
            Inferred.makeTrue(KB.currentlyTrue);
            bool result = PL_BC_ENTAILS(KB, (SimpleSentence)(q));
            Result(result);
        }

        public override string Result(bool result)
        {
            string stringResult = "";
            if (result)
            {
                stringResult += 
            }
        }

        public bool PL_BC_ENTAILS(KnowledgeBase KB, SimpleSentence q, List<SimpleSentence> facts)
        {
            Queue<SimpleSentence> agenda = new Queue<SimpleSentence>();
            agenda.Enqueue(q);
            while (agenda.Count > 0)
            {
                SimpleSentence p = agenda.Dequeue();
                if (!(facts.Contains(p)))
                {
                    List<SimpleSentence> temp = new List<SimpleSentence>(KB.getRulesWith(p));
                    foreach (SimpleSentence simp in temp)
                    {
                        agenda.Enqueue(simp);
                    }

                    /*List<ComplexSentence> temp = new List<ComplexSentence>(KB.getRulesWith(p));
                    foreach (ComplexSentence s in temp)
                    {
                        List<SimpleSentence> temp2 = new List<SimpleSentence>(KB.getSimple(s));
                        foreach (SimpleSentence s2 in temp2)
                        {
                            agenda.Enqueue(s2);
                        }
                    }*/

                }
                if (KB.isAllTrue(agenda))
                {
                    return true;
                }
                
            }
            return false;
    }
}
