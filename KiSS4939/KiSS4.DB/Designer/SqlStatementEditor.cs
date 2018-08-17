using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace KiSS4.DB.Designer
{
	/// <summary>
	/// Summary description for SqlStatementEditor.
	/// </summary>
	public class SqlStatementEditor : UITypeEditor
	{
		/// <summary>
		/// Gets the editor style used by the 
		/// <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> 
		/// method.
		/// </summary>
		/// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> 
		/// that can be used to gain additional context information.</param>
		/// <returns>
		/// A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle"></see> value that 
		/// indicates the style of editor used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method. If the <see cref="T:System.Drawing.Design.UITypeEditor"></see> does not support this method, then <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle"></see> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None"></see>.
		/// </returns>
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) 
		{
			if( context != null ) 
			{
				return UITypeEditorEditStyle.Modal;
			}
			return base.GetEditStyle(context);
		}

		/// <summary>
		/// Edits the specified object's value using the editor style indicated by the <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle"></see> method.
		/// </summary>
		/// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
		/// <param name="provider">An <see cref="T:System.IServiceProvider"></see> that this editor can use to obtain services.</param>
		/// <param name="value">The object to edit.</param>
		/// <returns>
		/// The new value of the object. If the value of the object has not changed, this should return the same object it was passed.
		/// </returns>
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) 
		{
			if( (context != null) && (provider != null) ) 
			{
				// Access the property browser’s UI display service, IWindowsFormsEditorService
				IWindowsFormsEditorService   editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
				if( editorService != null ) 
				{
					// Create an instance of the UI editor
					DlgSqlStatementEditorForm modalEditor = new DlgSqlStatementEditorForm();
					// Pass the UI editor the current property value
					modalEditor.SelectStatement = value as string;
					// Display the UI editor
					if( editorService.ShowDialog(modalEditor) == DialogResult.OK ) 
					{
						// Return the new property value from the editor
						return modalEditor.SelectStatement;
					}
				}
			}
			return base.EditValue(context, provider, value);
		}
	}
}
