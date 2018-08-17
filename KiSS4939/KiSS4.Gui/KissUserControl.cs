using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
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
    /// Summary description for KissUserControl.
    /// </summary>
    public partial class KissUserControl : KissComplexControl, IKissUserControl
    {
        /// <summary>
        /// The data navigator.
        /// </summary>
        protected KissDataNavigator kissDataNavigator;

        private readonly KissContext _kissContext;

        private bool _autoPost = true;
        private bool _autoRefresh = true;
        private bool _isNew = true;
        private UtilShowDetail _showDetail;

        /// <summary>
        /// Initializes a new instance of the <see cref="KissUserControl"/> class.
        /// </summary>
        public KissUserControl()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            kissDataNavigator = new KissDataNavigator(this);
            _kissContext = new KissContext(this);
        }

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

        /// <summary>
        /// Gets or sets a value indicating whether [auto post].
        /// </summary>
        /// <value><c>true</c> if [auto post]; otherwise, <c>false</c>.</value>
        [Browsable(true)]
        [DefaultValue(true)]
        public bool AutoPost
        {
            get { return _autoPost; }
            set { _autoPost = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [auto refresh].
        /// </summary>
        /// <value><c>true</c> if [auto refresh]; otherwise, <c>false</c>.</value>
        [Browsable(true)]
        [DefaultValue(true)]
        public bool AutoRefresh
        {
            get { return _autoRefresh; }
            set { _autoRefresh = value; }
        }

        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Control Control
        {
            get { return this; }
        }

        /// <summary>
        /// Current <see cref="KissUserControl"/>
        /// </summary>
        /// <value></value>
        [Browsable(false)]
        [DefaultValue(null)]
        public virtual KissUserControl DetailControl
        {
            get
            {
                return _showDetail != null ? _showDetail.DetailControl as KissUserControl : null;
            }
        }

        /// <summary>
        /// Spezialbehandlung für TabPageEx. Wenn die Maske ein TabPageControl enthält, wird die aktuelle TabPage als ActiveControl zurückgegeben
        /// und nicht das darin enthaltene Control mit Fokus.
        /// Abhilfe: aktives Tab noch einmal fragen.
        /// </summary>
        Control IKissActiveSQLQuery.ActiveControl
        {
            get
            {
                var activeControl = ActiveControl;

                var activeTabPageControl = activeControl as TabPageEx;

                if (activeTabPageControl != null)
                {
                    //TabControl sagt falscherweise, dass die aktive TabPage das aktive Control sei.
                    //Abhilfe: aktives Tab noch einmal fragen, so dass das darin enthaltene Control mit Fokus zurückgegeben wird.
                    return activeTabPageControl.ActiveControl;
                }

                return activeControl;
            }
        }

        IKissUserControl IKissActiveSQLQuery.DetailControl
        {
            get { return DetailControl; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is new.
        /// </summary>
        /// <value><c>true</c> if this instance is new; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public bool IsNew
        {
            get { return _isNew; }
        }

        [Browsable(false),
                DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Control ParentControl
        {
            get
            {
                return Parent;
            }
            set
            {
                if (value == null)
                {
                    // Parent was removed
                    Dock = DockStyle.None;
                    Parent = null;
                }
                else
                {
                    Parent = value;
                    Location = new System.Drawing.Point(0, 0);
                    Size = Parent.Size;
                    Dock = DockStyle.Fill;
                }
            }
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        public override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
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

        public static IKissContext GetParent_IKissContext(Control ctl)
        {
            return KissContext.GetParent_IKissContext(ctl);
        }

        /// <summary>
        /// Executes Tasks before the view can be closed
        /// </summary>
        /// <returns><c>true</c> if the View can be closed</returns>
        public virtual bool BeforeCloseView()
        {
            return true;
        }

        /// <summary>
        /// Deletes the layout registry.
        /// </summary>
        public virtual void DeleteLayoutRegistry()
        {
            RegistryKey registry = Session.UserAppDataRegistry;
            registry.DeleteSubKeyTree("Layout");
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
        /// Gets the <see cref="KissControlLayout"/> for this <see cref="KissForm"/>.
        /// </summary>
        /// <remarks>The WindowState is set to Normal before populating the <see cref="KissControlLayout"/>.</remarks>
        public KissControlLayout GetLayout(out LayoutErrorCollection errors)
        {
            KissControlLayout ret = new KissControlLayout(Name);

            // create LayoutEventArgs
            KissLayoutEventArgs e = new KissLayoutEventArgs(ret);

            // populate layout
            OnGettingLayout(e);

            errors = e.Errors;
            return ret;
        }

        /// <summary>
        /// Hides the View.
        /// The View has the option to cancel this operation e.g. because some validation failed
        /// </summary>
        /// <returns>false if the view does not allow hiding the view in it's current state, e.g. because some validation failed</returns>
        public bool HideView()
        {
            if (AutoPost)
            {
                return ((IKissDataNavigator)this).SaveData();
            }

            return true;
        }

        bool IKissDataNavigator.AddData()
        {
            return OnAddData();
        }

        bool IKissDataNavigator.DeleteData()
        {
            return OnDeleteData();
        }

        bool IKissDataNavigator.KeyDownKiss(KeyEventArgs e)
        {
            return OnKeyDownKiss(e);
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

        public virtual bool OnAddData()
        {
            return kissDataNavigator.AddData();
        }

        public virtual bool OnDeleteData()
        {
            return kissDataNavigator.DeleteData();
        }

        public virtual bool OnKeyDownKiss(KeyEventArgs e)
        {
            return kissDataNavigator.KeyDownKiss(e);
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

        /// <summary>
        /// A logical deleted row will be restored.
        /// See column "IsDeleted".
        /// </summary>
        /// <returns>If restore data has been successful.</returns>
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

        public virtual bool ReceiveMessage(HybridDictionary parameters)
        {
            // we need at least one parameter to know what to do
            if (parameters == null || parameters.Count < 1)
            {
                // by default, nothing to do
                return true;
            }

            // action depending
            switch (parameters["Action"] as string)
            {
                case "JumpToPath":
                    if (DetailControl != null)
                    {
                        return FormController.SendMessage(DetailControl, parameters);
                    }

                    if (ActiveSQLQuery != null && parameters.Contains("ActiveSQLQuery.Find"))
                    {
                        return ActiveSQLQuery.Count > 0 && ActiveSQLQuery.Find((string)parameters["ActiveSQLQuery.Find"]);
                    }

                    return true;

                default:
                    return false;
            }
        }

        /// <summary>
        /// Get a <see cref="KissControlLayout"/> from the registry and restore properties in the User Control.
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
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml); // warning: does not preserve white space; this is currently ok.
            KissControlLayout layout = KissControlLayout.FromXml(doc.DocumentElement);

            // set
            if (layout != null)
            {
                LayoutErrorCollection errors;
                SetLayout(layout, out errors);

                if (errors.Count > 0)
                {
                    throw new LayoutException(errors);
                }
            }
        }

        public virtual object ReturnMessage(HybridDictionary parameters)
        {
            // we need at least one parameter to know what to do
            if (parameters == null || parameters.Count < 1)
            {
                // by default, nothing to do
                return null;
            }

            // action depending
            switch (parameters["Action"] as string)
            {
                case "GetJumpToPath":
                    HybridDictionary dic = null;

                    if (DetailControl != null)
                    {
                        dic = FormController.GetMessage(DetailControl, parameters) as HybridDictionary;
                    }
                    else if (ActiveSQLQuery != null)
                    {
                        dic = new HybridDictionary();

                        string searchExpression = ActiveSQLQuery.GetSearchExpression();

                        if (searchExpression != null)
                        {
                            dic["ActiveSQLQuery.Find"] = searchExpression;
                        }
                    }
                    return dic;

                default:
                    return null;
            }
        }

        // virtual because FrmMain overrides it to do nothing
        /// <summary>
        /// Saves the layout.
        /// </summary>
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

                // add/update value in registry
                LayoutRegistry.SetValue(Name, xml);
            }

            if (errors.Count > 0)
            {
                throw new LayoutException(errors);
            }
        }

        /// <summary>
        /// Sets the <see cref="KissControlLayout"/> for this <see cref="KissUserControl"/>.
        /// </summary>
        public void SetLayout(KissControlLayout value, out LayoutErrorCollection errors)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            // create LayoutEventArgs
            KissLayoutEventArgs e = new KissLayoutEventArgs(value);

            // set layout
            OnSettingLayout(e);

            errors = e.Errors;
        }

        public void ShowView()
        {
            // Refresh KissUserControl if it is not a new created object
            if (AutoRefresh && !IsNew)
            {
                ((IKissDataNavigator)this).RefreshData();
            }
        }

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
        /// raises the <see cref="GettingLayout"/> event.
        /// </summary>
        /// <remarks>Note to inheritors: base implementation must be called.</remarks>
        protected virtual void OnGettingLayout(KissLayoutEventArgs e)
        {
            // raise the event
            if (GettingLayout != null)
            {
                GettingLayout(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="UserControl.Load"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            if (GuiConfig.Theme != GuiConfig.KissTheme.None)
            {
                this.BackColor = GuiConfig.PanelColor;
                foreach (Control c in UtilsGui.AllControls(this))
                {
                    if (c is KissTree) ((KissTree)c).Recolor();
                    if (c is KissGrid) ((KissGrid)c).SetDefaultLayout();
                    if (c is Panel) c.BackColor = GuiConfig.PanelColor;
                    if (c is KissHyperlinkButton) ((KissHyperlinkButton)c).ButtonStyle = ((KissHyperlinkButton)c).ButtonStyle; // enforce private KissButton.SetAppearance
                    if (c is KissSplitterCollapsible) c.BackColor = GuiConfig.colBack05;
                    if (c is TabControlEx)
                    {
                        c.BackColor = GuiConfig.colBack05;
                        foreach (TabPageEx p in ((TabControlEx)c).TabPages)
                        {
                            p.BackColor = GuiConfig.colBack05;
                        }
                    }
                }
            }

            //redirect the Binding Context of all SharpLibrary.TabPageEx (UserControl) to the Binding Context of the KissUsercontrol
            //(TabPages within UserControls are not touched)
            KissForm.ScanTabControls(this, BindingContext);

            try
            {
                RestoreLayout();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("KissUserControl", "LayoutTeilweiseGeladen", "Layout konnte nur teilweise geladen werden.", ex);
            }

            ApplicationFacade.DoEvents();

            base.OnLoad(e);
            _isNew = false;
        }

        /// <summary>
        /// raises the <see cref="SettingLayout"/> event.
        /// </summary>
        /// <remarks>Note to inheritors: base implementation must be called.</remarks>
        protected virtual void OnSettingLayout(KissLayoutEventArgs e)
        {
            if (SettingLayout != null)
            {
                SettingLayout(this, e);
            }
        }
    }
}