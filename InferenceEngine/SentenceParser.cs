using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InferenceEngine
{
    static class SentenceParser
    {
        private static Stack<Connective> connectiveQueue = new Stack<Connective>(); // must be outside the method ParseSentence because handling brackets requires the connective list to be saved
        public static Sentence ParseSentence(string s, bool bracketNegated = false) // bracketNegated is false unless true is passed through as a second parameter.
        {
            bool isFalse = false;
            Stack<Sentence> sentenceQueue = new Stack<Sentence>();
            //Stack<Connective> connectiveQueue = new Stack<Connective>();
            Queue<string> inputQueue = new Queue<string>();

            // If string s contains a > or ( ), then we want to divide the string into workable components. 
            // (p2>p3)&p4>p5 is divided into.. p2>p3 , &p4 , p5
            if (s.Contains(">"))
            {
                string[] propositions = s.Split('>');
                foreach (string p in propositions)
                {
                    sentenceQueue.Push(ParseSentence(p)); // recursively calls this function for each divided component of string s.

                }
                connectiveQueue.Push(Connective.IMPLICATION); // adds a connective for final linking of the body and head of string s.
            }
            else if ((s.Contains("(") || (s.Contains(")"))))
            {
                // Divides a complex sentence surrounded by parenthesis into smaller components
                // ~(p2&p3) --> { "~", "p2&p3", "" } 
                string[] propositions = s.Split(new char[] { '(', ')' });
                foreach (string p in propositions)
                    if (p == "~")  // if ~ exists at the beginning, the entire complex sentence within the parenthesis needs to be negated.
                    {
                        bracketNegated = true;
                    }
                    else if (p != "") // a "" exists at the beginning (if there's no negation) and at the end, and can be ignored.
                    {
                        sentenceQueue.Push(ParseSentence(p, bracketNegated)); // recursively calls this function for each divided component of string s.
                    }
                bracketNegated = false;
            }
            else
            {
                // if there is no implication or parenthesis, the clause has been divided into workable components and we can create the queue
                // the queue will contain the passed string s divided into strings representing propositions and connectives.
                // e.g; p2&p3 --> { "p2", "&", "p3" }
                inputQueue = createQueue(s);
            }

            // This loop populates the sentences and connective stacks by creating simple sentences out of propositions (e.g p2 or ~p2)
            // The inputQueue is dequeued after each string is converted into a simple sentence or connective and loop continues until queue is empty.
            while (!IsEmpty(inputQueue))
            {
                string input = inputQueue.Dequeue(); // take first string out of inputQueue.
                if (input == "~") // if it is a negation then the following proposition is false
                {
                    isFalse = true;
                }
                else if (IsProposition(input)) // IsProposition :: returns true if the input is alphanumeric
                {
                    SimpleSentence simple = new SimpleSentence(input, isFalse); // creates a new Simple Sentence with the proposition and if the proposition has been negated.
                    sentenceQueue.Push(simple); // pushes simple sentence to sentence stack.
                    isFalse = false; // resets isFalse
                    continue; // begins next iteration of loop.
                }
                else if (IsConnective(input)) // isConnective :: returns true if input is "|", ">" or "&"
                {
                    connectiveQueue.Push(getConnective(input)); // getConnective:: returns string converted into Connective enum e.g. "|" --> Connective.OR, pushes returned Connective to connectiveQueue.
                    continue; // next iteration of loop.
                }
            }

            // If 2 sentences and 1 connective exist in the respective stacks - a complex sentence can be formed.
            while (sentenceQueue.Count > 1) // if there is more then one sentence then in the sentenceQueue, there MUST be a connective in the connectiveQueue, all simple sentences joined by connectives.
            {
                Sentence head = sentenceQueue.Pop(); // take the 
                Sentence body = sentenceQueue.Pop();
                Connective conn = connectiveQueue.Pop();
                ComplexSentence complex = new ComplexSentence(body, head, (isFalse || bracketNegated), conn);
                sentenceQueue.Push(complex);
                isFalse = false;
            }
            if (sentenceQueue.Count == 0)
            {
                throw new Exception("Invalid input");
            }
            return sentenceQueue.Pop();
        }



        /// <summary>
        /// recieves Horn clause in string format 'p2>p3', turns into queue dividing propositions and connectives.
        /// </summary>
        /// <param name="s">Horn clause in string form</param>
        /// <returns>queue containing propositions and connectives</returns>
        public static Queue<string> createQueue(string s)
        {
            Queue<string> queue = new Queue<string>();
            while (s.Length > 0)
            {
                if (Char.IsLetterOrDigit(s[0])) // proposition
                {
                    string temp = new string(s.TakeWhile(Char.IsLetterOrDigit).ToArray());
                    s = s.Remove(0, temp.Length);
                    queue.Enqueue(temp);

                }
                else // connective
                {
                    queue.Enqueue(s[0].ToString());
                    s = s.Remove(0, 1);
                }
            }
            return queue;
        }

        private static Sentence createSentence(string s, bool isFalse)
        {
            SimpleSentence temp = new SimpleSentence(s, isFalse);
            return temp;
        }

        private static bool IsConnective(string s)
        {
            if (s == ">" || s == "|" || s == "&")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool IsProposition(string s)
        {
            bool result = false;
            foreach (char c in s)
            {
                if (Char.IsLetterOrDigit(c))
                {
                    result = true;
                }
                else
                {
                    return false;
                }
            }
            return result;
        }

        private static Connective getConnective(string s)
        {
            switch (s)
            {
                case ">":
                    return Connective.IMPLICATION;
                case "&":
                    return Connective.AND;
                default:
                    return Connective.OR;
            }
        }

        private static bool IsEmpty(Queue<string> q)
        {
            return (q.Count <= 0);
        }
    }
}
