using System;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.DB;

namespace KiSS4.Gesuchverwaltung
{
    public partial class CtlGvBegruendung : GvBaseControl
    {
        #region Constructors

        public CtlGvBegruendung(SqlQuery qryGvGesuch, bool hasKompetenzstufe0, bool hasKompetenzstufe1, bool hasKompetenzstufe2)
            : base(qryGvGesuch, hasKompetenzstufe0, hasKompetenzstufe1, hasKompetenzstufe2)
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        public override bool OnAddData()
        {
            return true;
        }

        public override bool OnDeleteData()
        {
            return true;
        }

        private void CtlGvBegruendung_Load(object sender, EventArgs e)
        {
            // Setup SQL query
            edtBegruendung.DataSource = _qryGvGesuch;
            edtBegruendung.DataMember = DBO.GvGesuch.Begruendung;
            ActiveSQLQuery = _qryGvGesuch;

            BindControls();

            SetEditMode();
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void LoadData(bool refresh)
        {
            if (refresh)
            {
                SetEditMode();
            }
        }

        #endregion

        #region Private Methods

        private bool AllowEdit
        {
            get
            {
                return _gvStatusCode == 0
                        || _gvStatusCode == LOVsGenerated.GvStatus.InErfassung
                        || (_gvStatusCode == LOVsGenerated.GvStatus.InBearbeitung && HasKompetenzstufe0);
            }
        }

        private void SetEditMode()
        {
            // Felder je nach Status aktivieren
            if (AllowEdit || AllowSpecialEdit)
            {
                edtBegruendung.EditMode = EditModeType.Normal;
            }
            else
            {
                edtBegruendung.EditMode = EditModeType.ReadOnly;
            }
        }

        #endregion

        #endregion
    }
}