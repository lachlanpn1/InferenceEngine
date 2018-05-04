using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InferenceEngine
{
    class TruthTableChecking : Algorithm
    {
        public override string Result()
        {
            throw new NotImplementedException();
        }

        private bool Entails(List<Sentence> kb, Sentence a)
        {
            List<String> symbols = new List<string>();


            return CheckAll(kb, a, symbols, model);
        }

        private bool CheckAll(List<Sentence> kb, Sentence a, List<String> symbols, )
        {
            if (symbols.Count < 1)
            {
                if (true)
                {

                }

                else
                {
                    return true;
                }
            }

            else
            {

            }
        }
    }
}
