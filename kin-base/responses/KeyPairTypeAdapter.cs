// This file was modified by Kin Ecosystem (2019)


using System;
using Newtonsoft.Json;

namespace Kin.Base.responses
{
    public class KeyPairTypeAdapter : JsonConverter<KeyPair>
    {
        public override void WriteJson(JsonWriter writer, KeyPair value, JsonSerializer serializer)
        {
            writer.WriteValue(value.AccountId);
        }

        public override KeyPair ReadJson(JsonReader reader, Type objectType, KeyPair existingValue,
            bool hasExistingValue, JsonSerializer serializer)
        {
            var accountId = reader.Value?.ToString();
            return accountId is null ? null : KeyPair.FromAccountId(accountId);
        }
    }
}
