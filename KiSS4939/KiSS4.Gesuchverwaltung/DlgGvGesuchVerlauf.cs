using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Gesuchverwaltung
{
    public partial class DlgGvGesuchVerlauf : KissDialog
    {
        private const string CLASSNAME = "DlgGvGesuchVerlauf";

        public DlgGvGesuchVerlauf()
        {
            InitializeComponent();
        }

        public DlgGvGesuchVerlauf(int gvGesuchId)
            : this()
        {
            colBewilligungCode.ColumnEdit = grdGvBewilligung.GetLOVLookUpEdit("GvBewilligung");

            qryGvBewilligung.Fill(gvGesuchId);

            Text = string.Format(KissMsg.GetMLMessage(CLASSNAME, "Title", "Verlauf Gesuchs-ID {0}"), gvGesuchId);
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }
    }
}