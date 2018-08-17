using System;
using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using SharpLibrary.WinControls;

namespace KiSS4.Inkasso
{
    public partial class CtlIkRechtstitel : KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly int _faFallID;
        private readonly int _faLeistungID;
        private readonly bool _hasSchulder;
        private readonly int _ikRechtstitelID;

        #endregion

        #endregion

        #region Constructors

        public CtlIkRechtstitel(int leistungID, int fallID, Image icon, bool gesperrt, int rechtstitelID)
            : this()
        {
            picTitle.Image = icon;
            _faLeistungID = leistungID;
            _faFallID = fallID;
            _ikRechtstitelID = rechtstitelID;

            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT SchuldnerBaPersonID
                FROM dbo.FaLeistung
                WHERE FaLeistungID = {0}",
                _faLeistungID);
            _hasSchulder = (Utils.ConvertToInt(qry[DBO.FaLeistung.SchuldnerBaPersonID]) > 0);
            qryIkRechtstitel.CanUpdate = _hasSchulder;

            if (!_hasSchulder)
            {
                KissMsg.ShowInfo(Name, "SchuldnerDefinieren", "Definieren Sie zuerst den Schuldner dieses Rechtstitels.");
            }

            // Personen aus FaFallPerson:
            qryPerson.Fill(_faFallID);
            edtElterlicheVertretung.Properties.DataSource = qryPerson;

            // Daten zeigen:
            qryIkRechtstitel.Fill(_ikRechtstitelID);

