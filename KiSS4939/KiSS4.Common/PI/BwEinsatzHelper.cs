using System;

using KiSS4.DB;

namespace KiSS4.Common.PI
{
    /// <summary>
    /// Methods and Information needed for interventions in "Begleitetes Wohnen".
    /// </summary>
    public class BwEinsatzHelper : EinsatzHelper
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string BA_PERSON_ID = "BaPersonID";
        private const string EINSATZ_ID = "BwEinsatzID";
        private const string FA_LEISTUNG_ID = "FaLeistungID";
        private const string USER_ID = "UserID";

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Creates the Helper class and passes the parameter to the base constructor.
        /// </summary>
        /// <param name="daten">Transfer object which holds all necessary values</param>
        public BwEinsatzHelper(EinsatzDTO daten)
            : base(daten)
        {
            // set the correct Bw values for the setter methods
            _tableNameOfActiveQuery = "BwEinsatz";
            _einsatzTypeName = "BwTyp";
            _contextNameForBericht = "BW_Einsatz_Bestaetigung";
            _dataMemberNameForMitarbeiterLookUpEdit = "XUser_BwEinsatzvereinbarungID";
            _lovNameForEinsatzTypLookUpEdit = "BwTyp";
            _textForEinsatzTypLabel = KissMsg.GetMLMessage("BwEinsatzHelper", "TypBW", "Typ BW");
            _captionAndFieldNameForEinsatzIDColumn = EINSATZ_ID;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get the primary key id column of the table to use
        /// </summary>
        public override string EinsatzID
        {
            get { return EINSATZ_ID; }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Get the context value by module
        /// </summary>
        /// <param name="fieldName">The name of the field to get information from</param>
        /// <param name="qryEinsatz">The SqlQuery which contains the data</param>
        /// <param name="searchTypeEditValue">The search type editvalue</param>
        /// <returns>The requested data or the fieldName if none found</returns>
        public override object ContextValueByModul(string fieldName, SqlQuery qryEinsatz, int searchTypeEditValue)
        {
            switch (fieldName.ToUpper())
            {
                case "BWEINSATZID":
                    // check if we have an entry
                    if (qryEinsatz.Count < 1)
                    {
                        return -1;
                    }

                    return qryEinsatz[EINSATZ_ID];

                case "BWEINSATZVEREINBARUNGID":
                    // get id of EdEinsatzvereinbarung with same FaLeistungID (FaLeistungID depends on AccessMode)
                    return FaUtils.GetBwEinsatzvereinbarungID(Convert.ToInt32(ContextValueByModul(FA_LEISTUNG_ID, qryEinsatz, searchTypeEditValue)));

                case "FALEISTUNGID":
                    // depending on current access mode
                    if (_daten.CurrentAccessMode == AccessMode.Leistung)
                    {
                        // get leistung from Init()-parameter
                        return _daten.FaLeistungID;
                    }

                    // else: get data from current entry
                    return DBUtil.IsEmpty(qryEinsatz[FA_LEISTUNG_ID]) ? -1 : Convert.ToInt32(qryEinsatz[FA_LEISTUNG_ID]);

                case "BAPERSONID":
                    // check if we have an entry
                    if (qryEinsatz.Count < 1)
                    {
                        return -1;
                    }

                    return qryEinsatz[BA_PERSON_ID];

                case "USERIDOFBW":
                    if (_daten.CurrentAccessMode == AccessMode.User)
                    {
                        // get bw-user from filter
                        return _daten.UserId;
                    }

                    // else: get current selected bw-user
                    if (DBUtil.IsEmpty(qryEinsatz[USER_ID]))
                    {
                        // no bw-user selected
                        return -1;
                    }

                    // else: return current selected bw-user
                    return Convert.ToInt32(qryEinsatz[USER_ID]);

                case "SEARCHTYPBW":
                    // depending on current access mode
                    if (_daten.CurrentAccessMode == AccessMode.Leistung)
                    {
                        // check if we have a search-type and return value
                        return searchTypeEditValue;
                    }

                    // else: return search-value from Init()-parameter
                    return _daten.EinsatzTyp;
            }

            return fieldName;
        }

        /// <summary>
        /// Get the lookup SqlQuery for searching users
        /// </summary>
        /// <returns>The SqlQuery containing the requested data</returns>
        public override SqlQuery GetMitarbeiterLookupQuery()
        {
            // get KS orgunits
            SqlQuery qryMA = DBUtil.OpenSQL(@"
                DECLARE @FaLeistungID INT
                DECLARE @LanguageCode INT

                SET @FaLeistungID = {0}
                SET @LanguageCode = {1}

                SELECT [Code]    = NULL,
                       [Text]    = '',
                       [UserID]  = NULL,
                       [Telefon] = NULL

                UNION

                SELECT [Code]    = UEV.XUser_BwEinsatzvereinbarungID,
                       [Text]    = dbo.fnGetLastFirstName(UEV.UserID, NULL, NULL),
                       [UserID]  = UEV.UserID,
                       [Telefon] = dbo.fnEdGetEntlasterKontakt(UEV.UserID, 1, 0, @LanguageCode)
                FROM dbo.BwEinsatzvereinbarung               EVB WITH (READUNCOMMITTED)
                  INNER JOIN dbo.XUser_BwEinsatzvereinbarung UEV WITH (READUNCOMMITTED) ON EVB.BwEinsatzvereinbarungID = UEV.BwEinsatzvereinbarungID
                WHERE EVB.FaLeistungID = @FaLeistungID
                ORDER BY [Text], [Code]", _daten.FaLeistungID, Session.User.LanguageCode);

            return qryMA;
        }

        /// <summary>
        /// Get the sql statement used for getting the main data from the database depending on current accessmode
        /// </summary>
        /// <returns>The sql statement for getting the data</returns>
        public override string GetSqlStatement()
        {
            // prepare vars for sql-statement
            string sqlStatement = string.Format(@"
                DECLARE @LanguageCode INT
                SET @LanguageCode = ISNULL({0}, 1)

                SELECT BWE.*,
                       BeginnDatum        = BWE.Beginn,
                       BeginnZeit         = BWE.Beginn,
                       EndeDatum          = BWE.Ende,
                       EndeZeit           = BWE.Ende,
                       Typ                = dbo.fnGetLOVMLText('BwTyp', BWE.TypCode, @LanguageCode),
                       Status             = dbo.fnGetLOVMLText('EinsatzStatus', BWE.StatusCode, @LanguageCode),
                       UserID             = UEV.UserID,
                       Mitarbeiter        = dbo.fnGetLastFirstName(UEV.UserID, NULL, NULL),
                       MitarbeiterTelefon = dbo.fnEdGetEntlasterKontakt(UEV.UserID, 1, 0, @LanguageCode),
                       BaPersonID         = LEI.BaPersonID,
                       Klient             = dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname) + ISNULL(' (' + CONVERT(VARCHAR, PRS.BaPersonID) + ')', '')
                FROM dbo.BwEinsatz                           BWE WITH (READUNCOMMITTED)
                  INNER JOIN dbo.FaLeistung                  LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = BWE.FaLeistungID
                  INNER JOIN dbo.XUser_BwEinsatzvereinbarung UEV WITH (READUNCOMMITTED) ON BWE.XUser_BwEinsatzvereinbarungID = UEV.XUser_BwEinsatzvereinbarungID
                  INNER JOIN dbo.BaPerson                    PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = LEI.BaPersonID", Session.User.LanguageCode);

            string sqlWhere;

            // set sql-statement where clause depending on current accessmode
            switch (_daten.CurrentAccessMode)
            {
                case AccessMode.Leistung:   // leistung
                    // create where
                    sqlWhere = string.Format(@"
                        WHERE LEI.FaLeistungID = {0}", _daten.FaLeistungID);

                    // append search-criteria
                    sqlWhere += @"
                        --- AND dbo.fnDateOf(BWE.Beginn) >= {edtSucheDatumVon}
                        --- AND dbo.fnDateOf(BWE.Ende)   <= {edtSucheDatumBis}
                        --- AND BWE.TypCode               = {edtSucheTyp}
                        --- AND BWE.StatusCode            = {edtSucheStatus}
                        --- AND UEV.UserID                = {edtSucheMitarbeiter}";
                    break;

                case AccessMode.Person:     // person
                    // create where
                    sqlWhere = string.Format(@"
                        WHERE LEI.BaPersonID = {0} AND
                              dbo.fnDateOf(BWE.Beginn) >= {1} AND
                              dbo.fnDateOf(BWE.Ende)   <= {2} AND
                              ({3} < 0 OR BWE.TypCode = {3})", _daten.BaPersonID,
                                                               DBUtil.SqlLiteral(_daten.DatumVon),
                                                               DBUtil.SqlLiteral(_daten.DatumBis),
                                                               _daten.EinsatzTyp);
                    break;

                case AccessMode.User:       // user
                    // create where
                    sqlWhere = string.Format(@"
                        WHERE UEV.UserID = {0} AND
                              dbo.fnDateOf(BWE.Beginn) >= {1} AND
                              dbo.fnDateOf(BWE.Ende)   <= {2} AND
                              ({3} < 0 OR BWE.TypCode = {3})", _daten.UserId,
                                                               DBUtil.SqlLiteral(_daten.DatumVon),
                                                               DBUtil.SqlLiteral(_daten.DatumBis),
                                                               _daten.EinsatzTyp);
                    break;

                default:
                    // this access mode is not supported
                    throw new NotImplementedException("The given AccessMode is not supported and therefore cannot be handled.");
            }

            // combine select with where and order by, return sql
            return string.Format(@"
                {0}
                {1}
                ORDER BY Klient, BWE.Beginn, BWE.Ende", sqlStatement, sqlWhere);
        }

        #endregion

        #endregion
    }
}