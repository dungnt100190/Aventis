using Dapper;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Kiss4Web.Modules.Pendenzen.SearchPendenzen
{
    public class SearchPendenzenHandler : TypedMessageHandler<SearchPendenzenQuery, IEnumerable<TablePendenzenItem>>
    {
        private readonly SqlConnection _dbConnection;

        public SearchPendenzenHandler(SqlConnection dbConnection)
        {
            _dbConnection = dbConnection;   
        }

        public override async Task<IEnumerable<TablePendenzenItem>> Handle(SearchPendenzenQuery query)
        {
            var userId = query.UserId;
            var fromTime = " 00:00:00.000";
            var toTime = " 23:59:59.99";
            var strQuery = @"
                    SELECT
                      TSK.XTaskID,
                      TSK.FaFallID,
                      TSK.FaLeistungID,
                      TSK.BaPersonID,

                      TSK.TaskTypeCode,
                      TSK.TaskStatusCode,
                      TSK.CreateDate,
                      TSK.StartDate,
                      TSK.UserID_InBearbeitung,
                      TSK.ExpirationDate,
                      TSK.DoneDate,
                      TSK.UserID_Erledigt,
                      TSK.Subject,
                      TSK.TaskDescription,
                      TSK.SenderID,
                      TSK.TaskSenderCode,
                      TSK.ReceiverID,
                      TSK.TaskReceiverCode,
                      TSK.ResponseText,
                      TSK.TaskResponseCode,
                      TSK.JumpToPath,

                      Sender            = IsNull(UTR.DisplayText, GTR.Name),
                      Receiver          = IsNull(URX.DisplayText, GRX.Name),

                      FaFall            = PRS.Name + IsNull(', ' + PRS.Vorname, '') + ' (' + CONVERT(VARCHAR, FAL.FaFallID) + ')',
                      Fallnummer        = FAL.FaFallID,

                      UserID         = USR.UserID,
                      SAR            = USR.DisplayText,

                      FAL_BaPersonID = FAL.BaPersonID,
                      PersonFT       = PRS.Name + ISNULL(', ' + PRS.Vorname, ''),
                      PersonBP       = PRB.NameVorname,
                      ModulID        = LEI.ModulID,
                      LeistungModul  = MOD.ShortName,

                      OrgUnitID      = OUU.OrgUnitID,

                      Auswahl        = CONVERT(BIT, 0),
                      DatumVon       = CONVERT(INT, YEAR(TSK.CreateDate)),
                      SenderEMail    = UTR.EMail,
                      ReceiverEMail  = URX.EMail,
                      TSK.XTaskTS
                    FROM XTask                    TSK
                      LEFT  JOIN vwUser           UTR ON UTR.UserID = TSK.SenderID AND TSK.TaskSenderCode = 1
                      LEFT  JOIN FaPendenzgruppe  GTR ON GTR.FaPendenzgruppeID = TSK.SenderID AND TSK.TaskSenderCode = 2
                      LEFT  JOIN vwUser           URX ON URX.UserID = TSK.ReceiverID AND TSK.TaskReceiverCode = 1
                      LEFT  JOIN FaPendenzgruppe  GRX ON GRX.FaPendenzgruppeID = TSK.ReceiverID AND TSK.TaskReceiverCode = 2

                      LEFT  JOIN FaLeistung       LEI ON LEI.FaLeistungID = TSK.FaLeistungID
                      LEFT  JOIN FaFall           FAL ON FAL.FaFallID = IsNull(LEI.FaFallID, TSK.FaFallID)
                      LEFT  JOIN BaPerson         PRS ON PRS.BaPersonID = IsNull(LEI.BaPersonID, FAL.BaPersonID)
                      LEFT  JOIN vwUser           USR ON USR.UserID = IsNull(LEI.UserID, FAL.UserID)
                      LEFT  JOIN XOrgUnit_User    OUU ON OUU.UserID = USR.UserID
                                                     AND OUU.OrgUnitMemberCode = 2 
                      LEFT  JOIN XModul           MOD ON MOD.ModulID = LEI.ModulID

                      LEFT  JOIN vwPersonSimple   PRB ON PRB.BaPersonID = TSK.BaPersonID ";
            switch (query.IdMenu)
            {
                case "SC001_left-menu_meine-pendenzen_fallige":
                    strQuery += " WHERE ((TaskReceiverCode = 2 AND EXISTS (SELECT TOP 1 1 FROM dbo.FaPendenzgruppe_User WHERE UserID = {0} AND FaPendenzgruppeID = ReceiverID)) OR (TaskReceiverCode = 1 AND ReceiverID = {0})) AND TaskStatusCode IN (1, 2) AND ExpirationDate <= GetDate()";
                    break;
                case "1_3":
                    strQuery += " WHERE TaskReceiverCode = 1 AND ReceiverID = {0} AND TaskStatusCode IN (2)";
                    break;
                case "1_4":
                    strQuery += "WHERE ((TaskReceiverCode = 2 AND EXISTS (SELECT TOP 1 1 FROM dbo.FaPendenzgruppe_User WHERE UserID = {0} AND FaPendenzgruppeID = ReceiverID)) OR (TaskReceiverCode = 1 AND ReceiverID = {0})) AND TaskSenderCode = 1 AND SenderID = {0} AND TaskStatusCode IN (1, 2)";
                    break;
                case "1_5":
                    strQuery += "WHERE ((TaskReceiverCode = 2 AND EXISTS (SELECT TOP 1 1 FROM dbo.FaPendenzgruppe_User WHERE UserID = {0} AND FaPendenzgruppeID = ReceiverID)) OR (TaskReceiverCode = 1 AND ReceiverID = {0})) AND (TaskSenderCode = 2 OR SenderID <> {0}) AND TaskStatusCode IN (1, 2)";
                    break;
                case "1_6":
                    strQuery += " WHERE ((TaskReceiverCode = 2 AND EXISTS (SELECT TOP 1 1 FROM dbo.FaPendenzgruppe_User WHERE UserID = {0} AND FaPendenzgruppeID = ReceiverID)) OR (TaskReceiverCode = 1 AND ReceiverID = {0})) AND TaskStatusCode IN (1, 2) AND TaskTypeCode = 2";
                    break;
                case "1_7":
                    strQuery += "  WHERE ((TaskReceiverCode = 2 AND EXISTS (SELECT TOP 1 1 FROM FaPendenzgruppe_User WHERE UserID = {0} AND FaPendenzgruppeID = ReceiverID)) AND TaskStatusCode IN (1, 2))";
                    break;
                case "1_8":
                    strQuery += " WHERE (((TaskReceiverCode = 2 AND EXISTS (SELECT TOP 1 1 FROM dbo.FaPendenzgruppe_User WHERE UserID = {0} AND FaPendenzgruppeID = ReceiverID)) OR (TaskReceiverCode = 1 AND ReceiverID = {0})) AND TaskStatusCode IN (3))";
                    break;
                case "2_1":
                    strQuery += " WHERE TaskSenderCode = 1 AND SenderID = {0} AND TaskStatusCode IN (1, 2) AND ExpirationDate <= GetDate()";
                    break;
                case "2_2":
                    strQuery += " WHERE TaskSenderCode = 1 AND SenderID = {0} AND TaskStatusCode IN (1, 2)";
                    break;
                case "2_3":
                    strQuery += " WHERE TaskSenderCode = 1 AND SenderID = {0} AND TaskStatusCode IN (1, 2) AND TaskTypeCode <> 2";
                    break;
                case "2_4":
                    strQuery += " WHERE TaskSenderCode = 1 AND SenderID = {0} AND TaskStatusCode IN (1, 2) AND TaskTypeCode = 2";
                    break;
                case "2_5":
                    strQuery += " WHERE (TaskSenderCode = 1 AND SenderID = @userId AND TaskStatusCode IN (1, 2) AND TaskReceiverCode = 2)";
                    break;
                case "2_6":
                    strQuery += " WHERE (TaskSenderCode = 1 AND SenderID = {0} AND TaskStatusCode IN (3))";
                    break;
                default:
                    strQuery += " WHERE (((TaskReceiverCode = 2 AND EXISTS (SELECT TOP 1 1 FROM dbo.FaPendenzgruppe_User WHERE UserID = {0} AND FaPendenzgruppeID = ReceiverID)) OR (TaskReceiverCode = 1 AND ReceiverID = {0})) AND TaskStatusCode IN (1, 2))";
                    break;
            }
            if (query.IdStatus != null) //AND TSK.TaskStatusCode = {edtSucheTaskStatusCode}
                strQuery += " AND TSK.TaskStatusCode = " + query.IdStatus;

            if (query.IdPendenzTyp != null) //AND TSK.TaskTypeCode = {edtSucheTaskTypeCode}
                strQuery += " AND TSK.TaskTypeCode = " + query.IdPendenzTyp;

            if (!string.IsNullOrEmpty(query.Betreff)) //AND TSK.Subject LIKE '%' + {edtSucheSubject} + '%'
                strQuery += " AND TSK.Subject LIKE '%" + query.Betreff + "%'";

            if (query.IdErsteller != null) // AND TSK.SenderID = {edtSucheSenderID.LookupID} AND TSK.TaskSenderCode = {edtSucheTaskSenderCode}
                strQuery += " AND TSK.SenderID = " + query.IdErsteller;

            if (query.IdEmpfanger != null) // AND TSK.ReceiverID = {edtSucheReceiverID.LookupID} AND TSK.TaskReceiverCode = {edtSucheTaskReceiverCode}
                strQuery += " AND TSK.ReceiverID = " + query.IdEmpfanger;

            if (!string.IsNullOrEmpty(query.NameKlientIn)) // AND PRS.Name LIKE {edtSucheName} + '%'
                strQuery += " AND PRS.Name LIKE '%" + query.NameKlientIn + "%'";

            if (!string.IsNullOrEmpty(query.VornameKlientIn)) // AND PRS.Vorname LIKE {edtSucheVorname} + '%'
                strQuery += " AND PRS.Vorname LIKE '%" + query.VornameKlientIn + "%'";

            if (query.FromErfasst != null) // AND TSK.CreateDate >= {edtSucheCreateDateVon}
                if (!"Invalid date".Equals(query.FromErfasst))
                    strQuery += " AND TSK.CreateDate >= '" + query.FromErfasst + fromTime + "'";

            if (query.ToErfasst != null) // AND TSK.CreateDate <= {edtSucheCreateDateVon}
                if (!"Invalid date".Equals(query.ToErfasst))
                    strQuery += " AND TSK.CreateDate <= '" + query.ToErfasst + toTime + "'";

            if (query.FromFallig != null) // AND TSK.ExpirationDate >= {edtSucheExpirationDateVon}
                if (!"Invalid date".Equals(query.FromFallig))
                    strQuery += " AND TSK.ExpirationDate >= '" + query.FromFallig + fromTime + "'";

            if (query.ToFallig != null) // AND TSK.ExpirationDate <= {edtSucheExpirationDateBis}
                if (!"Invalid date".Equals(query.ToFallig))
                    strQuery += " AND TSK.ExpirationDate <= '" + query.ToFallig + toTime + "'";

            if (query.FromBearbeitung != null) // AND TSK.StartDate >= {edtSucheCreateDateVon}
                if (!"Invalid date".Equals(query.FromBearbeitung))
                    strQuery += " AND TSK.StartDate >= '" + query.FromBearbeitung + fromTime + "'";

            if (query.ToBearbeitung != null) // AND TSK.StartDate <= {edtSucheCreateDateVon}
                if (!"Invalid date".Equals(query.ToBearbeitung))
                    strQuery += " AND TSK.StartDate <= '" + query.ToBearbeitung + toTime + "'";

            if (query.FromErledigt != null) // AND TSK.DoneDate >= {edtSucheDoneDateVon}
                if (!"Invalid date".Equals(query.FromErledigt))
                    strQuery += " AND TSK.DoneDate >= '" + query.FromErledigt + fromTime + "'";

            if (query.ToErledigt != null) // AND TSK.DoneDate <= {edtSucheDoneDateBis}
                if (!"Invalid date".Equals(query.ToErledigt))
                    strQuery += " AND TSK.DoneDate <= '" + query.ToErledigt + toTime + "'";

            if (query.Fallnummer != null) // AND FAL.FaFallID = {edtSucheFallID}
                strQuery += " AND FAL.FaFallID =" + query.Fallnummer;

            //if (!string.IsNullOrEmpty(userId)) // AND USR.UserID = {edtSucheSAR.LookupID}
            //    strQuery += " AND USR.UserID =" + userId;

            if (query.IdOrganisationseinheit != null) // AND OUU.OrgUnitID = {edtSucheOrgUnit}
                strQuery += " AND OUU.OrgUnitID =" + query.IdOrganisationseinheit;

            if (query.IdLeistungsverantw != null) // AND LEI.FaLeistungID = {edtSucheLeistungID}
                strQuery += " AND LEI.FaLeistungID =" + query.IdLeistungsverantw;
            
            strQuery += " ORDER BY TSK.CreateDate DESC";

            var data = _dbConnection.QueryAsync<TablePendenzenItem>(string.Format(strQuery, userId), new { userId }).Result.AsList();
            return data;
        }
    }
}
