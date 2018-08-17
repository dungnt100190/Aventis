namespace KiSS4.Main
{
    public partial class FrmManualFibu : ManualBaseForm
    {
        public FrmManualFibu()
        {
            _manualsLangAsKey.Add(1, "Handbuch_Mandatsbuchhaltung.chm");
            _manualsLangAsKey.Add(2, "Handbuch_Mandatsbuchhaltung_fr.chm");

            InitializeComponent();
        }
    }
}