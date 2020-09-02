﻿using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Internals;
using Alexa.NET.Management.ReferenceCatalogManagement;
using Refit;

namespace Alexa.NET.Management
{
    internal class ReferenceCatalogManagementApi:IReferenceCatalogManagementApi
    {
        public ReferenceCatalogManagementApi(HttpClient httpClient)
        {
            Client = RestService.For<IClientReferenceCatalogManagementApi>(httpClient, ManagementRefitSettings.Create());
        }

        public IClientReferenceCatalogManagementApi Client { get; set; }
        public Task<ReferenceCatalogCreationResponse> Create(string vendorId, string name, string description = null)
        {
            return Client.Create(new ReferenceCatalogCreationRequest
            {
                VendorId = vendorId,
                Catalog = new ReferenceCatalog
                {
                    Name = name,
                    Description = description
                }
            });
        }

        public async Task<Uri> CreateVersion(string catalogId, string url, string description = null)
        {
            var response = await Client.CreateVersion(catalogId, new ReferenceCatalogCreateVersionRequest
            {
                Source = new ReferenceCatalogSource
                {
                    Type = "URL",
                    Url = url
                },
                Description = description
            });

            return await response.UriOrError(HttpStatusCode.Accepted);
        }

        public Task<ReferenceCatalogUpdateStatus> GetUpdateStatus(string catalogId, string updateRequestId)
        {
            return Client.GetUpdateStatus(catalogId, updateRequestId);
        }

        public Task<ReferenceCatalogListResponse> List(string vendorId)
        {
            return Client.List(vendorId);
        }

        public Task<ReferenceCatalogListResponse> List(string vendorId, SortDirection sortDirection)
        {
            return Client.List(vendorId, sortDirection);
        }

        public Task<ReferenceCatalogListResponse> List(string vendorId, string nextToken, int maxResults)
        {
            return Client.List(vendorId, nextToken, maxResults);
        }

        public Task<ReferenceCatalogListResponse> List(string vendorId, SortDirection sortDirection, string nextToken, int maxResults)
        {
            return Client.List(vendorId, sortDirection, nextToken, maxResults);
        }

        public Task<ReferenceCatalogListVersionsResponse> ListVersions(string catalogId)
        {
            return Client.ListVersions(catalogId);
        }

        public Task<ReferenceCatalogListVersionsResponse> ListVersions(string catalogId, SortDirection sortDirection)
        {
            return Client.ListVersions(catalogId, sortDirection);
        }

        public Task<ReferenceCatalogListVersionsResponse> ListVersions(string catalogId, string nextToken, int maxResults)
        {
            return Client.ListVersions(catalogId, nextToken, maxResults);
        }

        public Task<ReferenceCatalogListVersionsResponse> ListVersions(string catalogId, SortDirection sortDirection, string nextToken, int maxResults)
        {
            return Client.ListVersions(catalogId, sortDirection, nextToken, maxResults);
        }

        public Task<ReferenceCatalogDefinition> Get(string catalogId)
        {
            return Client.Get(catalogId);
        }

        public Task<ReferenceCatalogVersionDefinition> GetVersion(string catalogId, string version)
        {
            return Client.GetVersion(catalogId, version);
        }

        public Task<ReferenceCatalogValuesResponse> GetValues(string catalogId, string version)
        {
            return Client.GetValues(catalogId, version);
        }

        public Task<ReferenceCatalogValuesResponse> GetValues(string catalogId, string version, int maxResults)
        {
            return Client.GetValues(catalogId, version, maxResults);
        }

        public Task<ReferenceCatalogValuesResponse> GetValues(string catalogId, string version, int nextToken, int maxResults)
        {
            return Client.GetValues(catalogId, version, nextToken, maxResults);
        }
    }
}
