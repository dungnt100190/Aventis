using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TriggerTrigger.WebReference;
using System.Net;

namespace TriggerTrigger
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			NotificationSvc svc = GetSvc();
			svc.NotifyAboutSAPDataReady("KLIENTEN_EINZAHL", 1);
		}

		private NotificationSvc GetSvc()
		{
			NotificationSvc svc = new NotificationSvc();
			if (!string.IsNullOrEmpty(edtProxy.Text))
				svc.Proxy = new WebProxy(edtProxy.Text, false);
			svc.Url = edtURL.Text;
			return svc;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			NotificationSvc svc = GetSvc();
			svc.NotifyAboutSAPDataReady("STADT_EINZAHL", 1);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			NotificationSvc svc = GetSvc();
			svc.NotifyAboutSAPDataReady("AUSGLEICH", 1);
		}

		private void btnInvalid_Click(object sender, EventArgs e)
		{
			NotificationSvc svc = GetSvc();
			svc.NotifyAboutSAPDataReady("QUATSCH", 1);
		}

		private void btnAusgleichLeichen_Click(object sender, EventArgs e)
		{
			NotificationSvc svc = GetSvc();
			svc.NotifyAboutSAPDataReady("AUSGLEICH_LEICHEN", 1);
		}

        private void button4_Click(object sender, EventArgs e)
        {
            NotificationSvc svc = GetSvc();
            svc.NotifyAboutSAPDataReady("WV_STATUS", 1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NotificationSvc svc = GetSvc();
            svc.NotifyAboutSAPDataReady("USER_SENDEN", 1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NotificationSvc svc = GetSvc();
            svc.NotifyAboutSAPDataReady("KLIENTEN_SALDO_LESEN", 1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            NotificationSvc svc = GetSvc();
            svc.NotifyAboutSAPDataReady("MAHNUNG_LESEN", 1);
        }
	}
}