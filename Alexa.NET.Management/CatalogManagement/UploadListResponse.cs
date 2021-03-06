﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.CatalogManagement
{
    public class UploadListResponse
    {
        [JsonProperty("_links")]
        public Dictionary<string, ApiLink> Links { get; set; }

        [JsonProperty("nextToken")]
        public string NextToken { get; set; }

        [JsonProperty("isTruncated")]
        public bool IsTruncated { get; set; }

        [JsonProperty("uploads")]
        public UploadSummary[] Uploads { get; set; }
    }
}
