using Dapper;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Kiss4Web.Modules.Pendenzen.ErstellerPendenzen
{
	public class ErstellerPendenzenHandler : TypedMessageHandler<ErstellerPendenzenQuery, string>
	{
		private readonly SqlConnection _dbConnection;

		public ErstellerPendenzenHandler(SqlConnection dbConnection)
		{
			_dbConnection = dbConnection;
		}

		public override async Task<string> Handle(ErstellerPendenzenQuery query)
		{
			var keyword = query.UserLoginName;
			var data = await _dbConnection.QueryAsync<ErstellerItem>(
							@"  SELECT Typ = 'Benutzer',
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
                                SELECT Typ = 'Gruppe',
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
				var item = query.Id != 0 ? result.Find(m => m.Id == query.Id) : result[0];
				if (item != null)
				{
					string resStr = "";
					if (!string.IsNullOrEmpty(item.Kurzel))
					{
						resStr += item.Kurzel + " - ";
					}
					if (!string.IsNullOrEmpty(item.Name))
					{
						resStr += item.Name + "";
					}
					if (!string.IsNullOrEmpty(item.Abteilung))
					{
						resStr += " (" + item.Abteilung + ")";
					}
					return resStr;
				}
			}
			return "";
		}
	}
}
