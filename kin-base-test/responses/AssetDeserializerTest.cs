// This file was modified by Kin Ecosystem (2019)


using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kin.Base;
using Kin.Base.responses;

namespace kin_base_test.responses
{
    [TestClass]
    public class AssetDeserializerTest
    {
        [TestMethod]
        public void TestDeserializeNative()
        {
            var json = File.ReadAllText(Path.Combine("testdata", "assetAssetTypeNative.json"));
            var asset = JsonSingleton.GetInstance<Asset>(json);

            Assert.AreEqual(asset.GetType(), "native");
        }

        [TestMethod]
        public void TestDeserializeCredit()
        {
            var json = File.ReadAllText(Path.Combine("testdata", "assetAssetTypeCredit.json"));
            var asset = JsonSingleton.GetInstance<Asset>(json);
            Assert.AreEqual(asset.GetType(), "credit_alphanum4");
            var creditAsset = (AssetTypeCreditAlphaNum) asset;
            Assert.AreEqual(creditAsset.Code, "CNY");
            Assert.AreEqual(creditAsset.Issuer, "GAREELUB43IRHWEASCFBLKHURCGMHE5IF6XSE7EXDLACYHGRHM43RFOX");
        }
    }
}
