// This file was modified by Kin Ecosystem (2019)


using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kin.Base.responses.results;

namespace kin_base_test.responses.results
{
    [TestClass]
    public class AllowTrustResultTest
    {
        [TestMethod]
        public void TestSuccess()
        {
            Util.AssertResultOfType("AAAAAACYloD/////AAAAAQAAAAAAAAAHAAAAAAAAAAA=", typeof(AllowTrustSuccess), true);
        }

        [TestMethod]
        public void TestMalformed()
        {
            Util.AssertResultOfType("AAAAAACYloD/////AAAAAQAAAAAAAAAH/////wAAAAA=", typeof(AllowTrustMalformed), false);
        }

        [TestMethod]
        public void TestNoTrustLine()
        {
            Util.AssertResultOfType("AAAAAACYloD/////AAAAAQAAAAAAAAAH/////gAAAAA=", typeof(AllowTrustNoTrustline),
                false);
        }

        [TestMethod]
        public void TestTrustNotRequired()
        {
            Util.AssertResultOfType("AAAAAACYloD/////AAAAAQAAAAAAAAAH/////QAAAAA=", typeof(AllowTrustNotRequired),
                false);
        }

        [TestMethod]
        public void TestCantRevoke()
        {
            Util.AssertResultOfType("AAAAAACYloD/////AAAAAQAAAAAAAAAH/////AAAAAA=", typeof(AllowTrustCantRevoke),
                false);
        }

        [TestMethod]
        public void TestSelfNotAllowed()
        {
            Util.AssertResultOfType("AAAAAACYloD/////AAAAAQAAAAAAAAAH////+wAAAAA=", typeof(AllowTrustSelfNotAllowed),
                false);
        }
    }
}
