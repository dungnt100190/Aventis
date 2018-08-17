using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Windows.Forms;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace Kiss.Integration.CaseShell
{
    /// <summary>
    /// Interaction logic for ModulTreeExtension.xaml
    /// </summary>
    public partial class ModulTreeExtension : IModulTreeExtension
    {
        private const string CLASS_NAME_ZEITACHSE = "FrmFaZeitachse";
        private const string KEY_PATH_ZEITACHSE = @"System\Fallfuehrung\Zeitachse";
        private int _baPersonId;
        private int _faFallId;

        public ModulTreeExtension()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            FormsHost.Child = null;
            FormsHost.Dispose();
            Root.Children.Clear();
        }

        public void Initialize(int baPersonId, int faFallId)
        {
            _baPersonId = baPersonId;
            _faFallId = faFallId;
            var installationInfo = InstallationInfo.GetInstallationInfo();

            if (installationInfo.ProductType == ProductType.Standard)
            {
                var btnZeitachseVisible = DBUtil.GetConfigBool(KEY_PATH_ZEITACHSE, false);

                if (btnZeitachseVisible)
                {
                    FormsHost.Child = GetZeitachseButton();
                }
            }
            else if (installationInfo.ProductType == ProductType.PI)
            {
                FormsHost.Child = GetCtlGotoFall();
            }
        }

        private void BtnZeitachseClick(object sender, EventArgs e)
        {
            // Prüfen ob eine F-Leistung vorhanden ist
            var hasFLeistung = DBUtil.ExecuteScalarSQLThrowingException(@"
                IF EXISTS(SELECT TOP 1 1
                          FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                          WHERE BaPersonID = {0}
                            AND ModulID = 2)
                BEGIN
                  SELECT CONVERT(BIT, 1);
                END
                ELSE
                BEGIN
                  SELECT CONVERT(BIT, 0);
                END;",
                _baPersonId) as bool? ?? false;

            if (!hasFLeistung)
            {
                KissMsg.ShowInfo(
                    KissMsg.GetMLMessage(
                        "CtlFall",
                        "FallfuehrungNichtVorhanden",
                        "Die Zeitachse kann nicht dargestellt werden da keine Fallführung vorhanden ist.",
                        KissMsgCode.MsgInfo));
                return;
            }

            // Zeitachse öffnen
            var dic = new HybridDictionary();
            dic.Add("BaPersonID", _baPersonId);

            dic.Add("ShowOldVersion", false);
            FormController.OpenForm("FrmFaZeitachse", dic);
        }

        private Control GetCtlGotoFall()
        {
            var ctlGotoFall = new CtlGotoFall
            {
                DisplayModules = "3,4,5,6,7,8,31",
                ShowToolTipsOnIcons = true,
                BaPersonID = _baPersonId,
                BackColor = Color.Transparent,
                BorderStyle = BorderStyle.None
            };
            return ctlGotoFall;
        }

        private Control GetZeitachseButton()
        {
            var btnZeitachse = new KissButton
            {
                Image = Infrastructure.Properties.Resources.Kiss_FaZeitachse_16,
                Enabled = DBUtil.UserHasRight(CLASS_NAME_ZEITACHSE),
                Size = new Size(26, 24)
            };
            btnZeitachse.Click += BtnZeitachseClick;
            return btnZeitachse;
        }
    }
}