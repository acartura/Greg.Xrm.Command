﻿using Microsoft.PowerPlatform.Dataverse.Client;

namespace Greg.Xrm.Command.Model
{
	public interface IUserQueryRepository
	{
		Task<IReadOnlyList<UserQuery>> GetByIdAsync(IOrganizationServiceAsync2 crm, IEnumerable<Guid> ids);
		Task<IReadOnlyList<UserQuery>> GetContainingAsync(IOrganizationServiceAsync2 crm, string tableName, string columnName);
	}
}
