using System.Drawing;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Vormundschaft
{
    /// <summary>
    /// Summary description for CtlVmVaterschaftVerlauf.
    /// </summary>
    public partial class CtlVmVaterschaftVerlauf : KissUserControl
    {
        private int _faLeistungID;

        public CtlVmVaterschaftVerlauf()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
        }

        public void Init(string titleName, Image titleImage, int faLeistungID)
        {
            lblTitel.Text = titleName;
            picTitel.Image = titleImage;
            _faLeistungID = faLeistungID;

            DBUtil.ApplyFallRightsToSqlQuery(_faLeistungID, qryVmVaterschaft);
            qryVmVaterschaft.CanDelete = false;
            qryVmVaterschaft.CanInsert = false;

            if (qryVmVaterschaft.CanUpdate)
            {
                DBUtil.ExecSQL(@"
					IF NOT EXISTS(SELECT * FROM VmVaterschaft WHERE FaLeistungID = {0}) BEGIN
						INSERT VmVaterschaft (FaLeistungID)
						VALUES ({0})
					END",
                    _faLeistungID);
            }

            qryVmVaterschaft.Fill(@"
				select VAT.*
				from   VmVaterschaft VAT
				where  VAT.FaLeistungID = {0}",
                _faLeistungID);

            if (qryVmVaterschaft.Count == 0)
                qryVmVaterschaft.Insert(null);
        }

        private void qryVmVaterschaft_AfterInsert(object sender, System.EventArgs e)
        {
            qryVmVaterschaft["FaLeistungID"] = _faLeistungID;
        }
    }
}
