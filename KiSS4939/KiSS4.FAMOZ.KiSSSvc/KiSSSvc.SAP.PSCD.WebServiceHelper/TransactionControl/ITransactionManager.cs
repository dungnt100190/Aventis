using System;
namespace KiSSSvc.SAP.PSCD.WebServiceHelper.TransactionControl
{

	public enum TransactionStatus
	{
		sent,
		successful,
		expired,
		warning,
		error
	}

	interface ITransactionManager
	{

		/// <summary>
		/// Gets the status for transaction.
		/// </summary>
		/// <param name="transactionId">The transaction id.</param>
		/// <returns></returns>
		ReturnMsgAsync GetStatusForTransaction(string transactionId);

		/// <summary>
		/// Processes the transaction to PSCD.
		/// </summary>
		/// <param name="transactionId">The transaction id.</param>
		/// <param name="callId">The call id.</param>
		/// <returns></returns>
		bool ProcessTransactionToPscd(string transactionId, string callId);

		/// <summary>
		/// Gets the return MSG for call id.
		/// </summary>
		/// <param name="callId">The call id.</param>
		/// <returns></returns>
		ReturnMsgAsync GetReturnMsgForCallId(string callId);

		/// <summary>
		/// Creates the new transaction.
		/// </summary>
		/// <param name="transactionId">The transaction id.</param>
		/// <param name="callId">The call id.</param>
		/// <param name="status">The status.</param>
		void CreateNewTransaction(string transactionId, string callId, string status, int? objectID);

		/// <summary>
		/// Sets the transaction status successful.
		/// </summary>
		/// <param name="transactionId">The transaction id.</param>
		void SetTransactionStatusSuccessful(string transactionId);

		/// <summary>
		/// Sets the transaction status failed.
		/// </summary>
		/// <param name="transactionId">The transaction id.</param>
		void SetTransactionStatusFailed(string transactionId);

		/// <summary>
		/// Sets the transaction message.
		/// </summary>
		/// <param name="transactionId">The transaction id.</param>
		/// <param name="message">The message.</param>
		void SetTransactionMessage(string transactionId, string message);
	}
}
