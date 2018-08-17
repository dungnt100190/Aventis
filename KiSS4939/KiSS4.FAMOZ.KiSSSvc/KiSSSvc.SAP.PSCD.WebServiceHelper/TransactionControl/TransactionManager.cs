using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.SAP.PSCD.BLL;
using KiSSSvc.DAL;
using KiSSSvc.Logging;
using System.Threading;

namespace KiSSSvc.SAP.PSCD.WebServiceHelper.TransactionControl
{

	internal class TransactionManager : ITransactionManager
	{

		private const int TRANSACTION_EXPIRATION_TIME_MIN = 2;

		#region Businesslogic
		/// <summary>
		/// Processes the transaction to PSCD.
		/// </summary>
		/// <param name="transactionId">The transaction id.</param>
		/// <param name="callId">The call id.</param>
		/// <returns></returns>
		public bool ProcessTransactionToPscd(string transactionId, string callId)
		{
			return false;
		}


		/// <summary>
		/// Gets the status for transaction.
		/// </summary>
		/// <param name="transactionId">The transaction id.</param>
		/// <returns></returns>
		public ReturnMsgAsync GetStatusForTransaction(string transactionId)
		{

			KiSSDB.XTransactionTableRow tableRow = XTransactionBLL.GetTransactionForTransactionId(transactionId);

			if (tableRow != null)
			{
				return ParseTableRow(tableRow);
			}
			return null;
		}


		/// <summary>
		/// Gets the return MSG for call id.
		/// </summary>
		/// <param name="callId">The call id.</param>
		/// <returns></returns>
		public ReturnMsgAsync GetReturnMsgForCallId(string callId)
		{
			KiSSDB.XTransactionTableRow tableRow = XTransactionBLL.GetTransactionForCallId(callId);
			if (tableRow != null)
			{
				if (CheckSendTime(tableRow))
				{
					return ParseTableRow(tableRow);
				}
				else
				{
					SetRowExpired(tableRow);
				}
			}
			return null;
		}

		/// <summary>
		/// Gets the object ID for call id.
		/// </summary>
		/// <param name="callId">The call id.</param>
		/// <returns></returns>
		public int? GetObjectIDFromCallID(string callId)
		{
			KiSSDB.XTransactionTableRow tableRow = XTransactionBLL.GetTransactionForCallId(callId);
			if (tableRow != null || tableRow.IsObjectIDNull())
				return null;
			return tableRow.ObjectID;
		}



		/// <summary>
		/// Creates the new transaction.
		/// </summary>
		/// <param name="transactionId">The transaction id.</param>
		/// <param name="callId">The call id.</param>
		/// <param name="status">The status.</param>
		public void CreateNewTransaction(string transactionId, string callId, string status, int? objectID)
		{
			XTransactionBLL.CreateNewTransaction(transactionId, callId, status, objectID);
			try
			{
				AddTransactionWatcher(transactionId);
			}
			catch { }
		}

		/// <summary>
		/// Adds the transaction watcher.
		/// </summary>
		/// <param name="transactionId">The transaction id.</param>
		private void AddTransactionWatcher(string transactionId)
		{
			ParameterizedThreadStart tStart = new ParameterizedThreadStart(ThreadedTransactionWatcher);
			Thread thread = new Thread(tStart);
			thread.Start(transactionId);
		}

		/// <summary>
		/// Threadeds the transaction watcher.
		/// </summary>
		/// <param name="transId">The trans id.</param>
		private void ThreadedTransactionWatcher(object transId)
		{
			String transactionId = transId.ToString();
			while (CheckTransactionTimeout(transactionId))
			{
				Thread.Sleep(3000);
			}
		}

		/// <summary>
		/// Sets the transaction status successful.
		/// </summary>
		/// <param name="transactionId">The transaction id.</param>
		public void SetTransactionStatusSuccessful(string transactionId)
		{
			KiSSDB.XTransactionTableRow tableRow = XTransactionBLL.GetTransactionForTransactionId(transactionId);

			if (tableRow != null)
			{
				Log.Debug(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType, String.Format("Setting Transactionsatus to succesful. TransactionId: '{0}'", transactionId));
				SetRowSuccessful(tableRow);
			}
			else
			{
				throw new Exception(String.Format("Transactionrow not found for Id: '{0}'", transactionId));
			}
		}

		/// <summary>
		/// Sets the transaction status failed.
		/// </summary>
		/// <param name="transactionId">The transaction id.</param>
		public void SetTransactionStatusFailed(string transactionId)
		{
			KiSSDB.XTransactionTableRow tableRow = XTransactionBLL.GetTransactionForTransactionId(transactionId);

			if (tableRow != null)
			{
				Log.Debug(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType, String.Format("Setting Transactionsatus to failed. TransactionId: '{0}'", transactionId));
				SetRowFailed(tableRow);
			}
			else
			{
				throw new Exception(String.Format("Transactionrow not found for Id: '{0}'", transactionId));
			}
		}

