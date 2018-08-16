using Dapper;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model;
using Kiss4Web.Model.QueryTypes;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Kiss4Web.Modules.Pendenzen.GetPendenzenDetail
{
    public class PendenzenDetailHandler : TypedMessageHandler<PendenzenDetailQuery, PendenzenDetailItem>
    {
        private readonly SqlConnection _dbConnection;
        private readonly IQueryable<Xtask> _xtasks;
        private readonly IQueryable<FaPendenzgruppe> _faPendenzgruppe;
        public PendenzenDetailHandler(SqlConnection dbConnection, IQueryable<Xtask> xtasks, IQueryable<FaPendenzgruppe> faPendenzgruppe)
        {
            _dbConnection = dbConnection;
            _xtasks = xtasks;
            _faPendenzgruppe = faPendenzgruppe;

        }

        public override async Task<PendenzenDetailItem> Handle(PendenzenDetailQuery query)
        {

            var data = await _dbConnection.QueryAsync<PendenzenDetailItem>(string.Format(@"SELECT XTaskID AS id,
                    TSK.TaskStatusCode   AS status,
                    TSK.TaskTypeCode   AS pendenzTyp,
                    TSK.Subject     AS betreff,
                    XLOV.Text     AS TaskTypeName,
                    TSK.TaskDescription   AS beschreibung,
                    TSK.ReceiverID    AS empfanger,
                            empfangerName = IsNull(URX.DisplayText, GRX.Name),
                            empfangerId = TSK.ReceiverId,
                    FAL.FaFallID    AS falltrager,
                    FalltragerName = PRS.Name + IsNull(', ' + PRS.Vorname, '') + ' (' + CONVERT(VARCHAR, FAL.FaFallID) + ')',

                    LeistungModul =(MOD.ShortName + ' - ' + 
				                           CASE WHEN LEI.FaProzessCode IS NOT NULL
				                             THEN dbo.fnLOVMLText('FaProzess', LEI.FaProzessCode, 1)
				                             ELSE MOD.NAME
				                           END +
				                           ' (' + dbo.fnGetZeitraumString(LEI.DatumVon, LEI.DatumBis) + ')'),

                    TSK.FaLeistungID   AS leistung,
                     leistungsverantw =  TSK.FaLeistungID,
                   Ersteller =  URXSender.DisplayText,
                    LeistungsverantName = (SELECT NULLIF(USR.DisplayText, '') as LeistungsverantwName
                                FROM dbo.vwUser USR
                                  INNER JOIN dbo.FaLeistung LEI ON LEI.UserID = USR.UserID
                                WHERE LEI.FaLeistungID =TSK.FaLeistungID),
                    TSK.FaAktennotizID   AS betrifftPerson,
                    TSK.ResponseText   AS antwort,
                    TSK.StartDate    AS erfasst,
                    TSK.ExpirationDate   AS fallig,
                    BearbeitungName = Xuser.LogonName + ', ' + CONVERT(VARCHAR, TSK.StartDate, 104),
                    ErledigtName = XuserDone.LogonName + ', ' + CONVERT(VARCHAR, TSK.DoneDate, 104),
                 BetrifftPersonName = Person.Name,
                 TSK.BaPersonID as PersonId
                        FROM XTask    TSK
                        LEFT JOIN FaLeistung    LEI ON LEI.FaLeistungID = TSK.FaLeistungID
                        LEFT JOIN FaFall  FAL ON FAL.FaFallID = IsNull(LEI.FaFallID, TSK.FaFallID)
                        LEFT  JOIN FaPendenzgruppe  GRX ON GRX.FaPendenzgruppeID = TSK.ReceiverID
                        LEFT  JOIN vwUser           URX ON URX.UserID = TSK.ReceiverID
                        LEFT  JOIN vwUser           URXSender ON URXSender.UserID = TSK.SenderID
                        LEFT  JOIN BaPerson         PRS ON PRS.BaPersonID = IsNull(LEI.BaPersonID, FAL.BaPersonID)
                        LEFT  JOIN XModul           MOD ON MOD.ModulID = LEI.ModulID
                        LEFT  JOIN XUser           Xuser ON TSK.UserID_InBearbeitung = Xuser.UserID
                        LEFT JOIN XLOVCode  XLOV ON TSK.TaskTypeCode = XLOV.Code AND XLOV.LOVName = 'TaskType'
                  LEFT JOIN XUser   XuserDone ON XuserDone.UserID = TSK.UserID_Erledigt
                  LEFT JOIN (
                  SELECT
                   Value = PRS.BaPersonID,
                   Name = PRS.NameVorname,
                   FAP.FaFallID
                  FROM dbo.FaFallPerson     FAP
                   INNER JOIN dbo.vwPerson PRS ON PRS.BaPersonID = FAP.BaPersonID) as Person on Person.FaFallID = TSK.FaFallID
                   and Person.Value = TSK.BaPersonID
                                     WHERE XTaskID = {0}", query.TaskId), new { query.TaskId });
            var result = data.AsList();
            if (result.Count > 0)
            {
                return result[0];
            }
            return new PendenzenDetailItem();
        }

    }
}
