using System.Collections.Generic;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query
{
    /// <summary>
    /// Die Abfrage zeigt eine Übersicht über alle Teilnehmenden mit offener Leistung Vermittlung SI. 
    /// Es werden Angaben zur Person (Basisdaten) und aus den Masken Vermittlung SI (Übersicht, Vermittlungsprofil und Einsätze) verwendet.
    /// 
    /// Die Liste dient der Fallsteuerung und zur Verteilung der Dossiers auf die Mitarbeitenden SI. 
    /// Zusätzlich ist sie ein Instrument, welchen den einzelnen Mitarbeitenden im Team SI einen aktuellen Überblick über die ihnen zugeteilten Teilnehmenden bietet.
    /// </summary>
    public partial class CtlQueryKaTeilnehmendenlisteSi : KissQueryControl
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlQueryKaTeilnehmendenlisteSi"/> class.
        /// </summary>
        public CtlQueryKaTeilnehmendenlisteSi()
        {
            InitializeComponent();

            SetupStatusVermittlung();

            // HACK: Tabulator springt nicht aus einem KissLookUpEdit, wenn es nicht das letzte seiner Art ist..
            tpgSuchen.Controls.Add(new KissLookUpEdit { TabIndex = 999, TabStop = false, Visible = false });
        }

        #endregion

        #region EventHandlers

        private void edtSucheZustaendigKA_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var searchString = edtSucheZustaendigKA.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    edtSucheZustaendigKA.EditValue = null;
                    edtSucheZustaendigKA.LookupID = null;
                    return;
                }
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                SELECT DISTINCT
                       [ID$]            = USR.UserID,
                       [Kürzel]         = USR.LogonName,
                       [Mitarbeiter/in] = USR.NameVorname,
                       [Org.Einheit]    = USR.OrgUnit
                FROM dbo.vwUser             USR WITH (READUNCOMMITTED)
                  INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.UserID = USR.UserID
                                                                      AND LEI.ModulID = 7           -- KA
                                                                      AND LEI.FaProzessCode = 706   -- Vermittlung SI
                WHERE USR.DisplayText LIKE '%' + {0} + '%'
                ORDER BY USR.NameVorname;", searchString, e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                edtSucheZustaendigKA.EditValue = dlg[2];
                edtSucheZustaendigKA.LookupID = dlg[0];
            }
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();
            edtSucheStatusVermittlung.Focus();
        }

        #endregion

        #region Private Methods

        private void SetupStatusVermittlung()
        {
            var codeTexts = new Dictionary<int, string>
            {
                { 0, "Nicht vermittelt" },
                { 1, "Vermittelt" }
            };

            edtSucheStatusVermittlung.ApplyCodeTextPairsAsPopupDataSource(codeTexts);
        }

        #endregion

        #endregion
    }
}