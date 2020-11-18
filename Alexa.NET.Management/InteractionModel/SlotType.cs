﻿using VoicifyAlexa.NET.Management.SlotType;
using Newtonsoft.Json;

namespace VoicifyAlexa.NET.Management.InteractionModel
{
    public class SlotType
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("values", NullValueHandling = NullValueHandling.Ignore)]
        public SlotTypeValue[] Values { get; set; }

        [JsonProperty("valueSupplier", NullValueHandling = NullValueHandling.Ignore)]
        public ValueSupplier ValueSupplier { get; set; }
    }
}