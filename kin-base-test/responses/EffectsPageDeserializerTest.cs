// This file was modified by Kin Ecosystem (2019)


using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kin.Base.responses;
using Kin.Base.responses.effects;
using Kin.Base.responses.page;

namespace kin_base_test.responses
{
    [TestClass]
    public class EffectsPageDeserializerTest
    {
        [TestMethod]
        public void TestDeserialize()
        {
            var json = File.ReadAllText(Path.Combine("testdata", "effectPage.json"));
            var effectsPage = JsonSingleton.GetInstance<Page<EffectResponse>>(json);

            AssertTestData(effectsPage);
        }

        public static void AssertTestData(Page<EffectResponse> effectsPage)
        {
            var signerCreatedEffect = (SignerCreatedEffectResponse) effectsPage.Records[0];
            Assert.AreEqual(signerCreatedEffect.PublicKey, "GAZHVTAM3NRJ6W643LOVA76T2W3TUKPF34ED5VNE4ZKJ2B5T2EUQHIQI");
            Assert.AreEqual(signerCreatedEffect.PagingToken, "3964757325385729-3");

            var accountCreatedEffect = (AccountCreatedEffectResponse) effectsPage.Records[8];
            Assert.AreEqual(accountCreatedEffect.StartingBalance, "10000.0");
            Assert.AreEqual(accountCreatedEffect.Account, "GDIQJ6G5AWSBRMHIZYWVWCFN64Q4BZ4TYEAQRO5GVR4EWR23RKBJ2A4R");

            Assert.AreEqual(effectsPage.Links.Next.Href, "http://horizon-testnet.stellar.org/effects?order=desc&limit=10&cursor=3962163165138945-3");
        }
    }
}
