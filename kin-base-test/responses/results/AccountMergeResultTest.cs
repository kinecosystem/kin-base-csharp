// This file was modified by Kin Ecosystem (2019)


using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kin.Base.responses;
using Kin.Base.responses.results;

namespace kin_base_test.responses.results
{
    [TestClass]
    public class AccountMergeResultTest
    {
        [TestMethod]
        public void TestSuccess()
        {
            var tx = Util.AssertResultOfType("AAAAAACYloD/////AAAAAQAAAAAAAAAIAAAAAAAAAAAF9eEAAAAAAA==",
                typeof(AccountMergeSuccess), true);
            var failed = (TransactionResultFailed) tx;
            var op = (AccountMergeSuccess) failed.Results[0];
            Assert.AreEqual("1000", op.SourceAccountBalance);
        }

        [TestMethod]
        public void TestMalformed()
        {
            Util.AssertResultOfType("AAAAAACYloD/////AAAAAQAAAAAAAAAI/////wAAAAA=", typeof(AccountMergeMalformed),
                false);
        }

        [TestMethod]
        public void TestNoAccount()
        {
            Util.AssertResultOfType("AAAAAACYloD/////AAAAAQAAAAAAAAAI/////gAAAAA=", typeof(AccountMergeNoAccount),
                false);
        }

        [TestMethod]
        public void TestImmutableSet()
        {
            Util.AssertResultOfType("AAAAAACYloD/////AAAAAQAAAAAAAAAI/////QAAAAA=", typeof(AccountMergeImmutableSet),
                false);
        }

        [TestMethod]
        public void TestHasSubEntry()
        {
            Util.AssertResultOfType("AAAAAACYloD/////AAAAAQAAAAAAAAAI/////AAAAAA=", typeof(AccountMergeHasSubEntries),
                false);
        }

        [TestMethod]
        public void TestSeqnumTooFar()
        {
            Util.AssertResultOfType("AAAAAACYloD/////AAAAAQAAAAAAAAAI////+wAAAAA=", typeof(AccountMergeSeqnumTooFar),
                false);
        }

        [TestMethod]
        public void TestDestFull()
        {
            Util.AssertResultOfType("AAAAAACYloD/////AAAAAQAAAAAAAAAI////+gAAAAA=", typeof(AccountMergeDestFull),
                false);
        }
    }
}
