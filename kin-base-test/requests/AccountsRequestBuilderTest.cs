// This file was modified by Kin Ecosystem (2019)


using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kin.Base;
using Kin.Base.requests;
using kin_base_test.responses;

namespace kin_base_test.requests
{
    [TestClass]
    public class AccountsRequestBuilderTest
    {
        [TestMethod]
        public void TestAccountsBuildUri()
        {
            using (var server = new Server("https://horizon-testnet.stellar.org"))
            {
                var uri = server.Accounts
                    .Cursor("13537736921089")
                    .Limit(200)
                    .Order(OrderDirection.ASC)
                    .BuildUri();

                Assert.AreEqual("https://horizon-testnet.stellar.org/accounts?cursor=13537736921089&limit=200&order=asc", uri.ToString());
            }
        }

        [TestMethod]
        public async Task TestAccountsAccount()
        {
            var jsonResponse = File.ReadAllText(Path.Combine("testdata", "account.json"));
            var fakeHttpClient = FakeHttpClient.CreateFakeHttpClient(jsonResponse);

            using (var server = new Server("https://horizon-testnet.stellar.org", fakeHttpClient))
            {
                var account = await server.Accounts.Account("GAAZI4TCR3TY5OJHCTJC2A4QSY6CJWJH5IAJTGKIN2ER7LBNVKOCCWN7");

                AccountDeserializerTest.AssertTestData(account);
            }
        }

        [TestMethod]
        public async Task TestAccountsData()
        {
            var jsonResponse = File.ReadAllText(Path.Combine("testdata", "accountData.json"));
            var fakeHttpClient = FakeHttpClient.CreateFakeHttpClient(jsonResponse);

            using (var server = new Server("https://horizon-testnet.stellar.org", fakeHttpClient))
            {
                var accountData = await server.Accounts.AccountData("GAKLBGHNHFQ3BMUYG5KU4BEWO6EYQHZHAXEWC33W34PH2RBHZDSQBD75", "TestValue");

                Assert.AreEqual("VGVzdFZhbHVl", accountData.Value);
                Assert.AreEqual("TestValue", accountData.ValueDecoded);
            }
        }
    }
}
