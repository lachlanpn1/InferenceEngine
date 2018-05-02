using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InferenceEngine
{
    public class SentenceCreator
    {
      private List<SimpleSentence> _sentences = new List<SimpleSentence>();
      private List<Connective> _connectives = new List<Connective>();
      public Sentence convertToSentence(string clause)
        {
            // p2>p3
            _sentences.Clear();
            _connectives.Clear();

            string temp = new string(clause.TakeWhile(Char.IsLetterOrDigit).ToArray());
            _sentences.Add(new SimpleSentence(temp));
            clause = clause.Remove(0, temp.Length);


            while (clause.Length > 0)
            {
                 switch (clause[0])
                 {
                     case '<':
                        //biconditional
                        break;
                     case '&':
                        _connectives.Add(Connective.AND);
                        clause = clause.Remove(0,1);
                        break;
                     case 'v':
                        _connectives.Add(Connective.OR);
                        clause = clause.Remove(0,1);
                        break;
                     case '>':
                        _connectives.Add(Connective.IMPLICATION);
                        clause = clause.Remove(0,1);
                        break;
                     default:
                         temp = new string(clause.TakeWhile(Char.IsLetterOrDigit).ToArray());
                         _sentences.Add(new SimpleSentence(temp));
                         clause = clause.Remove(0, temp.Length);
                         break;
                 }
            }

            if(_sentences.Count <= 1 ) // complex sentence
            {
                SimpleSentence sentence = (_sentences[0]);
                return sentence;
            }
            else
            {
                ComplexSentence sentence = new ComplexSentence(_sentences, _connectives);
                return sentence;
            }
        }
    }
}
