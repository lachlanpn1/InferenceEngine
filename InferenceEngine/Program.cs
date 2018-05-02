using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InferenceEngine
{
    class Program
    {
        static Input inp;
        static void Main(string[] args)
        {
            inp = new Input(args[1]);
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

            switch (args[0])
            {
                case "TT":
                    
                    break;
                case "FC":
                    break;
                case "BC":
                    break;
            }

            //remove from final file, for testing in VS
            Console.ReadLine();
        }
    }
}
