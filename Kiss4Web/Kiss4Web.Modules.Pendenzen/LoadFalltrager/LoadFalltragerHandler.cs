using Dapper;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Kiss4Web.Modules.Pendenzen.LoadFalltrager
{
	public class LoadFalltragerHandler : TypedMessageHandler<LoadFalltragerQuery, IEnumerable<FalltragerItem>>
	{
		private readonly SqlConnection _dbConnection;

		public LoadFalltragerHandler(SqlConnection dbConnection)
		{
			_dbConnection = dbConnection;
		}

		public override async Task<IEnumerable<FalltragerItem>> Handle(LoadFalltragerQuery query)
		{
			var data = await _dbConnection.QueryAsync<FalltragerItem>(@"  
				SELECT	Id			= FAL.FaFallID,
						Name        = PRS.Name,
						Vorname     = PRS.Vorname,
						Benutzer    = USR.DisplayText,
						FaFallID    = FAL.FaFallID,
						NameVorname = PRS.NameVorname + ' (' + CONVERT(VARCHAR, FAL.FaFallID) + ')'
                FROM	dbo.FaFall FAL WITH (READUNCOMMITTED)
                  INNER JOIN dbo.vwPerson PRS ON PRS.BaPersonID = FAL.BaPersonID
                  INNER JOIN dbo.vwUser   USR ON USR.UserID = FAL.UserID
                WHERE	PRS.NameVorname LIKE @SearchString + '%' OR
						FAL.FaFallID = CASE WHEN ISNUMERIC(@SearchString) = 1 THEN CONVERT(INT, ROUND(@SearchString, 0)) ELSE -1 END
                ORDER BY PRS.Name, PRS.Vorname", new { query.SearchString });

			if (data.AsList().Count > 0)
			{
				return data;
			}
			return new List<FalltragerItem>();
		}
	}
}
