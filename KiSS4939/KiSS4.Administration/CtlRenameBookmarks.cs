using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Kiss.Infrastructure;
using Kiss.Interfaces.DocumentHandling;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Dokument;
using KiSS4.Dokument.WordAutomation;
using log4net;

namespace KiSS4.Administration
{
    // Shortcut because of the long generic type
    using RenameParameters = KeyValuePair<IList<Template>, IDictionary<string, string>>;

    public partial class CtlRenameBookmarks : KissSearchUserControl
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private static readonly Regex _rxRenameFileLine = new Regex(@"^([a-z0-9_]+)\s+([a-z0-9_]+)$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        #endregion

        #region Private Constant/Read-Only Fields

        /// <summary>
        /// A dictionary of all templates and their bookmarks.
        /// </summary>
        private readonly Dictionary<string, Template> _templates = new Dictionary<string, Template>();

        #endregion

        #endregion

        #region Constructors

        public CtlRenameBookmarks()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void CtlRenameBookmarks_Leave(object sender, EventArgs e)
        {
            bgwLoadBookmarks.CancelAsync();
            bgwRenameBookmarks.CancelAsync();

            while (bgwLoadBookmarks.IsBusy || bgwRenameBookmarks.IsBusy)
            {
                Thread.Sleep(50);
                ApplicationFacade.DoEvents();
            }
        }

        private void CtlRenameBookmarks_Load(object sender, EventArgs e)
        {
            UpdateUI(false);
        }

        private void bgwLoadBookmarks_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadBookmarks(txtTemplateFilter.Text);
            SetCursor(false);
        }

