using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using KiSSSvc.SAP.PSCD.BusinessPartner;
using KiSSSvc.SAP.PSCD.BudgetData;
using System.Web;
using System.Net;
using KiSSSvc.SAP.PSCD.WebServiceHelper;
using KiSSSvc.SAP.Helpers;
//using KiSSSvc.Common.Settings;
using KiSSSvc.Test.TestGUI.NotificationWebReference;
using KiSSSvc.SAP.PSCD.KiSSClientInterface;
using KiSSSvc.Test.TestGUI.SettlementInfoReference;
using KiSSSvc.SAP.PSCD.WebServiceHelper.Settings;
using KiSSSvc.SAP.PSCD.InfoFetcher;

namespace KiSSToPSCDServerComponent_TestGUI
{
	public partial class TestForm : Form
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.Run(new TestForm());
		}

		public TestForm()
		{
			InitializeComponent();
			WebServiceHelperMethods.GetSettings().PSCDUseMock = edtUseMock.Checked;
			ReadSettings();
		}

		private void ReadSettings()
		{
			SettingsAccessor settings = WebServiceHelperMethods.GetSettings();
			txtUser.Text = settings.PSCDUserName;
			txtPassword.Text = settings.PSCDPassword;
			txtProxy.Text = settings.PSCDProxy;
			edtUseMock.Checked = settings.PSCDUseMock;
			txtServerUrl.Text = settings.PSCDServerUrl;
			//txtServiceLocation.Text = settings.PSCDLocationBusinessPartner;
		}

		private void btnTest_Click(object sender, System.EventArgs e)
		{
			try
			{
				lblBusy.Visible = true;
				Application.DoEvents();

				//btnSetSettings_Click( null, System.EventArgs.Empty );
				Stammdaten bps = new Stammdaten();
				string externalKey = edtExternalKey.Text;
				string bankID = edtBankID.Text;
				string str = "";
				if (sender == btnNormal)
				{
					//str = bps.CreateAndSubmitBusinessPartnerPersonData("Quasimodo", "Meyer", new DateTime(1930, 7, 7), "Gloecknerstrasse", 333, "f", 1003, "Lausanne", "CH", Language.DE, externalKey, BU_BPCATEGORY.NatuerlichePerson, BU_BPKIND.Person, BU_BPGROUP.Personen, AD_TITLE.Herr, Language.DE, bankID, BU_SEX.Männlich, externalKey, bankID);
				}
				else if (sender == btnUmlaute)
				{
					//str = bps.CreateAndSubmitBusinessPartnerPersonData("Françoise", "Müller", new DateTime(1940, 8, 8), "Rue du Rhône", 444, "z", 1204, "Genève", "CH", Language.FR, externalKey, BU_BPCATEGORY.NatuerlichePerson, BU_BPKIND.Person, BU_BPGROUP.Personen, AD_TITLE.Herr, Language.FR, bankID, BU_SEX.Männlich, externalKey, bankID);
				}
				txtAnswer.Text = str;

			}
			catch (HttpException httpEx)
			{
				txtAnswer.Text = string.Format("Exception occured:\r\nHttpCode: {0}\r\n\r\n{1}\r\n{2}", httpEx.GetHttpCode(), httpEx.Message, httpEx.StackTrace);
				Exception exInner = httpEx.InnerException;
				while (exInner != null)
				{
					txtAnswer.Text += "\r\n--\r\n" + exInner.Message;
					exInner = exInner.InnerException;
				}
			}
			catch (WebException webEx)
			{
				string output = string.Format("Exception occured:\r\nType: {1}\r\nStatus: {0}\r\nResponseUri:{2}\r\n\r\n", webEx.Status, webEx.GetType(), webEx.Response == null ? "(Response is null)" : webEx.Response.ResponseUri.AbsoluteUri);
				HttpWebResponse response = webEx.Response as HttpWebResponse;
				if (response != null)
				{
					if (response.StatusCode == HttpStatusCode.Unauthorized)
					{
						output += "Authentifizierung nötig";
					}
					else
					{
						output += string.Format("HttpStatusCode: {0}", response.StatusCode);
					}
				}
				output += "Headers:\r\n";
				if (webEx.Response == null)
				{
					output += "(Response is null)";
				}
				else
				{
					foreach (string key in webEx.Response.Headers.Keys)
					{
						output += string.Format("{0} = {1}\r\n", key, webEx.Response.Headers[key]);
					}
				}
				output += string.Format("\r\nMessage:\r\n{0}\r\n\r\nStackTrace:\r\n{1}", webEx.Message, webEx.StackTrace);
				Exception exInner = webEx.InnerException;
				while (exInner != null)
				{
					output += "\r\n--\r\n" + exInner.Message;
					exInner = exInner.InnerException;
				}
				txtAnswer.Text = output;
			}
			catch (System.Web.Services.Protocols.SoapException soapEx)
			{
				string output = string.Format("SoapException occured:\r\nType: {0}\r\nCode: {1}\r\nActor: {2}\r\nDetail:{3}\r\n\r\n", soapEx.GetType(), soapEx.Code, soapEx.Actor, soapEx.Detail);
				output += string.Format("\r\nMessage:\r\n{0}\r\n\r\nStackTrace:\r\n{1}", soapEx.Message, soapEx.StackTrace);
				Exception exInner = soapEx.InnerException;
				while (exInner != null)
				{
					output += "\r\n--\r\n" + exInner.Message;
					exInner = exInner.InnerException;
				}
				txtAnswer.Text = output;
			}
			catch (Exception ex)
			{
				txtAnswer.Text = string.Format("Exception occured:\r\nType: {0}\r\n\r\n Message:\r\n{1}\r\nStackTrace: {2}", ex.GetType(), ex.Message, ex.StackTrace);
				Exception exInner = ex.InnerException;
				while (exInner != null)
				{
					txtAnswer.Text += "\r\n--\r\n" + exInner.Message;
					exInner = exInner.InnerException;
				}
			}
			finally
			{
				lblBusy.Visible = false;
			}

		}

		private void btnSetSettings_Click(object sender, System.EventArgs e)
		{
			SettingsAccessor settings = WebServiceHelperMethods.GetSettings();
			if (txtServerUrl.Text.Length > 0)
			{
				settings.PSCDServerUrl = txtServerUrl.Text;
			}
			if (txtServiceLocation.Text.Length > 0)
			{
				//settings.PSCDLocationBusinessPartner = txtServiceLocation.Text;
			}
			// user / password
			if (txtUser.Text.Trim().Length > 0 && txtPassword.Text.Trim().Length > 0)
			{
				//settings.UserName = txtUser.Text;
				//settings.Password = txtPassword.Text;
			}
			// proxy
			//settings.Proxy = txtProxy.Text;
		}

		private void edtUseMock_CheckedChanged(object sender, EventArgs e)
		{
			WebServiceHelperMethods.GetSettings().PSCDUseMock = edtUseMock.Checked;
			ReadSettings();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				lblBusy.Visible = true;
				Application.DoEvents();

				//btnSetSettings_Click( null, System.EventArgs.Empty );
				Stammdaten bds = new Stammdaten();
				string externalKey = edtExternalKey.Text;
				string bankID = edtBankID.Text;
				string str = "";
				//str = bds.CreateAndSubmitBusinessPartnerPersonData("Quasimodo", "Meyer", new DateTime(1930, 7, 7), "Gloecknerstrasse", 333, "f", 1003, "Lausanne", "CH", Language.DE, externalKey, BU_BPCATEGORY.NatuerlichePerson, BU_BPKIND.Person, BU_BPGROUP.Personen, AD_TITLE.Herr, Language.DE, bankID, BU_SEX.Männlich, edtLEKey.Text, edtIBAN.Text);
				txtAnswer.Text = str;

			}
			catch (HttpException httpEx)
			{
				txtAnswer.Text = string.Format("Exception occured:\r\nHttpCode: {0}\r\n\r\n{1}\r\n{2}", httpEx.GetHttpCode(), httpEx.Message, httpEx.StackTrace);
				Exception exInner = httpEx.InnerException;
				while (exInner != null)
				{
					txtAnswer.Text += "\r\n--\r\n" + exInner.Message;
					exInner = exInner.InnerException;
				}
			}
			catch (WebException webEx)
			{
				string output = string.Format("Exception occured:\r\nType: {1}\r\nStatus: {0}\r\nResponseUri:{2}\r\n\r\n", webEx.Status, webEx.GetType(), webEx.Response == null ? "(Response is null)" : webEx.Response.ResponseUri.AbsoluteUri);
				HttpWebResponse response = webEx.Response as HttpWebResponse;
				if (response != null)
				{
					if (response.StatusCode == HttpStatusCode.Unauthorized)
					{
						output += "Authentifizierung nötig";
					}
					else
					{
						output += string.Format("HttpStatusCode: {0}", response.StatusCode);
					}
				}
				output += "Headers:\r\n";
				if (webEx.Response == null)
				{
					output += "(Response is null)";
				}
				else
				{
					foreach (string key in webEx.Response.Headers.Keys)
					{
						output += string.Format("{0} = {1}\r\n", key, webEx.Response.Headers[key]);
					}
				}
				output += string.Format("\r\nMessage:\r\n{0}\r\n\r\nStackTrace:\r\n{1}", webEx.Message, webEx.StackTrace);
				Exception exInner = webEx.InnerException;
				while (exInner != null)
				{
					output += "\r\n--\r\n" + exInner.Message;
					exInner = exInner.InnerException;
				}
				txtAnswer.Text = output;
			}
			catch (System.Web.Services.Protocols.SoapException soapEx)
			{
				string output = string.Format("SoapException occured:\r\nType: {0}\r\nCode: {1}\r\nActor: {2}\r\nDetail:{3}\r\n\r\n", soapEx.GetType(), soapEx.Code, soapEx.Actor, soapEx.Detail);
				output += string.Format("\r\nMessage:\r\n{0}\r\n\r\nStackTrace:\r\n{1}", soapEx.Message, soapEx.StackTrace);
				Exception exInner = soapEx.InnerException;
				while (exInner != null)
				{
					output += "\r\n--\r\n" + exInner.Message;
					exInner = exInner.InnerException;
				}
				txtAnswer.Text = output;
			}
			catch (Exception ex)
			{
				txtAnswer.Text = string.Format("Exception occured:\r\nType: {0}\r\n\r\n Message:\r\n{1}\r\nStackTrace: {2}", ex.GetType(), ex.Message, ex.StackTrace);
				Exception exInner = ex.InnerException;
				while (exInner != null)
				{
					txtAnswer.Text += "\r\n--\r\n" + exInner.Message;
					exInner = exInner.InnerException;
				}
			}
			finally
			{
				lblBusy.Visible = false;
			}


		}

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				lblBusy.Visible = true;
				Application.DoEvents();

				//btnSetSettings_Click( null, System.EventArgs.Empty );
				NotificationSvc svc = new NotificationSvc();
				//KiSSSvc.SAP.PSCD.Notification.NotificationSvc svc = new KiSSSvc.SAP.PSCD.Notification.NotificationSvc();
				if (!string.IsNullOrEmpty(txtProxy.Text))
				{
					svc.Proxy = new WebProxy(txtProxy.Text, false);
				}
				svc.Url = edtNotificationLocation.Text;
				string externalKey = edtExternalKey.Text;
				string str = svc.NotifyAboutSAPDataReady("type", int.Parse(externalKey));
				txtAnswer.Text = str;

			}
			catch (HttpException httpEx)
			{
				txtAnswer.Text = string.Format("Exception occured:\r\nHttpCode: {0}\r\n\r\n{1}\r\n{2}", httpEx.GetHttpCode(), httpEx.Message, httpEx.StackTrace);
				Exception exInner = httpEx.InnerException;
				while (exInner != null)
				{
					txtAnswer.Text += "\r\n--\r\n" + exInner.Message;
					exInner = exInner.InnerException;
				}
			}
			catch (WebException webEx)
			{
				string output = string.Format("Exception occured:\r\nType: {1}\r\nStatus: {0}\r\nResponseUri:{2}\r\n\r\n", webEx.Status, webEx.GetType(), webEx.Response == null ? "(Response is null)" : webEx.Response.ResponseUri.AbsoluteUri);
				HttpWebResponse response = webEx.Response as HttpWebResponse;
				if (response != null)
				{
					if (response.StatusCode == HttpStatusCode.Unauthorized)
					{
						output += "Authentifizierung nötig";
					}
					else
					{
						output += string.Format("HttpStatusCode: {0}", response.StatusCode);
					}
				}
				output += "Headers:\r\n";
				if (webEx.Response == null)
				{
					output += "(Response is null)";
				}
				else
				{
					foreach (string key in webEx.Response.Headers.Keys)
					{
						output += string.Format("{0} = {1}\r\n", key, webEx.Response.Headers[key]);
					}
				}
				output += string.Format("\r\nMessage:\r\n{0}\r\n\r\nStackTrace:\r\n{1}", webEx.Message, webEx.StackTrace);
				Exception exInner = webEx.InnerException;
				while (exInner != null)
				{
					output += "\r\n--\r\n" + exInner.Message;
					exInner = exInner.InnerException;
				}
				txtAnswer.Text = output;
			}
			catch (System.Web.Services.Protocols.SoapException soapEx)
			{
				string output = string.Format("SoapException occured:\r\nType: {0}\r\nCode: {1}\r\nActor: {2}\r\nDetail:{3}\r\n\r\n", soapEx.GetType(), soapEx.Code, soapEx.Actor, soapEx.Detail);
				output += string.Format("\r\nMessage:\r\n{0}\r\n\r\nStackTrace:\r\n{1}", soapEx.Message, soapEx.StackTrace);
				Exception exInner = soapEx.InnerException;
				while (exInner != null)
				{
					output += "\r\n--\r\n" + exInner.Message;
					exInner = exInner.InnerException;
				}
				txtAnswer.Text = output;
			}
			catch (Exception ex)
			{
				txtAnswer.Text = string.Format("Exception occured:\r\nType: {0}\r\n\r\n Message:\r\n{1}\r\nStackTrace: {2}", ex.GetType(), ex.Message, ex.StackTrace);
				Exception exInner = ex.InnerException;
				while (exInner != null)
				{
					txtAnswer.Text += "\r\n--\r\n" + exInner.Message;
					exInner = exInner.InnerException;
				}
			}
			finally
			{
				lblBusy.Visible = false;
			}


		}

		private void button3_Click(object sender, EventArgs e)
		{
			try
			{
				lblBusy.Visible = true;
				Application.DoEvents();

				//btnSetSettings_Click( null, System.EventArgs.Empty );
				Buchungsstoff bss = new Buchungsstoff();
				string externalKey = edtExternalKey.Text;
				string bankID = edtBankID.Text;
				string str = "";
				//str = bss.SubmitBuchungsstoff(int.Parse(edtBelegNr.Text), int.Parse(edtFiKey.Text), int.Parse(edtExternalKey.Text), int.Parse(edtAccount.Text), int.Parse(edtContract.Text));
				//bss.SubmitBuchungsstoff(int.Parse(edtExternalKey.Text), int.Parse(edtLEKey.Text), int.Parse(edtFiKey.Text));
				//bss.SubmitBudget(int.Parse(edtFiKey.Text), new UserInfo(-1,""),ref str);
				txtAnswer.Text = str;

			}
			catch (HttpException httpEx)
			{
				txtAnswer.Text = string.Format("Exception occured:\r\nHttpCode: {0}\r\n\r\n{1}\r\n{2}", httpEx.GetHttpCode(), httpEx.Message, httpEx.StackTrace);
				Exception exInner = httpEx.InnerException;
				while (exInner != null)
				{
					txtAnswer.Text += "\r\n--\r\n" + exInner.Message;
					exInner = exInner.InnerException;
				}
			}
			catch (WebException webEx)
			{
				string output = string.Format("Exception occured:\r\nType: {1}\r\nStatus: {0}\r\nResponseUri:{2}\r\n\r\n", webEx.Status, webEx.GetType(), webEx.Response == null ? "(Response is null)" : webEx.Response.ResponseUri.AbsoluteUri);
				HttpWebResponse response = webEx.Response as HttpWebResponse;
				if (response != null)
				{
					if (response.StatusCode == HttpStatusCode.Unauthorized)
					{
						output += "Authentifizierung nötig";
					}
					else
					{
						output += string.Format("HttpStatusCode: {0}", response.StatusCode);
					}
				}
				output += "Headers:\r\n";
				if (webEx.Response == null)
				{
					output += "(Response is null)";
				}
				else
				{
					foreach (string key in webEx.Response.Headers.Keys)
					{
						output += string.Format("{0} = {1}\r\n", key, webEx.Response.Headers[key]);
					}
				}
				output += string.Format("\r\nMessage:\r\n{0}\r\n\r\nStackTrace:\r\n{1}", webEx.Message, webEx.StackTrace);
				Exception exInner = webEx.InnerException;
				while (exInner != null)
				{
					output += "\r\n--\r\n" + exInner.Message;
					exInner = exInner.InnerException;
				}
				txtAnswer.Text = output;
			}
			catch (System.Web.Services.Protocols.SoapException soapEx)
			{
				string output = string.Format("SoapException occured:\r\nType: {0}\r\nCode: {1}\r\nActor: {2}\r\nDetail:{3}\r\n\r\n", soapEx.GetType(), soapEx.Code, soapEx.Actor, soapEx.Detail);
				output += string.Format("\r\nMessage:\r\n{0}\r\n\r\nStackTrace:\r\n{1}", soapEx.Message, soapEx.StackTrace);
				Exception exInner = soapEx.InnerException;
				while (exInner != null)
				{
					output += "\r\n--\r\n" + exInner.Message;
					exInner = exInner.InnerException;
				}
				txtAnswer.Text = output;
			}
			catch (Exception ex)
			{
				txtAnswer.Text = string.Format("Exception occured:\r\nType: {0}\r\n\r\n Message:\r\n{1}\r\nStackTrace: {2}", ex.GetType(), ex.Message, ex.StackTrace);
				Exception exInner = ex.InnerException;
				while (exInner != null)
				{
					txtAnswer.Text += "\r\n--\r\n" + exInner.Message;
					exInner = exInner.InnerException;
				}
			}
			finally
			{
				lblBusy.Visible = false;
			}
		}

		private void edtBelegNr_TextChanged(object sender, EventArgs e)
		{

		}
		private void btnKontoabfrage_Click(object sender, EventArgs e)
		{
		/*
			try
			{
				lblBusy.Visible = true;
				Application.DoEvents();

				//btnSetSettings_Click( null, System.EventArgs.Empty );
				KontenstandAbfrageService kss = new KontenstandAbfrageService();
				string externalKey = edtExternalKey.Text;
				string bankID = edtBankID.Text;
				string str = "";
				//kss.GetKontostand();// SubmitBuchungsstoff(int.Parse(edtBelegNr.Text), int.Parse(edtFiKey.Text), int.Parse(edtExternalKey.Text), int.Parse(edtAccount.Text), int.Parse(edtContract.Text));
				DataSet ds = kss.GetKontostand(int.Parse(edtExternalKey.Text), int.Parse(edtContract.Text), new DateTime(1900, 1, 1), true, true, true);
				MessageBox.Show(string.Format("DataSet is {0}null", ds == null ? "" : "not "));
				if (ds != null && ds.Tables.Count > 0)
				{
					gridView.DataSource = ds.Tables[0];
				}
				txtAnswer.Text = str;
			}
			catch (HttpException httpEx)
			{
				txtAnswer.Text = string.Format("Exception occured:\r\nHttpCode: {0}\r\n\r\n{1}\r\n{2}", httpEx.GetHttpCode(), httpEx.Message, httpEx.StackTrace);
				Exception exInner = httpEx.InnerException;
				while (exInner != null)
				{
					txtAnswer.Text += "\r\n--\r\n" + exInner.Message;
					exInner = exInner.InnerException;
				}
			}
			catch (WebException webEx)
			{
				string output = string.Format("Exception occured:\r\nType: {1}\r\nStatus: {0}\r\nResponseUri:{2}\r\n\r\n", webEx.Status, webEx.GetType(), webEx.Response == null ? "(Response is null)" : webEx.Response.ResponseUri.AbsoluteUri);
				HttpWebResponse response = webEx.Response as HttpWebResponse;
				if (response != null)
				{
					if (response.StatusCode == HttpStatusCode.Unauthorized)
					{
						output += "Authentifizierung nötig";
					}
					else
					{
						output += string.Format("HttpStatusCode: {0}", response.StatusCode);
					}
				}
				output += "Headers:\r\n";
				if (webEx.Response == null)
				{
					output += "(Response is null)";
				}
				else
				{
					foreach (string key in webEx.Response.Headers.Keys)
					{
						output += string.Format("{0} = {1}\r\n", key, webEx.Response.Headers[key]);
					}
				}
				output += string.Format("\r\nMessage:\r\n{0}\r\n\r\nStackTrace:\r\n{1}", webEx.Message, webEx.StackTrace);
				Exception exInner = webEx.InnerException;
				while (exInner != null)
				{
					output += "\r\n--\r\n" + exInner.Message;
					exInner = exInner.InnerException;
				}
				txtAnswer.Text = output;
			}
			catch (System.Web.Services.Protocols.SoapException soapEx)
			{
				string output = string.Format("SoapException occured:\r\nType: {0}\r\nCode: {1}\r\nActor: {2}\r\nDetail:{3}\r\n\r\n", soapEx.GetType(), soapEx.Code, soapEx.Actor, soapEx.Detail);
				output += string.Format("\r\nMessage:\r\n{0}\r\n\r\nStackTrace:\r\n{1}", soapEx.Message, soapEx.StackTrace);
				Exception exInner = soapEx.InnerException;
				while (exInner != null)
				{
					output += "\r\n--\r\n" + exInner.Message;
					exInner = exInner.InnerException;
				}
				txtAnswer.Text = output;
			}
			catch (Exception ex)
			{
				txtAnswer.Text = string.Format("Exception occured:\r\nType: {0}\r\n\r\n Message:\r\n{1}\r\nStackTrace: {2}", ex.GetType(), ex.Message, ex.StackTrace);
				Exception exInner = ex.InnerException;
				while (exInner != null)
				{
					txtAnswer.Text += "\r\n--\r\n" + exInner.Message;
					exInner = exInner.InnerException;
				}
			}
			finally
			{
				lblBusy.Visible = false;
			}
		*/
		}
		private void btnTestBpWs_Click(object sender, EventArgs e)
		{
			try
			{
				lblBusy.Visible = true;
				Application.DoEvents();

				//btnSetSettings_Click( null, System.EventArgs.Empty );
				//BudgetDataClientSvc svc = new BudgetDataClientSvc();
				//svc.CreateAndSubmitBusinessPartnerPersonData(null, int.Parse(edtExternalKey.Text));
				//txtAnswer.Text = str;

			}
			catch (HttpException httpEx)
			{
				txtAnswer.Text = string.Format("Exception occured:\r\nHttpCode: {0}\r\n\r\n{1}\r\n{2}", httpEx.GetHttpCode(), httpEx.Message, httpEx.StackTrace);
				Exception exInner = httpEx.InnerException;
				while (exInner != null)
				{
					txtAnswer.Text += "\r\n--\r\n" + exInner.Message;
					exInner = exInner.InnerException;
				}
			}
			catch (WebException webEx)
			{
				string output = string.Format("Exception occured:\r\nType: {1}\r\nStatus: {0}\r\nResponseUri:{2}\r\n\r\n", webEx.Status, webEx.GetType(), webEx.Response == null ? "(Response is null)" : webEx.Response.ResponseUri.AbsoluteUri);
				HttpWebResponse response = webEx.Response as HttpWebResponse;
				if (response != null)
				{
					if (response.StatusCode == HttpStatusCode.Unauthorized)
					{
						output += "Authentifizierung nötig";
					}
					else
					{
						output += string.Format("HttpStatusCode: {0}", response.StatusCode);
					}
				}
				output += "Headers:\r\n";
				if (webEx.Response == null)
				{
					output += "(Response is null)";
				}
				else
				{
					foreach (string key in webEx.Response.Headers.Keys)
					{
						output += string.Format("{0} = {1}\r\n", key, webEx.Response.Headers[key]);
					}
				}
				output += string.Format("\r\nMessage:\r\n{0}\r\n\r\nStackTrace:\r\n{1}", webEx.Message, webEx.StackTrace);
				Exception exInner = webEx.InnerException;
				while (exInner != null)
				{
					output += "\r\n--\r\n" + exInner.Message;
					exInner = exInner.InnerException;
				}
				txtAnswer.Text = output;
			}
			catch (System.Web.Services.Protocols.SoapException soapEx)
			{
				string output = string.Format("SoapException occured:\r\nType: {0}\r\nCode: {1}\r\nActor: {2}\r\nDetail:{3}\r\n\r\n", soapEx.GetType(), soapEx.Code, soapEx.Actor, soapEx.Detail);
				output += string.Format("\r\nMessage:\r\n{0}\r\n\r\nStackTrace:\r\n{1}", soapEx.Message, soapEx.StackTrace);
				Exception exInner = soapEx.InnerException;
				while (exInner != null)
				{
					output += "\r\n--\r\n" + exInner.Message;
					exInner = exInner.InnerException;
				}
				txtAnswer.Text = output;
			}
			catch (Exception ex)
			{
				txtAnswer.Text = string.Format("Exception occured:\r\nType: {0}\r\n\r\n Message:\r\n{1}\r\nStackTrace: {2}", ex.GetType(), ex.Message, ex.StackTrace);
				Exception exInner = ex.InnerException;
				while (exInner != null)
				{
					txtAnswer.Text += "\r\n--\r\n" + exInner.Message;
					exInner = exInner.InnerException;
				}
			}
			finally
			{
				lblBusy.Visible = false;
			}
		}

		private void btnTestSettlement_Click(object sender, EventArgs e)
		{
			try
			{
				lblBusy.Visible = true;
				Application.DoEvents();

				//btnSetSettings_Click( null, System.EventArgs.Empty );
				SettlementInfo svc = new SettlementInfo();
				svc.Url = edtSettlementLocation.Text;
				string externalKey = edtExternalKey.Text;
				string bankID = edtBankID.Text;
				string str = "";
				str = svc.NotifyAboutSettlement("123456", "234567", "345678", DateTime.Now, DateTime.Now + new TimeSpan(1, 0, 0, 0), 313.50m, "456789", "weil wir testen");
				txtAnswer.Text = str;

			}
			catch (HttpException httpEx)
			{
				txtAnswer.Text = string.Format("Exception occured:\r\nHttpCode: {0}\r\n\r\n{1}\r\n{2}", httpEx.GetHttpCode(), httpEx.Message, httpEx.StackTrace);
				Exception exInner = httpEx.InnerException;
				while (exInner != null)
				{
					txtAnswer.Text += "\r\n--\r\n" + exInner.Message;
					exInner = exInner.InnerException;
				}
			}
			catch (WebException webEx)
			{
				string output = string.Format("Exception occured:\r\nType: {1}\r\nStatus: {0}\r\nResponseUri:{2}\r\n\r\n", webEx.Status, webEx.GetType(), webEx.Response == null ? "(Response is null)" : webEx.Response.ResponseUri.AbsoluteUri);
				HttpWebResponse response = webEx.Response as HttpWebResponse;
				if (response != null)
				{
					if (response.StatusCode == HttpStatusCode.Unauthorized)
					{
						output += "Authentifizierung nötig";
					}
					else
					{
						output += string.Format("HttpStatusCode: {0}", response.StatusCode);
					}
				}
				output += "Headers:\r\n";
				if (webEx.Response == null)
				{
					output += "(Response is null)";
				}
				else
				{
					foreach (string key in webEx.Response.Headers.Keys)
					{
						output += string.Format("{0} = {1}\r\n", key, webEx.Response.Headers[key]);
					}
				}
				output += string.Format("\r\nMessage:\r\n{0}\r\n\r\nStackTrace:\r\n{1}", webEx.Message, webEx.StackTrace);
				Exception exInner = webEx.InnerException;
				while (exInner != null)
				{
					output += "\r\n--\r\n" + exInner.Message;
					exInner = exInner.InnerException;
				}
				txtAnswer.Text = output;
			}
			catch (System.Web.Services.Protocols.SoapException soapEx)
			{
				string output = string.Format("SoapException occured:\r\nType: {0}\r\nCode: {1}\r\nActor: {2}\r\nDetail:{3}\r\n\r\n", soapEx.GetType(), soapEx.Code, soapEx.Actor, soapEx.Detail);
				output += string.Format("\r\nMessage:\r\n{0}\r\n\r\nStackTrace:\r\n{1}", soapEx.Message, soapEx.StackTrace);
				Exception exInner = soapEx.InnerException;
				while (exInner != null)
				{
					output += "\r\n--\r\n" + exInner.Message;
					exInner = exInner.InnerException;
				}
				txtAnswer.Text = output;
			}
			catch (Exception ex)
			{
				txtAnswer.Text = string.Format("Exception occured:\r\nType: {0}\r\n\r\n Message:\r\n{1}\r\nStackTrace: {2}", ex.GetType(), ex.Message, ex.StackTrace);
				Exception exInner = ex.InnerException;
				while (exInner != null)
				{
					txtAnswer.Text += "\r\n--\r\n" + exInner.Message;
					exInner = exInner.InnerException;
				}
			}
			finally
			{
				lblBusy.Visible = false;
			}
		}

		private void btnTestSettlementFetcher_Click(object sender, EventArgs e)
		{
			SettlementInfoFetcher adapter = new SettlementInfoFetcher();
			adapter.FetchSettlementInfo(false);
		}

	}
}