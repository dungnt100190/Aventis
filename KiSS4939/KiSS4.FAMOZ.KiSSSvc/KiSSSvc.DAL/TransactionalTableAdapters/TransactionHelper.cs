using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace KiSSSvc.DAL.TransactionalTableAdapters
{
	/// <summary>
	/// Makes TableAdapters in a code block transactional. This class cannot be inherited.
    /// Code copied from http://www.codeexperiment.com/post/Implementing-Transactional-TableAdapters.aspx
	/// </summary>
	/// <example> The following example demonstrates how to use the <c>TransactionHelper</c> class
	/// to define a block of code to enlist a TableAdapter to participatein a transaction.
	/// <code>
	/// using (TransactionHelper th = new TransactionHelper())
	/// {
	///		//Create a table adapter and enlist in transaction
	///		TableAdapter1 ta = new TableAdapter1();
	///		th.EnlistParticipant(ta);
	/// 
	///		//Commit the transaction
	///		th.Complete();
	/// }
	/// </code>
	/// </example>
	public sealed class TransactionHelper : IDisposable
	{
		#region Private Fields
		DbConnection _connection;		//The database connection
		DbTransaction _tran = null;		//The database transaction
        List<IExtendTableAdapter> _adapters = new List<IExtendTableAdapter>();
		#endregion Private Fields

		#region Public Methods
		/// <summary>
		/// Enlists the specified table adapter in the current transaction.
		/// </summary>
		/// <param name="tableAdapter">The table adapter to enlist. The table adapter must implement <see cref="IExtendTableAdapter"/>.</param>
		/// <remarks>
		/// </remarks>
		public void EnlistParticipant(System.ComponentModel.Component tableAdapter)
		{
			//Make sure the TableAdapter implements IExtendTableAdapter which is required for transaction support
			if (!(tableAdapter is IExtendTableAdapter))
				throw new Exception("Type " + tableAdapter.GetType().Name + " is invalid because it does not implement IExtendTableAdapter.");

			IExtendTableAdapter ta = tableAdapter as IExtendTableAdapter;

            // Add this adapter to the internal list to keep the object reference around (in case the transaction doesn't do this itself...)
            _adapters.Add(ta);

			//We need to share the same connection across TableAdapters for them to participate in the same
			//transaction so get connection from the first TableAdapter we encounter and use it for all
			//others.
			if (_connection == null)
			{
				_connection = ta.DbConnection as DbConnection;	//get the connection
				_connection.Open();								//open the connection
				_tran = _connection.BeginTransaction();			//create a transaction
			}
			else //we already have our connection so change the connection of the TableAdapter to use it
			{
				ta.DbConnection = _connection;
			}

			//Enslist the TableAdapter in the transaction
			ta.DataAdapter.EnlistTransaction(_tran);
		}

		/// <summary>
		/// Completes the operations and commits the transaction.
		/// </summary>
		public void Complete()
		{
			//Commit and dispose the transaction
			if (_tran != null)
			{
				_tran.Commit();
				_tran.Dispose();
				_tran = null;
			}
		}
		#endregion Public Methods

		#region IDisposable Members

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			//Rollback and dispose transaction if still present
			if (_tran != null)
			{
				_tran.Rollback();
				_tran.Dispose();
			}

			//close the connection
			if ((_connection != null) && (_connection.State != ConnectionState.Closed))
				_connection.Close();

            _adapters.Clear();
		}

		#endregion
	}
}