        private void bgwLoadBookmarks_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateListView();
            UpdateUI(false);
        }

        private void bgwRenameBookmarks_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument is RenameParameters)
            {
                RenameBookmarks((RenameParameters)e.Argument);
            }
            else
            {
                _logger.Error("Wrong object type supplied to bgwRenameBookmarks_DoWork!");
            }

            SetCursor(false);
        }

        private void bgwRenameBookmarks_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            txtFilter.Text = "";
            txtRenameTo.Text = "";

            UpdateListView();

            UpdateUI(false);

            KissMsg.ShowInfo(Name, "InfoRenamed", "Die Textmarken wurden umbenannt.");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelBackgroundWorkers();
        }

        private void btnRenameFromFile_Click(object sender, EventArgs e)
        {
            if (ofdRenameFile.ShowDialog() == DialogResult.OK)
            {
                var renameList = ReadFile(ofdRenameFile.FileName);

                var templates = (from template in _templates.Values
                                 from bookmark in renameList.Keys
                                 where template.Bookmarks.Contains(bookmark)
                                 select template);

                var parameters = new RenameParameters(templates.ToList(), renameList);

                UpdateUI(true);

                bgwRenameBookmarks.RunWorkerAsync(parameters);
            }
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            UpdateUI(true);

            // Create the rename parameters for multithreaded renaming
            var parameters = new RenameParameters(new List<Template>(), new Dictionary<string, string>());

            foreach (ListViewItem item in lvwResult.SelectedItems)
            {
                var tmpName = _templates[item.Group.Header];

                if (!parameters.Key.Contains(tmpName))
                {
                    parameters.Key.Add(tmpName);
                }

                if (!parameters.Value.ContainsKey(item.Text))
                {
                    parameters.Value.Add(item.Text, txtRenameTo.Text);
                }
            }

            bgwRenameBookmarks.RunWorkerAsync(parameters);
        }

        private void btnSaveList_Click(object sender, EventArgs e)
        {
            if (sfdOutput.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var writer = new StreamWriter(sfdOutput.FileName, false))
                    {
                        foreach (ListViewGroup group in lvwResult.Groups)
                        {
                            // only save if the group (template) has items (bookmarks)
                            if (group.Items.Count == 0)
                            {
                                continue;
                            }

                            var t = (Template)group.Tag;

                            writer.WriteLine("{0} ({1}):", group.Header, t.Format);

                            foreach (ListViewItem item in group.Items)
                            {
                                writer.WriteLine("\t" + item.Text);
                            }

                            writer.Flush();
                        }

                        writer.Close();
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error("CtlRenameBookmarks.btnSaveList_Click: Exception abgefangen.", ex);
                }
            }
        }

        private void chkRegex_CheckedChanged(object sender, EventArgs e)
        {
            chkStrict.Enabled = !chkRegex.Checked;
            UpdateListView();
            UpdateUI(false);
        }

        private void chkStrict_CheckedChanged(object sender, EventArgs e)
        {
            chkRegex.Enabled = !chkStrict.Checked;
            UpdateListView();
            UpdateUI(false);
        }

        private void chkValidate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkValidate.Checked)
            {
                UpdateUI(true);

                UpdateListView();

                UpdateUI(false);

                lblResult.Text = @"Die folgenden Vorlagen/Textmarken sind nicht korrekt:";
            }
            else
            {
                UpdateListView();
                UpdateUI(false);
            }
        }

        private void lvwResult_KeyDown(object sender, KeyEventArgs e)
        {
            // CTRL+A: select all
            if (e.KeyCode == Keys.A && e.Control)
            {
                foreach (ListViewItem item in lvwResult.Items)
                {
                    item.Selected = true;
                }
            }

            // CTRL+C: copy selected items
            if (e.KeyCode == Keys.C && e.Control)
            {
                string temp = "";

                foreach (ListViewItem item in lvwResult.SelectedItems)
                {
                    temp += item.Text + Environment.NewLine;
                }

                if (temp != "")
                {
                    temp = temp.Remove(temp.Length - Environment.NewLine.Length);
                }

                Clipboard.Clear();
                Clipboard.SetData(DataFormats.Text, temp);
            }
        }

        private void lvwResult_Resize(object sender, EventArgs e)
        {
            chdBookmarkName.Width = lvwResult.Width - 25;
        }

        private void lvwResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUI(false);
        }

        private void txtFilter_EditValueChanged(object sender, EventArgs e)
        {
            UpdateListView();
            UpdateUI(false);
        }

        private void txtRenameTo_EditValueChanged(object sender, EventArgs e)
        {
            UpdateUI(false);
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            CancelBackgroundWorkers();

            base.NewSearch();
        }

        protected override void RunSearch()
        {
            _templates.Clear();
            lvwResult.Groups.Clear();
            lvwResult.Items.Clear();
            UpdateUI(true);
            bgwLoadBookmarks.RunWorkerAsync();
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Reads a file that contains a list of bookmarks to rename with format "OldName NewName\n"
        /// </summary>
        /// <param name="fileName">The name of the file to read.</param>
        /// <returns>A dictionary containing the names of the bookmarks to rename (old/new name).</returns>
        private static Dictionary<string, string> ReadFile(string fileName)
        {
            var result = new Dictionary<string, string>();

            try
            {
                // Open a reader to parse the file line by line
                using (TextReader reader = new StreamReader(fileName))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        Match match = _rxRenameFileLine.Match(line);

                        if (match.Success && match.Groups.Count > 2 && !result.ContainsKey(match.Groups[1].Value))
                        {
                            result.Add(match.Groups[1].Value, match.Groups[2].Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }

            return result;
        }

        #endregion

        #region Private Methods

        private void CancelBackgroundWorkers()
        {
            bgwLoadBookmarks.CancelAsync();
            bgwRenameBookmarks.CancelAsync();
        }

        /// <summary>
        /// Gets all valid bookmark names from the DB.
        /// </summary>
        /// <returns>A list of valid bookmark names (Upper case).</returns>
        private List<string> GetValidBookmarks()
        {
            var bookmarks = new List<string>();

            qryXBookmark.Fill(@"EXEC dbo.spXGetBookmark");

            do
            {
                string originalName = qryXBookmark.Row["BookmarkName"].ToString();

                int index = originalName.IndexOf(',');
                if (index > 0)
                {
                    originalName = originalName.Substring(0, index);
                }

                index = originalName.IndexOf(' ');
                if (index > 0)
                {
                    originalName = originalName.Substring(0, index);
                }

                bookmarks.Add(originalName.ToUpper());
            }
            while (qryXBookmark.Next());

            return bookmarks;
        }

        /// <summary>
        /// Loads the templates and bookmarks from the DB.
        /// </summary>
        private void LoadBookmarks(string templateFilter)
        {
            // Show warning and then close all open word / excel instances
            if (!KissMsg.ShowQuestion(Name, "CloseOfficeDocuments_v01", "Bitte speichern Sie alle geöffneten Dokumente in Word/Excel und schliessen Sie die Anwendungen. Offene Word/Excel-Anwendungen können geschlossen werden, sobald Sie auf 'Ja' klicken. Wollen Sie fortfahren?", true))
            {
                return;
            }

            SetCursor(true);

            // Get the templates from the DB
            // We have to use string.Format since SqlQuery.Fill does non-conventional parameter replacement
            qryXDocTemplate.Fill(
                string.Format(@"
                SELECT {0},
                       FileBinary
                FROM dbo.XDocTemplate DTP
                WHERE DTP.FileBinary IS NOT NULL
                  AND DTP.DocTemplateName LIKE dbo.fnReplaceWildcard('{1}')
                ORDER BY DTP.DocTemplateName",
                XDocFileHandler.GetXDocumentNonBlobFieldList(DBO.XDocTemplate.DBOName),
                templateFilter));

            int count = qryXDocTemplate.Count;

            // Check result
            // Cancel if there is no result
            if (count == 0)
            {
                bgwLoadBookmarks.ReportProgress(100, "0/0");
                KissMsg.ShowInfo(Name, "ResultEmpty", "Keine Vorlagen gefunden.");

                return;
            }

            // An output string of exceptions that are thrown throughout the loading process
            var errors = string.Empty;

            // Iteration variable for the progress bar
            int i = 0;

            do
            {
                // Create a template object from the current row
                var tmp = new Template(qryXDocTemplate.Row);

                try
                {
                    if (bgwLoadBookmarks.CancellationPending)
                    {
                        break;
                    }

                    tmp.Load();

                    // Add a dictionary entry
                    if (!_templates.ContainsKey(tmp.Name))
                    {
                        _templates.Add(tmp.Name, tmp);
                    }

                    // Iterate progress bar
                    i++;
                    bgwLoadBookmarks.ReportProgress((int)((100f / count) * i), i + @"/" + count);
                }
                catch (Exception)
                {
                    errors += tmp.Name + Environment.NewLine;
                }
            }
            while (qryXDocTemplate.Next());

            if (errors != string.Empty)
            {
                KissMsg.ShowInfo(Name, "InfoErrors", "Fehler beim Laden der Vorlagen:{0}{1}", Environment.NewLine, errors);
            }
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblProgress.Text = (string)e.UserState;
            progressBar.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// Renames the bookmarks
        /// </summary>
        /// <param name="parameters">A dictionary containing the corresponding template name and bookmark name.</param>
        private void RenameBookmarks(RenameParameters parameters)
        {
            SetCursor(true);

            int count = parameters.Key.Count;

            // Iteration var for progress bar
            int i = 0;

            foreach (var template in parameters.Key)
            {
                if (bgwRenameBookmarks.CancellationPending)
                {
                    break;
                }

                try
                {
                    template.RenameBookmarks(parameters.Value);
                }
                catch (Exception ex)
                {
                    KissMsg.ShowError(Name, "RenameError", "Fehler beim Umbenennen der Textmarken.", ex);
                }

                // Iterate progress bar
                i++;
                bgwRenameBookmarks.ReportProgress((int)((100f / count) * i), i + @"/" + count);
            }

            SetCursor(false);
        }

        /// <summary>
        /// Sets the control's mouse cursor to wait or default.
        /// </summary>
        private void SetCursor(bool wait)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<bool>(SetCursor), wait);
                return;
            }

            Cursor = wait ? Cursors.WaitCursor : Cursors.Default;
        }

        /// <summary>
        /// Updates / sorts the ListView.
        /// </summary>
        private void UpdateListView()
        {
            lvwResult.Groups.Clear();
            lvwResult.Items.Clear();

            List<string> validBookmarks = null;

            // get valid bookmarks if param is set
            if (chkValidate.Checked)
            {
                validBookmarks = GetValidBookmarks();
            }

            string filter = txtFilter.Text;

            // create a regular expression from the filter
            Regex rx;

            try
            { // ignore errors generated from regex
                rx = new Regex(@txtFilter.Text);
            }
            catch
            {
                rx = new Regex("");
            }

            foreach (KeyValuePair<string, Template> template in _templates)
            {
                // type/index for choosing a word/excel image in the list view
                int type = template.Value.Format == DokFormat.Word ? 0 : 1;

                // add groups
                if (lvwResult.Groups[template.Key] == null)
                {
                    // add a new group with a reference to the template in its tag
                    lvwResult.Groups.Add(
                        new ListViewGroup
                        {
                            Name = template.Key,
                            Header = template.Key,
                            Tag = template.Value
                        });
                }

                // add bookmarks to corresponding groups
                foreach (string bookmark in template.Value.Bookmarks)
                {
                    // apply filters
                    if (string.IsNullOrEmpty(filter) || bookmark == filter ||
                        (!chkStrict.Checked && bookmark.ToLower().Contains(filter.ToLower())) ||
                        (chkRegex.Checked && rx.IsMatch(bookmark)))
                    {
                        // remove everything after an underscore (i.e. "_2")
                        int index = bookmark.IndexOf('_');
                        string shortBm = index > 0 ? bookmark.Substring(0, index) : bookmark;

                        // do not add if validating and the bookmark is valid
                        // or the bookmark is reserved (checkbox, dropdown, ..)
                        if ((chkValidate.Checked && validBookmarks != null && validBookmarks.Contains(shortBm.ToUpper())) ||
                            BookmarkHelper.IsReservedBookmark(shortBm))
                        {
                            continue;
                        }

                        // add the bookmark to the list
                        lvwResult.Items.Add(new ListViewItem(bookmark, type, lvwResult.Groups[template.Key]));
                    }
                }
            }
        }

        /// <summary>
        /// Updates the UI to default values.
        /// </summary>
        /// <param name="running">A parameter that indicates if a process is currently running.</param>
        private void UpdateUI(bool running)
        {
            progressBar.Enabled = running;
            //progressBar.Minimum = 0;
            //progressBar.Maximum = 100;
            //progressBar.Value = 0;
            //lblProgress.Text = "0/0";

            lblResult.Text = @"Liste der Textmarken:";

            bool loaded = _templates.Count > 0;
            bool hasItems = lvwResult.Items.Count > 0;

            btnCancel.Enabled = running;

            // there have to be selected items to be able to rename
            btnRename.Enabled = running ? false : lvwResult.SelectedItems.Count > 0 && txtRenameTo.Text.Length > 0;
            btnSaveList.Enabled = running ? false : hasItems;
            btnRenameFromFile.Enabled = running ? false : hasItems;

            chkValidate.Enabled = running ? false : loaded;

            // strict and regex are exclusive to each other
            chkRegex.Enabled = running ? false : !chkStrict.Checked && loaded;
            chkStrict.Enabled = running ? false : !chkRegex.Checked && loaded;

            txtFilter.Enabled = running ? false : loaded;
            txtRenameTo.Enabled = running ? false : hasItems;
            txtTemplateFilter.Enabled = !running;
        }

        #endregion

        #endregion
    }
}