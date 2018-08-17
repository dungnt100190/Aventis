using System;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

using Kiss.BL.Wsh;
using Kiss.Interfaces.BL;
using Kiss.Model;
using Kiss.Model.DTO.Wsh;

using KiSS4.Common;
using KiSS4.Common.ZH;
using KiSS4.DB;
using KiSS4.Gui;

using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace Kiss.UI.Container.Wsh
{
    public partial class CtlWshModulTree : KissModulTree
    {
        #region Fields


        #region Private Constant/Read-Only Fields

        /// <summary>
        /// Module id for neue WSH.
        /// </summary>
        private const int MODULEID_WSH = 103;

        #endregion

        #endregion

        #region Constructors

        public CtlWshModulTree()
        {
            InitializeComponent();
        }

        //Gopf, doku = null!!!!
        public CtlWshModulTree(int baPersonID, Panel panelDetail)
            : base(baPersonID, panelDetail, MODULEID_WSH)
        {
            InitializeComponent();
            SetupTreeColumns();

            // Fallzugriff/Fallinfo/Fallzuteilung:
            btnFallZugriff.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;    // Standard
            btnFallInfo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;       // Standard
            btnFallZuteilung.Visibility = DevExpress.XtraBars.BarItemVisibility.Always; // ZH: analog an FallZugriff und FallInfo. TODO wird dass die neue Standard-Maske?
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// A node is about to be selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void kissTree_AfterFocusNode(object sender, NodeEventArgs e)
        {
            if (e == null || e.Node == null)
            {
                ShowDetail(null);
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string className = e.Node.GetValue("ClassName") as string;
                Image imgIcon = GetIcon(e);
                string titel = e.Node.GetValue("Name") as string;
                object faLeistungId = e.Node.GetValue("FaLeistungID");
                CtlWpfMask ctl = null;
                if (faLeistungId is int)
                {
                    ctl = InitializeView(className, (int)faLeistungId);
                }

                //ApplyEditMaskToSqlQuery(ctl.ActiveSQLQuery);
                ShowDetail(ctl, true);
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("CtlWhModulTree", "EintragAnzeigenNichtMoeglich", "Der gewünschte Eintrag kann nicht angezeigt werden", ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void CtlWshModulTree_Load(object sender, EventArgs e)
        {
            FillTree();
            ExpandAndSelectFirstLeistung();
        }

        private void btnFaLeistung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CreateLeistung();
        }

        #endregion

        #region Methods

        #region Private Methods

        /// <summary>
        /// Creates a new Leistung and refreshes the tree afterwards.
        /// </summary>
        private void CreateLeistung()
        {
            var leistungService = Interfaces.IoC.Container.Resolve<WshLeistungService>();
            var data = new WshCreateLeistungDTO
            {
                BaPersonId = BaPersonID,
                DatumVon = DateTime.Today
            };
            FaLeistung leistung;
            var serviceResult = leistungService.InsertExistenzsicherungLeistung(null, data, out leistung);
            // Show warnings/errors to user
            if (!serviceResult.IsOk || leistung == null)
            {
                ShowWarnings("Neue WSH-Leistung kann nicht eingefügt werden:", serviceResult);
            }
            else
            {
                RefreshTree();
                ExpandLeistung(leistung.FaLeistungID, true);
            }
        }


        private void ExpandAndSelectFirstLeistung()
        {
            foreach (TreeListNode node in kissTree.Nodes)
            {
                var id = node.GetValue("FaLeistungID");
                if (id is int)
                {
                    node.Expanded = true;
                    kissTree.FocusedNode = node;
                    break;
                }
            }
        }

        private void ExpandLeistung(int leistungID, bool selectNode)
        {
            foreach (TreeListNode node in kissTree.Nodes)
            {
                var id = node.GetValue("FaLeistungID");
                if (id is int && (int)id == leistungID)
                {
                    node.Expanded = true;
                    if (selectNode)
                    {
                        kissTree.FocusedNode = node;
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// Initialisiert die WPF View.
        /// </summary>
        /// <param name="className"></param>
        /// <param name="leistungId"></param>
        /// <returns></returns>
        private CtlWpfMask InitializeView(string className, int leistungId)
        {
            CtlWpfMask ctl = new CtlWpfMask();
            Type type = AssemblyLoader.GetType(className);

            if (type == null)
            {
                return ctl;
            }
            var constructorInfo = type.GetConstructor(new Type[0]);
            dynamic view;
            try
            {
                view = constructorInfo.Invoke(new object[0]);
                view.InitViewAndViewModel(leistungId);
            }
            catch (TargetInvocationException ex)
            {
                // Damit wir im Fehlerdialog eine aussagekräftigere Fehlermeldung anzeigen können.
                var innerException = ex.InnerException;

                if (innerException != null)
                {
                    throw innerException;
                }
                throw;
            }
            ctl.InitializeKissControl(view);
            return ctl;
        }

        /// <summary>
        /// Reloads this tree and the FallNavigator. Used after a leistung is created or removed.
        /// </summary>
        private void RefreshTree()
        {
            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
            FormController.SendMessage("FrmFallNavigator", "Action", "RefreshTree");
            kissTree.MoveFirst();
            kissTree.FocusedNode.Expanded = true;
        }

        /// <summary>
        /// Hinweis: Die Verknüpfung zwischen Columns und Tree kann ich nicht im
        /// Designer machen (readonly). Bug?
        /// </summary>
        private void SetupTreeColumns()
        {
            kissTree.Columns.AddRange(
                new[]
                {
                    colName,
                    colFaLeistungID,
                    colBaPersonID
                });
        }

        /// <summary>
        /// Shows the user all warnings.
        /// </summary>
        /// <param name="header"></param>
        /// <param name="result"></param>
        private static void ShowWarnings(string header, KissServiceResult result)
        {
            var text = header + Environment.NewLine + result.GetWarningsAndErrors();
            KissMsg.ShowInfo(text);
        }

        private void btnFallZuteilung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new DlgFallZuteilung(BaPersonID);
            dlg.ShowDialog(GetKissMainForm());
        }

        #endregion

        #endregion
    }
}