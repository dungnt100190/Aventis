using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using KiSS4.Common;
using KiSS4.DB;

using KiSS.DBScheme;

namespace KiSS4.Sozialhilfe.ZH
{
    #region Enumerations

    public enum BewilligungTyp
    {
        Finanzplan = 1,
        Position = 2
    }

    #endregion

    public partial class DlgPositionBewilligungAnfragen : DlgBewilligungAnfragen
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly BewilligungTyp _bewilligungTyp;
        private readonly int? _bgBudgetID;
        private readonly int? _bgFinanzplanID;
        private readonly string _herkunftClassName;

        private const string CLASSNAME = "DlgBewilligungAnfragen";

        #endregion

        #region Private Fields

        private int? _bgPositionID;

        #endregion

        #endregion

        #region Constructors

        public DlgPositionBewilligungAnfragen()
        {
            InitializeComponent();
        }

        public DlgPositionBewilligungAnfragen(int bgFinanzplanID, bool openTransaction)
            : base(openTransaction)
        {
            InitializeComponent();
            _bewilligungTyp = BewilligungTyp.Finanzplan;
            _bgFinanzplanID = bgFinanzplanID;
        }

        public DlgPositionBewilligungAnfragen(int bgPositionID, int bgFinanzplanID, int bgBudgetID, string herkunftClassName, bool
            openTransaction)
            : base(openTransaction)
        {
            InitializeComponent();
            _bewilligungTyp = BewilligungTyp.Position;
            _bgPositionID = bgPositionID;
            _bgFinanzplanID = bgFinanzplanID;
            _bgBudgetID = bgBudgetID;
            _herkunftClassName = herkunftClassName;

            InitSammelposition();
        }

        #endregion

        #region EventHandlers

