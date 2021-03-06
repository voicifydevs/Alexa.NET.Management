﻿using System;
using System.Threading.Tasks;
using Alexa.NET.Management.ReferenceCatalogManagement;

namespace Alexa.NET.Management
{
    public interface IReferenceCatalogManagementApi
    {
        IUpdateJobsManagementApi UpdateJobs { get; }

        Task<ReferenceCatalogCreationResponse> Create(string vendorId, string name, string description = null);

        Task<Uri> CreateVersion(string catalogId, string url, string description = null);

        Task<ReferenceCatalogUpdateStatus> GetUpdateStatus(string catalogId, string updateRequestId);

        Task<ReferenceCatalogListResponse> List(string vendorId);

        Task<ReferenceCatalogListResponse> List(string vendorId, SortDirection sortDirection);

        Task<ReferenceCatalogListResponse> List(string vendorId, string nextToken, int maxResults);

        Task<ReferenceCatalogListResponse> List(string vendorId, SortDirection sortDirection, string nextToken, int maxResults);

        Task<ReferenceCatalogListVersionsResponse> ListVersions(string catalogId);

        Task<ReferenceCatalogListVersionsResponse> ListVersions(string catalogId, SortDirection sortDirection);

        Task<ReferenceCatalogListVersionsResponse> ListVersions(string catalogId, string nextToken, int maxResults);

        Task<ReferenceCatalogListVersionsResponse> ListVersions(string catalogId, SortDirection sortDirection, string nextToken, int maxResults);

        Task<ReferenceCatalogDefinition> Get(string catalogId);

        Task<ReferenceCatalogVersionDefinition> GetVersion(string catalogId, string version);

        Task<ReferenceCatalogValuesResponse> GetValues(string catalogId, string version);

        Task<ReferenceCatalogValuesResponse> GetValues(string catalogId, string version, int maxResults);

        Task<ReferenceCatalogValuesResponse> GetValues(string catalogId, string version, int nextToken, int maxResults);

        Task Update(string catalogId, string name = null, string description = null);

        Task UpdateVersion(string catalogId, string version, string description);

        Task Delete(string catalogId);

        Task DeleteVersion(string catalogId, string version);
    }
}
