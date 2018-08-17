namespace KiSS4.Main
{
    public partial class FrmManualInkasso : ManualBaseForm
    {
        public FrmManualInkasso()
        {
            _manualsLangAsKey.Add(1, "Handbuch_Inkasso.chm");
            _manualsLangAsKey.Add(2, "Handbuch_Inkasso_fr.chm");

            InitializeComponent();
        }
    }
}