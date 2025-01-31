// This file was modified by Kin Ecosystem (2019)


using Kin.Base.responses;
using Kin.Base.responses.operations;
using Kin.Base.responses.page;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Kin.Base.requests
{
    public class PaymentsRequestBuilder : RequestBuilderStreamable<PaymentsRequestBuilder, OperationResponse>
    {
        public PaymentsRequestBuilder(Uri serverURI, HttpClient httpClient)
            : base(serverURI, "payments", httpClient)
        {
        }

        ///<Summary>
        /// Builds request to <code>GET /accounts/{account}/payments</code>
        /// <a href="https://www.stellar.org/developers/horizon/reference/payments-for-account.html">Effects for Account</a>
        /// </Summary>
        /// <param name="account">Account for which to get payments</param> 
        public PaymentsRequestBuilder ForAccount(string account)
        {
            account = account ?? throw new ArgumentNullException(nameof(account), "account cannot be null");
            this.SetSegments("accounts", account, "payments");
            return this;
        }

        ///<Summary>
        /// Builds request to <code>GET /ledgers/{ledgerSeq}/effects</code>
        /// <a href="https://www.stellar.org/developers/horizon/reference/payments-for-ledger.html">Effects for Ledger</a>
        /// </Summary>
        /// <param name="ledgerSeq">Ledger for which to get effects</param> 
        public PaymentsRequestBuilder ForLedger(long ledgerSeq)
        {
            SetSegments("ledgers", ledgerSeq.ToString(), "payments");
            return this;
        }

        ///<Summary>
        /// Builds request to <code>GET /transactions/{transactionId}/payments</code>
        /// <a href="https://www.stellar.org/developers/horizon/reference/payments-for-transaction.html">Effect for Transaction</a>
        /// </Summary>
        /// <param name="transactionId">Transaction ID for which to get payments</param>
        public PaymentsRequestBuilder ForTransaction(string transactionId)
        {
            transactionId = transactionId ?? throw new ArgumentNullException(nameof(transactionId), "transactionId cannot be null");
            SetSegments("transactions", transactionId, "payments");
            return this;
        }
    }
}
