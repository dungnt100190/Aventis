using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using KiSSSvc.SAP.Helpers.DataObjects;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using KiSSSvc.SAP.PSCD.WebServiceHelper.TransactionControl;

namespace KiSSSvc.SAP.PSCD.Notification.Utils
{
	/// <summary>
	/// Preprocessor for Buchung Response Objects
	/// </summary>
	public class BuchungResponseObjectPreprocessor
	{

		/// <summary>
		/// Processes the response.
		/// </summary>
		/// <param name="TRANSACTIONID">The TRANSACTIONID.</param>
		/// <param name="item">The item.</param>
		internal void ProcessResponse(string transactionID, NotificationBelegeObjects.T_DOCUMENTS[] items)
		{
			long belegNr;
			foreach (NotificationBelegeObjects.T_DOCUMENTS beleg in items)
			{
				if (long.TryParse(beleg.DocumentNumber, out belegNr))
				{
					//ParseMessages(ref )

					IList<String> errorMessages = ExtractErrorMessages(beleg.T_RETURN_MESSAGES);


					//bool foundErrors = CheckHasErrors(documentNumbers, errorMessages, out errorMessage);

					//TerminateTransaction(transactionID, foundErrors, errorMessage);

				}
			}

			//IEnumerator enumBuchstoff = item.GetEnumerator();
			//while (enumBuchstoff.MoveNext())
			//{
			//   NotificationBelegeObjects._STZH_KISS_BUCHSTOFF itemBuchstoff = (NotificationBelegeObjects._STZH_KISS_BUCHSTOFF)enumBuchstoff.Current;

			//   NotificationBelegeObjects._STZH_T_BAPIDFKKOP partnerPos = itemBuchstoff.T_PARTNERPOSITIONS;
			//   IList<String> documentNumbers = ExtractDocumentNumbers(partnerPos);

			//   NotificationBelegeObjects._STZH_T_BAPIRET2 retMessages = itemBuchstoff.T_RETURN_MESSAGES;
			//   IList<String> errorMessages = ExtractErrorMessages(retMessages);

			//   String errorMessage = null;

			//   bool foundErrors = CheckHasErrors(documentNumbers, errorMessages, out errorMessage);

			//   TerminateTransaction(TRANSACTIONID, foundErrors, errorMessage);

			//}
		}

		#region Internal Business Logic

		/// <summary>
		/// Terminates the transaction.
		/// </summary>
		/// <param name="transactionId">The transaction id.</param>
		/// <param name="hasErrors">if set to <c>true</c> [has errors].</param>
		/// <param name="errorMessage">The error message.</param>
		private void TerminateTransaction(String transactionId, bool hasErrors, String errorMessage)
		{
			TransactionControlService.Instance.SetTransactionReturnedFromSap(transactionId, !hasErrors, errorMessage);
		}

		/// <summary>
		/// Checks the has errors.
		/// </summary>
		/// <param name="documentNumbers">The document numbers.</param>
		/// <param name="errorMessages">The error messages.</param>
		/// <param name="errorDescription">The error description.</param>
		/// <returns></returns>
		//private bool CheckHasErrors(IList<String> documentNumbers, IList<String> errorMessages, out String errorDescription)
		//{
		//   bool foundError = false;
		//   StringBuilder strBuilder = new StringBuilder();

		//   int countErrorMessages = errorMessages.Count;
		//   int i = 0;
		//   foreach (String docNo in documentNumbers)
		//   {
		//      if (countErrorMessages > i)
		//      {
		//         String errorMessage = errorMessages[i];
		//         if (!String.IsNullOrEmpty(errorMessage))
		//         {
		//            foundError = true;
		//            strBuilder.Append(errorMessage + "\n");
		//         }
		//      }
		//      else
		//      {
		//         break;
		//      }
		//      i++;
		//   }

		//   if (foundError)
		//   {
		//      errorDescription = strBuilder.ToString();
		//   }
		//   else
		//   {
		//      errorDescription = null;
		//   }

		//   return foundError;
		//}


		/// <summary>
		/// Extracts the error messaged.
		/// </summary>
		/// <param name="retMessages">The ret messages.</param>
		/// <returns></returns>
		private IList<String> ExtractErrorMessages(BAPIRET2[] retMessages)
		{
			IList<String> errorMessages = new List<String>();
			foreach (BAPIRET2 msg in retMessages)
			{
				string returnMessage = msg.MESSAGE;
				if (!string.IsNullOrEmpty(returnMessage.Trim()))
				{
					errorMessages.Add(returnMessage);
				}
				else
				{
					errorMessages.Add(null);
				}
			}
			return errorMessages;
		}
		#endregion

	}
}
