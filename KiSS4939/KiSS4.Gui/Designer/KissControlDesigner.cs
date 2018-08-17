using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace KiSS4.Gui.Designer
{
	/// <summary>
	/// Implements the KiSS Control designer.
	/// </summary>
	public class KissControlDesigner 
		: 
		System.Windows.Forms.Design.ControlDesigner
	{
		private Type type;

		/// <summary>
		/// Initializes the designer with the specified component.
		/// </summary>
		/// <param name="component">The <see cref="T:System.ComponentModel.IComponent"></see> to associate the designer with. This component must always be an instance of, or derive from, <see cref="T:System.Windows.Forms.Control"></see>.</param>
		public override void Initialize(IComponent component)
		{
			base.Initialize(component);
			this.type = component.GetType();

			//Set default width
			((Control)component).Width = 250;

			//Set default height
			if (this.type != typeof(KissMemoEdit))
			{
				((Control)component).Height = 24;
			}
			else
			{
				((Control)component).Height = 52;
			}
		}

		/// <summary>
		/// Initializes a newly created component.
		/// </summary>
		/// <param name="defaultValues">A name/value dictionary of default values to apply to properties. May be null if no default values are specified.</param>
		public override void InitializeNewComponent(System.Collections.IDictionary defaultValues)
		{
			base.InitializeNewComponent(defaultValues);

			//Set empty text
			((Control)base.Component).Text = "";
		}

		/// <summary>
		/// Gets the selection rules that indicate the movement capabilities of a component.
		/// </summary>
		/// <value></value>
		/// <returns>A bitwise combination of <see cref="T:System.Windows.Forms.Design.SelectionRules"></see> values.</returns>
		public override System.Windows.Forms.Design.SelectionRules SelectionRules
		{
			// Set Selectionrules Behaviour
			get
			{
				if (type == typeof(KissButtonEdit) || type == typeof(KissCalcEdit) || type == typeof(KissComboBox) || type == typeof(KissDateEdit) || type == typeof(KissImageComboBoxEdit) || type == typeof(KissTextEdit) || type.Name == "KissPLZOrt")
				{
					return System.Windows.Forms.Design.SelectionRules.LeftSizeable |
						System.Windows.Forms.Design.SelectionRules.RightSizeable |
						System.Windows.Forms.Design.SelectionRules.Visible |
						System.Windows.Forms.Design.SelectionRules.Moveable;
				}
				else
				{
					return System.Windows.Forms.Design.SelectionRules.LeftSizeable |
						System.Windows.Forms.Design.SelectionRules.RightSizeable |
						System.Windows.Forms.Design.SelectionRules.TopSizeable |
						System.Windows.Forms.Design.SelectionRules.BottomSizeable |
						System.Windows.Forms.Design.SelectionRules.Visible |
						System.Windows.Forms.Design.SelectionRules.Moveable;
				}
			}
		}
	}
}
