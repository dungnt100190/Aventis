namespace KiSS4.Main
{
    public partial class FrmManualFallsteuerung : ManualBaseForm
    {
        public FrmManualFallsteuerung()
        {
            _manualsLangAsKey.Add(1, "Handbuch_Fallsteuerung.chm");
            _manualsLangAsKey.Add(2, "Handbuch_Fallsteuerung_fr.chm");

            InitializeComponent();
        }
    }
}