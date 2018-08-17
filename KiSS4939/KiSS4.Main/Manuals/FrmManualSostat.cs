namespace KiSS4.Main
{
    public partial class FrmManualSostat : ManualBaseForm
    {
        public FrmManualSostat()
        {
            _manualsLangAsKey.Add(1, "Handbuch_Sostat.chm");
            _manualsLangAsKey.Add(2, "Handbuch_Sostat_fr.chm");

            InitializeComponent();
        }
    }
}