﻿using Microsoft.PowerPlatform.Dataverse.Client;

namespace Greg.Xrm.Command.Services.Connection
{
	public interface IOrganizationServiceRepository
	{
		string GetTokenCachePath();

		Task<ConnectionSetting> GetAllConnectionDefinitionsAsync();

		Task<IOrganizationServiceAsync2> GetCurrentConnectionAsync();

		Task SetConnectionAsync(string name, string connectionString);

		Task SetDefaultAsync(string name);
		Task SetDefaultSolutionAsync(string uniqueName);
		Task<string?> GetCurrentDefaultSolutionAsync();
	}
}
