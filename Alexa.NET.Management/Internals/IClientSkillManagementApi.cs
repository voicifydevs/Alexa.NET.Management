﻿using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.Skills;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public interface IClientSkillManagementApi
    {
        [Get("/skills/{skillId}/status")]
        Task<SkillStatus> Status(string skillId, [Query]SkillResourceContainer container);

        [Get("/skills/{skillId}/stages/{stage}/manifest")]
        Task<Skill> Get(string skillId, SkillStage stage);

        [Post("/skills")]
        Task<SkillId> Create([Body] SkillCreateRequest request);

        [Put("/skills/{skillId}/stages/{stage}/manifest")]
        Task<SkillId> Update(string skillId, SkillStage stage, [Body] Skill skill);

        [Post("/skills/{skillId}/submit")]
        Task<HttpResponseMessage> Submit(string skillId, [Body]SubmitRequest request);

        [Delete("/skills/{skillId}")]
        Task<HttpResponseMessage> Delete(string skillId);

        [Post("/skills/{skillId}/withdraw")]
        Task Withdraw(string skillId, [Body]WithdrawalRequest request);

        [Post("/skills/{skillId}/unpublish")]
        Task<UnpublishResponse> Unpublish(string skillId, [Body] UnpublishRequest request);

        [Post("/skills/{skillId}/invocations")]
        Task<InvocationResponse> Invoke(string skillId, [Body]InvocationRequest request);

        [Post("/skills/{skillId}/simulations")]
        Task<SimulationResponse> Simulate(string skillId, [Body] SimulationRequest request);

        [Get("/skills/{skillId}/simulations/{simulationId}")]
        Task<SimulationResponse> SimulationResult(string skillId, string simulationId);

        [Get("/skills?vendorId={vendorId}")]
        Task<SkillListResponse> List(string vendorId);

        [Get("/skills?vendorId={vendorId}")]
        Task<SkillListResponse> List(string vendorId, [Query]SkillIdContainer container);

        [Get("/skills?vendorId={vendorId}")]
        Task<SkillListResponse> List(string vendorId, int maxResults);

        [Get("/skills?vendorId={vendorId}")]
        Task<SkillListResponse> List(string vendorId, int maxResults, string nextToken);

        [Get("/skills/{skillId}/certifications")]
        Task<CertificationListResponse> ListCertification(string skillId);

        [Get("/skills/{skillId}/certifications")]
        Task<CertificationListResponse> ListCertification(string skillId, int maxResults);

        [Get("/skills/{skillId}/certifications")]
        Task<CertificationListResponse> ListCertification(string skillId, int maxResults, string nextToken);

        [Get("/skills/{skillId}/certifications/{certificationId}")]
        Task<Certification> Certification(string skillId, string certificationId);

        [Get("/skills/{skillId}/certifications/{certificationId}")]
        Task<Certification> Certification(string skillId, string certificationId, [Header("Accept-Language")]string locale);

        [Post("/skills/{skillId}/publications")]
        Task<HttpResponseMessage> Publish(string skillId);

        [Post("/skills/{skillId}/publications")]
        Task<HttpResponseMessage> Publish(string skillId, [Body]PublishRequest request);
    }
}
