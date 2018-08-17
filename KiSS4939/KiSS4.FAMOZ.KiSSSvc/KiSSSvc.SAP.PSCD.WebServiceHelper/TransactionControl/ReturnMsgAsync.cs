using System;
using System.Collections.Generic;
using System.Text;

namespace KiSSSvc.SAP.PSCD.WebServiceHelper.TransactionControl
{
	public class ReturnMsgAsync : ReturnMsg
	{
		private string _transactionId = "-1";
		private TransactionStatus _transactionStatus = TransactionStatus.sent;
		private string _callId;
		private string _message;
		private int? _objectID;

		/// <summary>
		/// Initializes a new instance of the <see cref="ReturnMsgAsync"/> class.
		/// </summary>
		public ReturnMsgAsync()
		{ }

		/// <summary>
		/// Initializes a new instance of the <see cref="ReturnMsgAsync"/> class.
		/// </summary>
		/// <param name="status">The status.</param>
		public ReturnMsgAsync(CreateObjectResult status)
		{
			Result = status;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ReturnMsgAsync"/> class.
		/// </summary>
		/// <param name="transactionId">The transaction id.</param>
		public ReturnMsgAsync(string transactionId)
		{
			_transactionId = transactionId;
		}

		public static ReturnMsgAsync Warning(string warningMessage)
		{
			ReturnMsgAsync msg = new ReturnMsgAsync(CreateObjectResult.Warning);
			msg.WarningMessage = warningMessage;
			return msg;
		}

		public static ReturnMsgAsync Exception(string exceptionMessage)
		{
			ReturnMsgAsync msg = new ReturnMsgAsync(CreateObjectResult.ExceptionOccured);
			msg.ExceptionMessage = exceptionMessage;
			return msg;
		}


		/// <summary>
		/// Gets or sets the transaction id.
		/// </summary>
		/// <value>The transaction id.</value>
		public string TransactionId
		{
			get { return _transactionId; }
			set { _transactionId = value; }
		}

		/// <summary>
		/// Gets the success.
		/// </summary>
		/// <value>The success.</value>
		public static ReturnMsgAsync Success
		{
			get
			{
				return new ReturnMsgAsync(CreateObjectResult.Success);
			}
		}

		/// <summary>
		/// Gets the exception occured.
		/// </summary>
		/// <value>The exception occured.</value>
		//public static ReturnMsgAsync ExceptionOccured
		//{
		//   get
		//   {
		//      return new ReturnMsgAsync(CreateObjectResult.ExceptionOccured);
		//   }
		//}

		/// <summary>
		/// Gets the warning.
		/// </summary>
		/// <value>The warning.</value>
		//public static ReturnMsgAsync Warning
		//{
		//   get
		//   {
		//      return new ReturnMsgAsync(CreateObjectResult.Warning);
		//   }
		//}

		#region Properties

		/// <summary>
		/// Gets or sets the transaction status.
		/// </summary>
		/// <value>The transaction status.</value>
		public TransactionStatus TransactionStatus
		{
			get
			{
				return _transactionStatus;
			}
			set
			{
				_transactionStatus = value;
			}
		}

		/// <summary>
		/// Gets or sets the call id.
		/// </summary>
		/// <value>The call id.</value>
		public string CallId
		{
			get { return _callId; }
			set { _callId = value; }
		}

		/// <summary>
		/// Gets or sets the message.
		/// </summary>
		/// <value>The message.</value>
		public string Message
		{
			get { return _message; }
			set { _message = value; }
		}

		/// <summary>
		/// Gets or sets the Object ID.
		/// </summary>
		/// <value>The Object ID</value>
		public int? ObjectID
		{
			get { return _objectID; }
			set { _objectID = value; }
		}
		#endregion
	}
}
