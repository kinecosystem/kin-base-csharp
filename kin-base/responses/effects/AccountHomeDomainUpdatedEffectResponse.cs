// This file was modified by Kin Ecosystem (2019)


using Newtonsoft.Json;

namespace Kin.Base.responses.effects
{
    /// <summary>
    ///     Represents account_home_domain_updated effect response.
    ///     See: https://www.stellar.org/developers/horizon/reference/resources/effect.html
    ///     <seealso cref="requests.EffectsRequestBuilder" />
    ///     <seealso cref="Server" />
    /// </summary>
    public class AccountHomeDomainUpdatedEffectResponse : EffectResponse
    {
        [JsonProperty(PropertyName = "home_domain")]
        public string HomeDomain { get; private set; }

        public override int TypeId => 5;

        public AccountHomeDomainUpdatedEffectResponse()
        {

        }

        /// <inheritdoc />
        public AccountHomeDomainUpdatedEffectResponse(string homeDomain)
        {
            HomeDomain = homeDomain;
        }
    }
}
