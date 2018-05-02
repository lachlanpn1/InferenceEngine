using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InferenceEngine
{
    static class SentenceCreator
    {
      static List<Sentence> _sentences = new List<Sentence>();
      static List<Connective> _connectives = new List<Connective>();
      public static Sentence convertToSentence(string clause)
        {
            // p2>p3
            _sentences.Clear();
            _connectives.Clear();

            string temp = new string(clause.TakeWhile(Char.IsLetterOrDigit).ToArray());
            _sentences.Add(new SimpleSentence(temp));
            clause = clause.Remove(0, temp.Length - 1);


            while (clause.Length - 1 > 0)
            {
                 switch (clause[0])
                 {
                     case '<':
                        //biconditional
                        break;
                     case '^':
                        _connectives.Add(Connective.AND);
                        clause = clause.Remove(0);
                        break;
                     case 'v':
                        _connectives.Add(Connective.OR);
                        clause = clause.Remove(0);
                        break;
                     case '>':
                        _connectives.Add(Connective.IMPLICATION);
                        clause = clause.Remove(0);
                        break;
                     default:
                         temp = new string(clause.TakeWhile(Char.IsLetterOrDigit).ToArray());
                         _sentences.Add(new SimpleSentence(temp));
                         clause = clause.Remove(0, temp.Length - 1);
                         break;
                 }
            }

            if(_sentences.Count > 1 ) // complex sentence
            {
                ComplexSentence sentence = new ComplexSentence(_sentences, _connectives);
                return sentence;
            } else
            {
                return _sentences[0];
            }
         
            


        }
    }
}
