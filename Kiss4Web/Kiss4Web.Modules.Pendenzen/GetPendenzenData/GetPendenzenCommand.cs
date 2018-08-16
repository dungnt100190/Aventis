namespace Kiss4Web.Modules.Pendenzen.GetPendenzenData
{
    public class GetPendenzenCommand
    {
        public const string GetPendenzen = @"
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
					TSK.XTaskTS,

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
					ReceiverEMail  = URX.EMail
					
			FROM	XTask	TSK
				LEFT JOIN vwUser           UTR ON UTR.UserID = TSK.SenderID AND TSK.TaskSenderCode = 1
				LEFT JOIN FaPendenzgruppe  GTR ON GTR.FaPendenzgruppeID = TSK.SenderID AND TSK.TaskSenderCode = 2
				LEFT JOIN vwUser           URX ON URX.UserID = TSK.ReceiverID AND TSK.TaskReceiverCode = 1
				LEFT JOIN FaPendenzgruppe  GRX ON GRX.FaPendenzgruppeID = TSK.ReceiverID AND TSK.TaskReceiverCode = 2
				
				LEFT JOIN FaLeistung       LEI ON LEI.FaLeistungID = TSK.FaLeistungID
				LEFT JOIN FaFall           FAL ON FAL.FaFallID = IsNull(LEI.FaFallID, TSK.FaFallID)
				LEFT JOIN BaPerson         PRS ON PRS.BaPersonID = IsNull(LEI.BaPersonID, FAL.BaPersonID)
				LEFT JOIN vwUser           USR ON USR.UserID = IsNull(LEI.UserID, FAL.UserID)
				LEFT JOIN XOrgUnit_User    OUU ON OUU.UserID = USR.UserID
				                              AND OUU.OrgUnitMemberCode = 2 --2: Mitglied
				LEFT JOIN XModul           MOD ON MOD.ModulID = LEI.ModulID
				
				LEFT JOIN vwPersonSimple   PRB ON PRB.BaPersonID = TSK.BaPersonID";

        public const string FilterPendenzen_11 = @" 
			((TaskReceiverCode = 2 AND EXISTS (SELECT TOP 1 1 FROM dbo.FaPendenzgruppe_User WHERE UserID = @userId AND FaPendenzgruppeID = ReceiverID)) OR (TaskReceiverCode = 1 AND ReceiverID = @userId)) AND TaskStatusCode IN (1, 2) AND ExpirationDate <= GetDate()";

        public const string FilterPendenzen_12 = @"
			((TaskReceiverCode = 2 AND EXISTS (SELECT TOP 1 1 FROM dbo.FaPendenzgruppe_User WHERE UserID = @userId AND FaPendenzgruppeID = ReceiverID)) OR (TaskReceiverCode = 1 AND ReceiverID = @userId)) AND TaskStatusCode IN (1, 2)";

        public const string FilterPendenzen_13 = @"
			TaskReceiverCode = 1 AND ReceiverID = @userId AND TaskStatusCode IN (2)";

        public const string FilterPendenzen_14 = @"
			((TaskReceiverCode = 2 AND EXISTS (SELECT TOP 1 1 FROM dbo.FaPendenzgruppe_User WHERE UserID = @userId AND FaPendenzgruppeID = ReceiverID)) OR (TaskReceiverCode = 1 AND ReceiverID = @userId)) AND TaskSenderCode = 1 AND SenderID = @userId AND TaskStatusCode IN (1, 2)";

        public const string FilterPendenzen_15 = @"
			((TaskReceiverCode = 2 AND EXISTS (SELECT TOP 1 1 FROM dbo.FaPendenzgruppe_User WHERE UserID = @userId AND FaPendenzgruppeID = ReceiverID)) OR (TaskReceiverCode = 1 AND ReceiverID = @userId)) AND (TaskSenderCode = 2 OR SenderID <> @userId) AND TaskStatusCode IN (1, 2)";

        public const string FilterPendenzen_16 = @"
			((TaskReceiverCode = 2 AND EXISTS (SELECT TOP 1 1 FROM dbo.FaPendenzgruppe_User WHERE UserID = @userId AND FaPendenzgruppeID = ReceiverID)) OR (TaskReceiverCode = 1 AND ReceiverID = @userId)) AND TaskStatusCode IN (1, 2) AND TaskTypeCode = 2";

        public const string FilterPendenzen_17 = @"
			((TaskReceiverCode = 2 AND EXISTS (SELECT TOP 1 1 FROM FaPendenzgruppe_User WHERE UserID = @userId AND FaPendenzgruppeID = ReceiverID)) AND TaskStatusCode IN (1, 2))";

        public const string FilterPendenzen_18 = @"
			(((TaskReceiverCode = 2 AND EXISTS (SELECT TOP 1 1 FROM dbo.FaPendenzgruppe_User WHERE UserID = @userId AND FaPendenzgruppeID = ReceiverID)) OR (TaskReceiverCode = 1 AND ReceiverID = @userId)) AND TaskStatusCode IN (3))";

        public const string FilterPendenzen_21 = @"
			TaskSenderCode = 1 AND SenderID = @userId AND TaskStatusCode IN (1, 2) AND ExpirationDate <= GetDate()";

        public const string FilterPendenzen_22 = @"
			TaskSenderCode = 1 AND SenderID = @userId AND TaskStatusCode IN (1, 2)";

        public const string FilterPendenzen_23 = @"
			TaskSenderCode = 1 AND SenderID = @userId AND TaskStatusCode IN (1, 2) AND TaskTypeCode <> 2";

        public const string FilterPendenzen_24 = @"
			TaskSenderCode = 1 AND SenderID = @userId AND TaskStatusCode IN (1, 2) AND TaskTypeCode = 2";
        public const string FilterPendenzen_25 = @"
			TaskSenderCode = 1 AND SenderID = @userId AND TaskStatusCode IN (1, 2) AND TaskReceiverCode = 2";

        public const string FilterPendenzen_26 = @"
			(TaskSenderCode = 1 AND SenderID = @userId AND TaskStatusCode IN (3))";
    }
}