		/// <summary>
		/// Sets the transaction message.
		/// </summary>
		/// <param name="transactionId">The transaction id.</param>
		/// <param name="message">The message.</param>
		public void SetTransactionMessage(string transactionId, string message)
		{
			KiSSDB.XTransactionTableRow tableRow = XTransactionBLL.GetTransactionForTransactionId(transactionId);
			if (tableRow != null)
			{
				tableRow.Message = message;
				XTransactionBLL.UpdateTransaction(tableRow);
			}
		}


		#endregion

		#region internal Logic


		/// <summary>
		/// Parses the table row.
		/// </summary>
		/// <param name="tableRow">The table row.</param>
		/// <returns></returns>
		private ReturnMsgAsync ParseTableRow(KiSSDB.XTransactionTableRow tableRow)
		{
			string transactionId = tableRow.TransactionId;
			ReturnMsgAsync msg = new ReturnMsgAsync(transactionId);
			String status = tableRow.Status;

			if (!String.IsNullOrEmpty(status) && status.Equals(TransactionStatus.error.ToString()))
			{
				msg.TransactionStatus = TransactionStatus.error;
			}
			else if (!String.IsNullOrEmpty(status) && status.Equals(TransactionStatus.sent.ToString()))
			{
				msg.TransactionStatus = TransactionStatus.sent;
			}
			else if (!String.IsNullOrEmpty(status) && status.Equals(TransactionStatus.expired.ToString()))
			{
				msg.TransactionStatus = TransactionStatus.expired;
			}
			else if (!String.IsNullOrEmpty(status) && status.Equals(TransactionStatus.successful.ToString()))
			{
				msg.TransactionStatus = TransactionStatus.successful;
			}
			else if (!String.IsNullOrEmpty(status) && status.Equals(TransactionStatus.warning.ToString()))
			{
				msg.TransactionStatus = TransactionStatus.warning;
			}

			msg.Message = tableRow.Message;
			if (!tableRow.IsObjectIDNull())
				msg.ObjectID = tableRow.ObjectID;

			return msg;
		}




		/// <summary>
		/// Sets the row expired.
		/// </summary>
		/// <param name="tableRow">The table row.</param>
		private void SetRowExpired(KiSSDB.XTransactionTableRow tableRow)
		{
			tableRow.Status = TransactionStatus.expired.ToString();
			XTransactionBLL.UpdateTransaction(tableRow);
		}


		/// <summary>
		/// Sets the row successful.
		/// </summary>
		/// <param name="tableRow">The table row.</param>
		private void SetRowSuccessful(KiSSDB.XTransactionTableRow tableRow)
		{
			tableRow.Status = TransactionStatus.successful.ToString();
			XTransactionBLL.UpdateTransaction(tableRow);
		}

		/// <summary>
		/// Sets the row failed.
		/// </summary>
		/// <param name="tableRow">The table row.</param>
		private void SetRowFailed(KiSSDB.XTransactionTableRow tableRow)
		{
			tableRow.Status = TransactionStatus.error.ToString();
			XTransactionBLL.UpdateTransaction(tableRow);
		}

		/// <summary>
		/// Checks the transaction timeout.
		/// </summary>
		/// <param name="transactionId">The transaction id.</param>
		private bool CheckTransactionTimeout(string transactionId)
		{
			KiSSDB.XTransactionTableRow tableRow = XTransactionBLL.GetTransactionForTransactionId(transactionId);
			if (tableRow != null)
			{
				if (tableRow.Status == TransactionStatus.sent.ToString())
				{
					if (!CheckSendTime(tableRow))
					{
						SetRowExpired(tableRow);
						return false;
					}
				}
			}
			return true;
		}

		/// <summary>
		/// Checks the send time.
		/// </summary>
		/// <param name="tableRow">The table row.</param>
		/// <returns></returns>
		private bool CheckSendTime(KiSSDB.XTransactionTableRow tableRow)
		{

			DateTime sendTime = tableRow.SendTime;
			DateTime now = DateTime.Now;

			Log.Debug(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType, String.Format("Checking Transaction Expiration for Date: '{0}'", sendTime));

			TimeSpan timeSpan = now.Subtract(sendTime);

			int minutes = timeSpan.Minutes;
			int hours = timeSpan.Hours;
			int days = timeSpan.Days;

			int totMinutes = minutes;
			totMinutes += hours * 60;
			totMinutes += days * 24 * 60;

			if (totMinutes > TRANSACTION_EXPIRATION_TIME_MIN)
			{
				Log.Debug(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType, String.Format("Transaction has expirated for '{0}' minutes. Transaction will be set to expired and a new one will be created", totMinutes));
				return false;
			}

			return true;
		}

		#endregion
	}
}
