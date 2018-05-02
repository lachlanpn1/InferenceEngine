using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace InferenceEngine
{
    public class Input
    {
        string[] hornClauses;
        string[] fileText;

        public Input(string filename)
        {
            string[] tempFileText;

            fileText = File.ReadAllLines(filename);
            tempFileText = fileText;
            //remove spaces from each line
            for (int i = 0; i < fileText.Length; i++)
            {
                tempFileText[i] = Regex.Replace(fileText[i], @"\s+", "");
            }
            fileText = tempFileText;
            //required to get rid of the last element, which will be empty
            fileText[1] = tempFileText[1].Remove(tempFileText[1].Length - 1);

            hornClauses = Regex
                .Replace(fileText[1], @"=", "")
                .Split(';');
        }

        public List<Sentence> Convert()
        {
            List<SimpleSentence> _simpleSentences = new List<SimpleSentence>();
            List<ComplexSentence> _complexSentences = new List<ComplexSentence>();
            List<Sentence> _sentences = new List<Sentence>();
            foreach (string clause in hornClauses)
            {
                if ((SentenceCreator.convertToSentence(clause)) is SimpleSentence)
                {
                    _simpleSentences.Add((SimpleSentence)(SentenceCreator.convertToSentence(clause)));
                }

                if ((SentenceCreator.convertToSentence(clause)) is ComplexSentence)
                {
                    _complexSentences.Add((ComplexSentence)(SentenceCreator.convertToSentence(clause)));
                }
            }

            _sentences.AddRange(_simpleSentences);
            _sentences.AddRange(_complexSentences);
            return _sentences;
        }

        
    }
}
