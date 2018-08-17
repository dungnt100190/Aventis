using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using Kiss.Interfaces.UI;
using KiSS.Context;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Main
{
    /// <summary>
    /// Summary description for FrmLogin.
    /// </summary>
    public partial class FrmLogin : KissForm
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly Dictionary<int, ImageComboBoxItem> _environmentItems = new Dictionary<int, ImageComboBoxItem>();

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor to init login form
        /// </summary>
        public FrmLogin()
        {
            // Required for Windows Form Designer support
            InitializeComponent();

            FirstLogin = false;

            // get imagelist from main and setup properties
            var mainForm = Session.MainForm as FrmMain;

            if (mainForm != null)
            {
                edtEnvironment.Properties.SmallImages = mainForm.GetDBImageList();
            }

            // translation
            TranslateForm();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Flag if login is the first after starting KiSS
        /// </summary>
        public bool FirstLogin
        {
            get;
            set;
        }

        #endregion

        #region EventHandlers

        private void btnClearFilterEnvironments_Click(object sender, EventArgs e)
        {
            ClearFilter();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            TryLogin();
        }

        private void editEnvironment_EditValueChanged(object sender, EventArgs e)
        {
            EnableControls();
        }

        private void edtFilterEnvironments_EditValueChanged(object sender, EventArgs e)
        {
            var filter = (edtFilterEnvironments.Text ?? string.Empty).ToUpper();
            var isFilterEmpty = string.IsNullOrEmpty(filter);

            edtEnvironment.SelectedIndex = -1;
            edtEnvironment.Properties.Items.Clear();

            foreach (var item in _environmentItems)
            {
                if (isFilterEmpty)
                {
                    edtEnvironment.Properties.Items.Add(item.Value);
                }
                else if (!string.IsNullOrEmpty(item.Value.Description) && item.Value.Description.ToUpper().Contains(filter))
                {
                    edtEnvironment.Properties.Items.Add(item.Value);
                }
            }

            if (edtEnvironment.Properties.Items.Count > 0)
            {
                edtEnvironment.SelectedIndex = 0;
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            // load environments
            foreach (var index in from env in Session.Envs
                                  let index = edtEnvironment.Properties.Items.Add(new ImageComboBoxItem(env.Name, env, (int)env.EnvType))
                                  where env == Session.LastEnv
                                  select index)
            {
                edtEnvironment.SelectedIndex = index;
            }

            var itemIndex = 0;

            foreach (ImageComboBoxItem item in edtEnvironment.Properties.Items)
            {
                _environmentItems.Add(itemIndex, item);
                itemIndex++;
            }

            if (edtEnvironment.Properties.Items.Count > 0 && edtEnvironment.SelectedIndex == -1)
            {
                edtEnvironment.SelectedIndex = 0;
            }

            edtUser.Text = Session.LastLogon;

            if (DBUtil.IsEmpty(edtUser.Text))
            {
                edtUser.Text = Environment.UserName;
            }

            //
            rgrAnmeldung.SelectedIndex = Convert.ToInt32(Session.UserAppDataRegistry.GetValue("LastLogonChoice"));

            EnableControls();
            ApplyAdvancedSettings();
        }

        private void rgrAnmeldung_SelectedIndexChanged(object sender, EventArgs e)
        {
            // falls Windows Benutzer ausgewählt wurde, dann die Eingabefelder inaktiv setzen
            var enabled = rgrAnmeldung.SelectedIndex.Equals(0);
            if (enabled)
            {
                edtUser.EditMode = EditModeType.ReadOnly;
                edtPassword.EditMode = EditModeType.ReadOnly;
            }
            else
            {
                edtUser.EditMode = EditModeType.Normal;
                edtPassword.EditMode = EditModeType.Normal;
            }

            Session.UserAppDataRegistry.SetValue("LastLogonChoice", rgrAnmeldung.SelectedIndex);
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (edtFilterEnvironments.Visible)
            {
                if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.F)
                {
                    // ALT+F = Focus Filter
                    edtFilterEnvironments.Focus();
                    e.Handled = true;
                }
                else if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.C)
                {
                    // ALT+C = Clear Filter
                    ClearFilter();
                    e.Handled = true;
                }
            }

            if (!e.Handled && edtEnvironment.Focused && e.Modifiers == Keys.None && e.KeyCode == Keys.Space)
            {
                // SPACE on Environments = ShowPopup
                edtEnvironment.ShowPopup();
                e.Handled = true;
            }

            base.OnKeyUp(e);
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Gets the setting in App.config for Login.AutoTryLogin
        /// </summary>
        private static bool GetAppConfigSettingLoginAutoTryLogin()
        {
            try
            {
                var asr = new AppSettingsReader();
                return Convert.ToBoolean(asr.GetValue("Login.AutoTryLogin", typeof(bool)));
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the setting in App.config for Login.ShowFilter
        /// </summary>
        private static bool GetAppConfigSettingLoginShowFilter()
        {
            try
            {
                var asr = new AppSettingsReader();
                return Convert.ToBoolean(asr.GetValue("Login.ShowFilter", typeof(bool)));
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the setting in App.config for Login.Sizeable
        /// </summary>
        private static bool GetAppConfigSettingLoginSizeable()
        {
            try
            {
                var asr = new AppSettingsReader();
                return Convert.ToBoolean(asr.GetValue("Login.Sizeable", typeof(bool)));
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Private Methods

        private void ApplyAdvancedSettings()
        {
            // check if we need to show filter for environments
            if (GetAppConfigSettingLoginShowFilter())
            {
                ShowFilterAndArrangeControls();
            }

            // check if we need to have login-screen sizeable
            if (GetAppConfigSettingLoginSizeable())
            {
                MinimumSize = Size;
                FormBorderStyle = FormBorderStyle.Sizable;
            }

            if (GetAppConfigSettingLoginAutoTryLogin() && btnLogin.Enabled && !string.IsNullOrEmpty(edtUser.Text) && FirstLogin)
            {
                TryLogin();
            }
        }

        private void ClearFilter()
        {
            edtFilterEnvironments.Text = null;
            edtFilterEnvironments.Focus();
        }

        /// <summary>
        /// Enable controls depending on current values
        /// </summary>
        private void EnableControls()
        {
            btnLogin.Enabled = edtEnvironment.SelectedIndex >= 0;
        }

        private void ShowFilterAndArrangeControls()
        {
            const int margin = 6;
            const int filterSmaller = 140;

            var edtEnvTop = edtEnvironment.Top;
            edtEnvironment.Top = lblFilterEnvironments.Top;
            lblEnvironment.Top = edtEnvironment.Top;

            lblFilterEnvironments.Top = edtEnvTop;
            lblFilterEnvironments.Left = lblEnvironment.Left;
            lblFilterEnvironments.Width = lblEnvironment.Width;

            edtFilterEnvironments.Top = edtEnvTop;
            edtFilterEnvironments.Left = edtEnvironment.Left;
            edtFilterEnvironments.Width = edtEnvironment.Width - btnClearFilterEnvironments.Width - filterSmaller - margin;
            btnClearFilterEnvironments.Top = edtEnvTop;
            btnClearFilterEnvironments.Left = edtFilterEnvironments.Left + edtFilterEnvironments.Width + margin;

            rgrAnmeldung.Top = edtEnvironment.Top + edtEnvironment.Height + margin;

            edtUser.Top = rgrAnmeldung.Top + rgrAnmeldung.Height / 2;

            lblPassword.Top = edtUser.Top + edtUser.Height + margin;
            edtPassword.Top = lblPassword.Top;

            var btnTop = edtPassword.Top + edtPassword.Height + margin * 3;

            ClientSize = new System.Drawing.Size(ClientSize.Width, btnTop + btnLogin.Height + margin * 3);

            btnLogin.Top = btnTop;
            btnCancel.Top = btnTop;

            lblFilterEnvironments.Visible = true;
            edtFilterEnvironments.Visible = true;
            btnClearFilterEnvironments.Visible = true;
        }

        /// <summary>
        /// Translate form using the defined resources files depending on current OS's language
        /// </summary>
        private void TranslateForm()
        {
            try
            {
                // update controls
                Text = DB.Properties.Resources.FrmLogin_FormText;
                btnLogin.Text = DB.Properties.Resources.FrmLogin_btnLogin;
                btnCancel.Text = DB.Properties.Resources.FrmLogin_btnCancel;
                lblEnvironment.Text = DB.Properties.Resources.FrmLogin_lblEnvironment;
                lblPassword.Text = DB.Properties.Resources.FrmLogin_lblPassword;
                lblFilterEnvironments.Text = DB.Properties.Resources.FrmLogin_lblFilterEnvironments;
                rgrAnmeldung.Properties.Items[0].Description = DB.Properties.Resources.FrmLogin_rgrAnmeldung_WindowsUser;
                rgrAnmeldung.Properties.Items[1].Description = DB.Properties.Resources.FrmLogin_lblUser;
            }
            catch (Exception ex)
            {
                // show error
                KissMsg.ShowError(String.Format("There was an error with the translation:\r\n{0}", ex.Message));

                // stop if debugger is available
                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }
            }
        }

        private void TryLogin()
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                Env env = null;

                if (edtFilterEnvironments.Visible)
                {
                    // get original index of selected item to get environment in session
                    foreach (var keyValuePair in _environmentItems.Where(keyValuePair => edtEnvironment.SelectedItem.Equals(keyValuePair.Value)))
                    {
                        env = Session.Envs[keyValuePair.Key];
                        break;
                    }
                }
                else
                {
                    env = Session.Envs[edtEnvironment.SelectedIndex];
                }

                var logonName = edtUser.Text;
                var password = edtPassword.Text;

                logonName = logonName.Trim().Length == 0 ? null : logonName.Trim();

                if (password.Trim().Length == 0)
                {
                    password = null;
                }

                // do login with given values
                Session.Open(env, logonName, password, (rgrAnmeldung.SelectedIndex == 0));
                AppContext.Init(Session.ConnectionString);
                Utils.WarningIfIBANExpired(Session.Active);

                // check if success
                if (!Session.Active)
                {
                    // failed, set focus to username
                    edtUser.Focus();
                    return;
                }

                // successfully connected to db with valid login
                Close();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("FrmLogin", "FehlerAnmeldung", DB.Properties.Resources.FrmLogin_ErrorWithLogin, ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        #endregion

        #endregion
    }
}