            // anderer Register aktualisieren:
            FillOtherRegisters();
        }

        public CtlIkRechtstitel()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public override KissUserControl DetailControl
        {
            get
            {
                if (tabRechtstitel.SelectedTab.Controls.Count == 1 && tabRechtstitel.SelectedTab.Controls[0] is KissUserControl)
                {
                    return (KissUserControl)tabRechtstitel.SelectedTab.Controls[0];
                }

                return base.DetailControl;
            }
        }

        #endregion

        #region EventHandlers

        private void edtIkIndexTypCode_CloseUp(object sender, CloseUpEventArgs e)
        {
            e.AcceptValue = true;
            if (!e.CloseMode.Equals(PopupCloseMode.Normal))
            {
                return;
            }

            qryIkRechtstitel[DBO.IkRechtstitel.IndexStandPunkte] = GetIndexPunkte(
                e.Value as int?, qryIkRechtstitel[DBO.IkRechtstitel.IndexStandVom] as DateTime?);
        }

        private void edtIndexStandVom_EditValueChanged(object sender, EventArgs e)
        {
            if (!edtIndexStandVom.UserModified)
            {
                return;
            }

            // Indexstand neu holen:
            if (!DBUtil.IsEmpty(edtIndexStandVom.EditValue))
            {
                qryIkRechtstitel[DBO.IkRechtstitel.IndexStandVom] = edtIndexStandVom.EditValue;
                qryIkRechtstitel[DBO.IkRechtstitel.IndexStandPunkte] = GetIndexPunkte(
                    qryIkRechtstitel[DBO.IkRechtstitel.IkIndexTypCode] as int?,
                    qryIkRechtstitel[DBO.IkRechtstitel.IndexStandVom] as DateTime?);
            }
        }

        private void qryIkRechtstitel_AfterFill(object sender, EventArgs e)
        {
            if (qryIkRechtstitel.CanUpdate && qryIkRechtstitel.Count == 0)
            {
                qryIkRechtstitel.Insert(qryIkRechtstitel.TableName);
                qryIkRechtstitel.RowModified = true;
            }

            if (qryIkRechtstitel.Count == 0)
            {
                qryIkRechtstitel_PositionChanged(sender, e);
            }
        }

        private void qryIkRechtstitel_AfterInsert(object sender, EventArgs e)
        {
            qryIkRechtstitel[DBO.IkRechtstitel.FaLeistungID] = _faLeistungID;

            qryIkRechtstitel.Post();
        }

        private void qryIkRechtstitel_AfterPost(object sender, EventArgs e)
        {
            // Registe anzeigen:
            EnableOtherRegisters();

            // Daten auf anderen Register anzeigen:
            FillOtherRegisters();
        }

        private void qryIkRechtstitel_BeforePost(object sender, EventArgs e)
        {
            if (!DBUtil.IsEmpty(qryIkRechtstitel[DBO.IkRechtstitel.IkIndexTypCode]) &&
                !DBUtil.IsEmpty(qryIkRechtstitel[DBO.IkRechtstitel.IndexStandVom]))
            {
                qryIkRechtstitel[DBO.IkRechtstitel.IndexStandPunkte] = GetIndexPunkte(
                    qryIkRechtstitel[DBO.IkRechtstitel.IkIndexTypCode] as int?,
                    qryIkRechtstitel[DBO.IkRechtstitel.IndexStandVom] as DateTime?);

                ctlIkRechtstitelForderung.RechtstitelIndexCode = Utils.ConvertToInt(qryIkRechtstitel[DBO.IkRechtstitel.IkIndexTypCode]);
                ctlIkRechtstitelForderung.RechtstitelDatum = (DateTime)qryIkRechtstitel[DBO.IkRechtstitel.IndexStandVom];
            }
        }

        private void qryIkRechtstitel_PositionChanged(object sender, EventArgs e)
        {
            qryIkRechtstitel.EnableBoundFields(qryIkRechtstitel.Count > 0 && qryIkRechtstitel.CanUpdate);

            ctlIkRechtstitelForderung.RechtstitelIndexCode = Utils.ConvertToInt(qryIkRechtstitel[DBO.IkRechtstitel.IkIndexTypCode]);
            if (!DBUtil.IsEmpty(qryIkRechtstitel[DBO.IkRechtstitel.IndexStandVom]))
            {
                ctlIkRechtstitelForderung.RechtstitelDatum = (DateTime)qryIkRechtstitel[DBO.IkRechtstitel.IndexStandVom];
            }

            // Die anderen Register aktualsiieren:
            EnableOtherRegisters();
        }

        private void tabRechtstitel_SelectedTabChanged(TabPageEx page)
        {
            // Damit die korrekten Personen angezeigt werden:
            if (tabRechtstitel.SelectedTabIndex == 2)
            {
                ctlIkRechtstitelForderung.qryPerson.Refresh();
            }
        }

        private void tabRechtstitel_SelectedTabChanging(object sender, CancelEventArgs e)
        {
            if (tabRechtstitel.SelectedTabIndex == 0)
            {
                e.Cancel = !qryIkRechtstitel.Post();
            }
            else if (tabRechtstitel.SelectedTabIndex == 1)
            {
                e.Cancel = !ctlIkGlaeubiger.AllesSpeichern();
            }
            else if (tabRechtstitel.SelectedTabIndex == 2)
            {
                e.Cancel = !ctlIkRechtstitelForderung.qryIkForderung.Post();
            }
            else if (tabRechtstitel.SelectedTabIndex == 3)
            {
                e.Cancel = !ctlIkEinkommen.ActiveSQLQuery.Post();
            }
            else
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region Methods

        #region Private Static Methods

        private static decimal? GetIndexPunkte(int? ikIndexTypCode, DateTime? indexStandVom)
        {
            if (!ikIndexTypCode.HasValue || !indexStandVom.HasValue)
            {
                return null;
            }

            var year = indexStandVom.Value.Year;
            var month = indexStandVom.Value.Month;

            return IkUtils.GetLandesIndexWert(ikIndexTypCode.Value, year, month);
        }

        #endregion

        #region Private Methods

        private void EnableOtherRegisters()
        {
            tbpGlaeubiger.Enabled = (qryIkRechtstitel.Count > 0 && !DBUtil.IsEmpty(qryIkRechtstitel[DBO.IkRechtstitel.IkRechtstitelID]));
            tbpForderung.Enabled = tbpGlaeubiger.Enabled;
            tbpEinkommen.Enabled = tbpGlaeubiger.Enabled;
        }

        private void FillOtherRegisters()
        {
            // Register "Glauebiger" aktualiseren:
            ctlIkGlaeubiger.Init(
                Utils.ConvertToInt(qryIkRechtstitel[DBO.IkRechtstitel.IkRechtstitelID]),
                _faFallID,
                qryIkRechtstitel.CanUpdate);

            // Register "Forderungen" aktualiseren:
            ctlIkRechtstitelForderung.Init(
                Utils.ConvertToInt(qryIkRechtstitel[DBO.IkRechtstitel.IkRechtstitelID]),
                _faFallID,
                qryIkRechtstitel.CanUpdate);

            // Register "Einkommen" aktualiseren:
            ctlIkEinkommen.Init(
                Utils.ConvertToInt(qryIkRechtstitel[DBO.IkRechtstitel.IkRechtstitelID]),
                _faFallID,
                qryIkRechtstitel.CanUpdate);
        }

        #endregion

        #endregion
    }
}