
namespace KiSS4.DesignerHost
{
	public partial class DlgTextEditorControl : KiSS4.Gui.KissDialog
	{
		public DlgTextEditorControl()
		{
			InitializeComponent();
		}

		public TextEditorControl TextEditorControl
		{
			get { return this.textEditorControl; }
		}
	}
}