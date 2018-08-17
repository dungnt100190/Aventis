using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace KiSS4.DB.Designer
{
	/// <summary>
	/// SqlQueryDesigner set automaticaly the HostControl
	/// </summary>
	public class SqlQueryDesigner 
		: 
		System.ComponentModel.Design.ComponentDesigner
	{
		private System.ComponentModel.IComponent component;

		/// <summary>
		/// 
		/// </summary>
		public SqlQueryDesigner() { }

		/// <summary>
		/// Prepares the designer to view, edit, and design the specified component.
		/// </summary>
		/// <param name="component">The component for this designer.</param>
		public override void Initialize(IComponent component)
		{
			this.component = component;
			base.Initialize(component);
		}

		/// <summary>
		/// Creates a method signature in the source code file for the default event on the component and navigates the user's cursor to that location.
		/// </summary>
		/// <exception cref="T:System.ComponentModel.Design.CheckoutException">An attempt to check out a file that is checked into a source code management program failed.</exception>
		public override void DoDefaultAction()
		{
			SetHostControl();

			base.DoDefaultAction();
		}

		/// <summary>
		/// Sets the default properties for the component.
		/// </summary>
		[Obsolete]
		public override void OnSetComponentDefaults()
		{
			SetHostControl();

			base.OnSetComponentDefaults();
		}

		private void SetHostControl()
		{
			if (component is SqlQuery && ((SqlQuery)component).HostControl != null)
				return;

			IDesignerHost host = (IDesignerHost)this.component.Site.GetService(typeof(IDesignerHost));
			ContainerControl hostControl = host.RootComponent as ContainerControl;

			PropertyDescriptor property = TypeDescriptor.GetProperties(typeof(SqlQuery))["HostControl"];
			property.SetValue(this.component, hostControl);
		}
	}
}
