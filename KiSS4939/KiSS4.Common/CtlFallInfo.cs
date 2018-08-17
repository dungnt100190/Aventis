using System;
using System.Data;

using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTreeList.Nodes;

using KiSS.DBScheme;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Common
{
    public partial class CtlFallInfo : KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly int _baPersonId;
        private readonly int _faLeistungId;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlFallInfo"/> class.
        /// </summary>
        /// <param name="baPersonId">The ba person ID.</param>
        /// <param name="dummy">Obsolet, es gibt aber noch dynamische Aufrufe mit diesem Parameter.</param>
        public CtlFallInfo(int baPersonId, bool dummy)
            : this()
        {
            _baPersonId = baPersonId;

            var qry = DBUtil.OpenSQL(@"
                SELECT TOP 1 FaLeistungID
                FROM dbo.FaLeistung	WITH (READUNCOMMITTED)
                WHERE BaPersonID = {0}
                ORDER BY DatumVon DESC;",
                baPersonId);

            if (!qry.IsEmpty)
            {
                _faLeistungId = (int)qry[DBO.FaLeistung.FaLeistungID];
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlFallInfo"/> class.
        /// </summary>
        /// <param name="faLeistungId">The fa leistung ID.</param>
        public CtlFallInfo(int faLeistungId)
            : this()
        {
            _faLeistungId = faLeistungId;

            var qry = DBUtil.OpenSQL(@"
                SELECT TOP 1 BaPersonID
                FROM dbo.FaLeistung	WITH (READUNCOMMITTED)
                WHERE FaLeistungID = {0};",
                faLeistungId);

            if (!qry.IsEmpty)
            {
                _baPersonId = (int)qry[DBO.FaLeistung.BaPersonID];
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlFallInfo"/> class.
        /// </summary>
        private CtlFallInfo()
        {
            InitializeComponent();

            treFaLeistung.SelectImageList = KissImageList.SmallImageList;
            treFaLeistung.ImageIndexFieldName = "ImageIndex";
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// Handles the Load event of the CtlFallInfo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CtlFallInfo_Load(object sender, EventArgs e)
        {
            tabFallinfo.SelectedTabIndex = 0;

            qryBaPerson.Fill(_faLeistungId);
            qryFaLeistung.Fill(_baPersonId);

            TreeListNode node = DBUtil.FindNodeByValue(treFaLeistung.Nodes, _faLeistungId.ToString(), DBO.FaLeistung.FaLeistungID);

            if (node != null)
            {
                treFaLeistung.FocusedNode = node;
            }

            // Modul-Icon Zustaendigkeit
            repModulIcon.SmallImages = KissImageList.SmallImageList;

            var qryModul = DBUtil.OpenSQL(@"
                SELECT IconID = 100 * ModulID + 1000
                FROM dbo.XModul WITH(READUNCOMMITTED)
                WHERE ModulTree = 1;");

            foreach (DataRow row in qryModul.DataTable.Rows)
            {
                for (int i = (int)row["IconID"]; i < (int)row["IconID"] + 10; i++)
                {
                    repModulIcon.Items.Add(new ImageComboBoxItem("", i, KissImageList.GetImageIndex(i)));
                }
            }

            // Modul-Icon Zustaendigkeit
            repModulIconGastrecht.SmallImages = KissImageList.SmallImageList;
            foreach (DataRow row in qryModul.DataTable.Rows)
            {
                for (int i = (int)row["IconID"]; i < (int)row["IconID"] + 10; i++)
                {
                    repModulIconGastrecht.Items.Add(new ImageComboBoxItem("", i, KissImageList.GetImageIndex(i)));
                }
            }
        }

        /// <summary>
        /// Handles the AfterFill event of the qryFaLeistung control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void qryFaLeistung_AfterFill(object sender, EventArgs e)
        {
            if (!qryFaLeistung.DataTable.Columns.Contains("ImageIndex"))
            {
                qryFaLeistung.DataTable.Columns.Add("ImageIndex", typeof(int));
            }

            foreach (DataRow row in qryFaLeistung.DataTable.Rows)
            {
                if (!DBUtil.IsEmpty(row["IconID"]))
                {
                    row["ImageIndex"] = KissImageList.GetImageIndex((int)row["IconID"]);
                }
            }

            treFaLeistung.DataSource = sender;
        }

        /// <summary>
        /// Handles the PositionChanged event of the qryFaLeistung control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void qryFaLeistung_PositionChanged(object sender, EventArgs e)
        {
            qryFaLeistungArchiv.Fill(qryFaLeistung[DBO.FaLeistung.FaLeistungID]);
            qryFaLeistungArchiv.Last();
            qryZustaendigkeit.Fill(qryFaLeistung[DBO.FaLeistung.FaLeistungID]);
            qryGastrecht.Fill(qryFaLeistung[DBO.FaLeistung.FaLeistungID]);
        }

        #endregion
    }
}