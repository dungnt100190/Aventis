namespace KiSS4.Main
{
    public partial class FrmManualPendenzenverwaltung : ManualBaseForm
    {
        public FrmManualPendenzenverwaltung()
        {
            _manualsLangAsKey.Add(1, "Handbuch_Pendenzen.chm");
            _manualsLangAsKey.Add(2, "Handbuch_Pendenzen_fr.chm");

            InitializeComponent();
        }
    }
}