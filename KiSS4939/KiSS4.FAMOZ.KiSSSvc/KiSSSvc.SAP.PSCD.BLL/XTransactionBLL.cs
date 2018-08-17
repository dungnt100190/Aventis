using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.DAL;
using KiSSSvc.DAL.KiSSDBTableAdapters;
using System.Diagnostics;
using KiSSSvc.Logging;

namespace KiSSSvc.SAP.PSCD.BLL
{
	public static class XTransactionBLL
	{
		/// <summary>
		/// Gets the transaction for call id.
		/// </summary>
		/// <param name="callId">The call id.</param>
		/// <returns></returns>
		public static KiSSDB.XTransactionTableRow GetTransactionForCallId(string callId)
		{
			try
			{
				XTransactionTableTableAdapter xtransadapter = new XTransactionTableTableAdapter();
				xtransadapter.InitializeKiSSAdapter(null);

				KiSSDB.XTransactionTableDataTable transactions = xtransadapter.GetTransactionByCallId(callId);
				if (transactions.Rows.Count > 1)
				{
					throw new Exception(String.Format("Es existieren mehrere transaktionen mit der Id {0}", callId));
				}
				else if (transactions.Rows.Count == 1)
				{
					return transactions[0];
				}
			}
			catch (Exception e)
			{
				Debug.WriteLine(e);
			}


			return null;
		}

		/// <summary>
		/// Gets the transaction for transaction id.
		/// </summary>
		/// <param name="transactionId">The transaction id.</param>
		/// <returns></returns>
		public static KiSSDB.XTransactionTableRow GetTransactionForTransactionId(string transactionId)
		{
			try
			{
				XTransactionTableTableAdapter xtransadapter = new XTransactionTableTableAdapter();
				xtransadapter.InitializeKiSSAdapter(null);

				KiSSDB.XTransactionTableDataTable transactions = xtransadapter.GetTransactionByTransactionId(transactionId);
				if (transactions.Rows.Count > 1)
				{
					//SetTransactionsExpired
					foreach (KiSSDB.XTransactionTableRow row in transactions.Rows)
					{
						row.Status = "expired";
					}

					// throw new Exception(String.Format("Es existieren mehrere transaktionen mit der Id {0}", transactionId));
				}
				else if (transactions.Rows.Count == 1)
				{
					return transactions[0];
				}
			}
			catch (Exception e)
			{
				Debug.WriteLine(e);
			}


			return null;
		}


		/// <summary>
		/// Creates the new transaction.
		/// </summary>
		/// <param name="transactionId">The transaction id.</param>
		/// <param name="callId">The call id.</param>
		/// <param name="status">The status.</param>
		public static void CreateNewTransaction(string transactionId, string callId, string status, int? objectID)
		{
			Log.Info(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, String.Format("Inserting Transaction data into Table: transactionId: '{0}' callId: '{1}' status: '{2}'", transactionId, callId, status));
			XTransactionTableTableAdapter adapter = new XTransactionTableTableAdapter();
			Log.Info(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, String.Format("Tableadapter Created, replacing Pwd"));

			adapter.InitializeKiSSAdapter(null);

			Log.Info(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, String.Format("Pwd replaced, inserting row into table"));

			int row = adapter.Insert(transactionId, status, callId, DateTime.Now, null, null, objectID);
		}

		/// <summary>
		/// Updates the transaction.
		/// </summary>
		/// <param name="transaction">The transaction.</param>
		public static void UpdateTransaction(KiSSDB.XTransactionTableRow transaction)
		{
			XTransactionTableTableAdapter xtransadapter = new XTransactionTableTableAdapter();
			xtransadapter.InitializeKiSSAdapter(null);

			xtransadapter.Update(transaction);
		}

	}
}
