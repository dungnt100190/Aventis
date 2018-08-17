using System;
using System.Collections.Generic;
using System.Text;

/// Code copied from http://www.codeexperiment.com/post/Implementing-Transactional-TableAdapters.aspx
namespace KiSSSvc.DAL.TransactionalTableAdapters
{
	public class AdapterDecorator
	{
		#region Properties
		private System.Data.Common.DbDataAdapter _adapter;
		/// <summary>
		/// Gets or sets the DataAdapter for the TableAdapter.
		/// </summary>
		public System.Data.Common.DbDataAdapter Adapter
		{
			get { return _adapter; }
			set { _adapter = value; }
		}

		private System.Data.Common.DbCommand[] _commands;
		/// <summary>
		/// Gets or sets the non-DataAdapter Command objects.
		/// </summary>
		public System.Data.Common.DbCommand[] Commands
		{
			get { return _commands; }
			set { _commands = value; }
		}
		#endregion Properties

		#region Constructors
		public AdapterDecorator(System.Data.Common.DbDataAdapter adapter)
		{
			_adapter = adapter;
		}

		public AdapterDecorator(System.Data.Common.DbDataAdapter adapter, System.Data.Common.DbCommand[] commands)
		{
			_adapter = adapter;
			_commands = commands;
		}
		#endregion Constructors

		#region Public Methods
		public void EnlistTransaction(System.Data.Common.DbTransaction transaction)
		{
			//set Adapter Command object transactions
			if (_adapter != null)
			{
				if (_adapter.InsertCommand != null)
				{
					_adapter.InsertCommand.Connection = transaction.Connection;
					_adapter.InsertCommand.Transaction = transaction;
				}
				if (_adapter.UpdateCommand != null)
				{
					_adapter.UpdateCommand.Connection = transaction.Connection;
					_adapter.UpdateCommand.Transaction = transaction;
				}
				if (_adapter.DeleteCommand != null)
				{
					_adapter.DeleteCommand.Connection = transaction.Connection;
					_adapter.DeleteCommand.Transaction = transaction;
				}
			}

			//set non-Adapter Command object transactions
			if (_commands != null)
			{
				for (int i = 0; i < this._commands.Length; i++)
				{
					_commands[i].Connection = transaction.Connection;
					_commands[i].Transaction = transaction;
				}
			}
		}
		#endregion Public Methods
	}
}
