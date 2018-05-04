using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InferenceEngine
{
    static class KnowledgeBase
    {
        static List<Sentence> _kb = new List<Sentence>();
        public static void Add(List<Sentence> sentences)
        {
            _kb = sentences;
            Console.WriteLine("b");
        }

        public static List<Sentence> List
        {
            get
            {
                return _kb;
            }
            set
            {
                _kb = value;
            }
        }

    }
}
