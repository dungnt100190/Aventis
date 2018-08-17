using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using KiSSSvc.SVA;
using Microsoft.Win32.SafeHandles;

namespace ReportDesignerStandalone
{
    public partial class ReportDesignerStandalone : Form
    {
        public ReportDesignerStandalone()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new XRDesignFormEx();

            form.OpenReport(new IKAuszug());
            form.ShowDialog(this);

            MemoryStream newStream = new MemoryStream();
            form.DesignPanel.Report.SaveLayout(newStream);
            newStream.Position = 0; //required!
            StreamReader sr = new StreamReader(newStream);
            textBox1.Text = sr.ReadToEnd();
        }

        ///// <summary>
        ///// Gets the Report being designed
        ///// </summary>
        //[Browsable(false)]
        //public DevExpress.XtraReports.UI.XtraReport Report
        //{
        //    get { return xrDesignPanel.Report; }
        //}

        ///// <summary>
        ///// Gets the ReportState of the report being designed
        ///// </summary>
        //[Browsable(false)]
        //public DevExpress.XtraReports.UserDesigner.ReportState ReportState
        //{
        //    get { return xrDesignPanel.ReportState; }
        //}
    }
}