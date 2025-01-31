// This file was modified by Kin Ecosystem (2019)


using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kin.Base.responses.results;

namespace kin_base_test.responses.results
{
    [TestClass]
    public class BumpSequenceResultTest
    {
        [TestMethod]
        public void TestSuccess()
        {
            Util.AssertResultOfType("AAAAAACYloD/////AAAAAQAAAAAAAAALAAAAAAAAAAA=", typeof(BumpSequenceSuccess), true);
        }

        [TestMethod]
        public void TestBadSeq()
        {
            Util.AssertResultOfType("AAAAAACYloD/////AAAAAQAAAAAAAAAL/////wAAAAA=", typeof(BumpSequenceBadSeq), false);
        }
    }
}
