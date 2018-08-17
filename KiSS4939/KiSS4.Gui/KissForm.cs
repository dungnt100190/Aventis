using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Kiss.Infrastructure;
using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui.Layout;
using Microsoft.Win32;
using SharpLibrary.WinControls;

namespace KiSS4.Gui
{
    /// <summary>
    /// Base class for all child and modal forms in KiSS4
    /// </summary>
    public class KissForm : Form, IKissDataNavigator, IKissContext, IKissActiveSQLQuery, IKissTranslation, IKissTranslatable
    {
        #region DllImport

        // Import GetFocus() from user32.dll
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        internal static extern IntPtr GetFocus();

        [DllImport("user32.dll")]
        private static extern bool LockWindowUpdate(IntPtr hWndLock);

        [DllImport("user32.dll")]
        private static extern int ShowScrollBar(IntPtr hWnd, int wBar, int bShow);

        #endregion DllImport

        #region Fields

        #region Protected Fields

        /// <summary>
        /// The data navigator.
        /// </summary>
        protected KissDataNavigator kissDataNavigator;

        /// <summary>
        /// Gets a value indicating whether the user cancelled the operation.
        /// </summary>
        /// <value><c>true</c> if [user cancel]; otherwise, <c>false</c>.</value>
        protected bool userCancel = true;

        #endregion Protected Fields

        #region Private Constant/Read-Only Fields

        private const int SB_BOTH = 3;
        private const int SB_CTL = 2;
        private const int SB_HORZ = 0;
        private const int SB_VERT = 1;
        private readonly KissContext _kissContext;

        #endregion Private Constant/Read-Only Fields

        #region Private Fields

        private int _lockCloseCounter; // count the close-lock requests used to prevent closing of form
        private UtilShowDetail _showDetail;

        /// <summary>
        /// The translation of this component.
        /// </summary>
        private KissTranslation _translation;

        #endregion Private Fields

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KissForm"/> class.
        /// </summary>
        public KissForm()
        {
            // init form
            InitializeComponent();

            // set instances
            kissDataNavigator = new KissDataNavigator(this);
            _kissContext = new KissContext(this);

            RestoreOnLogin = true;

            // init
            ResetLockCloseForm();

            if (Session.IsKiss5Mode)
            {
                Icon = null;
                ShowIcon = false;
            }
        }

