using System;
using System.Drawing;
using KiSS.DBScheme;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    /// <summary>
    /// Summary description for CtlKaQJPZBerichte.
    /// </summary>
    public partial class CtlKaQJPZBerichte : KissUserControl
    {
        private int _baPersonID;
        private int _faLeistungID;

        public CtlKaQJPZBerichte()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
        }

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "BAPERSONID":
                    return _baPersonID;

                case "FALEISTUNGID":
                    return _faLeistungID;

                case "OWNERUSERID":
                    return (int)DBUtil.ExecuteScalarSQL("select UserID from FaLeistung where FaLeistungID = {0}", _faLeistungID);

                default:
                    return base.GetContextValue(fieldName);
            }
        }

        public void Init(string titleName, Image titleImage, int faLeistungID, int baPersonID)
        {
            _faLeistungID = faLeistungID;
            _baPersonID = baPersonID;

            lblTitel.Text = titleName;
            picTitle.Image = titleImage;

            qryKaQJPZBericht.Fill(_faLeistungID, Session.User.IsUserKA ? 0 : 1);

            colBericht.ColumnEdit = grdIntakegespraeche.GetLOVLookUpEdit("KaQJPZBerichtTyp");
        }

        private void qryKaQJPZBericht_AfterInsert(object sender, EventArgs e)
        {
            qryKaQJPZBericht[DBO.KaQJPZBericht.FaLeistungID] = _faLeistungID;
            qryKaQJPZBericht[DBO.KaQJPZBericht.SichtbarSDFlag] = KaUtil.IsVisibleSD(_baPersonID);
        }
    }
}