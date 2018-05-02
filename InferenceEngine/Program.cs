using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InferenceEngine
{
    class Program
    {
        //Input inp;
        static void Main(string[] args)
        {
            Algorithm alg;
            

            Input inp = new Input(args[1]);
            if (args.Length == 2)
            {
                if (!((args[0] == "TT") || (args[0] == "FC") || (args[0] == "BC")))
                {
                    Console.WriteLine("Error: The second argument must be either TT, FC or BC");
                }
            }
            else
            {
                Console.WriteLine("Error: There must be 3 command line arguments: the path to ");
            }
            
            //set the list of sentences in the knowledge base
            KnowledgeBase.Add(inp.getSentences);


            switch (args[0])
            {
                case "TT":
                    alg = new TruthTableChecking();
                    break;
                case "FC":
                    alg = new ForwardChaining();
                    break;
                case "BC":
                    alg = new BackwardChaining();
                    break;
                default:
                    alg = null;
                    break;
            }
            Console.WriteLine(alg.Result());

            //remove from final file, for testing in VS
            Console.ReadLine();
        }
    }
}
