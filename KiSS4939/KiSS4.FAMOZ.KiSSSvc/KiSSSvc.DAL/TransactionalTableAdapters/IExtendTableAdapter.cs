using System;
using System.Collections.Generic;
using System.Text;

/// Code copied from http://www.codeexperiment.com/post/Implementing-Transactional-TableAdapters.aspx
namespace KiSSSvc.DAL.TransactionalTableAdapters
{
	public interface IExtendTableAdapter
	{
		/// <summary>
		/// Returns the DataAdapter for the TableAdapter
		/// </summary>
		AdapterDecorator DataAdapter { get; }

		/// <summary>
		/// Gets or sets the DbConnection for the TableAdapter.
		/// </summary>
		System.Data.IDbConnection DbConnection { get; set;}
	}
}
