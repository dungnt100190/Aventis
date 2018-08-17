using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

namespace KiSS4.Query
{
    public partial class CtlQueryKaBetriebeAdressen : KissQueryControl
    {
        #region Constructors

        public CtlQueryKaBetriebeAdressen()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void CtlQueryKaBetriebeAdressen_Load(object sender, EventArgs e)
        {
            edtSucheStatus.LoadQuery(DBUtil.OpenSQL(@"
                    SELECT  Code = NULL, Text = ''
                    UNION ALL
                    SELECT  1, 'Aktiv'
                    UNION ALL
                    SELECT  0, 'Inaktiv'"));

            edtSucheEinsatzplatz.LoadQuery(DBUtil.OpenSQL(@"
                    SELECT Code = NULL, Text = ''
                    UNION ALL
                    SELECT 1, 'mit Einsatzplatz'
                    UNION ALL
                    SELECT 0, 'ohne Einsatzplatz'"));

            qryQuery.SelectStatement = GetBetriebQuery();
            qryQuery.AfterFill += new EventHandler(qryQuery_AfterFill);

            EnableDisableKaProgramm();
        }

        private void btnGeheZuBetrieb_Click(object sender, EventArgs e)
        {
            JumpToBetrieb();
        }

        private void edtSucheEinsatzplatz_EditValueChanged(object sender, System.EventArgs e)
        {
            EnableDisableKaProgramm();
        }

        private void qryQuery_AfterFill(object sender, EventArgs e)
        {
            KissRTFEdit rtfEdit = new KissRTFEdit();

            if (qryQuery.Count > 0)
            {
                foreach (DataRow row in qryQuery.DataTable.Rows)
                {
                    rtfEdit.EditValue = row[DBO.KaBetrieb.Bemerkung];
                    row[DBO.KaBetrieb.Bemerkung] = rtfEdit.Text;
                }

            }
        }

        #endregion

        #region Methods

        #region Private Static Methods

        private static string GetBetriebQuery()
        {
            string qry = string.Format(@"
                DECLARE @BetriebAktiv bit, @MitEinsatzplatz bit, @Charakter int, @Programm int, @LanguageCode int;

                SET @LanguageCode = {0};
                SET @BetriebAktiv = NULL;
                --- SET @BetriebAktiv = {1}

                SET @MitEinsatzplatz = NULL;
                --- SET @MitEinsatzplatz = {2}

                SET @Charakter = NULL;
                --- SET @Charakter = {3}

                SET @Programm = NULL;
                --- SET @Programm = {4}

                SELECT
                  [Name Betrieb] = BTR.BetriebName,
                  Anrede = CASE WHEN BTK.GeschlechtCode = 1 THEN 'Herr' WHEN BTK.GeschlechtCode = 2 THEN 'Frau' ELSE '' END,
                  Name = ISNULL(BTK.Name, ''),
                  Vorname = ISNULL(BTK.Vorname, ''),
                  Zusatz = CASE WHEN BTK.UseZusatzadresse = 1
                             THEN (SELECT Zusatz FROM BaAdresse WHERE KaBetriebKontaktID = BTK.KaBetriebKontaktID)
                             ELSE (SELECT Zusatz FROM BaAdresse WHERE KaBetriebID = BTR.KaBetriebID)
                           END,
                  [Strasse/Nr.] = CASE WHEN BTK.UseZusatzadresse = 1
                                    THEN (SELECT Strasse +' '+HausNr FROM BaAdresse WHERE KaBetriebKontaktID = BTK.KaBetriebKontaktID)
                                    ELSE (SELECT Strasse +' '+HausNr FROM BaAdresse WHERE KaBetriebID = BTR.KaBetriebID)
                                  END,
                  PLZ = CASE WHEN BTK.UseZusatzadresse = 1
                          THEN (SELECT PLZ FROM BaAdresse WHERE KaBetriebKontaktID = BTK.KaBetriebKontaktID)
                          ELSE (SELECT PLZ FROM BaAdresse WHERE KaBetriebID = BTR.KaBetriebID)
                        END,
                  Ort = CASE WHEN BTK.UseZusatzadresse = 1
                          THEN (SELECT Ort FROM BaAdresse WHERE KaBetriebKontaktID = BTK.KaBetriebKontaktID AND BTK.Aktiv = 1)
                          ELSE (SELECT Ort FROM BaAdresse WHERE KaBetriebID = BTR.KaBetriebID)
                        END,
                  [Telefon Betrieb] = BTR.Telefon,
                  Charakter = dbo.fnLOVMLText('KaBetriebCharakter', BTR.CharakterCode, @LanguageCode),
                  [Teilbetrieb von] = (SELECT SUB.BetriebName FROM KaBetrieb SUB WHERE BTR.TeilbetriebID = SUB.KaBetriebID),
                  BTR.Aktiv,
                  [In Ausbild. Verb.] = ISNULL(BTR.InAusbildungsverbund, CONVERT(bit,0)),
                  [KA Programm] = CASE WHEN @Programm IS NOT NULL AND @MitEinsatzplatz = 1 THEN COUNT(EPL.KaProgrammCode) ELSE COUNT(EPL.KaEinsatzplatzID) END,
                  BTR.Bemerkung,
                  KaBetriebID$ = BTR.KaBetriebID
                FROM KaBetrieb BTR
                  LEFT JOIN KaEinsatzplatz EPL ON EPL.KaBetriebID = BTR.KaBetriebID
                  LEFT JOIN KaBetriebKontakt BTK ON BTK.KaBetriebID = BTR.KaBetriebID
                WHERE 1 = 1
                  AND (@BetriebAktiv IS NULL OR BTR.Aktiv = @BetriebAktiv)
                  AND (@MitEinsatzplatz IS NULL OR (@MitEinsatzplatz = 0 AND EPL.KaEinsatzplatzID IS NULL) OR (@MitEinsatzplatz = 1 AND EPL.KaEinsatzplatzID IS NOT NULL))
                  AND (@Charakter IS NULL OR BTR.CharakterCode = @Charakter)
                  AND (@Programm IS NULL OR (@MitEinsatzplatz IS NULL OR @MitEinsatzplatz = 0) OR (@MitEinsatzplatz = 1 AND EPL.KaProgrammCode = @Programm))
                GROUP BY BTR.BetriebName, BTK.GeschlechtCode, BTK.Name, BTK.Vorname, BTK.Funktion,
                  BTR.Telefon, BTK.KaBetriebKontaktID, BTR.CharakterCode, BTR.KaBetriebID, BTR.TeilbetriebID, BTR.Aktiv,
                  BTR.InAusbildungsverbund, BTR.Bemerkung, BTK.UseZusatzadresse, BTK.Aktiv
                ORDER BY BTR.BetriebName;",
                          Session.User.LanguageCode,
                          "{edtSucheStatus}",
                          "{edtSucheEinsatzplatz}",
                          "{edtSucheCharakter}",
                          "{edtSucheProgramm}");

            return qry;
        }

        #endregion

        #region Private Methods

        private void EnableDisableKaProgramm()
        {
            if ((edtSucheEinsatzplatz.EditValue as int?).HasValue && (edtSucheEinsatzplatz.EditValue as int?).Value == 1)
            {
                edtSucheProgramm.EditMode = Kiss.Interfaces.UI.EditModeType.Normal;
            }
            else
            {
                edtSucheProgramm.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
                edtSucheProgramm.EditValue = null;
            }
        }

        private void JumpToBetrieb()
        {
            string jumpToPath = string.Format("KaBetriebID={0}", qryQuery["KaBetriebID$"]);
            System.Collections.Specialized.HybridDictionary dic = FormController.ConvertToDictionary(jumpToPath);
            bool result = FormController.OpenForm("FrmKaEinsatzorte", "Action", "JumpToBetrieb", dic);
        }

        #endregion

        #endregion
    }
}