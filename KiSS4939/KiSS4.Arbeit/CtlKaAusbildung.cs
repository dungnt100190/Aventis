using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    public partial class CtlKaAusbildung : KissUserControl
    {
        private int _faLeistungID;

        public CtlKaAusbildung()
        {
            InitializeComponent();
        }

        public void Init(string maskName, Image maskImage, int faLeistungID, int baPersonID)
        {
            _faLeistungID = faLeistungID;

            lblTitle.Text = maskName;
            imageTitle.Image = maskImage;
            qryKaAusbildung.Fill(_faLeistungID);
        }

        private void qryKaAusbildung_AfterInsert(object sender, EventArgs e)
        {
            qryKaAusbildung["FaLeistungID"] = _faLeistungID;
        }
    }
}