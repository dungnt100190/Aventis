using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using KiSSSvc.Logging;

namespace KiSSSvc.SAP.PSCD.WebServiceHelper.TransactionControl
{
	public class TransactionControlService
	{

		private const string ID_TRANSACTION_CTRL_SYSTEM = "TransactionControlService";
		private static TransactionControlService _instance;
		private TransactionManager _transactionManager;

		#region Instance Control

		/// <summary>
		/// Initializes a new instance of the <see cref="TransactionControlService"/> class.
		/// </summary>
		private TransactionControlService()
		{ }


		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>The instance.</value>
		public static TransactionControlService Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = HttpRuntime.Cache[ID_TRANSACTION_CTRL_SYSTEM] as TransactionControlService;
					if (_instance == null)
					{
						_instance = new TransactionControlService();
						HttpRuntime.Cache.Add(ID_TRANSACTION_CTRL_SYSTEM, _instance, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(1, 0, 0), System.Web.Caching.CacheItemPriority.Normal, null);
					}
				}
				return _instance;
			}
		}

		#endregion

		#region Businesslogic

		/// <summary>
		/// Gets the return MSG for call id.
		/// </summary>
		/// <param name="callId">The call id.</param>
		/// <returns></returns>
		public ReturnMsgAsync GetReturnMsgForCallId(string callId)
		{
			return TransactionManager.GetReturnMsgForCallId(callId);
		}

		/// <summary>
		/// Gets the return MSG for call id.
		/// </summary>
		/// <param name="callId">The call id.</param>
		/// <returns></returns>
		public int? GetObjectIDFromCallID(string callId)
		{
			return TransactionManager.GetObjectIDFromCallID(callId);
		}


		/// <summary>
		/// Creates the new transaction.
		/// </summary>
		/// <param name="transactionId">The transaction id.</param>
		/// <param name="callId">The call id.</param>
		public void CreateNewTransaction(ReturnMsgAsync messageService)
		{
			TransactionManager.CreateNewTransaction(messageService.TransactionId, messageService.CallId, messageService.TransactionStatus.ToString(), messageService.ObjectID);
		}


		/// <summary>
		/// Gets the transaction status.
		/// </summary>
		/// <param name="transactionId">The transaction id.</param>
		/// <returns></returns>
		public ReturnMsgAsync GetTransactionStatus(string transactionId)
		{
			return TransactionManager.GetStatusForTransaction(transactionId);
		}


		/// <summary>
		/// Sets the transaction returned from sap.
		/// </summary>
		/// <param name="TRANSACTIONID">The TRANSACTIONID.</param>
		public void SetTransactionReturnedFromSap(string transactionId, bool success, string errorMessage)
		{
			if (!string.IsNullOrEmpty(errorMessage))
			{
				TransactionManager.SetTransactionMessage(transactionId, errorMessage);
			}

			if (success)
			{
				TransactionManager.SetTransactionStatusSuccessful(transactionId);
			}
			else
			{
				TransactionManager.SetTransactionStatusFailed(transactionId);
			}
		}


		#endregion


		#region Properties

		/// <summary>
		/// Gets or sets the transaction manager.
		/// </summary>
		/// <value>The transaction manager.</value>
		internal TransactionManager TransactionManager
		{
			get
			{
				if (_transactionManager == null)
				{
					_transactionManager = new TransactionManager();
				}
				return _transactionManager;
			}
			set { _transactionManager = value; }
		}

		#endregion

	}
}