        #endregion Constructors

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KissForm));
            this.SuspendLayout();
            //
            // KissForm
            //
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = GuiConfig.PanelColor;
            this.ClientSize = new System.Drawing.Size(292, 286);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "KissForm";
            this.ResumeLayout(false);
        }

        #endregion Windows Form Designer generated code

        #region Events

        public event EventHandler AddData
        {
            add { kissDataNavigator.onAddData += value; }
            remove { kissDataNavigator.onAddData -= value; }
        }

        public event EventHandler DeleteData
        {
            add { kissDataNavigator.onDeleteData += value; }
            remove { kissDataNavigator.onDeleteData -= value; }
        }

        /// <summary>
        /// Event raised when saving the layout.
        /// </summary>
        public event KissLayoutEventHandler GettingLayout;

        /// <summary>
        /// Event to handel the KeyDown event in child-controls
        /// </summary>
        /// <returns>a <see cref="KeyEventHandler"/></returns>
        public event KeyEventHandler KeyDownKiss
        {
            add { kissDataNavigator.onKeyDownKiss += value; }
            remove { kissDataNavigator.onKeyDownKiss -= value; }
        }

        public event EventHandler MoveFirst
        {
            add { kissDataNavigator.onMoveFirst += value; }
            remove { kissDataNavigator.onMoveFirst -= value; }
        }

        public event EventHandler MoveLast
        {
            add { kissDataNavigator.onMoveLast += value; }
            remove { kissDataNavigator.onMoveLast -= value; }
        }

        public event EventHandler MoveNext
        {
            add { kissDataNavigator.onMoveNext += value; }
            remove { kissDataNavigator.onMoveNext -= value; }
        }

        public event EventHandler MovePrevious
        {
            add { kissDataNavigator.onMovePrevious += value; }
            remove { kissDataNavigator.onMovePrevious -= value; }
        }

        public event EventHandler Print
        {
            add { _kissContext.onPrint += value; }
            remove { _kissContext.onPrint -= value; }
        }

        public event EventHandler RefreshData
        {
            add { kissDataNavigator.onRefreshData += value; }
            remove { kissDataNavigator.onRefreshData -= value; }
        }

        public event EventHandler RestoreData
        {
            add { kissDataNavigator.onResotreData += value; }
            remove { kissDataNavigator.onResotreData -= value; }
        }

        public event EventHandler SaveData
        {
            add { kissDataNavigator.onSaveData += value; }
            remove { kissDataNavigator.onSaveData -= value; }
        }

        public event EventHandler Search
        {
            add { kissDataNavigator.onSearch += value; }
            remove { kissDataNavigator.onSearch -= value; }
        }

        /// <summary>
        /// Event raised when restoring the layout.
        /// </summary>
        public event KissLayoutEventHandler SettingLayout;

        public event EventHandler UndoDataChanges
        {
            add { kissDataNavigator.onUndoDataChanges += value; }
            remove { kissDataNavigator.onUndoDataChanges -= value; }
        }

        #endregion Events

        #region Properties

        /// <summary>
        /// Gets the active SQL query.
        /// </summary>
        /// <value>The active SQL query.</value>
        [DefaultValue(null)]
        public virtual SqlQuery ActiveSQLQuery
        {
            get;
            set;
        }

        /// <summary>
        /// Current <see cref="KissUserControl"/>
        /// </summary>
        /// <value></value>
        [Browsable(false)]
        public virtual KissUserControl DetailControl
        {
            get
            {
                return _showDetail != null ? _showDetail.DetailControl as KissUserControl : null;
            }
        }

        IKissUserControl IKissActiveSQLQuery.DetailControl
        {
            get { return DetailControl; }
        }

        /// <summary>
        /// Get flag if closing is locked and therefore form cannot be closed
        /// </summary>
        [Browsable(false)]
        public bool IsClosingLocked
        {
            get { return (_lockCloseCounter > 0); }
        }

        /// <summary>
        /// Gets a flag that indicates whether this form should be opened after logging in.
        /// </summary>
        public bool RestoreOnLogin
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the translation.
        /// </summary>
        /// <value>The translation.</value>
        [Browsable(false)]
        public KissTranslation Translation
        {
            get
            {
                if (_translation == null && !DesignMode && Session.User != null)
                {
                    _translation = new KissTranslation(this);
                }

                return _translation;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the user cancelled the operation.
        /// </summary>
        /// <value><c>true</c> if [user cancel]; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public bool UserCancel
        {
            get { return userCancel; }
        }

        /// <summary>
        /// The key where layouts are saved.
        /// </summary>
        private static RegistryKey LayoutRegistry
        {
            get
            {
                RegistryKey ret = Session.UserAppDataRegistry;
                ret = ret.CreateSubKey("Layout");
                return ret;
            }
        }

        /// <summary>
        /// Get flag if current window type can be maximised
        /// </summary>
        private bool CanBeMaximised
        {
            get { return !(this is KissDialog || Modal); }
        }

        /// <summary>
        /// Get if form has to be painted in special maximized state (special hack-handling with preventing flicker, etc.)
        /// Return value <c>True</c> means: KissMainForm exists and has maximised child forms
        /// </summary>
        private bool PaintFormSpecialMaximized
        {
            get
            {
                // get main
                KissMainForm mainForm = GetKissMainForm();

                // validate
                if (mainForm == null || mainForm.ActiveMdiChild == null || mainForm.MdiChildren.Length < 2 || !CanBeMaximised)
                {
                    // do not paint form as special maximised
                    return false;
                }

                // get current maximised state
                return mainForm.ActiveMdiChild.WindowState == FormWindowState.Maximized;
            }
        }

        #endregion Properties

        #region EventHandlers

        public static IKissContext GetParent_IKissContext(Control ctl)
        {
            return KissContext.GetParent_IKissContext(ctl);
        }

        #endregion EventHandlers

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Gets the kiss main form.
        /// </summary>
        /// <returns></returns>
        public static KissMainForm GetKissMainForm()
        {
            if (Session.MainForm is KissMainForm)
            {
                return (KissMainForm)Session.MainForm;
            }

            return null;
        }

        #endregion Public Static Methods

        #region Public Methods

        /// <summary>
        /// Activates the form and gives it focus (special handling to reduce flickering on maximized mdi child state)
        /// </summary>
        public new void Activate()
        {
            // get maximized state
            bool isSpecialMaximized = PaintFormSpecialMaximized;
            bool kissMainFormLocked = false;

            try
            {
                // lock painting main form
                kissMainFormLocked = LockKissMainForm();

                // due to flickering in mdi-window change when maximized, suspend painting child forms
                if (isSpecialMaximized)
                {
                    // do not paint child forms
                    SuspendResumePaintingChildForms(true);
                }

                // activate form now
                base.Activate();
            }
            finally
            {
                if (isSpecialMaximized)
                {
                    // resume painting child forms
                    SuspendResumePaintingChildForms(false);
                }

                // resume painting main form
                UnlockKissMainForm(kissMainFormLocked);
            }
        }

        /// <summary>
        /// Deletes the layout registry.
        /// </summary>
        public virtual void DeleteLayoutRegistry()
        {
            RegistryKey registry = Session.UserAppDataRegistry;

            try
            {
                registry.DeleteSubKeyTree("Layout");
            }
            catch { }
        }

        public virtual string GetContextName()
        {
            return _kissContext.GetContextName();
        }

        public virtual object GetContextValue(string fieldName)
        {
            return _kissContext.GetContextValue(fieldName);
        }

        /// <summary>
        /// Gets the Control that has the current focus
        /// </summary>
        /// <returns>Control with current focus</returns>
        public Control GetFocusControl()
        {
            Control focusControl = null;
            IntPtr focusHandle = GetFocus();

            if (focusHandle != IntPtr.Zero)
            {
                // returns null if handle is not to a .NET control
                focusControl = FromHandle(focusHandle);
            }

            return focusControl;
        }

        /// <summary>
        /// Gets the <see cref="KissControlLayout"/> for this <see cref="KissForm"/>.
        /// </summary>
        /// <remarks>The WindowState is set to Normal before populating the <see cref="KissControlLayout"/>.</remarks>
        public KissControlLayout GetLayout(out LayoutErrorCollection errors)
        {
            KissControlLayout ret = new KissControlLayout(Name);

            // lock painting kiss main form
            bool kissMainFormLocked = LockKissMainForm();

            // stop painting
            SuspendPainting(false);

            try
            {
                // save WindowState
                FormWindowState ws = WindowState;

                // special handling for maximized mdi-children
                if (PaintFormSpecialMaximized)
                {
                    ws = FormWindowState.Maximized;
                }

                // set normal to get its proper size values
                ApplyWindowState(FormWindowState.Normal);

                // create LayoutEventArgs
                KissLayoutEventArgs e = new KissLayoutEventArgs(ret);

                // store WindowState property
                SimpleProperty p = new SimpleProperty("WindowState", (int)ws);

                try
                {
                    e.Layout.Properties.Add(p);
                }
                catch (Exception ex)
                {
                    e.Errors.Add(new LayoutError(p, ex));
                }

                // populate layout
                OnGettingLayout(e);

                // reset WindowState
                ApplyWindowState(ws);

                errors = e.Errors;
                return ret;
            }
            finally
            {
                // unlock painting kiss main form
                UnlockKissMainForm(kissMainFormLocked);

                // repaint
                ResumePainting(false);
            }
        }

        bool IKissDataNavigator.AddData()
        {
            return OnAddData();
        }

        bool IKissDataNavigator.DeleteData()
        {
            return OnDeleteData();
        }

        /// <summary>
        /// To handel the KeyDown event in child-controls
        /// </summary>
        /// <param name="keyEvent">the <see cref="KeyEventArgs"/> that the user has pressed</param>
        /// <returns>true if the key could be handeld, else false</returns>
        bool IKissDataNavigator.KeyDownKiss(KeyEventArgs keyEvent)
        {
            return OnKeyDownKiss(keyEvent);
        }

        void IKissDataNavigator.MoveFirst()
        {
            OnMoveFirst();
        }

        void IKissDataNavigator.MoveLast()
        {
            OnMoveLast();
        }

        void IKissDataNavigator.MoveNext()
        {
            OnMoveNext();
        }

        void IKissDataNavigator.MovePrevious()
        {
            OnMovePrevious();
        }

        void IKissDataNavigator.RefreshData()
        {
            OnRefreshData();
        }

        /// <summary>
        ///  A logical deleted row will be restored.
        ///  See boolean column IsDeleted.
        /// </summary>
        /// <returns></returns>
        bool IKissDataNavigator.RestoreData()
        {
            return OnRestoreData();
        }

        bool IKissDataNavigator.SaveData()
        {
            return OnSaveData();
        }

        void IKissDataNavigator.Search()
        {
            OnSearch();
        }

        void IKissDataNavigator.UndoDataChanges()
        {
            OnUndoDataChanges();
        }

        /// <summary>
        /// Prevent window from closing. Remember to call UnlockCloseForm() after finished work!
        /// </summary>
        public void LockCloseForm()
        {
            // count up lock conunter
            _lockCloseCounter++;
        }

        public virtual bool OnAddData()
        {
            return kissDataNavigator.AddData();
        }

        public virtual bool OnDeleteData()
        {
            return kissDataNavigator.DeleteData();
        }

        /// <summary>
        /// To handel the KeyDown event in child-controls
        /// </summary>
        /// <param name="keyEvent">the <see cref="KeyEventArgs"/> that the user has pressed</param>
        /// <returns>true if the key could be handeld, else false</returns>
        public virtual bool OnKeyDownKiss(KeyEventArgs keyEvent)
        {
            return kissDataNavigator.KeyDownKiss(keyEvent);
        }

        public virtual void OnMoveFirst()
        {
            kissDataNavigator.MoveFirst();
        }

        public virtual void OnMoveLast()
        {
            kissDataNavigator.MoveLast();
        }

        public virtual void OnMoveNext()
        {
            kissDataNavigator.MoveNext();
        }

        public virtual void OnMovePrevious()
        {
            kissDataNavigator.MovePrevious();
        }

        public virtual void OnPrint()
        {
            _kissContext.PrintReport();
        }

        public virtual void OnRefreshData()
        {
            kissDataNavigator.RefreshData();
        }

        public virtual bool OnRestoreData()
        {
            return kissDataNavigator.RestoreData();
        }

        public virtual bool OnSaveData()
        {
            return kissDataNavigator.SaveData();
        }

        public virtual void OnSearch()
        {
            kissDataNavigator.Search();
        }

        public virtual void OnUndoDataChanges()
        {
            kissDataNavigator.UndoDataChanges();
        }

        public void PrintReport()
        {
            OnPrint();
        }

        /// <summary>
        /// Reset any applied lock for closing form (e.g. when form cannot be closed due to missing UnlockFormClose() call)
        /// </summary>
        public void ResetLockCloseForm()
        {
            _lockCloseCounter = 0;
        }

        /// <summary>
        /// Get a <see cref="KissControlLayout"/> from the registry and restore properties in the form.
        /// </summary>
        /// <exception cref="LayoutException">The layout was restored, but errors occurred.</exception>
        /// <exception cref="Exception">Something worse happened.</exception>
        public void RestoreLayout()
        {
            string xml = (string)LayoutRegistry.GetValue(Name);

            if (xml == null)
            {
                return;
            }

            // get KissControlLayout
            var doc = new XmlDocument();
            doc.LoadXml(xml); // warning: does not preserve white space; this is currently ok.
            var layout = KissControlLayout.FromXml(doc.DocumentElement);

            if (layout == null)
            {
                return;
            }

            // do it: apply stored layout
            LayoutErrorCollection errors;
            SetLayout(layout, out errors);

            if (errors.Count > 0)
            {
                throw new LayoutException(errors);
            }
        }

        // virtual because FrmMain overrides it to do nothing
        /// <summary>
        /// Create a <see cref="KissControlLayout"/> object, populate it and write the content to the registry.
        /// </summary>
        /// <exception cref="LayoutException">The layout was saved, but errors occurred.</exception>
        /// <exception cref="Exception">The layout was not saved.</exception>
        public virtual void SaveLayout()
        {
            LayoutErrorCollection errors;
            KissControlLayout layout = GetLayout(out errors);

            // get xml
            XmlDocument doc = layout.ToXml();

            if (doc == null)
            {
                // delete from registry if there
                LayoutRegistry.DeleteValue(Name, false);
            }
            else
            {
                // get as string
                StringBuilder sb = new StringBuilder();
                TextWriter tw = new StringWriter(sb);
                XmlTextWriter xtw = new XmlTextWriter(tw) { Formatting = Formatting.Indented };
                doc.Save(xtw);
                string xml = sb.ToString();
                Debug.WriteLine(xml);

                // add/update value in registry
                LayoutRegistry.SetValue(Name, xml);
            }

            if (errors.Count > 0)
            {
                throw new LayoutException(errors);
            }
        }

        /// <summary>
        /// Sets the <see cref="KissControlLayout"/> for this <see cref="KissForm"/>.
        /// </summary>
        /// <remarks>The WindowState is set to Normal before restoring the <see cref="KissControlLayout"/>.</remarks>
        public void SetLayout(KissControlLayout value, out LayoutErrorCollection errors)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            // get special maximized state
            bool isSpecialMaximized = PaintFormSpecialMaximized;

            if (isSpecialMaximized)
            {
                // stop painting
                SuspendPainting(true);
            }

            try
            {
                // save WindowState and set to Normal
                FormWindowState ws = WindowState;
                FormWindowState wsOriginal = WindowState;

                // create LayoutEventArgs
                KissLayoutEventArgs e = new KissLayoutEventArgs(value);

                // get WindowState property from layout

                try
                {
                    SimpleProperty p = (SimpleProperty)e.Layout.Properties["WindowState"];

                    try
                    {
                        ws = (FormWindowState)(int)p.Value;
                    }
                    catch (Exception ex)
                    {
                        e.Errors.Add(new LayoutError(p, ex));
                    }
                }
                catch { }

                // set layout
                OnSettingLayout(e);

                // see #5407: set window state depending on current conditions:
                // a) no forms opened yet: apply window state from layout
                // b) forms opened: apply window state from other forms
                KissMainForm mainForm = GetKissMainForm();

                if (mainForm != null)
                {
                    // count children (current form will be already counted, too)
                    if (mainForm.MdiChildren.Length > 1)
                    {
                        // apply window state of other child forms
                        ApplyWindowState(wsOriginal);
                    }
                    else
                    {
                        // first child window, set state from layout
                        ApplyWindowState(ws);
                    }
                }
                else
                {
                    // check if this is mainform
                    if (this is KissMainForm)
                    {
                        // set state as defined in layout
                        ApplyWindowState(ws);
                    }
                    else
                    {
                        // no main form > this state should not occure > apply default window state
                        ApplyWindowState(wsOriginal);
                    }
                }

                errors = e.Errors;
            }
            finally
            {
                if (isSpecialMaximized)
                {
                    // resume painting
                    ResumePainting(true);
                }
            }
        }

        /// <summary>
        /// Displays the control to the user (special handling to reduce flickering on maximized mdi child state)
        /// </summary>
        public new void Show()
        {
            // get maximized state
            bool isSpecialMaximized = PaintFormSpecialMaximized;
            bool kissMainFormLocked = false;

            try
            {
                // lock painting main form
                kissMainFormLocked = LockKissMainForm();

                // due to flickering in mdi-window change when maximized, suspend painting for main form
                if (isSpecialMaximized)
                {
                    // do not paint child forms
                    SuspendResumePaintingChildForms(true);
                }

                // show form now
                base.Show();
            }
            finally
            {
                if (isSpecialMaximized)
                {
                    // resume painting child forms
                    SuspendResumePaintingChildForms(false);
                }

                // resume painting main form
                UnlockKissMainForm(kissMainFormLocked);
            }
        }

        /// <summary>
        /// Translate the components of this instance.
        /// </summary>
        public virtual void Translate()
        {
            if (Translation != null)
            {
                Translation.Translate(Session.User.LanguageCode);
            }
        }

        /// <summary>
        /// Allow window closing again
        /// </summary>
        public void UnlockCloseForm()
        {
            // count down lock counter to minimum of 0
            _lockCloseCounter = Math.Max(_lockCloseCounter - 1, 0);
        }

        #endregion Public Methods

        #region Internal Static Methods

        /// <summary>
        /// Scans the tab controls.
        /// </summary>
        /// <param name="parentControl">The parent control.</param>
        /// <param name="bindContext">The bind context.</param>
        internal static void ScanTabControls(Control parentControl, BindingContext bindContext)
        {
            foreach (Control ctl in parentControl.Controls)
            {
                if (ctl is TabControlEx)
                {
                    foreach (TabPageEx page in ((TabControlEx)ctl).TabPages)
                    {
                        page.BindingContext = bindContext;
                    }
                }
                else
                {
                    if (!(ctl is UserControl))
                    {
                        ScanTabControls(ctl, bindContext);
                    }
                }
            }
        }

        #endregion Internal Static Methods

        #region Protected Methods

        /// <summary>
        /// Activates the user control.
        /// </summary>
        /// <param name="newSubMask">The new sub mask.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="forceDispose">if set to <c>true</c> [force dispose].</param>
        /// <returns></returns>
        protected bool ActivateUserControl(IKissView newSubMask, Control parent, bool forceDispose)
        {
            return UtilsGui.ActivateUserControl(newSubMask, parent, forceDispose, ref _showDetail);
        }

        /// <summary>
        /// Activates the user control.
        /// </summary>
        /// <param name="newSubMask">The new sub mask.</param>
        /// <param name="parent">The parent.</param>
        /// <returns></returns>
        protected bool ActivateUserControl(KissUserControl newSubMask, Control parent)
        {
            return ActivateUserControl(newSubMask, parent, false);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Closing"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.ComponentModel.CancelEventArgs"></see> that contains the event data.</param>
        protected override void OnClosing(CancelEventArgs e)
        {
            // check if window can be closed
            if (IsClosingLocked)
            {
                // window cannot be closed at the moment
                e.Cancel = true;
                return;
            }

            // save pending changes
            if (!OnSaveData())
            {
                if (!KissMsg.ShowQuestion("KissForm", "FensterSchliessenOhneSpeichern", "Fenster trotz der nicht gespeicherten Daten schliessen ?"))
                {
                    e.Cancel = true;
                    return;
                }
                OnUndoDataChanges();
            }

            e.Cancel = false;
            base.OnClosing(e);

            // save layout
            if (!e.Cancel)
            {
                try
                {
                    SaveLayout();
                }
                catch (LayoutException ex)
                {
                    KissMsg.ShowError("KissForm", "LayoutTeilweiseGespeichert", "Layout konnte teilweise nicht gespeichert werden.", ex);
                }
                catch (Exception ex)
                {
                    KissMsg.ShowError("KissForm", "LayoutNichtGespeichert", "Layout konnte nicht gespeichert werden.", ex);
                }
            }

            this.SaveLayoutOfChildControls();
        }

        /// <summary>
        /// Stores the window's Left, Top, Width, Hight properties, then raises the <see cref="GettingLayout"/> event.
        /// </summary>
        /// <remarks>Note to inheritors: base implementation must be called.</remarks>
        protected virtual void OnGettingLayout(KissLayoutEventArgs e)
        {
            // store window position properties
            SimpleProperty p = new SimpleProperty("Left", Left);

            try
            {
                e.Layout.Properties.Add(p);
            }
            catch (Exception ex)
            {
                e.Errors.Add(new LayoutError(p, ex));
            }

            p = new SimpleProperty("Top", Top);

            try
            {
                e.Layout.Properties.Add(p);
            }
            catch (Exception ex)
            {
                e.Errors.Add(new LayoutError(p, ex));
            }

            p = new SimpleProperty("Width", Width);

            try
            {
                e.Layout.Properties.Add(p);
            }
            catch (Exception ex)
            {
                e.Errors.Add(new LayoutError(p, ex));
            }

            p = new SimpleProperty("Height", Height);

            try
            {
                e.Layout.Properties.Add(p);
            }
            catch (Exception ex)
            {
                e.Errors.Add(new LayoutError(p, ex));
            }

            // raise the event
            if (GettingLayout != null)
            {
                GettingLayout(this, e);
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            // restore any possibly saved layout
            try
            {
                // do restore layout
                RestoreLayout();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("KissForm", "LayoutTeilweiseGeladen_v01", "Das Layout konnte nur teilweise geladen werden.", ex);
            }

            // let base do stuff
            base.OnHandleCreated(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.KeyDown"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs"></see> that contains the event data.</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Handled)
            {
                return;
            }

            //Restore logical deleted row
            //This is done by pressing Ctrl and F8.
            if (e.KeyCode == Keys.F8 && e.Control)
            {
                OnRestoreData();
                e.Handled = true;
            }

            KeyDownHandler.OnKeyDown(ActiveControl, this, e);

            #region Simulate Toolbar of KissMainForm

            if (MdiParent == null && !IsMdiContainer)
            {
                if (e.Modifiers == Keys.Control)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Home:
                            OnMoveFirst();
                            break;

                        case Keys.Up:
                            OnMovePrevious();
                            break;

                        case Keys.Down:
                            OnMoveNext();
                            break;

                        case Keys.End:
                            OnMoveLast();
                            break;
                    }
                }
                else if (e.Modifiers == Keys.None)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.F5:
                            OnAddData();
                            break;

                        case Keys.F2:
                            OnSaveData();
                            break;

                        case Keys.F6:
                            OnUndoDataChanges();
                            break;

                        case Keys.F8:
                            OnDeleteData();
                            break;

                        case Keys.F7:
                            OnRefreshData();
                            break;

                        case Keys.F3:
                            OnSearch();
                            break;

                        case Keys.F9:
                            OnPrint();
                            break;
                    }
                }
            }

            #endregion Simulate Toolbar of KissMainForm

            OnKeyDownKiss(e);

            base.OnKeyDown(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Load"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            if (GuiConfig.Theme != GuiConfig.KissTheme.None)
            {
                this.BackColor = GuiConfig.PanelColor;
                foreach (Control c in UtilsGui.AllControls(this))
                {
                    if (c is KissTree) ((KissTree)c).Recolor();
                    if (c is KissGrid) ((KissGrid)c).SetDefaultLayout();
                    if (c is KissHyperlinkButton) ((KissHyperlinkButton)c).ButtonStyle = ((KissHyperlinkButton)c).ButtonStyle; // enforce private KissButton.SetAppearance
                    if (c is Panel) c.BackColor = GuiConfig.PanelColor;
                    if (c is TabControlEx) c.BackColor = GuiConfig.colBack05;
                    if (c is KissSplitterCollapsible) c.BackColor = GuiConfig.colBack05;
                }
            }

            //redirect the Binding Context of ale SharpLibrary.TabPageEx (UserControl) to the Binding Context of the form
            //(TabPages within UserControls are not touched)
            ScanTabControls(this, BindingContext);

            Translate();

            ApplicationFacade.DoEvents();

            base.OnLoad(e);
        }

        /// <summary>
        /// Stores the window's Left, Top, Width, Hight properties, then raises the <see cref="SettingLayout"/> event.
        /// </summary>
        /// <remarks>Note to inheritors: base implementation must be called.</remarks>
        protected virtual void OnSettingLayout(KissLayoutEventArgs e)
        {
            // restore window position properties

            int offsetLeft = 0;
            int offsetTop = 0;

            // stop painting
            SuspendPainting(false);

            try
            {
                // check current mode
                SimpleProperty p;

                if (FormBorderStyle == FormBorderStyle.Sizable ||
                    FormBorderStyle == FormBorderStyle.SizableToolWindow)
                {
                    try
                    {
                        p = (SimpleProperty)e.Layout.Properties["Width"];

                        try
                        {
                            offsetLeft = ((int)p.Value - Width) / 2;
                            Width = (int)p.Value;
                        }
                        catch (Exception ex)
                        {
                            e.Errors.Add(new LayoutError(p, ex));
                        }
                    }
                    catch { }

                    try
                    {
                        p = (SimpleProperty)e.Layout.Properties["Height"];

                        try
                        {
                            offsetTop = ((int)p.Value - Height) / 2;
                            Height = (int)p.Value;
                        }
                        catch (Exception ex)
                        {
                            e.Errors.Add(new LayoutError(p, ex));
                        }
                    }
                    catch { }
                }

                if (StartPosition == FormStartPosition.CenterParent ||
                    StartPosition == FormStartPosition.CenterScreen)
                {
                    Left += offsetLeft;
                    Top += offsetTop;
                }
                else
                {
                    try
                    {
                        p = (SimpleProperty)e.Layout.Properties["Left"];

                        try
                        {
                            Left = (int)p.Value;
                        }
                        catch (Exception ex)
                        {
                            e.Errors.Add(new LayoutError(p, ex));
                        }
                    }
                    catch { }

                    try
                    {
                        p = (SimpleProperty)e.Layout.Properties["Top"];

                        try
                        {
                            Top = (int)p.Value;
                        }
                        catch (Exception ex)
                        {
                            e.Errors.Add(new LayoutError(p, ex));
                        }
                    }
                    catch { }
                }

                // raise the event
                if (SettingLayout != null)
                {
                    SettingLayout(this, e);
                }
            }
            finally
            {
                ResumePainting(false);
            }
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Apply the window state if not already set
        /// </summary>
        /// <param name="ws">The window state to apply</param>
        private void ApplyWindowState(FormWindowState ws)
        {
            if (WindowState != ws && CanBeMaximised)
            {
                WindowState = ws;
            }
        }

        /// <summary>
        /// Lock painting main form
        /// </summary>
        /// <returns><c>True</c> if main form was locked, otherwise <c>False</c></returns>
        private bool LockKissMainForm()
        {
            // get main
            KissMainForm mainForm = GetKissMainForm();

            if (mainForm != null && !(this is KissMainForm))
            {
                // prevent painting main form
                LockWindowUpdate(mainForm.Handle);

                // lock applied
                return true;
            }

            // no lock applied
            return false;
        }

        /// <summary>
        /// Resume painting of form and optionally main form
        /// </summary>
        /// <param name="resumeMainForm"><c>True</c> if need to resume painting main form, <c>False</c> will not resume painting main form</param>
        private void ResumePainting(bool resumeMainForm)
        {
            // handle main form
            if (resumeMainForm)
            {
                KissMainForm mainForm = GetKissMainForm();

                if (mainForm != null)
                {
                    mainForm.ResumeLayout();
                }
            }

            // handle this form
            ResumeLayout();
        }

        /// <summary>
        /// Suspend painting of form and optionally main form
        /// </summary>
        /// <param name="suspendMainForm"><c>True</c> if need to suspend painting main form, <c>False</c> will not suspend painting main form</param>
        private void SuspendPainting(bool suspendMainForm)
        {
            // handle this form
            SuspendLayout();

            // handle main form
            if (suspendMainForm)
            {
                KissMainForm mainForm = GetKissMainForm();

                if (mainForm != null)
                {
                    mainForm.SuspendLayout();
                }
            }
        }

        /// <summary>
        /// Suspend or resume painting all child forms (except this one)
        /// </summary>
        /// <param name="suspend"><c>True</c> will suspend painting, <c>False</c> will resume painting</param>
        private void SuspendResumePaintingChildForms(bool suspend)
        {
            // get and validate main form
            KissMainForm mainForm = GetKissMainForm();

            if (mainForm == null || !mainForm.HasChildren)
            {
                // nothing to do
                return;
            }

            // loop all child forms
            foreach (Form frm in mainForm.MdiChildren)
            {
                if (frm == this)
                {
                    // do nothing as this is handled separated
                    continue;
                }

                if (suspend)
                {
                    frm.SuspendLayout();
                }
                else
                {
                    frm.ResumeLayout();
                }
            }
        }

        /// <summary>
        /// Unlock painting main form
        /// </summary>
        /// <param name="wasLocked"><c>True</c> will unlock (if form was locked), <c>False</c> will not unlock form as it was not locked</param>
        private void UnlockKissMainForm(bool wasLocked)
        {
            if (wasLocked)
            {
                // resume painting main form
                LockWindowUpdate(IntPtr.Zero);

                // check if dialog or something like that (no further scrollbar-handling!)
                if (!CanBeMaximised)
                {
                    // do nothing more
                    return;
                }

                // get main
                KissMainForm mainForm = GetKissMainForm();

                // validate main
                if (mainForm != null && !(this is KissMainForm))
                {
                    // find mdiclient control
                    foreach (Control ctl in mainForm.Controls)
                    {
                        if (ctl is MdiClient)
                        {
                            // check if current state is maximized
                            if (PaintFormSpecialMaximized || (mainForm.MdiChildren.Length < 2 && WindowState == FormWindowState.Maximized))
                            {
                                // HACK: prevent having scrollbars when maximized
                                // see: http://www.codeproject.com/KB/dialog/mdiclientcontroller.aspx#Hiding the Scrollbars
                                // > as described, the scrollbar will be visible automatically again on recalculating non-client-area
                                ShowScrollBar(ctl.Handle, SB_BOTH, 0 /*false*/);
                            }
                            else
                            {
                                // HACK: force showing scrollbars as these would only be visible when moving the form (already before KiSS4.1.39)
                                // known-issue: the scrollbars will resize the scroll-bar-element when moving the mousecursor on it
                                if ((Left + Width) > ctl.ClientSize.Width &&
                                    (Top + Height) > ctl.ClientSize.Height)
                                {
                                    // H-Scroll + V-Scroll
                                    ShowScrollBar(ctl.Handle, SB_BOTH, 1 /*true*/);
                                }
                                else if ((Left + Width) > ctl.ClientSize.Width)
                                {
                                    // H-Scroll only
                                    ShowScrollBar(ctl.Handle, SB_HORZ, 1 /*true*/);
                                }
                                else if ((Top + Height) > ctl.ClientSize.Height)
                                {
                                    // V-Scroll only
                                    ShowScrollBar(ctl.Handle, SB_VERT, 1 /*true*/);
                                }
                            }

                            // done
                            break;
                        }
                    }
                }
            }
        }

        #endregion Private Methods

        #endregion Methods
    }
}