        private void btnDetails_Click(object sender, EventArgs e)
        {
            DlgWhWeitereKOA dlg = new DlgWhWeitereKOA(_bgPositionID ?? 0, this.Name, 0, false);  //AllowEdit = false
            dlg.ShowDialog(this);
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void DetermineLeistungUndLeistungsverantwortlicher(out int userID, out string nameVorname)
        {
            SqlQuery qryLeistung;

            if(_bgFinanzplanID > 0)
            {
                qryLeistung = 
                    DBUtil.OpenSQL(@"
                        SELECT TOP 1
                          LEI.UserID,
                          Name = USR.NameVorname
                        FROM dbo.BgFinanzplan       FPL WITH (READUNCOMMITTED)
                          INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = FPL.FaLeistungID
                          INNER JOIN dbo.vwUser     USR WITH (READUNCOMMITTED) ON USR.UserID = LEI.UserID
                        WHERE FPL.BgFinanzplanID = {0};",
                        _bgFinanzplanID);
            }
            else
            {
                qryLeistung =
                    DBUtil.OpenSQL(@"
                        SELECT TOP 1
                          LEI.UserID,
                          Name = USR.NameVorname
                        FROM dbo.BgPosition           POS WITH (READUNCOMMITTED)
                          INNER JOIN dbo.BgBudget     BDG WITH (READUNCOMMITTED) ON BDG.BgBudgetID = POS.BgBudgetID
                          INNER JOIN dbo.BgFinanzplan FPL WITH (READUNCOMMITTED) ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
                          INNER JOIN dbo.FaLeistung   LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = FPL.FaLeistungID
                          INNER JOIN dbo.vwUser       USR WITH (READUNCOMMITTED) ON USR.UserID = LEI.UserID
                        WHERE POS.BgPositionID = {0};",
                        _bgPositionID);
            }

            if (qryLeistung.IsEmpty)
            {
                throw new KissErrorException(
                    KissMsg.GetMLMessage(
                        this.Name,
                        "LVKonnteNichtErmitteltWerden",
                        "Der Leistungsverantwortliche konnte nicht ermittelt werden"));
            }

            userID = Utils.ConvertToInt(qryLeistung[DBO.FaLeistung.UserID]);
            nameVorname = Utils.ConvertToString(qryLeistung["Name"]);
        }

        protected override bool HasUserKompetenz(int userID)
        {
            if (_bgPositionID.HasValue)
            {
                //Determine based on BgPositionID
                var hasPermission = DBUtil.ExecuteScalarSQL(@"
                    select dbo.fnWhPosition_Permission({0},{1})",
                    _bgPositionID.Value,
                    userID) as bool?;

                return hasPermission ?? false;
            }

            if (_bgBudgetID.HasValue)
            {
                //gemäss CtlWhBudget Zeile 437 (in btnBudgetGruen_Click(...)): alle dürfen grün stellen per 23.06.2008
                return true;
            }

            if (_bgFinanzplanID.HasValue)
            {
                var qry = DBUtil.OpenSQL("EXECUTE spWhFinanzPlan_Check {0}, {1}", _bgFinanzplanID.Value, userID);
                return qry.DataTable.Select("Typ = 1").Length == 0;  //if no warnings occur, the user has enough competence
            }

            return false;
        }

        protected override void PrepareBewilligungQuery(SqlQuery query, out string tableName)
        {
            query.Fill("SELECT TOP 0 * FROM dbo.BgBewilligung WITH (READUNCOMMITTED)");
            query.Insert(query.TableName);
            query[DBO.BgBewilligung.BgFinanzplanID] = _bgFinanzplanID;
            query[DBO.BgBewilligung.BgBudgetID] = _bgBudgetID;
            query[DBO.BgBewilligung.BgPositionID] = _bgPositionID;
            query["ClassName"] = _herkunftClassName;
            tableName = "BgBewilligung";
        }

        protected override void SetValuesInBewilligungQuery(SqlQuery query)
        {
            query["UserID"] = _userIdLV;
            query["UserID_Erstellt"] = Session.User.UserID;
            query["UserID_An"] = _userIdSelected;
            query["Datum"] = DateTime.Now;
            query["ClassName"] = _herkunftClassName;

            query["BgBewilligungCode"] = 1; // Anfrage zur Bewilligung
        }

        #endregion

        #region Private Methods

        private void InitSammelposition()
        {
            //Hauptposition, Anzahl/Total bestimmen
            SqlQuery qry2 = DBUtil.OpenSQL(@"
                DECLARE @BgPositionID INT;

                -- von Detail auf Hauptposition wechseln
                SELECT @BgPositionID = ISNULL(BgPositionID_Parent, BgPositionID)
                FROM dbo.BgPosition WITH (READUNCOMMITTED)
                WHERE BgPositionID = {0}
                  AND BgKategorieCode IN (100, 101);

                SELECT BgPositionID = @BgPositionID,
                       Anzahl       = COUNT(1),
                       AnzahlZL     = SUM(CASE WHEN BgKategorieCode = 100 THEN 1 ELSE 0 END),
                       AnzahlEZ     = SUM(CASE WHEN BgKategorieCode = 101 THEN 1 ELSE 0 END),
                       Total        = SUM(Betrag),
                       TotalZL      = SUM(CASE WHEN BgKategorieCode = 100 THEN Betrag ELSE 0 END),
                       TotalEZ      = SUM(CASE WHEN BgKategorieCode = 101 THEN Betrag ELSE 0 END)
                FROM dbo.BgPosition WITH (READUNCOmMITTED)
                WHERE BgPositionID = @BgPositionID
                   OR (BgPositionID_Parent = @BgPositionID
                     AND BgKategorieCode IN (100, 101));",
                _bgPositionID);

            if (qry2.Count > 0 && (int)qry2["Anzahl"] > 1)
            {
                _bgPositionID = (int)qry2["BgPositionID"];
                if ((int)qry2["AnzahlEZ"] > 0)
                {
                    lblSammelposition.Text = string.Format(
                        "{0} Positionen, Total {1:n2} CHF\r\n" +
                        "- {2} ZL: {3:n2} CHF\r\n" +
                        "- {4} EZ: {5:n2} CHF",
                        qry2["Anzahl"], qry2["Total"],
                        qry2["AnzahlZL"], qry2["TotalZL"],
                        qry2["AnzahlEZ"], qry2["TotalEZ"]);
                }
                else
                {
                    lblSammelposition.Text = string.Format("{0} Positionen, Total {1:n2} CHF", qry2["Anzahl"], qry2["Total"]);
                }

                lblSammelposition.Visible = true;
                btnDetails.Visible = true;
            }
        }

        #endregion

        #endregion
    }
}