using Dapper;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Kiss4Web.Modules.Pendenzen.EmpfangerPendenzen
{
	public class EmpfangerPendenzenHandler : TypedMessageHandler<EmpfangerPendenzenQuery, IEnumerable<EmpfangerItem>>
	{
		private readonly SqlConnection _dbConnection;

		public EmpfangerPendenzenHandler(SqlConnection dbConnection)
		{
			_dbConnection = dbConnection;
		}

		public override async Task<IEnumerable<EmpfangerItem>> Handle(EmpfangerPendenzenQuery query)
		{
			string keyword = query.Keyword ?? "";
			var data = await _dbConnection.QueryAsync<EmpfangerItem>(
							@"  SELECT  Typ = 'Benutzer',
                                        Kurzel = USR.LogonName,
                                        Name = USR.NameVorname,
                                        Abteilung = USR.OrgEinheitName,
                                        Id = USR.UserID,
                                        TypeCode = 1,
                                        DisplayText = USR.DisplayText
                                FROM dbo.vwUser USR WITH (READUNCOMMITTED)
                                WHERE (USR.NameVorname LIKE @keyword + '%'
                                        OR USR.LogonName LIKE @keyword + '%')
                                        AND USR.IsLocked = 0  --nur nicht gesperrte
                                UNION ALL
                                SELECT  Typ = 'Gruppe',
                                        Kurzel = NULL,
                                        Name = FPG.Name,
                                        Abteilung = NULL,
                                        Id = FPG.FaPendenzgruppeID,
                                        TypeCode = 2,
                                        DisplayText = FPG.Name
                                FROM dbo.FaPendenzgruppe FPG WITH (READUNCOMMITTED)
                                WHERE FPG.Name LIKE @keyword + '%'
                                    AND FPG.Name NOT LIKE 'migrierte_Grp_%'
                                ORDER BY TypeCode DESC, Name", new { keyword });
			var result = data.AsList();
			if (result.Count > 0)
			{
				return result;
			}
			return new List<EmpfangerItem>();
		}
	}
}
