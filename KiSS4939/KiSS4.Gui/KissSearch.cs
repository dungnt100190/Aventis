using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using KiSS4.DB;
using SharpLibrary.WinControls;
using Kiss.Interfaces.UI;

namespace KiSS4.Gui
{
    /// <summary>
    /// Summary description for KissSearch.
    /// </summary>
    public class KissSearch : IDisposable
    {
        #region Static Fields

        private static Regex rxControlName = new Regex(@"{(?<ControlName>\w*)(?:\.(?<PropertyName>\w*))*}");

        #endregion

        #region Fields

        private IKissDataNavigator container;
        private Boolean disabled;
        private Boolean fillDone;
        private Hashtable htControl = new Hashtable();
        private Boolean inSearchEvent;
        private SharpLibrary.WinControls.TabPageEx lastSelectedTab;
        private Object[] selectParameters = new Object[] { };
        private String selectStatement;
        private SqlQuery sqlQuery;
        private KissTabControlEx tabControl;
        private SharpLibrary.WinControls.TabPageEx tpgListe;
        private SharpLibrary.WinControls.TabPageEx tpgSuchen;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KissSearch"/> class.
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="tabControl"></param>
        /// <param name="tpgSuchen"></param>
        /// <param name="tpgListe"></param>
        public KissSearch(KissUserControl ctl, KissTabControlEx tabControl, TabPageEx tpgSuchen, TabPageEx tpgListe)
            : this(tabControl, tpgSuchen, tpgListe)
        {
            container = (IKissDataNavigator)ctl;
            ctl.Search += new EventHandler(ctl_Search);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KissSearch"/> class.
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="tabControl"></param>
        /// <param name="tpgSuchen"></param>
        /// <param name="tpgListe"></param>
        public KissSearch(KissForm frm, KissTabControlEx tabControl, TabPageEx tpgSuchen, TabPageEx tpgListe)
            : this(tabControl, tpgSuchen, tpgListe)
        {
            container = (IKissDataNavigator)frm;
            frm.Search += new EventHandler(ctl_Search);
        }

        /// <summary>
        /// Run search with additional query to kissSearch
        /// </summary>
        /// <param name="kissSearch">The main instance of kissSearch where control/form and tabpages are set</param>
        /// <param name="sqlQuery">The query to fill in addition to kissSearch main query</param>
        public KissSearch(KissSearch kissSearch, SqlQuery sqlQuery)
        {
            this.sqlQuery = sqlQuery;
            this.tpgSuchen = kissSearch.tpgSuchen;
            kissSearch.RunSearch += new EventHandler(kissSearch_RunSearch);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KissSearch"/> class.
        /// </summary>
        /// <param name="tabControl"></param>
        /// <param name="tpgSuchen"></param>
        /// <param name="tpgListe"></param>
        private KissSearch(KissTabControlEx tabControl, TabPageEx tpgSuchen, TabPageEx tpgListe)
        {
            this.tabControl = tabControl;
            this.tpgSuchen = tpgSuchen;
            this.tpgListe = tpgListe;

            this.tabControl.SelectedTabChanging += new System.ComponentModel.CancelEventHandler(tabControl_SelectedTabChanging);
            this.tabControl.SelectedTabChanged += new TabControlExTabChangeEventHandler(tabControl_SelectedTabChanged);
        }

        #endregion

        #region Events

        /// <summary>
        /// Initialize a new search
        /// </summary>
        public event System.EventHandler NewSearch;

        /// <summary>
        /// Occurs when [run search].
        /// </summary>
        public event System.EventHandler RunSearch;

        #endregion

        #region Public Properties

        /// <summary>
        /// Indicates whether this instance is disabled.
        /// </summary>
        public Boolean Disabled
        {
            get { return disabled; }
            set { disabled = value; }
        }

        /// <summary>
        /// Parameter value List for SqlQuery.Fill()
        /// </summary>
        public Object[] SelectParameters
        {
            set { selectParameters = value; }
            get { return selectParameters; }
        }

        /// <summary>
        /// SelectStatement for SqlQuery.Fill()
        /// </summary>
        public String SelectStatement
        {
            set { selectStatement = value; }
            get { return selectStatement; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Zeilen, in denen where-Parameter eingesetzt wurden, aktivieren
        /// d.h. "---" am Anfang einer Zeile entfernen, falls sie keine Token mehr hat
        /// </summary>
        /// <param name="selectStatement">Select-Statement</param>
        /// <returns>Select ohne "---"</returns>
        public static string ActivateLinesWithParameter(string selectStatement)
        {
            String[] lines = selectStatement.Split(new String[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            for (Int32 i = 0; i < lines.Length; i++)
            {
                if (lines[i].TrimStart().StartsWith("---") && lines[i].IndexOf("{") == -1)
                {
                    lines[i] = lines[i].TrimStart().Substring(3);
                }
            }

            return String.Join(Environment.NewLine, lines);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            KissUserControl ctl = container as KissUserControl;

            if (ctl != null)
            {
                ctl.Search -= new EventHandler(ctl_Search);
            }

            KissForm frm = container as KissForm;

            if (frm != null)
            {
                frm.Search -= new EventHandler(ctl_Search);
            }

            if (tabControl != null)
            {
                this.tabControl.SelectedTabChanging -= new System.ComponentModel.CancelEventHandler(tabControl_SelectedTabChanging);
                this.tabControl.SelectedTabChanged -= new TabControlExTabChangeEventHandler(tabControl_SelectedTabChanged);
            }
        }

        /// <summary>
        /// Execute Query
        /// </summary>
        public bool OnRunSearch()
        {
            // check if it is required to run search
            if (this.Disabled || Session.IsInTranslationDialog)
            {
                return true;
            }

            Cursor currentCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // get query to use and select statement
                SqlQuery qry = container == null ? sqlQuery : ((IKissActiveSQLQuery)container).ActiveSQLQuery;

                if (qry != null && String.IsNullOrEmpty(this.selectStatement))
                {
                    this.selectStatement = qry.SelectStatement;
                }

                String selStatement = this.selectStatement;

                // revalidate select statement
                if (DBUtil.IsEmpty(selStatement))
                {
                    RunSearch(this, EventArgs.Empty);
                    return true;
                }

                // get all controls on the search tabpage and store them in hashtable
                foreach (Control ctl in UtilsGui.AllControls(tpgSuchen, false))
                {
                    this.htControl[ctl.Name] = ctl;
                    if (ctl is KissButtonEdit)
                    {
                        ((KissButtonEdit)ctl).CheckPendingSearchValue();
                    }
                }

                // replace fields-tokens with values
                selStatement = rxControlName.Replace(selStatement, new MatchEvaluator(rxControlName_MatchEvaluator));

                // clear hashtable again to save memory
                this.htControl.Clear();

                // Zeilen, in denen where-Parameter eingesetzt wurden, aktivieren
                // d.h. "---" am Anfang einer Zeile entfernen, falls sie keine Token mehr hat
                selStatement = ActivateLinesWithParameter(selStatement);

                // run search on event or manually
                if (RunSearch != null)
                {
                    qry.AfterFill += new EventHandler(qry_AfterFill);

                    this.fillDone = false;
                    qry.SelectStatement = selStatement;
                    RunSearch(this, EventArgs.Empty);

                    qry.AfterFill -= new EventHandler(qry_AfterFill);
                }

                // if not run search, execute selectstatement manually now
                if (!fillDone)
                {
                    qry.Fill(selStatement, selectParameters);
                }
            }
            catch (Exception ex)
            {
                if (ex is KissCancelException)
                {
                    ((KissCancelException)ex).ShowMessage();
                }

                if (this.tabControl != null)
                {
                    this.tabControl.SelectTab(tpgSuchen);
                }

                return false;
            }
            finally
            {
                Cursor.Current = currentCursor;
            }
            return true;
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Select Tabpage 'tpgSuchen' and erase Values in the Controls on this Tab.
        /// </summary>
        public void OnNewSearch()
        {
            if (this.Disabled)
            {
                return;
            }

            // select search-tab and reset editvalue of search-controls
            this.tabControl.SelectTab(tpgSuchen);

            foreach (Control ctl in UtilsGui.AllControls(tpgSuchen))
            {
                if (ctl is KissLabel)
                {
                    continue;
                }

                if (ctl is KissButtonEdit)
                {
                    ((KissButtonEdit)ctl).LookupID = null;
                    ((KissButtonEdit)ctl).EditValue = null;
                }
                else if (ctl is KissLookUpEdit)
                {
                    KissLookUpEdit edt = (KissLookUpEdit)ctl;
                    SqlQuery qry = edt.Properties.DataSource as SqlQuery;

                    if (qry != null && qry.Count > 0)
                    {
                        edt.EditValue = qry.DataTable.Rows[0][edt.Properties.ValueMember];
                    }
                    else
                    {
                        edt.EditValue = null;
                    }
                }
                else if (ctl is IKissBindableEdit)
                {
                    AssemblyLoader.SetPropertyValue(ctl, ((IKissBindableEdit)ctl).GetBindablePropertyName(), null);
                }
            }

            if (NewSearch != null)
            {
                NewSearch(this, EventArgs.Empty);
            }
        }

        #endregion

        #region Private Methods

        private void ctl_Search(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tpgSuchen)
            {
                if (this.OnRunSearch())
                {
                    inSearchEvent = true;
                    tabControl.SelectTab(tpgListe);
                    inSearchEvent = false;
                }
            }
            else
            {
                if (container.SaveData())
                {
                    this.OnNewSearch();
                }
            }
        }

        private void kissSearch_RunSearch(object sender, EventArgs e)
        {
            OnRunSearch();
        }

        /// <summary>
        /// Handles the AfterFill event of the qry control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void qry_AfterFill(object sender, EventArgs e)
        {
            fillDone = true;
        }

        /// <summary>
        /// Regexes the control name_ match evaluator.
        /// </summary>
        /// <param name="m">The m.</param>
        /// <returns></returns>
        private string rxControlName_MatchEvaluator(Match m)
        {
            Object value = htControl[m.Groups["ControlName"].Value] as Control;

            if (value != null)
            {
                try
                {
                    foreach (Capture item in m.Groups["PropertyName"].Captures)
                    {
                        value = AssemblyLoader.GetPropertyValue(value, item.Value);
                    }

                    if (value is IKissBindableEdit)
                    {
                        value = AssemblyLoader.GetPropertyValue(value, ((IKissBindableEdit)value).GetBindablePropertyName());
                    }

                    if (!DBUtil.IsEmpty(value))
                    {
                        return DBUtil.SqlLiteral(value);
                    }
                }
                catch { }

                return m.Value;
            }

            switch (m.Groups["ControlName"].Value)
            {
                default:
                    return m.Value;
            }
        }

        private void tabControl_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            if (UtilsGui.IsCalledFromAnyMethod("InitializeComponent"))
            {
                // During Initialization, we don't need to do anything here
                return;
            }

            if (page == this.tpgSuchen && !container.SaveData())
            {
                this.tabControl.SelectTab(lastSelectedTab);
            }
            else if (lastSelectedTab == this.tpgSuchen && !inSearchEvent)
            {
                if (!this.OnRunSearch())
                {
                    this.tabControl.SelectTab(tpgSuchen);
                }
            }
            else if (page == this.tpgSuchen)
            {
                tpgSuchen.Focus();
                tpgSuchen.SelectNextControl(null, true, true, true, false);
            }
        }

        private void tabControl_SelectedTabChanging(object sender, System.ComponentModel.CancelEventArgs e)
        {
            lastSelectedTab = ((KissTabControlEx)sender).SelectedTab;
            e.Cancel = !container.SaveData();
        }

        #endregion
    }
}