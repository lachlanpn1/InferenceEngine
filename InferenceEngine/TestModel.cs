//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using NUnit.Framework;
//using System.Threading.Tasks;

//namespace InferenceEngine
//{
//    [TestFixture]
//    class TestModel
//    {
//        [Test]
//        public void TestExtend()
//        {
//            List<String> strings = new List<string> { "a", "b" , "c" };
//            Model m = new Model();
//            m.Extend(strings[0], true);
//            m.Extend(strings[1], true);
//            m.Extend(strings[2], true);
//            m.Extend(strings[0], false);
//            m.Extend(strings[1], false);
//            m.Extend(strings[0], true);

//            Model expected = new Model();
//            expected.Extend(strings[0], true);
//            expected.Extend(strings[1], false);
//            expected.Extend(strings[2], true);

//            Assert.AreEqual(expected.Contains(strings[0]), m.Contains(strings[0]), "hsits fucked yo");

//        }
//    }
//}
