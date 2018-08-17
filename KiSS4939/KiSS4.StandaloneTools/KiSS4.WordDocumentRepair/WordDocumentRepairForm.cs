using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KiSS4.DB;
using KiSS4.Dokument;

namespace KiSS4.WordDocumentRepair
{
    public partial class WordDocumentRepairForm : Form
    {
        public WordDocumentRepairForm()
        {
            InitializeComponent();
            Session.MainForm = this;
        }
    }
}
