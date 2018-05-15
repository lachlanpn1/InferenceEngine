//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using NUnit.Framework;
//using System.Threading.Tasks;

//namespace InferenceEngine
//{
//    [TestFixture]
//    class TestKnowledgeBase
//    {
//        [Test]
//        public void TestCheckAllFailure()
//        {
//            // with test1.txt as input.
//            Input inp = new Input("C:/Users/lachl/Dropbox/ITA/assignment2/InferenceEngine/InferenceEngine/bin/Debug/test1.txt");
//            KnowledgeBase.KB = inp.Convert();

//            Model m = new Model();
//            List <String> temp = new List<String> { "a", "c", "b", "p1" };
//            for(int i = 0; i < temp.Count - 1; i++)
//            {
//                m.Extend(temp[i], true);
//            }

//            bool actual = KnowledgeBase.CheckAll(m);
//            bool expected = false;

//            Assert.AreEqual(expected, actual);

//        }

//        [Test]
//        public void TestCheckAllSuccess()
//        {
//            // with test1.txt as input.
//            Input inp = new Input("C:/Users/lachl/Dropbox/ITA/assignment2/InferenceEngine/InferenceEngine/bin/Debug/test1.txt");
//            KnowledgeBase.KB = inp.Convert();

//            Model m = new Model();
//            List<String> temp = new List<String> { "p2", "a", "b", "c", "d", "e", "f", "g", "h", "p1", "p3" };
//            for (int i = 0; i < temp.Count - 1; i++)
//            {
//                m.Extend(temp[i], true);
//            }

//            bool actual = KnowledgeBase.CheckAll(m);
//            bool expected = true;

//            Assert.AreEqual(expected, actual);
//        }

//        [Test]
//        public void TestConcatenateSentenes()
//        {
//            // with test2.txt as input.
//            Input inp = new Input("C:/Users/lachl/Dropbox/ITA/assignment2/InferenceEngine/InferenceEngine/bin/Debug/test2.txt");
//            KnowledgeBase.KB = inp.Convert();


//            Sentence c1 = new ComplexSentence(KnowledgeBase.KB[0], KnowledgeBase.KB[1], false, Connective.AND);
//            Sentence c2 = new ComplexSentence(KnowledgeBase.KB[2], KnowledgeBase.KB[3], false, Connective.AND);
//            Sentence c3 = KnowledgeBase.KB[4];

//            Sentence c1_2 = new ComplexSentence(c1, c2, false, Connective.AND);
//            Sentence c2_2 = new ComplexSentence(c1_2, c3, false, Connective.AND);

//            Sentence expected = c2_2;
//            Sentence actual = KnowledgeBase.ConcatenateSentences();

            
//            Assert.AreEqual(expected, actual);


//        }
//    }
//}
