using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using KiSS4.DB;

namespace KiSS4.Pendenzen.Monitor
{
    public class PendenzProvider : IPendenzProvider
    {
        private static readonly log4net.ILog LOG = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region Fields and Properties

        private String SqlString;  
        protected List<IPendenz> pendenzen = new List<IPendenz>();

        public Int32 Count
        {
            get {
                lock (pendenzen)
                {
                    return pendenzen.Count;
                }
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PendenzProvider"/> class.
        /// </summary>
        public PendenzProvider()
        {
            SqlString = GetSQLStatement(0, 0);
        }

        public PendenzProvider(Int32 tasktype, Int32 taskstate)
        {
            SqlString = GetSQLStatement(tasktype, taskstate);
        }

        #endregion

        private String GetSQLStatement(Int32 tasktype, Int32 taskstate)
        {
            StringBuilder sqlstr = new StringBuilder();

            sqlstr.Insert(0, @"
                   SELECT TaskTypeCode, 
                          TaskStatusCode, 
                          CreateDate, 
                          StartDate, 
                          ExpirationDate, 
                          DoneDate, 
                          Subject, 
                          TaskDescription, 
                          SenderID, 
                          TaskSenderCode, 
                          ReceiverID, 
                          TaskReceiverCode, 
                          ResponseText, 
                          TaskResponseCode, 
                          FaFallID, 
                          FaLeistungID, 
                          BaPersonID, 
                          XTaskTS 
                   FROM dbo.XTask WITH (READUNCOMMITTED)");

            if (!tasktype.Equals(0) && !taskstate.Equals(0))
            {
                sqlstr.AppendLine("   WHERE TaskTypeCode = " + tasktype.ToString());
                sqlstr.AppendLine("   AND taskStatusCode = " + taskstate.ToString());
            }
            else if (tasktype.Equals(0) && !taskstate.Equals(0))
            {
                sqlstr.AppendLine("   WHERE taskStatusCode = " + taskstate.ToString());
            }
            else if (!tasktype.Equals(0) && taskstate.Equals(0))
            {
                sqlstr.AppendLine("   WHERE TaskTypeCode = " + tasktype.ToString());
            }

            return sqlstr.ToString();
        }

        public virtual void LookUp()
        {
            lock (pendenzen)
            {
                pendenzen.Clear();
                // Vorschlag
                try
                {
                    // Connection klonen, sonst steht KiSS trotz asynchron bei der ersten DB-Abfrage still...
                    SqlConnection connection = (SqlConnection)((ICloneable)Session.Connection).Clone();
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(SqlString, connection);
                    DataTable result = new DataTable();
                    adapter.Fill(result);
                    connection.Close();

                    foreach (DataRow row in result.Rows)
                    {
                        Pendenz pendenz = new Pendenz();
                        pendenz.Subject = row["Subject"].ToString();
                        pendenzen.Add(pendenz);
                    }
                }
                catch (Exception ex)
                {
                    // Eintrag ins Log.
                    LOG.ErrorFormat("Fehler in: [{0}]. Exception: [{1}]", GetType().FullName, ex.Message);

                    // Eintrag ins Log (Ansicht unter Anwendung/Newod Schnittstelle/Protokolle)
                    XLog.Create(GetType().FullName, LogLevel.ERROR, ex.Message);

                    return;
                }

                //SqlQuery qry = DBUtil.OpenSQL(SqlString);

                //foreach (DataRow row in qry.DataTable.Rows)
                //{
                //    Pendenz pendenz = new Pendenz();
                //    pendenz.Subject = row["Subject"].ToString();
                //    pendenzen.Add(pendenz);
                //}
            }
        }

        //public System.Collections.ArrayList<IPendenz> GetList()
        //{
        //    throw new Exception("The method or operation is not implemented.");
        //}

        #region IEnumerable Members

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"></see> object that can be used to iterate through the collection.
        /// </returns>
        public System.Collections.IEnumerator GetEnumerator()
        {
            foreach (IPendenz pendenz in pendenzen)
            {
                yield return pendenz;
            }
        }

        #endregion
    }
}
