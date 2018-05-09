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
        string query;

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
            Query = fileText[3];
            hornClauses = Regex
                .Replace(fileText[1], @"=", "")
                .Split(';');
        }

        public string Query { get => query; set => query = value; }

        public List<Sentence> Convert()
        {
            List<Sentence> createdSentences = new List<Sentence>();
            foreach (string str in hornClauses)
            {
                createdSentences.Add(SentenceParser.ParseSentence(str));
            }
            return createdSentences;
        }

        
    }
}
