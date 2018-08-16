using Dapper;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Kiss4Web.Modules.Pendenzen.MasterData
{
	public class CreateUpdateHandler : TypedMessageHandler<CreateUpQuery, MasterDataItem>
	{
		private readonly SqlConnection _dbConnection;
		//private readonly UnitOfWork unitOfWork = new UnitOfWork
		
		public CreateUpdateHandler(SqlConnection dbConnection)
		{
			_dbConnection = dbConnection;
		}

		public override async Task<MasterDataItem> Handle(CreateUpQuery query)
		{
			var status =  await _dbConnection.QueryAsync<SelectItem>(
							@"Select Code as Value, Text as Name From XLOVCode Where LOVName = 'TaskStatus'");

			var type = await _dbConnection.QueryAsync<SelectItem>(
							@"Select Code as Value, Text as Name From XLOVCode Where LOVName = 'TaskType'");

			var organisation = await _dbConnection.QueryAsync<SelectItem>(
							@"Select OrgUnitID as Value, ItemName as Name From XOrgUnit");

			var masterDataItem = new MasterDataItem() {
				Status = status,
				PendenzType = type,
				Organisationseinheit = organisation
			};
			return masterDataItem;
			
		}
	}
}
