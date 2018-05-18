using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InferenceEngine
{
    class BackwardChaining : Algorithm
    {
        public override string Result()
        {
            throw new NotImplementedException();
        }

        private List<string> FOL_BC_ASK(KnowledgeBase KB, List<Sentence> goals, Sentence θ)
        {
            List<String> answers = new List<string>();
            if (goals.Count < 1)
            {
                return θ;
            }
            Sentence q = ;
            foreach (Sentence r in KB.KB)
            {
                if ((standardize-apart(r)) == (unify(q, !q))
                {
                    new_goals = ;
                    answers = 
                }
            }
            return answers;
        }
    }
}
