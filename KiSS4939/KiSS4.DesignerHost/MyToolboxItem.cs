using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.DesignerHost
{
	/// <summary>
	/// Summary description for MyToolBoxItem.
	/// </summary>
	public class MyToolboxItem : System.Drawing.Design.ToolboxItem
	{
		public readonly Type Type = null;
		public readonly string DataMember;
		private readonly SqlQuery DataSource;
		private readonly DataRow Row;
		
		public MyToolboxItem(SqlQuery DataSource)
		{
			this.DataSource = DataSource;

			Type = typeof(KissGrid);
			this.Initialize(Type);

			this.DisplayName = DataSource.TableName;
		}

		public MyToolboxItem(SqlQuery DataSource, DataRow row)
		{
			this.DataMember = row["ColumnName"] as string;
			this.DataSource = DataSource;
			this.Row = row;

			if (!DBUtil.IsEmpty(row["TypeName"]))
				Type = AssemblyLoader.GetType((string)row["TypeName"]);

			if (Type == null)
				Type = typeof(KissTextEdit);

			this.Initialize(Type);
			this.DisplayName = row["ColumnName"] as string;
		}

		public override void Initialize(Type type)
		{
			base.Initialize(type);

			ToolboxBitmapAttribute tba = TypeDescriptor.GetAttributes(Type)[typeof(ToolboxBitmapAttribute)] as ToolboxBitmapAttribute;
			if (tba != null)
				this.Bitmap = (Bitmap)tba.GetImage(Type);
		}

		public void SetProperty(object instance)
		{
			if (instance is KissGrid)
			{
				KissGrid grid = (KissGrid)instance;
				grid.DataSource = this.DataSource;
				DevExpress.XtraGrid.Views.Base.BaseView view = grid.CreateView( "GridView" );
				grid.ViewCollection.Add( view );
				grid.MainView = view;
			}
			else if (instance is KissTree)
			{
				((KissTree)instance).DataSource = this.DataSource;
			}
			else if (instance is KissLabel)
			{
				((KissLabel)instance).Text = Row["UserText"] as string;
			}
			else if (instance is IKissBindableEdit)
			{
				((IKissBindableEdit)instance).DataMember = this.DataMember;
				((IKissBindableEdit)instance).DataSource = this.DataSource;
			}
			
			if (instance is KissLookUpEdit)
			{
				((KissLookUpEdit)instance).LOVName = Row["LOVName"] as string;
			}
			else if (instance is KissCalcEdit && (int)Row["FieldCode"] == 12)
			{
				((KissCalcEdit)instance).Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
				((KissCalcEdit)instance).Properties.EditFormat.FormatString = "N2";

				((KissCalcEdit)instance).Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                ((KissCalcEdit)instance).Properties.DisplayFormat.FormatString = "N2";
			}
		}
	}
}
