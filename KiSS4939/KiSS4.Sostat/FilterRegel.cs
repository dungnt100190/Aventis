using Kiss.Interfaces.UI;
using KiSS4.ExpressionEvaluation;
using KiSS4.Gui;

namespace KiSS4.Sostat
{
	public class FilterRegel
	{
		public readonly IKissEditable Control;
		public readonly string Regel = null;
		
		private readonly EditModeType editModeTrue = EditModeType.Normal;
		private readonly EditModeType editModeFalse = EditModeType.Normal;
		
		public FilterRegel(IKissEditable edt, string regel, int excelFarbCode)
		{
			this.Control = edt;
			this.Regel = regel;
			
			switch (excelFarbCode)
			{
				case 3: // Obligatorisch
					editModeTrue = EditModeType.BfsMust;
					editModeFalse = EditModeType.BfsMust;
					break;
				
				case 44: // Obligatorisch nach Filterführung, sonst freiwillig
					editModeTrue = EditModeType.BfsMust;
					editModeFalse = EditModeType.BfsCan;
					break;
				
				case 15: // Obligatorisch nach Filterführung, sonst ausgeblendet
					editModeTrue = EditModeType.BfsMust;
					editModeFalse = EditModeType.ReadOnly;
					break;
				
				case 35: // Freiwillig nach Filterführung, sonst ausgeblendet
					editModeTrue = EditModeType.BfsCan;
					editModeFalse = EditModeType.ReadOnly;
					break;
				
				case 2: // freiwillig
				case -4142:
					editModeTrue = EditModeType.BfsCan;
					editModeFalse = EditModeType.BfsCan;
					break;
			}
		}
		
		public void Evaluate(AdditionalFunctionEventHandler handler)
		{
			if (editModeTrue == editModeFalse || Regel == null || (bool)ExpressionEval.Evaluate(Regel, handler))
			{
				Control.EditMode = editModeTrue;
			}
			else
			{
				Control.EditMode = editModeFalse;
			}
		}
	}
}