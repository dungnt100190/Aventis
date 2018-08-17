using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

using KiSS4.DB;
using KiSS4.Schnittstellen.Newod.DTO;

namespace KiSS4.Schnittstellen.Newod.Service
{
    public class NewodPendenzService
    {
        private int _anzahlTage;

        #region Methods

        public NewodPendenzService()
        {
            _anzahlTage = DBUtil.GetConfigInt(@"System\Pendenzen\Newod\NewodDatenMeldung\AnzahlTage", 10);
        }

        #region Public Methods

        public void InsertPendenz(int baPersonID, List<PropertyInfo> changedProperties)
        {
            List<FallLeistungUser> userIDs = GetZustaendigeSAR(baPersonID);
            string pendenzText = GetPendenzText(changedProperties);
            InsertPendenzForAllUsers(baPersonID, userIDs, pendenzText);
        }

        #endregion

        #region Private Methods

        private string GetPendenzText(List<PropertyInfo> changedProperties)
        {
            StringBuilder pendenzText = new StringBuilder();
            foreach (PropertyInfo prop in changedProperties)
            {
                pendenzText.AppendLine(string.Format(KissMsg.GetMLMessage("NewodPendenzService", "PendenzText", "Änderung {0}"), prop.Name));
            }
            return pendenzText.ToString();
        }

        private List<FallLeistungUser> GetZustaendigeSAR(int baPersonID)
        {
            SqlQuery qryLeistungUser = new SqlQuery();
            qryLeistungUser.Fill(@"IF EXISTS(SELECT 1 FROM FaLeistung WHERE BaPersonID = {0} AND GETDATE() BETWEEN DatumVon AND ISNULL(DatumBis, '99990101'))
                                   BEGIN
                                     SELECT DISTINCT UserID
                                     FROM FaLeistung LST
                                     WHERE BaPersonID = {0}
                                       AND GETDATE() BETWEEN LST.DatumVon AND ISNULL(LST.DatumBis, '99990101')
                                   END
                                   ELSE BEGIN
                                     SELECT DISTINCT UserID
                                     FROM BaPerson_Relation  REL
                                       INNER JOIN FaLeistung LST ON LST.BaPersonID IN (REL.BaPersonID_1, REL.BaPersonID_2)
                                                                AND GETDATE() BETWEEN LST.DatumVon AND ISNULL(LST.DatumBis, '99990101')
                                     WHERE {0} IN (BaPersonID_1, BaPersonID_2)

                                   END
                                   ", baPersonID);

            List<FallLeistungUser> users = new List<FallLeistungUser>();
            foreach (DataRow fallLeistungUser in qryLeistungUser.DataTable.Rows)
            {
                FallLeistungUser user = new FallLeistungUser((int)fallLeistungUser["UserID"]);
                users.Add(user);
            }
            return users;
        }

        private void InsertPendenz(int baPersonID, string pendenzText, FallLeistungUser user)
        {
            string jumptopath = String.Format("ClassName=FrmFall;ModulID=1;BaPersonID={0};", baPersonID);

            DateTime? expirationDate = _anzahlTage >= 0 ? DateTime.Today.AddDays(_anzahlTage) : null as DateTime?;

            DBUtil.ExecuteScalarSQLThrowingException(@"
                DECLARE @FaLeistungID INT;
                SELECT TOP 1 @FaLeistungID = LEI.FaLeistungID
                FROM dbo.FaLeistung LEI
                WHERE
                    LEI.FaFallID = {2}
                    AND (LEI.FaProzessCode = 200 OR LEI.FaProzessCode IS NULL)
                    AND LEI.ModulID = 2
                    AND (LEI.DatumBis IS NULL OR LEI.DatumBis >= GETDATE())
                    AND (LEI.DatumVon IS NULL OR LEI.DatumVon <= GETDATE())

                INSERT INTO XTask(
                    TaskTypeCode,
                    TaskStatusCode,
                    StartDate,
                    ExpirationDate,
                    Subject,
                    TaskDescription,
                    SenderID,
                    TaskSenderCode,
                    ReceiverID,
                    TaskReceiverCode,
                    BaPersonID,
                    FaFallID,
                    FaLeistungID,
                    JumpToPath)
                VALUES(
                    8,                                 --TaskType     8	Newod-Daten Meldung
                    1,                                 --TaskStatus   1	Pendent
                    GETDATE(),                         --StartDate
                    {4},                               --ExpirationDate
                    'Mutationsmeldung aus NEWOD',      --Subject
                    {0},                               --TaskDescription
                    NULL,                              --SenderID
                    4,                                 --TaskSenderCode
                    {1},                               --ReceiverID
                    1,                                 --TaskReceiverCode
                    {2},                               --BaPersonID
                    {2},                               --FaFallID
                    @FaLeistungID,                     --FaLeistungID
                    {3}                                --JumpToPath
                );", pendenzText, user.UserID, baPersonID, jumptopath, expirationDate);
        }

        private void InsertPendenzForAllUsers(int baPersonID, List<FallLeistungUser> users, string pendenzText)
        {
            foreach (FallLeistungUser user in users)
            {
                InsertPendenz(baPersonID, pendenzText, user);
            }
        }

        #endregion

        #endregion
    }
}