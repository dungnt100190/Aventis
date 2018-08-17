using System;

using KiSS4.DB;

namespace KiSS4.Query
{
    public partial class CtlQueryGvExterneFonds : CtlQueryGvFondsBase
    {
        public CtlQueryGvExterneFonds()
        {
            InitializeComponent();

            // Tab Gesuch
            colGesuchInternerFonds.Visible = false;
            colGesuchKostenart.Visible = false;
            colGesuchPositionsart.Visible = false;
            colGesuchAusbezahlterBetrag.Visible = false;
            colGesuchRentenstufe.Visible = false;
            colGesuchIVGrad.Visible = false;
            colGesuchHilfslosenentschaedigung.Visible = false;
            colGesuchHelbEntscheid.Visible = false;
            colGesuchIntensivpflegezuschlag.Visible = false;
            colGesuchErgaenzungsleistungen.Visible = false;
            colGesuchHaushaltsgroesse.Visible = false;
            colGesuchInternerFonds.Visible = false;
            colInternesExternesGesuch.Visible = false;
            colGesuchTage.Visible = false;
            colGesuchKompetenzKantFlb.Visible = false;

            // Tab Klient
            colKlientRentenstufe.Visible = false;
            colKlientIVGrad.Visible = false;
            colKlientHilfslosenentschaedigung.Visible = false;
            colKlientHelbEntscheid.Visible = false;
            colKlientIntensivpflegezuschlag.Visible = false;
            colKlientErgaenzungsleistungen.Visible = false;
            colKlientHaushaltsgroesse.Visible = false;
            colKlientAusbezahlterBetrag.Visible = false;

            // Tab Fonds
            colFondsInternerFonds.Visible = false;

            kissSearch.SelectParameters = new object[]
            {
                true, // 1) ExternInterner Fonds (true = externe Fonds)
                Session.User.LanguageCode // 2) Sprachcode des Benutzers
            };
        }

        private void CtlQueryGvExterneFonds_Load(object sender, EventArgs e)
        {
            InitializeLookupFonds();
        }

        /// <summary>
        /// Dropdown Fonds initialisieren
        /// </summary>
        private void InitializeLookupFonds()
        {
            // all mandanten the user can see
            SqlQuery queryExterneFonds =
                DBUtil.OpenSQL(
                    @"
                    SELECT [Code] = NULL,
                           [Text] = ''
                    UNION ALL
                    SELECT [Code] = GvFondsID,
                           [Text] = NameKurz
                    FROM dbo.GvFonds WITH (READUNCOMMITTED)
                    WHERE GvFondsTypCode = 2
                    ORDER BY [Text];");
            edtSucheFonds.LoadQuery(queryExterneFonds);
        }
    }
}