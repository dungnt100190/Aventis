using Dapper;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Kiss4Web.Modules.Pendenzen.LoadLeistungPerson
{
	public class LoadLeistungPersonHandler : TypedMessageHandler<LoadLeistungPersonQuery, LeistungPersonItem>
	{
		private readonly SqlConnection _dbConnection;

		public LoadLeistungPersonHandler(SqlConnection dbConnection)
		{
			_dbConnection = dbConnection;
		}

		public override async Task<LeistungPersonItem> Handle(LoadLeistungPersonQuery query)
		{
			int languageCode = 1;
			var leistung = await _dbConnection.QueryAsync<SelectItem>(@"  
				SELECT 
				  Value = FaLeistungID, 
				  Name	= MDL.ShortName + ' - ' + 
				           CASE WHEN LEI.FaProzessCode IS NOT NULL
				             THEN dbo.fnLOVMLText('FaProzess', LEI.FaProzessCode, @languageCode)
				             ELSE MDL.NAME
				           END +
				           ' (' + dbo.fnGetZeitraumString(LEI.DatumVon, LEI.DatumBis) + ')'
				FROM dbo.FaLeistung       LEI WITH (READUNCOMMITTED)
				  INNER JOIN dbo.XModul   MDL WITH (READUNCOMMITTED) ON MDL.ModulID = LEI.ModulID
				                                                    AND MDL.Licensed = 1
				WHERE 
				  LEI.FaFallID = @FaFallID
				  -- Nur abgeschlossene Leistungen (ausser F Leistung)
				  AND ((LEI.DatumBis IS NULL OR LEI.DatumBis >= GETDATE())
				        AND(LEI.DatumVon IS NULL OR LEI.DatumVon <= GETDATE() )
				       OR (LEI.ModulID = 2 AND (LEI.FaProzessCode = 200 OR LEI.FaProzessCode IS NULL)))
				ORDER BY MDL.SortKey, LEI.DatumVon, dbo.fnLOVMLText('FaProzess', LEI.FaProzessCode, @languageCode);", new { query.FaFallID, languageCode });

			var betrifftPerson = await _dbConnection.QueryAsync<SelectItem>(@"  
				SELECT
				  Value = PRS.BaPersonID,
				  Name	= PRS.NameVorname
				FROM dbo.FaFallPerson     FAP
				  INNER JOIN dbo.vwPerson PRS ON PRS.BaPersonID = FAP.BaPersonID
				WHERE FAP.FaFallID = @FaFallID;", new { query.FaFallID });

			var result = new LeistungPersonItem {
				ListLeistung = leistung,
				ListBetrifftPerson = betrifftPerson
			};
			return result;
		}
	}
}
