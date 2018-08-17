using System;
using Kiss.Infrastructure.Constant;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Gesuchverwaltung
{
    public class GvBaseControl : KissUserControl
    {
        #region Fields

        #region Protected Constant/Read-Only Fields

        protected readonly SqlQuery _qryGvGesuch;

        #endregion

        #region Protected Fields

        protected int _gvGesuchId;
        protected LOVsGenerated.GvStatus _gvStatusCode;

        #endregion

        #region Private Fields

        private int _gvFondsId;

        #endregion

        #endregion

        #region Constructors

        public GvBaseControl(SqlQuery qryGvGesuch, bool hasKompetenzstufe0, bool hasKompetenzstufe1, bool hasKompetenzstufe2)
        {
            if (qryGvGesuch == null)
            {
                throw new ArgumentNullException("qryGvGesuch");
            }

            _qryGvGesuch = qryGvGesuch;

            HasKompetenzstufe0 = hasKompetenzstufe0;
            HasKompetenzstufe1 = hasKompetenzstufe1;
            HasKompetenzstufe2 = hasKompetenzstufe2;
        }

        /// <summary>
        /// Used by the designer.
        /// </summary>
        private GvBaseControl()
        {
        }

        #endregion

        #region Events

        public new event EventHandler Search;

        #endregion

        #region Properties

        /// <summary>
        /// Spezialrechte für die Editierung von Felder
        /// </summary>
        protected bool AllowSpecialEdit
        {
            get
            {
                return (_gvStatusCode == LOVsGenerated.GvStatus.InBearbeitung || _gvStatusCode == LOVsGenerated.GvStatus.InPruefung || _gvStatusCode == LOVsGenerated.GvStatus.InPruefungCh) &&
                       (HasKompetenzstufe0 || HasKompetenzstufe1 || HasKompetenzstufe2);
            }
        }

        /// <summary>
        /// Beschreibt, ob der aktuell eingeloggte Benutzer das Spezialrecht CtlGvGesuchverwaltung_Kompetenzstufe0 hat.
        /// </summary>
        protected bool HasKompetenzstufe0
        {
            get;
            private set;
        }

        /// <summary>
        /// Beschreibt, ob der aktuell eingeloggte Benutzer das Spezialrecht CtlGvGesuchverwaltung_Kompetenzstufe1 hat.
        /// </summary>
        protected bool HasKompetenzstufe1
        {
            get;
            private set;
        }

        /// <summary>
        /// Beschreibt, ob der aktuell eingeloggte Benutzer das Spezialrecht CtlGvGesuchverwaltung_Kompetenzstufe2 hat.
        /// </summary>
        protected bool HasKompetenzstufe2
        {
            get;
            private set;
        }

        protected bool IsExternerFonds
        {
            get
            {
                return (LOVsGenerated.GvFondsTyp)Utils.ConvertToInt(_qryGvGesuch[DBO.GvFonds.GvFondsTypCode]) == LOVsGenerated.GvFondsTyp.Extern;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "BAPERSONID":
                    return _qryGvGesuch[DBO.GvGesuch.BaPersonID];
                case "GVGESUCHID":
                    return _qryGvGesuch[DBO.GvGesuch.GvGesuchID];
            }

            return base.GetContextValue(fieldName);
        }

        public void LoadData()
        {
            var gvGesuchId = Utils.ConvertToInt(_qryGvGesuch[DBO.GvGesuch.GvGesuchID]);
            var gvFondsId = Utils.ConvertToInt(_qryGvGesuch[DBO.GvGesuch.GvFondsID]);
            var statusCode = (LOVsGenerated.GvStatus)Utils.ConvertToInt(_qryGvGesuch[DBO.GvGesuch.GvStatusCode]);

            var refresh = gvGesuchId != _gvGesuchId || gvFondsId != _gvFondsId || statusCode != _gvStatusCode;

            _gvGesuchId = gvGesuchId;
            _gvFondsId = gvFondsId;
            _gvStatusCode = statusCode;

            LoadData(refresh);
        }

        public override void OnSearch()
        {
            if (Search != null)
            {
                Search(this, EventArgs.Empty);
            }
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Wird benötigt, wenn Controls auf _qryGvGesuch gebunden sind, um die Daten anzuzeigen, obwohl Fill bereits ausgeführt wurde.
        /// </summary>
        protected void BindControls()
        {
            _qryGvGesuch.BindControls();
            _qryGvGesuch.EnableBoundFields();
        }

        protected virtual void LoadData(bool refresh)
        {
        }

        protected void StatusWechsel(LOVsGenerated.GvStatus gvStatusNeu, LOVsGenerated.GvBewilligung gvBewilligungNeu)
        {
            var transactionOpen = Session.Transaction != null;

            try
            {
                if (!transactionOpen)
                {
                    Session.BeginTransaction();
                }

                // Bewilligung
                GvUtil.InsertGvBewilligung(_gvGesuchId, gvBewilligungNeu);

                // Status aktualisieren
                _qryGvGesuch[DBO.GvGesuch.GvStatusCode] = (int)gvStatusNeu;
                if (gvBewilligungNeu == LOVsGenerated.GvBewilligung.ErfassungAbschliessen)
                {
                    _qryGvGesuch[DBO.GvGesuch.ErfassungAbgeschlossen] = DateTime.Today;
                }

                _qryGvGesuch.Post();

                if (!transactionOpen)
                {
                    Session.Commit();
                }

                // Status im Memory erst nach Commit
                _gvStatusCode = gvStatusNeu;

                UpdateGui();
            }
            catch
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }

                throw;
            }
        }

        protected virtual void UpdateGui()
        {
        }

        #endregion

        #endregion
    }
}