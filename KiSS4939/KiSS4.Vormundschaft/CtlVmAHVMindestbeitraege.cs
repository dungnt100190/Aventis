using System;
using System.Drawing;

using Kiss.Interfaces.UI;
using KiSS4.Common;

using KiSS.DBScheme;

namespace KiSS4.Vormundschaft
{
    public partial class CtlVmAHVMindestbeitraege : KissSearchLogischesLoeschenUserControl
    {
        #region Constructors

        public CtlVmAHVMindestbeitraege()
        {
            InitializeComponent();

            SetupDataSource();
            SetupDataMembers();
            SetupFieldNames();
            SetupTags();
            SetupLogischesLoeschen();
        }

        #endregion

        #region EventHandlers

        private void btnRestoreDocument_Click(object sender, EventArgs e)
        {
            OnRestoreData();
        }

        private void qryAHVMindestbeitraege_AfterFill(object sender, EventArgs e)
        {
        }

        private void qryAHVMindestbeitraege_AfterInsert(object sender, EventArgs e)
        {
            qryAHVMindestbeitraege[DBO.VmAHVMindestbeitrag.FaLeistungID] = _faLeistungId;
            qryAHVMindestbeitraege.SetCreator();
        }

        private void qryAHVMindestbeitraege_BeforePost(object sender, EventArgs e)
        {
            qryAHVMindestbeitraege.SetModifierModified();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void Init(string titleName, Image titleImage, int baPersonId, int faLeistungId)
        {
            base.Init(titleName, titleImage, baPersonId, faLeistungId);

            lblTitel.Text = titleName;
            picTitel.Image = titleImage;

            NewSearchAndRun();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Enabled die Felder, je nachdem ob ein Datensatz logisch gelöscht worden ist.
        /// </summary>
        /// <param name="isActive"></param>
        /// <param name="editMode"></param>
        protected override void OnEnableFields(bool isActive, EditModeType editMode)
        {
            edtIkAuszugVom.EditMode = editMode;
            edtNeAnmeldungPer.EditMode = editMode;
            edtBeitragsrechungJahr.EditMode = editMode;
            edtQuartalsrechung.EditMode = editMode;
            edtBruttolohn.EditMode = editMode;
            docIkAuszug.EditMode = editMode;
            docNeAnmeldung.EditMode = editMode;
            docNeutral.EditMode = editMode;
            edtBemerkungen.EditMode = editMode;
        }

        /// <summary>
        /// Führt die Suche aus.  Hier werden dem Query die Parameter übergeben
        /// {0}, {1} ...      
        /// </summary>
        protected override void RunSearch()
        {
            bool isDeleted1;
            bool isDeleted2;

            int editVal = Convert.ToInt32(radGrpDeleted.EditValue);

            //Nur aktive Dokumente anzeigen
            if (editVal == 1)
            {
                isDeleted1 = false;
                isDeleted2 = false;
            }

            //Alle (gelöschte und aktuelle Dokumente) anzeigen
            else if (editVal == 0)
            {
                isDeleted1 = true;
                isDeleted2 = false;
            }

            //Nur gelöschte Dokumente anzeigen
            else
            {
                isDeleted1 = true;
                isDeleted2 = true;
            }

            kissSearch.SelectParameters = new object[] { _faLeistungId, isDeleted1, isDeleted2 };

            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private void SetupDataMembers()
        {
            edtIkAuszugVom.DataMember = DBO.VmAHVMindestbeitrag.IKAuszugDatum;
            edtNeAnmeldungPer.DataMember = DBO.VmAHVMindestbeitrag.NEAnmeldungDatum;
            edtBeitragsrechungJahr.DataMember = DBO.VmAHVMindestbeitrag.BeitragsRechnungsJahr;
            edtQuartalsrechung.DataMember = DBO.VmAHVMindestbeitrag.VmQuartalCode;
            edtBruttolohn.DataMember = DBO.VmAHVMindestbeitrag.Bruttolohn;
            docIkAuszug.DataMember = DBO.VmAHVMindestbeitrag.DocumentID_IKAuszug;
            docNeAnmeldung.DataMember = DBO.VmAHVMindestbeitrag.DocumentID_NEAnmeldung;
            docNeutral.DataMember = DBO.VmAHVMindestbeitrag.DocumentID_Neutral;
            edtBemerkungen.DataMember = DBO.VmAHVMindestbeitrag.Bemerkungen;
        }

        private void SetupDataSource()
        {
            edtIkAuszugVom.DataSource = qryAHVMindestbeitraege;
            edtNeAnmeldungPer.DataSource = qryAHVMindestbeitraege;
            edtBeitragsrechungJahr.DataSource = qryAHVMindestbeitraege;
            edtQuartalsrechung.DataSource = qryAHVMindestbeitraege;
            edtBruttolohn.DataSource = qryAHVMindestbeitraege;
            docIkAuszug.DataSource = qryAHVMindestbeitraege;
            docNeAnmeldung.DataSource = qryAHVMindestbeitraege;
            docNeutral.DataSource = qryAHVMindestbeitraege;
            edtBemerkungen.DataSource = qryAHVMindestbeitraege;
        }

        private void SetupFieldNames()
        {
            colIkAuszugVom.FieldName = DBO.VmAHVMindestbeitrag.IKAuszugDatum;
            colNeAnmeldungPer.FieldName = DBO.VmAHVMindestbeitrag.NEAnmeldungDatum;
            colBeitragsrechnungJahr.FieldName = DBO.VmAHVMindestbeitrag.BeitragsRechnungsJahr;
            colBruttolohn.FieldName = DBO.VmAHVMindestbeitrag.Bruttolohn;
            colIsDeleted.FieldName = DBO.VmAHVMindestbeitrag.IsDeleted;
        }

        private void SetupLogischesLoeschen()
        {
            //Positionierung der RadioGrp
            radGrpDeleted.Top = edtSucheIkAuszugDatumVon.Top;

            //DrawZell render Methode hinzufügen.
            GridView = grvAHVMindestbeitraege;
        }

        private void SetupTags()
        {
            edtIkAuszugVom.Tag = lblIkAuszugVom.Text;
            edtNeAnmeldungPer.Tag = lblNeAnmeldungPer.Text;
            edtBeitragsrechungJahr.Tag = lblBeitragsrechnungJahr.Text;
            edtQuartalsrechung.Tag = lblQuartalsrechnung.Text;
            edtBruttolohn.Tag = lblBruttolohn.Text;
            docIkAuszug.Tag = lblIkAuszugDok.Text;
            docNeAnmeldung.Tag = lblNeAnmeldungDok.Text;
            docNeutral.Tag = lblNeutralDok.Text;
            edtBemerkungen.Tag = lblBemerkungen.Text;
        }

        #endregion

        #endregion
    }
}