using System;

using KiSS4.DB;

namespace KiSS4.Common.PI
{
    /// <summary>
    /// Methods and Information needed for interventions in "Entlastungsdienst".
    /// </summary>
    public class EdEinsatzHelper : EinsatzHelper
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string BA_PERSON_ID = "BaPersonID";
        private const string EINSATZ_ID = "EdEinsatzID";
        private const string FA_LEISTUNG_ID = "FaLeistungID";
        private const string USER_ID = "UserID";

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Creates the Helper class and passes the parameter to the base constructor.
        /// </summary>
        /// <param name="daten">Transfer object which holds all necessary values</param>
        public EdEinsatzHelper(EinsatzDTO daten)
            : base(daten)
        {
            // set the correct Ed values for the setter methods
            _tableNameOfActiveQuery = "EdEinsatz";
            _einsatzTypeName = "EdTyp";
            _contextNameForBericht = "ED_Einsatz_Bestaetigung";
            _dataMemberNameForMitarbeiterLookUpEdit = "XUser_EdEinsatzvereinbarungID";
            _lovNameForEinsatzTypLookUpEdit = "EdTyp";
            _textForEinsatzTypLabel = KissMsg.GetMLMessage("EdEinsatzHelper", "TypED", "Typ ED");
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
                case "EDEINSATZID":
                    // check if we have an entry
                    if (qryEinsatz.Count < 1)
                    {
                        return -1;
                    }

                    return qryEinsatz[EINSATZ_ID];

                case "EDEINSATZVEREINBARUNGID":
                    // get id of EdEinsatzvereinbarung with same FaLeistungID (FaLeistungID depends on AccessMode)
                    return FaUtils.GetEdEinsatzvereinbarungID(Convert.ToInt32(ContextValueByModul(FA_LEISTUNG_ID, qryEinsatz, searchTypeEditValue)));

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

                case "USERIDOFED":
                    if (_daten.CurrentAccessMode == AccessMode.User)
                    {
                        // get ed-user from filter
                        return _daten.UserId;
                    }

                    // else: get current selected ed-user
                    if (DBUtil.IsEmpty(qryEinsatz[USER_ID]))
                    {
                        // no ed-user selected
                        return -1;
                    }

                    // else: return current selected ed-user
                    return Convert.ToInt32(qryEinsatz[USER_ID]);

                case "SEARCHTYPED":
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

                SELECT [Code]    = UEV.XUser_EdEinsatzvereinbarungID,
                       [Text]    = dbo.fnGetLastFirstName(UEV.UserID, NULL, NULL),
                       [UserID]  = UEV.UserID,
                       [Telefon] = dbo.fnEdGetEntlasterKontakt(UEV.UserID, 1, 0, @LanguageCode)
                FROM dbo.EdEinsatzvereinbarung               EVB WITH (READUNCOMMITTED)
                  INNER JOIN dbo.XUser_EdEinsatzvereinbarung UEV WITH (READUNCOMMITTED) ON EVB.EdEinsatzvereinbarungID = UEV.EdEinsatzvereinbarungID
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

                SELECT EDE.*,
                       BeginnDatum        = EDE.Beginn,
                       BeginnZeit         = EDE.Beginn,
                       EndeDatum          = EDE.Ende,
                       EndeZeit           = EDE.Ende,
                       Typ                = dbo.fnGetLOVMLText('EdTyp', EDE.TypCode, @LanguageCode),
                       Status             = dbo.fnGetLOVMLText('EinsatzStatus', EDE.StatusCode, @LanguageCode),
                       UserID             = UEV.UserID,
                       Mitarbeiter        = dbo.fnGetLastFirstName(UEV.UserID, NULL, NULL),
                       MitarbeiterTelefon = dbo.fnEdGetEntlasterKontakt(UEV.UserID, 1, 0, @LanguageCode),
                       BaPersonID         = LEI.BaPersonID,
                       Klient             = dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname) + ISNULL(' (' + CONVERT(VARCHAR, PRS.BaPersonID) + ')', '')
                FROM dbo.EdEinsatz                           EDE WITH (READUNCOMMITTED)
                  INNER JOIN dbo.FaLeistung                  LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = EDE.FaLeistungID
                  INNER JOIN dbo.XUser_EdEinsatzvereinbarung UEV WITH (READUNCOMMITTED) ON EDE.XUser_EdEinsatzvereinbarungID = UEV.XUser_EdEinsatzvereinbarungID
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
                        --- AND dbo.fnDateOf(EDE.Beginn) >= {edtSucheDatumVon}
                        --- AND dbo.fnDateOf(EDE.Ende)   <= {edtSucheDatumBis}
                        --- AND EDE.TypCode               = {edtSucheTyp}
                        --- AND EDE.StatusCode            = {edtSucheStatus}
                        --- AND UEV.UserID                = {edtSucheMitarbeiter}";
                    break;

                case AccessMode.Person:     // person
                    // create where
                    sqlWhere = string.Format(@"
                        WHERE LEI.BaPersonID = {0} AND
                              dbo.fnDateOf(EDE.Beginn) >= {1} AND
                              dbo.fnDateOf(EDE.Ende)   <= {2} AND
                              ({3} < 0 OR EDE.TypCode = {3})", _daten.BaPersonID, DBUtil.SqlLiteral(_daten.DatumVon), DBUtil.SqlLiteral(_daten.DatumBis), _daten.EinsatzTyp);
                    break;

                case AccessMode.User:       // user
                    // create where
                    sqlWhere = string.Format(@"
                        WHERE UEV.UserID = {0} AND
                              dbo.fnDateOf(EDE.Beginn) >= {1} AND
                              dbo.fnDateOf(EDE.Ende)   <= {2} AND
                              ({3} < 0 OR EDE.TypCode = {3})", _daten.UserId, DBUtil.SqlLiteral(_daten.DatumVon), DBUtil.SqlLiteral(_daten.DatumBis), _daten.EinsatzTyp);
                    break;

                default:
                    // this access mode is not supported
                    throw new NotImplementedException("The given AccessMode is not supported and therefore cannot be handled.");
            }

            // combine select with where and order by, return sql
            return string.Format(@"
                {0}
                {1}
                ORDER BY Klient, EDE.Beginn, EDE.Ende", sqlStatement, sqlWhere);
        }

        #endregion

        #endregion
    }
}