// This file was modified by Kin Ecosystem (2019)


using Kin.Base.responses;
using Kin.Base.responses.page;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Kin.Base.requests
{
    public class LedgersRequestBuilder : RequestBuilderStreamable<LedgersRequestBuilder, LedgerResponse>
    {
        public LedgersRequestBuilder(Uri serverUri, HttpClient httpClient)
            : base(serverUri, "ledgers", httpClient)
        {
        }

        /// <summary>
        ///     Requests specific uri and returns LedgerResponse
        ///     This method is helpful for getting the links.
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public async Task<LedgerResponse> Ledger(Uri uri)
        {
            var responseHandler = new ResponseHandler<LedgerResponse>();

            var response = await HttpClient.GetAsync(uri);
            return await responseHandler.HandleResponse(response);
        }

        ///<summary>
        /// Requests <code>GET /ledgers/{ledgerSeq}</code>
        /// <a href="https://www.stellar.org/developers/horizon/reference/ledgers-single.html">Ledger Details</a>
        ///</summary>
        ///<param name="ledgerSeq">Ledger to fetch</param>
        public Task<LedgerResponse> Ledger(long ledgerSeq)
        {
            SetSegments("ledgers", ledgerSeq.ToString());
            return Ledger(BuildUri());
        }
    }
}
