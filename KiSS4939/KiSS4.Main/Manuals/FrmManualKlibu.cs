namespace KiSS4.Main
{
    public partial class FrmManualKlibu : ManualBaseForm
    {
        public FrmManualKlibu()
        {
            _manualsLangAsKey.Add(1, "Handbuch_Klientenbuchhaltung.chm");
            _manualsLangAsKey.Add(2, "Handbuch_Klientenbuchhaltung_fr.chm");

            InitializeComponent();
        }
    }
}