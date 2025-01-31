// This file was modified by Kin Ecosystem (2019)


using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kin.Base.federation
{
    public static class Federation
    {
        /// <summary>
        /// This method is a helper method for handling user inputs that contain `destination` value.
        /// It accepts two types of values:
        /// For Stellar address (ex. bob*stellar.org`) it splits Stellar address and then tries to find information about
        /// federation server instellar.toml file for a given domain.
        /// 
        /// For account ID (ex. GB5XVAABEQMY63WTHDQ5RXADGYF345VWMNPTN2GFUDZT57D57ZQTJ7PS) it simply returns the
        /// given Account ID.
        /// </summary>
        /// <param name="value">Stellar address or account id</param>
        /// <exception cref="MalformedAddressException"></exception>
        /// <exception cref="ConnectionErrorException"></exception>
        /// <exception cref="NoFederationServerException"></exception>
        /// <exception cref="FederationServerInvalidException"></exception>
        /// <exception cref="StellarTomlNotFoundInvalidException"></exception>
        /// <exception cref="NotFoundException"></exception>
        /// <exception cref="ServerErrorException"></exception>
        /// <returns><see cref="FederationResponse"/></returns>
        public static async Task<FederationResponse> Resolve(string value)
        {
            var tokens = Regex.Split(value, "\\*");
            if (tokens.Length == 1)
                return new FederationResponse(null, value, null, null);

            if (tokens.Length == 2)
            {
                var domain = tokens[1];
                using (var server = await FederationServer.CreateForDomain(domain))
                {
                    return await server.ResolveAddress(value);
                }
            }

            throw new MalformedAddressException();
        }
    }
}
