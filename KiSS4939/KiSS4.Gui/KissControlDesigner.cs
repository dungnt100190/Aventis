using System;
using System.ComponentModel ;
using System.Windows.Forms ;

namespace KiSS4.Gui 
{

	public class KissControlDesigner : System.Windows.Forms.Design.ControlDesigner
	{
		private Type type ;

		public override void Initialize(IComponent component) 
		{
			base.Initialize(component) ;
			this.type = component.GetType() ;
			
			//Set default width
			((Control)component).Width = 250 ;

			//Set default height
			if(this.type != typeof(KissMemoEdit))
			{
				((Control)component).Height = 24 ;
			}
			else
			{
				((Control)component).Height = 52 ;
			}
		}

        [Obsolete]
		public override void OnSetComponentDefaults()
		{
			base.OnSetComponentDefaults() ;

			//Set empty text
			((Control)base.Component).Text = "" ;
		}

		public override System.Windows.Forms.Design.SelectionRules SelectionRules
		{
			// Set Selectionrules Behaviour
			get
			{
				if(type == typeof(KissButtonEdit) || type == typeof(KissCalcEdit) || type == typeof(KissComboBox) || type == typeof(KissDateEdit) || type == typeof(KissImageComboBoxEdit) || type == typeof(KissTextEdit) || type.Name == "KissPLZOrt")
				{
					return System.Windows.Forms.Design.SelectionRules.LeftSizeable |
						System.Windows.Forms.Design.SelectionRules.RightSizeable |
						System.Windows.Forms.Design.SelectionRules.Visible |
						System.Windows.Forms.Design.SelectionRules.Moveable ;
				}
				else
				{
					return System.Windows.Forms.Design.SelectionRules.LeftSizeable |
						System.Windows.Forms.Design.SelectionRules.RightSizeable |
						System.Windows.Forms.Design.SelectionRules.TopSizeable |
						System.Windows.Forms.Design.SelectionRules.BottomSizeable |
						System.Windows.Forms.Design.SelectionRules.Visible |
						System.Windows.Forms.Design.SelectionRules.Moveable ;				
				}
			}
		}	
	}
}
