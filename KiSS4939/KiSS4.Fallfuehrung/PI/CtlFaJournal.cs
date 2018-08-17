using System;
using System.Drawing;

using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Fallfuehrung.PI
{
    public partial class CtlFaJournal : KissSearchUserControl
    {
        #region Fields

        #region Private Fields

        private Int32 _baPersonID;

        #endregion

        #endregion

        #region Constructors

        public CtlFaJournal()
        {
            InitializeComponent();

            // init with default values
            Init(null, null, -1);
        }

        #endregion

        #region EventHandlers

        private void qryJournal_AfterFill(object sender, EventArgs e)
        {
            // select last row
            qryJournal.Last();
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Init(string titleName, Image titleImage, int baPersonID)
        {
            // deny changes
            qryJournal.CanInsert = false;
            qryJournal.CanUpdate = false;
            qryJournal.CanDelete = false;

            // validate
            if (baPersonID < 1)
            {
                // do not continue
                return;
            }

            // apply values
            _baPersonID = baPersonID;
            picTitel.Image = titleImage;
            lblTitel.Text = titleName;

            // setup select statement
            qryJournal.SelectStatement = @"
                DECLARE @BaPersonID INT;
                DECLARE @UserID INT;
                DECLARE @LanguageCode INT;
                DECLARE @Date DATETIME;

                SET @BaPersonID = {0};
                SET @UserID = {1};
                SET @LanguageCode = {2};
                SET @Date = GETDATE();

                SELECT RES.*,
                        --not used (?): Tage   = DATEDIFF(d, @Date, RES.Datum),
                        Themen = dbo.fnLOVMLColumnListe('FaLebensbereich', RES.ThemenCodes, NULL, @LanguageCode)
                FROM dbo.fnFaGetJournal(@BaPersonID, @UserID, @LanguageCode, @Date) RES
                WHERE 1 = 1
                --- AND Datum = {edtSucheDatum}
                --- AND TypCode = {edtSucheTyp}
                --- AND Autor LIKE '%' + {edtSucheAutor} + '%'
                --- AND ModulID = {edtSucheModul}
                --- AND Titel LIKE '%' + {edtSucheTitelStichworte} + '%'
                --- AND Text LIKE '%' + {edtSucheText} + '%'
                ORDER BY Datum ASC, TypCode ASC;";

            // replace search parameters
            object[] parameters = new object[] { _baPersonID, Session.User.UserID, Session.User.LanguageCode };
            kissSearch.SelectParameters = parameters;

            // start a new search (default behaviour) and switch to tabListe
            NewSearch();
            tabControlSearch.SelectedTabIndex = 0;
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            // refresh search fields
            base.NewSearch();

            // set focus
            edtSucheDatum.Focus();
        }

        #endregion

        #endregion
    }
}