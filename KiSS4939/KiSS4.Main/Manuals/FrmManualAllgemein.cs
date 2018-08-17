namespace KiSS4.Main
{
    public partial class FrmManualAllgemein : ManualBaseForm
    {
        public FrmManualAllgemein()
        {
            _manualsLangAsKey.Add(1, "Handbuch_Allgemein.chm");
            _manualsLangAsKey.Add(2, "Handbuch_Allgemein_fr.chm");

            InitializeComponent();
        }
    }
}