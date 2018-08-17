using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

namespace KiSS4.Arbeit
{
    public partial class CtlKaQJBildung : KissUserControl
    {
        #region Fields

        #region Private Fields

        private int _baPersonID;
        private int _faLeistungID;

        #endregion

        #endregion

        #region Constructors

        public CtlKaQJBildung()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void qryKaQJBildung_BeforePost(object sender, EventArgs e)
        {
            qryKaQJBildung.SetModifierModified();
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Init(string maskName, Image maskImage, int FaLeistungID, int BaPersonID)
        {
            this.lblTitle.Text = maskName;
            this.imageTitle.Image = maskImage;
            _faLeistungID = FaLeistungID;
            _baPersonID = BaPersonID;

            SetupDataSource();
            SetupDataMember();

            SetupEditMode();
            FillQuery();
        }

        #endregion

        #region Private Methods

        private bool BildungExists()
        {
            bool? exists = DBUtil.ExecuteScalarSQL(@"
                SELECT CONVERT(BIT, ISNULL((SELECT TOP 1 1
                FROM dbo.KaQJBildung QJB
                WHERE QJB.FaLeistungID = {0}), 0))", _faLeistungID) as bool?;

            return exists.HasValue ? exists.Value : false;
        }

        private void FillQuery()
        {
            if (!BildungExists() && qryKaQJBildung.CanInsert && qryKaQJBildung.CanUpdate)
            {
                DBUtil.ExecSQL(@"
                  INSERT INTO KaQJBildung (FaLeistungID, SichtbarSDFlag, Creator, Modifier)
                  VALUES ({0}, {1}, {2}, {2})",
                               _faLeistungID, KaUtil.IsVisibleSD(_baPersonID), DBUtil.GetDBRowCreatorModifier());
            }

            qryKaQJBildung.Fill(_faLeistungID, Session.User.IsUserKA ? 0 : 1);
        }

        private void SetupDataMember()
        {
            chkKursBewerbung.DataMember = DBO.KaQJBildung.KursBewerbungFlag;
            chkKursInformatik.DataMember = DBO.KaQJBildung.KursInformatikFlag;
            chkKursVideo.DataMember = DBO.KaQJBildung.KursVideoFlag;
            chkKursWissen.DataMember = DBO.KaQJBildung.KursWissenFlag;
            chkKursCustom1.DataMember = DBO.KaQJBildung.KursCustom1Flag;
            chkKursCustom2.DataMember = DBO.KaQJBildung.KursCustom2Flag;
            chkKursCustom3.DataMember = DBO.KaQJBildung.KursCustom3Flag;
            chkKursCustom4.DataMember = DBO.KaQJBildung.KursCustom4Flag;
            chkKursCustom5.DataMember = DBO.KaQJBildung.KursCustom5Flag;
            chkKursCustom6.DataMember = DBO.KaQJBildung.KursCustom6Flag;
            edtKursCustom1.DataMember = DBO.KaQJBildung.KursCustom1Text;
            edtKursCustom2.DataMember = DBO.KaQJBildung.KursCustom2Text;
            edtKursCustom3.DataMember = DBO.KaQJBildung.KursCustom3Text;
            edtKursCustom4.DataMember = DBO.KaQJBildung.KursCustom4Text;
            edtKursCustom5.DataMember = DBO.KaQJBildung.KursCustom5Text;
            edtKursCustom6.DataMember = DBO.KaQJBildung.KursCustom6Text;
        }

        private void SetupDataSource()
        {
            chkKursBewerbung.DataSource = qryKaQJBildung;
            chkKursInformatik.DataSource = qryKaQJBildung;
            chkKursVideo.DataSource = qryKaQJBildung;
            chkKursWissen.DataSource = qryKaQJBildung;
            chkKursCustom1.DataSource = qryKaQJBildung;
            chkKursCustom2.DataSource = qryKaQJBildung;
            chkKursCustom3.DataSource = qryKaQJBildung;
            chkKursCustom4.DataSource = qryKaQJBildung;
            chkKursCustom5.DataSource = qryKaQJBildung;
            chkKursCustom6.DataSource = qryKaQJBildung;
            edtKursCustom1.DataSource = qryKaQJBildung;
            edtKursCustom2.DataSource = qryKaQJBildung;
            edtKursCustom3.DataSource = qryKaQJBildung;
            edtKursCustom4.DataSource = qryKaQJBildung;
            edtKursCustom5.DataSource = qryKaQJBildung;
            edtKursCustom6.DataSource = qryKaQJBildung;
        }

        private void SetupEditMode()
        {
            bool MayRead;
            bool MayIns;
            bool MayUpd;
            bool MayDel;
            bool MayClose;
            bool MayReopen;
            DBUtil.GetFallRights(_faLeistungID, out MayRead, out MayIns, out MayUpd, out MayDel, out MayClose, out MayReopen);
            qryKaQJBildung.CanUpdate = MayUpd && DBUtil.UserHasRight(Name, "U");
            qryKaQJBildung.CanInsert = MayIns && DBUtil.UserHasRight(Name, "I");
            qryKaQJBildung.EnableBoundFields();
        }

        #endregion

        #endregion
    }
}