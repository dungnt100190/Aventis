using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.SAP.PSCD.BLL;
using KiSSSvc.DAL;
using KiSSSvc.SAP.PSCD.WebServiceHelper.TransactionControl;
using KiSSSvc.SAP.PSCD.WebServiceHelper;
using DTO = KiSSSvc.SAP.Helpers.DataObjects;
using System.Threading;

namespace KiSSSvc.SAP.PSCD.BudgetData
{
	class AsyncToSync
	{
		private const int MAX_WAIT_CYCLES = 20;
		private const int WAIT_TIME_MS = 2000;

        public ReturnMsg MahnlaufStarten(DTO.MahnungBeleg[] mahnungBelege, DateTime austellungsDatum, DateTime zahlungBeruecksichtigt, UserInfo userInfo)
        {
            MahnlaufStartenAsync mahnlaufStarten = new MahnlaufStartenAsync();
            ReturnMsgAsync startMsg = mahnlaufStarten.MahnlaufStarten(mahnungBelege, austellungsDatum, zahlungBeruecksichtigt, userInfo);

            return WaitForTransaction(startMsg);
        }

		public ReturnMsg CreateAndSubmitBusinessPartnerPerson(int baPersonID, UserInfo userInfo)
		{
			StammdatenAsync stammdaten = new StammdatenAsync();
			ReturnMsgAsync startMsg = stammdaten.CreateAndSubmitBusinessPartnerPerson(baPersonID, userInfo);

			return WaitForTransaction(startMsg);
		}

		public ReturnMsg CreateAndSubmitBusinessPartnerInstitution(int baInstitutionID, UserInfo userInfo)
		{
			StammdatenAsync stammdaten = new StammdatenAsync();
			ReturnMsgAsync startMsg = stammdaten.CreateAndSubmitBusinessPartnerInstitution(baInstitutionID, userInfo);

			return WaitForTransaction(startMsg);
		}

		public ReturnMsg ModifyBusinessPartnerPerson(KiSSDB.BaPersonRow person, KiSSDB.BaAdresseRow adresse, UserInfo userInfo)
		{
			StammdatenMutierenAsync stammdaten = new StammdatenMutierenAsync();
			ReturnMsgAsync startMsg = stammdaten.ModifyBusinessPartnerPerson(person, adresse, userInfo);

			return WaitForTransaction(startMsg);
		}

		public ReturnMsg ModifyBusinessPartnerInstitution(KiSSDB.BaInstitutionRow institution, KiSSDB.BaAdresseRow adresse, UserInfo userInfo)
		{
			StammdatenMutierenAsync stammdaten = new StammdatenMutierenAsync();
			ReturnMsgAsync startMsg = stammdaten.ModifyBusinessPartnerInstitution(institution, adresse, userInfo);

			return WaitForTransaction(startMsg);
		}

		//public CreateObjectResult SubmitLeistungen(int[] faLeistungIDs, UserInfo user, ref string warningMsg)
		//{
		//   VertragsgegenständeAsync vg = new VertragsgegenständeAsync();
		//   ReturnMsgAsync startMsg = vg.SubmitLeistungen(faLeistungIDs, user, ref warningMsg);

		//   return WaitForTransaction(startMsg);
		//}

		#region Private Methods

		private static ReturnMsg WaitForTransaction(ReturnMsgAsync startMsg)
		{
			if (startMsg.TransactionStatus != TransactionStatus.sent)
			{
				ReturnMsg msg = new ReturnMsg();
				msg.Result = startMsg.Result;
				msg.WarningMessage = startMsg.WarningMessage;
				msg.ExceptionMessage = startMsg.ExceptionMessage;
				return msg;
			}
			else
			{
				//now wait for answer
				int cylesLeft = MAX_WAIT_CYCLES;
				string transactionID = startMsg.TransactionId;
				try
				{
					while (!CheckTransactionCompleted(transactionID))
					{
						if (--cylesLeft <= 0)
							Thread.Sleep(WAIT_TIME_MS);
						else
							throw new Exception(string.Format("Timeout, keine Antwort von XI nach {0}s für Transaktion {1}", MAX_WAIT_CYCLES * WAIT_TIME_MS / 1000, transactionID));
					}
					ReturnMsg msg = new ReturnMsg();
					msg.Result = CreateObjectResult.Success;
					msg.WarningMessage = startMsg.WarningMessage;
					msg.ExceptionMessage = startMsg.ExceptionMessage;
					return msg;
				}
				catch (Exception ex)
				{
					ReturnMsg msg = new ReturnMsg();
					msg.Result = CreateObjectResult.ExceptionOccured;
					msg.ExceptionMessage = ex.Message;
					return msg;
				}
			}
		}

		/// <summary>
		/// Delegates the check transaction completed direct db connect.
		/// </summary>
		/// <param name="transactionId">The transaction id.</param>
		/// <returns></returns>
		private static bool CheckTransactionCompleted(string transactionId)
		{
			KiSSDB.XTransactionTableRow transactionRow = XTransactionBLL.GetTransactionForTransactionId(transactionId);
			if (transactionRow == null)
				throw new Exception(string.Format("No Transaction found with ID: '{0}'", transactionId));

			string status = transactionRow.Status;
			string message = transactionRow.Message;

			if (status.Equals(TransactionStatus.sent.ToString()))
				return false;
			else if (status.Equals(TransactionStatus.successful.ToString()))
				return true;
			else if (status.Equals(TransactionStatus.error.ToString()))
				throw new Exception("Fehler gemeldet von XI: " + message);
			else if (status.Equals(TransactionStatus.warning.ToString()))
				throw new Exception("Warnung gemeldet von XI: " + message);
			else if (status.Equals(TransactionStatus.expired.ToString()))
				throw new Exception(string.Format("Timeout für Transaktion {0}", transactionId));

			throw new Exception(string.Format("Unbekannter Status: '{0}'", status));
		}

		#endregion
	}
}
