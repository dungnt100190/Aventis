namespace KiSS4.Main
{
    public partial class FrmManualSystem : ManualBaseForm
    {
        public FrmManualSystem()
        {
            _manualsLangAsKey.Add(1, "Handbuch_System.chm");
            _manualsLangAsKey.Add(2, "Handbuch_System_fr.chm");

            InitializeComponent();
        }
    }
}