using System;
using System.Data;
using System.Threading;
using System.Web.Services.Protocols;

using log4net;
using log4net.Config;

using KiSS4.DB;
using KiSS4.Schnittstellen.Abacus.KACon.ODBC;
using KiSS4.Schnittstellen.Abacus.KlientenStammdaten;

namespace KiSS4.Schnittstellen.Abacus.KACon
{
    public class AbaDelegatorImpl : AbaDelegator
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The logger to use
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(AbaDelegatorImpl));

        /// <summary>
        /// The name of the mutex to use
        /// </summary>
        private static readonly String MUTEXNAME = "ch.diartis.KiSS.ALPI.Schnittstellen.Abacus.Mitarbeiter";

        #endregion

        #endregion

        #region Constructors

        static AbaDelegatorImpl()
        {
            XmlConfigurator.Configure();
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Returns a data set corresponding to the sqlString.
        /// Throws exception or child of it in case of error.
        /// </summary>
        /// <param name="techUser">Abacus user which is ODBC allowed</param>
        /// <param name="techPw">Pw of the techUser</param>
        /// <param name="techMandant">Mandant-> lohnmandant (technisch user)</param>
        /// <param name="oleUser">OLE user name</param>
        /// <param name="olePw">OLE user password</param>
        /// <param name="oleMandant">OLE MandantNr</param>
        /// <param name="sqlString">Select statement what we want the data from</param>
        /// <param name="abaPath">Folder of abacus data (eg: "C:\\abac")</param>
        /// <returns>Returns a data set corresponding to the sqlString</returns>
        public DataSet GetCoworkersWithSql(String techUser, String techPw, Int32 techMandant, String oleUser, String olePw, Int32 oleMandant, String sqlString, String abaPath)
        {
            // validate parameters
            if (techMandant < 1)
            {
                throw new ArgumentOutOfRangeException("techMandant", "Invalid value, cannot proceed.");
            }

            if (DBUtil.IsEmpty(techUser))
            {
                throw new ArgumentOutOfRangeException("techUser", "Invalid value, cannot proceed.");
            }

            if (DBUtil.IsEmpty(techPw))
            {
                throw new ArgumentOutOfRangeException("techPw", "Invalid value, cannot proceed.");
            }

            // log this call
            logger.Debug(String.Format("called: getCoworkersWithSql(techUser: {0}, techMandant: {1}, sqlString: {2}, abaPath: {3})", techUser, techMandant, sqlString, abaPath));

            //to get data in return
            DataSet dsresult = null;

            //mutex
            Boolean createdMutex = false;
            Mutex m = new Mutex(true, MUTEXNAME, out createdMutex);

            if (!createdMutex)
            {
                if (m.WaitOne())
                {
                }
            }

            logger.Debug(String.Format("Acquired mutex: '{0}'", MUTEXNAME));

            try
            {
                try
                {
                    // try to get data from abacus
                    dsresult = ODBCManager.GetAbacusLohnData(techUser, techPw, abaPath, techMandant, sqlString);

                    if (dsresult != null)
                    {
                        logger.Debug("looks like a valid data set!");
                    }
                    else
                    {
                        logger.Debug("unfortunately, dataset in return is null");
                    }
                }
                catch (SoapException soapEx)
                {
                    if (soapEx.Detail != null)
                    {
                        var detail = soapEx.Detail;
                        string soapMessage = detail.InnerText;

                        throw new KlientenStammdatenException(
                            string.Format("Login Failed. Error: {0}", soapMessage));
                    }
                }
                catch (Exception ex)
                {
                    //maybe the odbc driver is not installed
                    if (ex.Message.Contains("Object reference not set to an instance of an object"))
                    {
                        logger.Error(" --- !! this error happens when the abacus odbc driver is not installed or if the Abacus path is not ok (check it: '" + abaPath + "' ! --- ", ex);
                    }
                    else if (ex.Message.Contains("Invalid account name"))
                    {
                        logger.Debug("this happends when you were not logged first. this module tries to log on for you now.", ex);
                    }
                    else
                    {
                        logger.Error(ex);
                        throw ex;
                    }
                }

                this.cleanCoWorkerDataSet(ref dsresult);
                this.logResultSet(logger, dsresult);
            }
            catch (SoapException soapEx)
            {
                if (soapEx.Detail != null)
                {
                    var detail = soapEx.Detail;
                    string soapMessage = detail.InnerText;

                    throw new KlientenStammdatenException(
                        string.Format("Login Failed. Error: {0}", soapMessage));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                logger.Debug(String.Format("Release mutex: '{0}'", MUTEXNAME));
                m.ReleaseMutex();
            }

            return dsresult;
        }

        #endregion

        #region Private Methods

        private void cleanCoWorkerDataSet(ref DataSet ds)
        {
            //get rows of first table:
            if (ds != null)
            {
                //Iterate through tables of the data set
                DataTableCollection tables = ds.Tables;
                System.Collections.IEnumerator en = tables.GetEnumerator();

                while (en.MoveNext())
                {
                    //this is the first table. and the only one supposed to be given by sql statement on abacus
                    DataTable dt = (DataTable)en.Current;

                    //Iterate through rows of the table
                    Int32 newEmplNr = 0;
                    Int32 emplNrOfRowBefore = 0;

                    foreach (DataRow dr in dt.Rows)
                    {
                        //workaround 21.12.2007: sql statement on abacus data did not provide correct
                        //data so we had to make it less restrictive and we have to take only the first occurance
                        newEmplNr = Convert.ToInt32(dr["EMPL_NR"]);

                        if (newEmplNr == emplNrOfRowBefore)
                        {
                            //only the first is valid, the other one won't be found beause
                            //empl_nr is the find criteria
                            dr["EMPL_NR"] = 0;
                        }

                        emplNrOfRowBefore = newEmplNr;

                        //workaround 08.01.2008: sql statement on abacus data did not provide correct data
                        //so we had to ad a join on LPE table. because it was to slow, we did not
                        //put the LOHN_LPE.GB in the where clause. so with the outer left join
                        //we sometimes get an empty 'GB'. This one is filtered here by enabling
                        //the Empl_Nr on '0' so it is never find in further synchronisation and import processes.
                        if (dr["GB"].GetType().FullName == "System.DBNull")
                        {
                            dr["EMPL_NR"] = 0;
                        }

                        //workaround 09.01.2008: odbc driver seems to act differently on the test server as on my (daniel minder)
                        //dev computer. The fields 'SEX' and 'LANGUAGE_CODE' are supposed to have only 1 characters, but
                        //they come with 4 (example: SEX = 'MUTT' insteand of 'M', or 'FREC' instead of 'F'). But the
                        //first char seems all right always. But suddenly the error did not appear anymore.
                        //so I just give an error log in case such an error occurs.
                        if (dr["SEX"].GetType().FullName != "System.DBNull")
                        {
                            String sex = Convert.ToString(dr["SEX"]);
                            if (sex.Length > 1)
                            {
                                logger.Error("sex is longer than 1: '" + sex + "'. KiSS corrects it.");
                                dr["SEX"] = sex.Substring(0, 1);
                            }
                        }
                        if (dr["LANGUAGE_CODE"].GetType().FullName != "System.DBNull")
                        {
                            String lc = Convert.ToString(dr["LANGUAGE_CODE"]);
                            if (lc.Length > 1)
                            {
                                logger.Error("language code is longer than 1: '" + lc + "' KiSS corrects it.");
                                dr["LANGUAGE_CODE"] = lc.Substring(0, 1);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// logs each field of each row of each table in the data set with
        /// the debug method of the ILog (so is you don't want all that logging, just switch logging level)
        /// </summary>
        /// <param name="lg"></param>
        /// <param name="dsresult"></param>
        private void logResultSet(ILog lg, DataSet dsresult)
        {
            if (dsresult == null)
            {
                logger.Debug("dataset is null");

                // do not continue
                return;
            }

            //Iterate through tables of the data set
            DataTableCollection tables = dsresult.Tables;
            System.Collections.IEnumerator en = tables.GetEnumerator();

            while (en.MoveNext())
            {
                // this is one of the tables
                DataTable dt = (DataTable)en.Current;
                logger.Debug("   ----- yes, we have at least one table with '" + dt.Rows.Count + "' rows. ! name: '" + dt.TableName + "'");

                // Iterate throug columns of the table
                DataColumnCollection dc = dt.Columns;
                System.Collections.ArrayList columList = new System.Collections.ArrayList(dc.Count);
                System.Collections.IEnumerator ensub = dc.GetEnumerator();

                while (ensub.MoveNext())
                {
                    DataColumn dataColumn = (DataColumn)ensub.Current;
                    columList.Add(dataColumn.ColumnName);
                }

                //Iterate through rows of the table
                foreach (DataRow dr in dt.Rows)
                {
                    Int32 i = 0;

                    while (i < dr.ItemArray.Length)
                    {
                        logger.Debug("           +++++++++ value of field '" + i + "' (" + columList[i] + "): '" + dr[i].ToString() + "'. Type: '" + dr[i].GetType().FullName + "'.");
                        i++;
                    }

                    logger.Debug("shhhhh");
                }
            }
        }

        #endregion

        #endregion
    }
}