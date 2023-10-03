namespace datasheetapi.Services;
using System;
using System.Threading.Tasks;

using Models;

public interface IFusionService
{
    /// <summary>
    /// Obtain a "ProjectMaster" based on the given context ID/projectMasterId.
    /// </summary>
    /// <param name="contextId">The projectMaster ID to query for.</param>
    /// <returns>A "ProjectMaster" for the given id.</returns>
    /// <exception> "OperationFailed" If no projectMaster was found for the given ID.</exception>
    public Task<FusionProjectMaster> ProjectMasterAsync(Guid contextId);
    public Task<Fusion.Integration.Profile.FusionPersonProfile?> ResolveUserFromPersonId(Guid azureUniqueId);

}
