﻿using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.ReferenceCatalogManagement;
using Newtonsoft.Json;
using Xunit;

namespace Alexa.NET.Management.Tests
{
    public class ReferenceCatalogManagementTests
    {
        [Fact]
        public async Task Create()
        {
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Post, req.Method);
                Utility.CompareJson(JsonConvert.DeserializeObject<ReferenceCatalogCreationRequest>(await req.Content.ReadAsStringAsync()),"ReferenceCatalogCreate.json");
                Assert.Equal("/v1/skills/api/custom/interactionModel/catalogs", req.RequestUri.PathAndQuery);
            }, new ReferenceCatalogCreationResponse{CatalogId="testabc"}));

            var response = await management.ReferenceCatalogManagement.Create("ABC123","test","test desc");
            Assert.Equal("testabc", response.CatalogId);
        }

        [Fact]
        public async Task CreateVersion()
        {
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Post, req.Method);
                Utility.CompareJson(JsonConvert.DeserializeObject<ReferenceCatalogCreateVersionRequest>(await req.Content.ReadAsStringAsync()), "ReferenceCatalogCreateVersion.json");
                Assert.Equal("/v1/skills/api/custom/interactionModel/catalogs/ABC123/versions", req.RequestUri.PathAndQuery);
                var resp = new HttpResponseMessage(HttpStatusCode.Accepted);
                resp.Headers.Location = new Uri("https://example.com",UriKind.Absolute);
                return resp;
            }));

            var response = await management.ReferenceCatalogManagement.CreateVersion("ABC123", "https://exampledata.com", "test desc");
            Assert.Equal("https://example.com/", response.ToString());
        }

        [Fact]
        public async Task UpdateStatus()
        {
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/api/custom/interactionModel/catalogs/ABC123/updateRequest/requestABC", req.RequestUri.PathAndQuery);
            },Utility.ExampleFileContent<ReferenceCatalogUpdateStatus>("ReferenceCatalogUpdateStatus.json")));

            var response = await management.ReferenceCatalogManagement.GetUpdateStatus("ABC123", "requestABC");
            Utility.CompareJson(response, "ReferenceCatalogUpdateStatus.json");
        }

        [Fact]
        public void List()
        {
            Assert.False(true);
        }

        [Fact]
        public void ListVersions()
        {
            Assert.False(true);
        }

        [Fact]
        public void Get()
        {
            Assert.False(true);
        }

        [Fact]
        public void GetVersion()
        {
            Assert.False(true);
        }

        [Fact]
        public void GetValues()
        {
            Assert.False(true);
        }

        [Fact]
        public void Update()
        {
            Assert.False(true);
        }

        [Fact]
        public void UpdateVersionInformation()
        {
            Assert.False(true);
        }

        [Fact]
        public void Delete()
        {
            Assert.False(true);
        }

        [Fact]
        public void DeleteVersion()
        {
            Assert.False(true);
        }
    }
}
