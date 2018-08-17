using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

/// Code copied from http://www.codeexperiment.com/post/Implementing-Transactional-TableAdapters.aspx
namespace KiSSSvc.DAL.TransactionalTableAdapters
{
	public abstract class TableAdapterBase : System.ComponentModel.Component, IExtendTableAdapter
	{
		#region Private Fields
		AdapterDecorator adapterDecorator;	//The extended DataAdapter
		IDbConnection connection;			//The database connection
		#endregion Private Fields

        /// <summary>
        /// Initializes the TableAdapter and executes some KiSS specific initializations
        /// </summary>
        /// <param name="transHelper">If TransactionHelper is not null, then this TableAdapter will participate in the Transaction</param>
        public void InitializeKiSSAdapter(TransactionHelper transHelper)
        {
            // Replace the Password of the Connection String
            DbConnection.ConnectionString = KiSSSvc.DAL.KiSSDB.ReplacePwd(DbConnection.ConnectionString);

            if (transHelper != null)
            {
                transHelper.EnlistParticipant(this);
            }
        }

		#region IExtendTableAdapter Members

		public AdapterDecorator DataAdapter
		{
			get
			{
				//========================================================================================
				// Use Reflection to get the private Adapter and CommandCollection properties defined by
				// the Designer generated code.
				//========================================================================================

				if (this.adapterDecorator == null)
				{
					System.Data.Common.DbDataAdapter adapter = null;
					System.Data.Common.DbCommand[] commands = null;

					Type t = this.GetType();
					//If parent type is not TableAdapterBase then we need to reflect the properties 
					//from the parent type. Otherwise the "Adapter" property will not be found since 
					//it is private.
					Type parentT = t.BaseType;
					if (!(parentT.FullName == "KiSSSvc.DAL.TransactionalTableAdapters.TableAdapterBase"))
						t = parentT;

					//Get the Adapter property defined by the TableAdapter's designer generated code
					BindingFlags bf = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
					PropertyInfo pi = t.GetProperty("Adapter", bf);
					if (pi != null)
						adapter = pi.GetValue(this, null) as System.Data.Common.DbDataAdapter;

					//Get the CommandCollection property defined by the TableAdapter's designer generated code
					pi = t.GetProperty("CommandCollection", bf);
					if (pi != null)
						commands = pi.GetValue(this, null) as System.Data.Common.DbCommand[];

					//Create the AdapterDecorator object
					this.adapterDecorator = new AdapterDecorator(adapter, commands);
				}

				return this.adapterDecorator;
			}
		}

		public IDbConnection DbConnection
		{
			get
			{
				//=================================================================
				// Use Reflection to get the Connection property defined by the
				// Designer generated code.
				//=================================================================

				if (this.connection == null)
				{
					Type t = this.GetType();
					BindingFlags bf = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

					//Get the Connection property.
					PropertyInfo pi = t.GetProperty("Connection", bf);
					if (pi != null)
						connection = pi.GetValue(this, null) as IDbConnection;
				}

				return this.connection;
			}
			set
			{
				this.connection = value;
			}
		}

		#endregion
	}
}
