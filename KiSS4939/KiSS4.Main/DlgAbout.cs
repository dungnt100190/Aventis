using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;
using BIAG.AssemblyInfo;
using Kiss.BL.Cache;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Gui.Layout;
using KiSS4.Main.Helper;
using log4net;
using log4net.Appender;
using SharpLibrary.WinControls;

namespace KiSS4.Main
{
    /// <summary>
    /// About dialog for KiSS application. Shows system-information and application-information.
    /// </summary>
    public partial class DlgAbout : KissDialog
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Constant/Read-Only Fields

        /// <summary>
        /// The delimiter between header and values on clipboard exort
        /// </summary>
        private const string COPYDELIMITER = "-----------------------------------------------------------";

        /// <summary>
        /// The delta to add or subtract to current height while enlarging or shrinking form
        /// </summary>
        private const int HEIGHTDIFFERENCE = 6;

        /// <summary>
        /// The maximum height of the timer-enlarged form
        /// about DlgAbout.Height + 50
        /// </summary>
        private const int MAXHEIGHTDIFFERENCE = 50;

        /// <summary>
        /// Tag if no value was detected for desired property
        /// </summary>
        private const string NOVALUEFORPROPERTY = "-";

        /// <summary>
        /// The scrolling difference on one timer-tick for moving label upwards.
        /// This value also depends on timer-intervall for proper and smooth animation.
        /// </summary>
        private const int SCROLLINGDIFFERENCE = 1;

        private readonly Font _fontAboutBold = new Font("Arial", 11, FontStyle.Bold, GraphicsUnit.Pixel);
        private readonly Font _fontAboutDefault = new Font("Arial", 11, FontStyle.Regular, GraphicsUnit.Pixel);

        // fonts used for rtf-about-info
        private readonly Font _fontAboutKiSs = new Font("Verdana", 14, FontStyle.Bold, GraphicsUnit.Pixel);

        #endregion

        #region Private Fields

        /// <summary>
        /// List containing all available assemblies, used for binding
        /// </summary>
        private SortableBindingList<AvailableAssembly> _availableAssemblies;

        /// <summary>
        /// Flag to store if dialog is enlarged and therefore team-label scrolling
        /// </summary>
        private bool _isEnlarged;

        /// <summary>
        /// Flag to store if team-label is set and loaded
        /// </summary>
        private bool _isTeamLabelSet;

        /// <summary>
        /// List containing all loaded modules, used for binding
        /// </summary>
        private SortableBindingList<LoadedModule> _loadedModules;

        /// <summary>
        /// List containing all temporary files
        /// </summary>
        private SortableBindingList<FileEntry> _tempFiles;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor, default
        /// </summary>
        public DlgAbout()
        {
            // init components
            InitializeComponent();

            // setup properties of grids
            grdAvailableAssemblies.AutoGenerateColumns = false;
            grdLoadedModules.AutoGenerateColumns = false;
            grdTempFiles.AutoGenerateColumns = false;

            string mLMessageCopyInfoInMemory = KissMsg.GetMLMessage(Name, "CopyInfoInMemory", "Informationen in den Zwischenspeicher kopieren");
            string mLMessageRefreshDisplay = KissMsg.GetMLMessage(Name, "RefreshDisplay", "Ansicht aktualisieren");

            // setup tooltips
            ttpAbout.SetToolTip(btnCopyAbout, mLMessageCopyInfoInMemory);
            ttpAbout.SetToolTip(btnCopyDatabase, mLMessageCopyInfoInMemory);
            ttpAbout.SetToolTip(btnDatabaseVersionShowChanges, KissMsg.GetMLMessage(Name, "BtnDatabaseVersionShowChangesToolTip", "In dieser Version geänderte Datenbank-Objekte anzeigen"));
            ttpAbout.SetToolTip(btnCopyDatabaseVersion, mLMessageCopyInfoInMemory);
            ttpAbout.SetToolTip(btnCopyAvailableAssemblies, mLMessageCopyInfoInMemory);
            ttpAbout.SetToolTip(btnRefreshAvailableAssemblies, mLMessageRefreshDisplay);
            ttpAbout.SetToolTip(btnCopyMemoryInfo, mLMessageCopyInfoInMemory);
            ttpAbout.SetToolTip(btnRefreshMemoryInfo, mLMessageRefreshDisplay);
            ttpAbout.SetToolTip(btnGarbageCollector, KissMsg.GetMLMessage(Name, "btnGarbageCollectorToolTip", "Garbage Collector starten"));
            ttpAbout.SetToolTip(btnClearCache, KissMsg.GetMLMessage(Name, "btnClearCacheToolTip", "Cache leeren"));
            ttpAbout.SetToolTip(btnViewTempFile, KissMsg.GetMLMessage(Name, "btnViewTempFile", "Datei anzeigen"));
            ttpAbout.SetToolTip(btnRefreshTempFiles, mLMessageRefreshDisplay);
            ttpAbout.SetToolTip(btnCopyTempFilePath, KissMsg.GetMLMessage(Name, "btnCopyTempFilePath", "Dateipfad kopieren"));
            ttpAbout.SetToolTip(btnCleanTempFiles, KissMsg.GetMLMessage(Name, "btnCleanTempFiles", "Alle Dateien löschen (gerade verwendete Dateien können nicht gelöscht werden)"));

            // init the gui
            InitGui();

            // prevent crashing dialog if about-info cannot be shown
            try
            {
                // init about text
                InitAboutInformation();
            }
            catch (Exception ex)
            {
                _log.Error("Error calling InitAboutInformation()", ex);
                KissMsg.ShowError(Name, "ErrorConstructorInitAbout", "Es ist ein Fehler beim Erstellen der Informationen aufgetreten.", ex);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get and set original height before resizing form by timer
        /// </summary>
        private int OriginalHeight
        {
            get;
            set;
        }

        #endregion

        #region EventHandlers

        private void btnCleanTempFiles_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var appDataDirectory = Session.GetKissAppDataFolder();

                foreach (var file in appDataDirectory.GetFiles())
                {
                    try
                    {
                        file.Delete();
                    }
                    catch (Exception ex)
                    {
                        _log.Info(ex);
                    }
                }

                SetupTempFilesInformation();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Click event to manually clear the cache
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void btnClearCache_Click(object sender, EventArgs e)
        {
            if (Session.CacheManager == null)
            {
                // show info
                KissMsg.ShowInfo(Name, "ClearCacheNotAvailable", "Es sind keine Daten im Cache.");
                return;
            }

            // clear all cached values
            Session.CacheManager.ClearCache();

            // Clear cache -> alt-neue Architektur
            CacheManager.Instance.ClearCache();

            // Clear cache -> neu-neu Architektur
            var configService = Kiss.Infrastructure.IoC.Container.Resolve<Kiss.BusinessLogic.Sys.XConfigService>();
            configService.ReloadCache();
            // Clear XLovCache
            var xlovService = Kiss.Infrastructure.IoC.Container.Resolve<Kiss.BusinessLogic.Sys.XLovService>();
            xlovService.ClearCache();
            // show info
            KissMsg.ShowInfo(Name, "ClearCacheDone", "Cache wurde erfolgreich geleert.");
        }

        /// <summary>
        /// Click event to copy about information into clipboard
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void btnCopyAbout_Click(object sender, EventArgs e)
        {
            try
            {
                // create new stringbuilder to grab all data
                var sb = new StringBuilder();

                // add header
                sb.AppendLine(String.Format("About Information - {0}", DateTime.Now));
                sb.AppendLine(COPYDELIMITER);

                // add data
                sb.AppendLine(edtAboutKiSS.Text);

                // copy data to clipboard
                Clipboard.Clear();
                Clipboard.SetText(sb.ToString());

                // show info
                KissMsg.ShowInfo(Name, "SuccessfullyCopiedAboutText", "Die Angaben wurden in den Zwischenspeicher kopiert.");
            }
            catch (Exception ex)
            {
                // show error
                KissMsg.ShowError(Name, "ErrorCopyAboutText", "Es ist ein Fehler beim Kopieren der Angaben in den Zwischenspeicher aufgetreten.", ex);
            }
            finally
            {
                // reset cursor
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Click event to copy list of available assemblies into clipboard
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void btnCopyAvailableAssemblies_Click(object sender, EventArgs e)
        {
            try
            {
                // check if any data was found
                if (_availableAssemblies == null || _availableAssemblies.Count < 1)
                {
                    // do nothing
                    return;
                }

                // setup cursor
                Cursor.Current = Cursors.WaitCursor;

                // create new stringbuilder to grab all data
                var sb = new StringBuilder();

                // add header
                sb.AppendLine(string.Format("Available Assemblies - {0}", DateTime.Now));
                sb.AppendLine(COPYDELIMITER);

                // add content
                AppendGridContent(grdAvailableAssemblies, ref sb);

                // copy data to clipboard
                Clipboard.Clear();
                Clipboard.SetText(sb.ToString());

                // clear memory
                sb.Clear();

                // show info
                KissMsg.ShowInfo(Name, "SuccessfullyCopiedAvailableAssemblies", "Die Assembly-Daten wurden in den Zwischenspeicher kopiert.");
            }
            catch (Exception ex)
            {
                // show error
                KissMsg.ShowError(Name, "ErrorCopyAvailableAssemblies", "Es ist ein Fehler beim Kopieren der verfügbaren Assemblies in den Zwischenspeicher aufgetreten.", ex);
            }
            finally
            {
                // reset cursor
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnCopyDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                // create new stringbuilder to grab all data
                var sb = new StringBuilder();

                // add header
                sb.AppendLine(string.Format("About Database - {0}", DateTime.Now));
                sb.AppendLine(COPYDELIMITER);

                // add data
                sb.AppendLine(edtAboutDatabase.Text);

                // copy data to clipboard
                Clipboard.Clear();
                Clipboard.SetText(sb.ToString());

                // show info
                KissMsg.ShowInfo(Name, "SuccessfullyCopiedDatabaseText", "Die Angaben wurden in den Zwischenspeicher kopiert.");
            }
            catch (Exception ex)
            {
                // show error
                KissMsg.ShowError(Name, "ErrorCopyDatabaseText", "Es ist ein Fehler beim Kopieren der Angaben in den Zwischenspeicher aufgetreten.", ex);
            }
            finally
            {
                // reset cursor
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnCopyDatabaseVersion_Click(object sender, EventArgs e)
        {
            try
            {
                // check if any data was found
                if (qryDatabaseVersions == null || qryDatabaseVersions.Count < 1)
                {
                    // do nothing
                    return;
                }

                // setup cursor
                Cursor.Current = Cursors.WaitCursor;

                // create new stringbuilder to grab all data
                var sb = new StringBuilder();

                // add header
                sb.AppendLine(string.Format("Database Versions - {0}", DateTime.Now));
                sb.AppendLine(COPYDELIMITER);

                // add grid content
                AppendGridContent(grdDatabaseVersions, ref sb);

                // copy data to clipboard
                Clipboard.Clear();
                Clipboard.SetText(sb.ToString());

                // clear memory
                sb.Clear();

                // show info
                KissMsg.ShowInfo(Name, "SuccessfullyCopiedDatabaseVersions", "Die Datenbank-Versionen wurden in den Zwischenspeicher kopiert.");
            }
            catch (Exception ex)
            {
                // show error
                KissMsg.ShowError(Name, "ErrorCopyDatabaseVersions", "Es ist ein Fehler beim Kopieren der Datenbank-Versionen in den Zwischenspeicher aufgetreten.", ex);
            }
            finally
            {
                // reset cursor
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Click event to copy list of available assemblies into clipboard
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void btnCopyMemoryInfo_Click(object sender, EventArgs e)
        {
            try
            {
                // setup cursor
                Cursor.Current = Cursors.WaitCursor;

                // create new stringbuilder to grab all data
                var sb = new StringBuilder();

                // add headers and processinformation to sb
                sb.AppendLine(String.Format("Process Information - {0}", DateTime.Now));
                sb.AppendLine(COPYDELIMITER);
                sb.AppendLine(edtMemoryInfo.Text);
                sb.AppendLine(COPYDELIMITER);
                sb.AppendLine("Loaded Modules");
                sb.AppendLine(COPYDELIMITER);

                // check if we have any loaded modules
                if (_loadedModules != null && _loadedModules.Count > 0)
                {
                    // append grid content
                    AppendGridContent(grdLoadedModules, ref sb);
                }

                // copy data to clipboard
                Clipboard.Clear();
                Clipboard.SetText(sb.ToString());

                // clear memory
                sb.Clear();

                // show info
                KissMsg.ShowInfo(Name, "SuccessfullyCopiedMemory", "Die Speicher-Angaben wurden in den Zwischenspeicher kopiert.");
            }
            catch (Exception ex)
            {
                // show error
                KissMsg.ShowError(Name, "ErrorCopyMemory", "Es ist ein Fehler beim Kopieren der Speicher-Angaben in den Zwischenspeicher aufgetreten.", ex);
            }
            finally
            {
                // reset cursor
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnCopyTempFilePath_Click(object sender, EventArgs e)
        {
            if (grdTempFiles.SelectedCells.Count == 0)
            {
                KissMsg.ShowInfo(Name, "SelectTempFile", "Bitte eine Datei auswählen.");
                return;
            }

            var file = (FileEntry)grdTempFiles.SelectedCells[0].OwningRow.DataBoundItem;

            Clipboard.Clear();
            Clipboard.SetText(file.FileInfo.FullName);
        }

        private void btnDatabaseVersionShowChanges_Click(object sender, EventArgs e)
        {
            // validate
            if (qryDatabaseVersions.IsEmpty)
            {
                // do nothing
                return;
            }

            // request changes
            string changes = ConvertToString(qryDatabaseVersions, "ChangesSinceLastVersion");

            // validate changes
            if (changes == NOVALUEFORPROPERTY)
            {
                // no changes, show message and cancel
                KissMsg.ShowInfo(Name, "NoDatabaseVersionChanges", "Es wurden keine Änderungen gefunden.");
                return;
            }

            // show changes in dialog
            var dlg = new DlgMemoEdit(true, _fontAboutDefault);
            dlg.MemoEditor.EditValue = changes;
            dlg.RestoreLayout();
            dlg.ShowDialog(this);
        }

        /// <summary>
        /// Click event to manually start garbage collector
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void btnGarbageCollector_Click(object sender, EventArgs e)
        {
            // this button can only be used if debugger is attached
            if (!Debugger.IsAttached)
            {
                // disable button and do not continue
                btnGarbageCollector.Enabled = false;
                return;
            }

            try
            {
                // start manually GC
                // see:      http://www.developer.com/net/csharp/article.php/3343191
                // also see: http://msdn.microsoft.com/en-us/library/system.gc.waitforpendingfinalizers.aspx
                // also see: http://en.csharp-online.net/CSharp_FAQ:_How_can_I_force_garbage_collection%3F
                GC.Collect();
                GC.WaitForPendingFinalizers();

                // show info
                KissMsg.ShowInfo(Name, "SuccessfullyStartedGarbageCollection", "Der GarbageCollector wird nun ausgeführt.");
            }
            catch (Exception ex)
            {
                // show error
                KissMsg.ShowError(Name, "ErrorDoGarbageCollection", "Es ist ein Fehler beim Ausführen des GarbageCollectors aufgetreten.", ex);
            }
            finally
            {
                // reset cursor
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Click event to update list of available assemblies
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void btnRefreshAvailableAssemblies_Click(object sender, EventArgs e)
        {
            // refresh available assemblies
            SetupAvailableAssemblies();
        }

        /// <summary>
        /// Click event to update memory information
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void btnRefreshMemoryInfo_Click(object sender, EventArgs e)
        {
            // refresh memory information
            SetupMemoryInformation();
        }

        private void btnRefreshTempFiles_Click(object sender, EventArgs e)
        {
            FlushLogFiles();

            SetupTempFilesInformation();
        }

        private void btnViewTempFile_Click(object sender, EventArgs e)
        {
            ViewTempFile();
        }

        private void DlgAbout_Resize(object sender, EventArgs e)
        {
            // center controls
            CenterCloseButton();
            CenterAboutTeamLabel();
        }

        private void grdTempFiles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ViewTempFile();
        }

        /// <summary>
        /// The click event on link-label
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void lblOwnerLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // get current cursor
            Cursor currentCursor = Cursor;

            try
            {
                // set cursor
                Cursor = Cursors.WaitCursor;

                // create new process
                var process = new Process
                {
                    StartInfo = { UseShellExecute = true, Verb = "Open", FileName = "http://www.diartis.ch" }
                };

                // setup process

                // start process
                process.Start();
            }
            catch (Exception ex)
            {
                // show error message
                KissMsg.ShowError(Name, "ErrorOpenLink", "Es ist ein Fehler beim Ausführen des Befehls aufgetreten.", ex);
            }
            finally
            {
                // reset cursor
                Cursor = currentCursor;
            }
        }

        /// <summary>
        /// The click event on logo picture. Enlarge and scroll team-info or shrink form again.
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void picKiSSLogo_Click(object sender, EventArgs e)
        {
            // check if right tpg is selected
            if (!tabSystemInfo.IsTabSelected(tpgAbout))
            {
                // open link on other tpgss
                lblOwnerLink_LinkClicked(null, new LinkLabelLinkClickedEventArgs(lblOwnerLink.Links[0]));

                // done
                return;
            }

            // check if we need to setup team-info
            if (!_isTeamLabelSet)
            {
                // not yet set, do now
                InitTeamInfoLabel();
            }

            // enlarge or shrink form depending on current state
            StartEnlargeOrShrinkForm();
        }

        /// <summary>
        /// Event when changing tpg on tabcontrol
        /// </summary>
        /// <param name="page">The tabpage that is new selected</param>
        private void tabSystemInfo_SelectedTabChanged(TabPageEx page)
        {
            // check if currently enlarged form
            if (_isEnlarged)
            {
                // collapse again
                StartEnlargeOrShrinkForm();
            }

            // tpg depending action
            if (tabSystemInfo.IsTabSelected(tpgDatabase) && string.IsNullOrEmpty(edtAboutDatabase.Text))
            {
                InitDatabaseInformation();
            }
            else if (tabSystemInfo.IsTabSelected(tpgDatabaseVersions) &&
                     (grdDatabaseVersions.DataSource == null))
            {
                SetupDatabaseVersions();
            }
            else if (tabSystemInfo.IsTabSelected(tpgAvailableAssemblies) &&
                     (_availableAssemblies == null || _availableAssemblies.Count < 1))
            {
                SetupAvailableAssemblies();
            }
            else if (tabSystemInfo.IsTabSelected(tpgMemory) && string.IsNullOrEmpty(edtMemoryInfo.Text))
            {
                SetupMemoryInformation();
            }
            else if (tabSystemInfo.IsTabSelected(tpgTempFiles) && grdTempFiles.ColumnCount == 0)
            {
                SetupTempFilesInformation();
            }
        }

        /// <summary>
        /// Timer tick event to do enlargement or shrinking of form
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void tmrEnlargeShrink_Tick(object sender, EventArgs e)
        {
            // do it
            DoEnlargeOrShrinkForm();
        }

        /// <summary>
        /// Timer tick event to do scrolling of team-info-label
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void tmrScrollingLabel_Tick(object sender, EventArgs e)
        {
            // do it
            DoScrolling();
        }

        #endregion

        #region Methods

        #region Internal Static Methods

        /// <summary>
        /// Convert any long to its propriate byte/kb/mb/gb size
        /// </summary>
        /// <param name="bytes">The bytes as long to convert</param>
        /// <returns>String containing converted byte-size</returns>
        internal static string ConvertLongToByteInfo(long bytes)
        {
            if (bytes >= 1073741824)
            {
                var size = Decimal.Divide(bytes, 1073741824);
                return String.Format("{0:##.##} GB", size);
            }

            if (bytes >= 1048576)
            {
                var size = Decimal.Divide(bytes, 1048576);
                return String.Format("{0:##.##} MB", size);
            }

            if (bytes >= 1024)
            {
                var size = Decimal.Divide(bytes, 1024);
                return String.Format("{0:##.##} KB", size);
            }

            if (bytes > 0 & bytes < 1024)
            {
                var size = bytes;
                return String.Format("{0:##.##} Bytes", size);
            }

            return "0 Bytes";
        }

        #endregion

        #region Protected Methods

        protected override void OnSettingLayout(KissLayoutEventArgs e)
        {
            // prevent setting layout from base-class!
            ////base.OnSettingLayout(e);
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Append content of grid to string builder instance (considers sorting, etc. of grid content)
        /// </summary>
        /// <param name="grd">The grid to use for getting content</param>
        /// <param name="sb">The instance of a string builder to use for appending grid content</param>
        private static void AppendGridContent(DataGridView grd, ref StringBuilder sb)
        {
            // init counters
            int countRows = 0;

            // loop database versions
            foreach (DataGridViewRow row in grd.Rows)
            {
                // count up rows
                countRows++;

                // reset cell counter
                int countCells = 0;

                // loop cells in row
                foreach (DataGridViewCell cell in row.Cells)
                {
                    // count up cells
                    countCells++;

                    // add value
                    sb.AppendFormat("{0}='{1}'", grd.Columns[cell.ColumnIndex].HeaderText, Convert.ToString(cell.Value).Replace(Environment.NewLine, "; "));

                    // check if need to append separator
                    if (countCells < row.Cells.Count)
                    {
                        sb.Append("; ");
                    }
                }

                // check if need to append new line
                if (countRows < grd.Rows.Count)
                {
                    sb.AppendLine();
                }
            }
        }

        /// <summary>
        /// Helper method to autosize columns and set sorting mode
        /// </summary>
        /// <param name="grd">The <see cref="DataGridView"/> to handle</param>
        private static void AutoSizeColumnsAndAllowSorting(DataGridView grd)
        {
            // autosize columns
            foreach (DataGridViewColumn column in grd.Columns)
            {
                // fit to show full content including header
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }

            // allow resize again after autofit
            foreach (DataGridViewColumn column in grd.Columns)
            {
                // allow resize
                column.Tag = column.Width;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                column.Resizable = DataGridViewTriState.True;
                column.Width = Convert.ToInt32(column.Tag);
            }
        }

        /// <summary>
        /// Convert content of column to string
        /// </summary>
        /// <param name="qry">The sqlquery instance to use for getting data</param>
        /// <param name="columName">The column name within sqlquery datatable</param>
        /// <returns>If no content is defined: -, otherwise content in column of given sqlquery</returns>
        private static string ConvertToString(SqlQuery qry, string columName)
        {
            // check if empty
            if (DBUtil.IsEmpty(qry[columName]))
            {
                return NOVALUEFORPROPERTY;
            }

            // return converted string
            return Convert.ToString(qry[columName]).Trim();
        }

        /// <summary>
        /// Create new grid column
        /// </summary>
        /// <param name="propertyName">The name of the property to use for databinding and header text</param>
        /// <param name="valueType">The type of the value</param>
        /// <param name="displayIndex"></param>
        /// <param name="frozen">Flag if column shall be moved when scrolling</param>
        /// <param name="visible"><c>True</c> if column is visible to user, otherwise <c>False</c></param>
        /// <returns>The new created column, ready to add to grid</returns>
        private static DataGridViewColumn CreateGridColumn(string propertyName, Type valueType, int displayIndex, bool frozen = false, bool visible = true)
        {
            // create template
            DataGridViewCell cell = new DataGridViewTextBoxCell();

            // create column for template
            var column = new DataGridViewColumn(cell)
            {
                DataPropertyName = propertyName,
                HeaderText = propertyName,
                ReadOnly = true,
                ValueType = valueType,
                Frozen = frozen,
                DisplayIndex = displayIndex,
                Visible = visible
            };

            // setup column

            // done, return column
            return column;
        }

        /// <summary>
        /// Creates the administration info.
        /// </summary>
        /// <returns></returns>
        private static string GetAdministrationInfo()
        {
            try
            {
                // check if we have a session
                if (!Session.Active)
                {
                    // no session, return empty string
                    return NOVALUEFORPROPERTY;
                }

                // get admin state
                if (Session.User.IsUserBIAGAdmin)
                {
                    // special output if biag-admin
                    return string.Format("{0} (BIAG Admin)", Session.User.IsUserAdmin);
                }

                // normal admin only
                return Session.User.IsUserAdmin.ToString();
            }
            catch (NullReferenceException)
            {
                return NOVALUEFORPROPERTY;
            }
        }

        /// <summary>
        /// Get Client Name
        /// </summary>
        /// <returns></returns>
        private static string GetClientName()
        {
            try
            {
                string retVal = Environment.GetEnvironmentVariable("%CLIENTNAME%");
                //string retVal = Environment.GetEnvironmentVariable("CLIENTNAME", EnvironmentVariableTarget.Process);
                if (string.IsNullOrEmpty(retVal))
                {
                    return String.Empty;
                }
                return retVal;
            }
            catch
            {
                // some error occured, return string.empty
                return String.Empty;
            }
        }

        private static string GetIbanExpirationDate()
        {
            if (!DBUtil.GetConfigBool(@"System\Allgemein\IBANWarnmeldung", false))
            {
                return NOVALUEFORPROPERTY;
            }

            DateTime? ibanExDate = Belegleser.GetIBANExpirationDate();
            return !ibanExDate.HasValue ? NOVALUEFORPROPERTY : ibanExDate.Value.ToShortDateString();
        }

        /// <summary>
        /// Creates the language info.
        /// </summary>
        /// <returns></returns>
        private static string GetLanguageInfo()
        {
            try
            {
                // check if we have a session
                if (!Session.Active)
                {
                    // no session, return empty string
                    return NOVALUEFORPROPERTY;
                }

                // get language of current user
                return Session.User.LanguageCode.ToString();
            }
            catch (NullReferenceException)
            {
                return NOVALUEFORPROPERTY;
            }
        }

        /// <summary>
        /// Creates the logon info.
        /// </summary>
        /// <returns></returns>
        private static string GetLogonInfo()
        {
            try
            {
                // check if we have a session
                if (!Session.Active)
                {
                    // no session, return empty string
                    return NOVALUEFORPROPERTY;
                }

                // create the logon-information
                return string.Format("{0}, {1} ({2}, {3})", Session.User.LastName, Session.User.FirstName, Session.User.LogonName, Session.User.UserID);
            }
            catch (NullReferenceException)
            {
                return NOVALUEFORPROPERTY;
            }
        }

        /// <summary>
        /// Filters out the local MacAddress.
        /// </summary>
        /// <returns></returns>
        private static string GetMacAddress()
        {
            var addresses = "";
            var nics = NetworkInterface.GetAllNetworkInterfaces();
            if (nics.Length < 1)
            {
                addresses = "No network interfaces found.";
            }
            else
            {
                foreach (var adapter in nics)
                {
                    var phAddr = adapter.GetPhysicalAddress();
                    var bytes = phAddr.GetAddressBytes();
                    for (var i = 0; i < bytes.Length; i++)
                    {
                        // Display the physical address in hexadecimal.
                        addresses += bytes[i].ToString("X2");
                        // Always add a '-' and skip the last
                        if (i != bytes.Length - 1)
                        {
                            addresses += "-";
                        }
                    }
                    addresses += "   ";
                }
            }

            return addresses;
        }

        /// <summary>
        /// Get product version from main-exe
        /// </summary>
        /// <returns></returns>
        private static string GetProductVersion()
        {
            try
            {
                // try to get information from given file
                var asm = Assembly.LoadFrom(Application.ExecutablePath);

                // return assembly version and product version
                return String.Format("{0} (AssemblyVersion: {1})", Application.ProductVersion, asm.GetName().Version);
            }
            catch
            {
                // some error occured, return application-product-version
                return Application.ProductVersion;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Add error information line to edit control
        /// </summary>
        /// <param name="edt">The edit control to use for appending text</param>
        /// <param name="errMessage">The error message to apply</param>
        private void AddErrorInformationToEdit(RichTextBox edt, string errMessage)
        {
            edt.SelectionFont = _fontAboutDefault;
            edt.SelectedText = Environment.NewLine;
            edt.SelectionFont = _fontAboutBold;
            edt.SelectedText = string.Format("Error: {0}", errMessage);
        }

        /// <summary>
        /// Add information line to edit control
        /// </summary>
        /// <param name="edt">The edit control to use for appending text</param>
        /// <param name="label">The label to use for the value</param>
        /// <param name="value">The corresponding value of the label</param>
        /// <param name="twiceNewLine"><c>True</c> if twice a new line shall be applied (separated to next text), otherwise <c>False</c></param>
        /// <param name="doAppend"><c>True</c> if text shall be appended or <c>False</c> if call can be ignored</param>
        private void AddInformationToEdit(RichTextBox edt, string label, string value, bool twiceNewLine, bool doAppend = true)
        {
            AddInformationToEdit(edt, label, value, true, twiceNewLine, doAppend);
        }

        /// <summary>
        /// Add information line to edit control
        /// </summary>
        /// <param name="edt">The edit control to use for appending text</param>
        /// <param name="label">The label to use for the value</param>
        /// <param name="value">The corresponding value of the label</param>
        /// <param name="appendNewLine"><c>True</c> if new lines shall be appended, otherwise <c>False</c></param>
        /// <param name="twiceNewLine"><c>True</c> if twice a new line shall be applied (separated to next text), otherwise <c>False</c></param>
        /// <param name="doAppend"><c>True</c> if text shall be appended or <c>False</c> if call can be ignored</param>
        private void AddInformationToEdit(RichTextBox edt, string label, string value, bool appendNewLine, bool twiceNewLine, bool doAppend)
        {
            // check first
            if (!doAppend)
            {
                // do nothing
                return;
            }

            // add formatted text to control
            edt.SelectionFont = _fontAboutBold;
            edt.SelectedText = string.Format("{0}: ", label);
            edt.SelectionFont = _fontAboutDefault;
            edt.SelectedText = value;

            // check if need to append new lines
            if (appendNewLine)
            {
                // append one new line
                edt.SelectedText = Environment.NewLine;

                // check if need to add a further new line
                if (twiceNewLine)
                {
                    edt.SelectedText = Environment.NewLine;
                }
            }
        }

        /// <summary>
        /// Add information line to edit control
        /// </summary>
        /// <param name="edt">The edit control to use for appending text</param>
        /// <param name="title">The title to apply</param>
        private void AddTitleInformationToEdit(RichTextBox edt, string title)
        {
            edt.SelectionFont = _fontAboutKiSs;
            edt.SelectedText = title;
            edt.SelectionFont = _fontAboutDefault;
            edt.SelectedText = Environment.NewLine;
            edt.SelectedText = Environment.NewLine;
        }

        private void CenterAboutTeamLabel()
        {
            // center label of team on panel
            lblAboutTeam.Left = (panAboutTeam.Width - lblAboutTeam.Width) / 2;
        }

        private void CenterCloseButton()
        {
            btnClose.Left = (ClientSize.Width - btnClose.Width) / 2;
        }

        /// <summary>
        /// Do enlarge or shrink form to show or hide team-info-label
        /// </summary>
        private void DoEnlargeOrShrinkForm()
        {
            // check if we reached max or min height
            if ((!_isEnlarged && Height >= (OriginalHeight + MAXHEIGHTDIFFERENCE)) ||
                (_isEnlarged && Height <= OriginalHeight))
            {
                // disable timer
                tmrEnlargeShrink.Enabled = false;

                // set flag for current state (invert)
                _isEnlarged = !_isEnlarged;

                // init start/stop scrolling depending on current state
                StartStopScrolling();

                // init gui for enlarging/shrinking
                InitGuiEnlargeShrink(true);
            }
            else
            {
                // check current state
                if (_isEnlarged)
                {
                    // is now enlarged, do shrinking
                    Height = Height - HEIGHTDIFFERENCE;
                }
                else
                {
                    // is now shrinked, do enlarge
                    Height = Height + HEIGHTDIFFERENCE;
                }
            }
        }

        /// <summary>
        /// Do the scrolling of the label
        /// </summary>
        private void DoScrolling()
        {
            // check if we reached bottom
            if (lblAboutTeam.Top + lblAboutTeam.Height < 0)
            {
                // label is no more visible, do reset position
                ResetLabelPosition();
            }
            else
            {
                // move label upwards
                lblAboutTeam.Top = lblAboutTeam.Top - SCROLLINGDIFFERENCE;
            }
        }

        private void FlushLogFiles()
        {
            var rep = LogManager.GetRepository();

            foreach (var appender in rep.GetAppenders())
            {
                var buffered = appender as BufferingAppenderSkeleton;

                if (buffered != null)
                {
                    buffered.Flush();
                }
            }
        }

        private string GetLogFileInfo()
        {
            var appenders = _log.Logger.Repository.GetAppenders();

            foreach (var appender in appenders)
            {
                if (appender is RollingFileAppender)
                {
                    return ((RollingFileAppender)appender).File;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Init the about information text well formated
        /// </summary>
        private void InitAboutInformation()
        {
            // KiSS4
            AddTitleInformationToEdit(edtAboutKiSS, "KiSS4");

            // ----
            // kiss logon name
            AddInformationToEdit(edtAboutKiSS, "User", GetLogonInfo(), false);

            // kiss administration rights
            AddInformationToEdit(edtAboutKiSS, "Administrator", GetAdministrationInfo(), false);

            // kiss language code
            AddInformationToEdit(edtAboutKiSS, "LanguageCode", GetLanguageInfo(), true);

            // ----
            // client version
            AddInformationToEdit(edtAboutKiSS,
                "Client Version",
                string.Format("{0} (AssemblyVersion: {1})",
                    Utils.MainVersion,
                    GlobalAssemblyInfo.AssemblyVersion),
                false);

            // product version
            AddInformationToEdit(edtAboutKiSS, "Product Version", GetProductVersion(), false);

            // application path
            AddInformationToEdit(edtAboutKiSS, "Application Path", Session.ApplicationStartupPath, true);

            // ----
            // windows version
            AddInformationToEdit(edtAboutKiSS, "Windows Version", Environment.OSVersion.VersionString, false);

            // MS.NET version
            AddInformationToEdit(edtAboutKiSS, "MS.NET Version", Environment.Version.ToString(), false);

            // office version
            AddInformationToEdit(edtAboutKiSS,
                "Office Version",
                string.Format("Word='{0}', Excel='{1}', Outlook='{2}'", OfficeVersion.WordVersion,
                    OfficeVersion.ExcelVersion,
                    OfficeVersion.OutlookVersion),
                true);

            // ----
            // system user name
            AddInformationToEdit(edtAboutKiSS, "UserName", SystemInformation.UserName, false);

            // user domain name
            AddInformationToEdit(edtAboutKiSS, "UserDomainName", SystemInformation.UserDomainName, false);

            // user domain name (via System.Net.NetworkInformation )
            AddInformationToEdit(edtAboutKiSS, "UserDomainNameNet", IPGlobalProperties.GetIPGlobalProperties().DomainName, false);

            // Windows User
            AddInformationToEdit(edtAboutKiSS, "Windows User", WindowsIdentity.GetCurrent().Name, false);

            // AccountDomainSid
            AddInformationToEdit(edtAboutKiSS, "AccountDomainSid", WindowsIdentity.GetCurrent().User.AccountDomainSid.ToString(), false);

            // IsAccountSid
            AddInformationToEdit(edtAboutKiSS, "IsAccountSid", WindowsIdentity.GetCurrent().User.IsAccountSid().ToString(), false);

            // user interface
            AddInformationToEdit(edtAboutKiSS, "UserInterface", SystemInformation.UserInteractive.ToString(), true);

            // ----
            // culture info
            AddInformationToEdit(edtAboutKiSS, "CultureInfo", CultureInfo.CurrentCulture.ToString(), false);

            // culture info
            AddInformationToEdit(edtAboutKiSS, "CurrentInputLanguage", Application.CurrentInputLanguage.Culture.ToString(), false);

            // working area
            AddInformationToEdit(edtAboutKiSS, "WorkingArea", SystemInformation.WorkingArea.ToString(), true);

            // ----
            // Personal path
            AddInformationToEdit(edtAboutKiSS, "Personal", Environment.GetFolderPath(Environment.SpecialFolder.Personal), false);

            // ApplicationData path
            AddInformationToEdit(edtAboutKiSS, "ApplicationData", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), false);

            // KiSS ApplicationData path
            AddInformationToEdit(edtAboutKiSS, "ApplicationData KiSS", Session.GetKissAppDataFolder().FullName, false);

            // ProgramFiles path
            AddInformationToEdit(edtAboutKiSS, "ProgramFiles", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), false);

            // System path
            AddInformationToEdit(edtAboutKiSS, "System", Environment.GetFolderPath(Environment.SpecialFolder.System), false);

            // Temp path
            AddInformationToEdit(edtAboutKiSS, "Temp", Path.GetTempPath(), false);

            // Log files
            AddInformationToEdit(edtAboutKiSS, "Log file", GetLogFileInfo(), true);

            // ---
            // Current Directory
            AddInformationToEdit(edtAboutKiSS, "Current Directory", Environment.CurrentDirectory, false);

            // System Directory
            AddInformationToEdit(edtAboutKiSS, "System Directory", Environment.SystemDirectory, false);

            // Computer Name
            AddInformationToEdit(edtAboutKiSS, "Computer Name", SystemInformation.ComputerName, false);

            // Machine Name
            AddInformationToEdit(edtAboutKiSS, "Machine Name", Environment.MachineName, false);

            // Client Name
            AddInformationToEdit(edtAboutKiSS, "Client Name", GetClientName(), false);

            // Terminal Server Session
            AddInformationToEdit(edtAboutKiSS, "Terminal Server Session", SystemInformation.TerminalServerSession.ToString(), false);

            // Is 64Bit Operating System
            AddInformationToEdit(edtAboutKiSS, "Is 64Bit Operating System", Environment.Is64BitOperatingSystem.ToString(), false);

            // Is 64Bit Process
            AddInformationToEdit(edtAboutKiSS, "Is 64Bit Process", Environment.Is64BitProcess.ToString(), false);

            // MAC Address
            AddInformationToEdit(edtAboutKiSS, "MAC Address", GetMacAddress(), true);

            // ---
            // IBan Expiration Date
            AddInformationToEdit(edtAboutKiSS, KissMsg.GetMLMessage("DlgAbout", "IbanExpirationDate", "Gültigkeit IBANTool"), GetIbanExpirationDate(), false, false, true);
        }

        /// <summary>
        /// Init the database information text well formated
        /// </summary>
        private void InitDatabaseInformation()
        {
            #region Reset

            // reset text
            edtAboutDatabase.Text = "";

            #endregion

            #region Validate

            // validate
            if (!Session.Active)
            {
                // no session, cannot show any data
                AddErrorInformationToEdit(edtAboutDatabase, "No database connection, cannot show information.");

                // done
                return;
            }

            #endregion

            #region Get data

            // init vars
            SqlQuery qryServerDbInfo;
            bool isUserAdmin = Session.User.IsUserAdmin;

            try
            {
                qryServerDbInfo = DBUtil.OpenSQL(@"
                    -------------------------------------------------------------------------------
                    -- init vars
                    -------------------------------------------------------------------------------
                    DECLARE @ServerInformation TABLE
                    (
                      ID INT,
                      Name SYSNAME,
                      Internal_Value INT,
                      Value NVARCHAR(512)
                    );

                    DECLARE @SmoRoot NVARCHAR(512);
                    DECLARE @pages BIGINT;      -- Working variable for size calc.
                    DECLARE @dbsize BIGINT;
                    DECLARE @logsize BIGINT;
                    DECLARE @reservedpages BIGINT;
                    DECLARE @usedpages BIGINT;

                    -------------------------------------------------------------------------------
                    -- get server information
                    -------------------------------------------------------------------------------
                    INSERT @ServerInformation EXEC master.dbo.xp_msver;

                    EXEC master.dbo.xp_instance_regread N'HKEY_LOCAL_MACHINE', N'SOFTWARE\Microsoft\MSSQLServer\Setup', N'SQLPath', @SmoRoot OUTPUT;

                    -------------------------------------------------------------------------------
                    -- get database size information
                    -------------------------------------------------------------------------------
                    SELECT @dbsize  = SUM(CONVERT(BIGINT, CASE
                                                            WHEN status & 64 = 0 THEN size
                                                            ELSE 0
                                                          END)),
                           @logsize = SUM(CONVERT(BIGINT, CASE
                                                            WHEN status & 64 <> 0 THEN size
                                                            ELSE 0
                                                          END))
                    FROM dbo.sysfiles;

                    SELECT @reservedpages = SUM(A.total_pages),
                           @usedpages     = SUM(A.used_pages),
                           @pages         = SUM(CASE -- XML-Index and FT-Index-Docid is not considered 'data', but is part of 'index_size'
                                                  WHEN IT.internal_type IN (202, 204) THEN 0
                                                  WHEN A.type <> 1 THEN A.used_pages
                                                  WHEN P.index_id < 2 THEN a.data_pages
                                                  ELSE 0
                                                END)
                    FROM sys.partitions              P
                           JOIN sys.allocation_units A  ON P.partition_id = A.container_id
                      LEFT JOIN sys.internal_tables  IT ON P.OBJECT_ID = IT.OBJECT_ID;

                    -------------------------------------------------------------------------------
                    -- show output
                    -------------------------------------------------------------------------------
                    SELECT -- server
                           ServerName             = CAST(SERVERPROPERTY(N'Servername') AS SYSNAME),
                           ServerProduct          = (SELECT [Value]
                                                     FROM @ServerInformation
                                                     WHERE [Name] = N'ProductName'),
                           ServerOperatingSystem  = RIGHT(@@VERSION, LEN(@@VERSION) - 3 - CHARINDEX(' ON ', @@VERSION)),
                           ServerPlatform         = (SELECT [Value]
                                                     FROM @ServerInformation
                                                     WHERE [Name] = N'Platform'),
                           ServerEdition          = SERVERPROPERTY (N'Edition'),
                           ServerVersion          = SERVERPROPERTY(N'ProductVersion'),
                           ServerProductLevel     = SERVERPROPERTY(N'ProductLevel'),
                           ServerLanguage         = (SELECT [Value]
                                                     FROM @ServerInformation
                                                     WHERE [Name] = N'Language'),
                           ServerMemory           = (SELECT CONVERT(VARCHAR(50), [Internal_Value])  + ' (MB)'
                                                     FROM @ServerInformation
                                                     WHERE [Name] = N'PhysicalMemory'),
                           ServerProcessors       = (SELECT [Internal_Value]
                                                     FROM @ServerInformation
                                                     WHERE [Name] = N'ProcessorCount'),
                           ServerRootDirectory    = @SmoRoot,
                           ServerCollation        = CONVERT(SYSNAME, SERVERPROPERTY(N'Collation')),
                           ServerIsClustered      = CAST(SERVERPROPERTY('IsClustered') AS BIT),
                           ServerDateTime         = GETDATE(),

                           -- database
                           DatabaseName           = DTB.name,
                           DatabaseCollation      = DTB.collation_name,
                           DatabaseRecoveryModel  = DTB.recovery_model_desc,
                           DatabasseCompatibility = DTB.compatibility_level,
                           DatabasePageVerify     = DTB.page_verify_option_desc,
                           DatabaseReadOnly       = DTB.is_read_only,
                           DatabaseRestrictAccess = DTB.user_access_desc,
                           --
                           DatabaseDateCreated    = DTB.create_date,
                           DatabaseLastBackup     = (SELECT MAX(backup_finish_date)
                                                     FROM msdb..backupset
                                                     WHERE TYPE = 'D'
                                                       AND database_name = DTB.name),
                           DatabaseLastLogBackup  = (SELECT MAX(backup_finish_date)
                                                     FROM msdb..backupset
                                                     WHERE TYPE = 'L'
                                                       AND database_name = DTB.name),
                           DatabaseOwner          = SUSER_SNAME(DTB.owner_sid),
                           DatabaseStatus         = DTB.state_desc,
                           DatabaseNumberOfUsers  = (SELECT COUNT(1)
                                                     FROM sys.database_principals U
                                                     WHERE (U.type IN ('U', 'S', 'G', 'C', 'K'))),
                           DatabaseActiveConn     = (SELECT COUNT(1)
                                                     FROM master.dbo.sysprocesses p
                                                     WHERE DTB.database_id = P.dbid),
                           DatabaseSize           = LTRIM(STR((CONVERT (DEC(15, 2), @dbsize) + CONVERT (DEC(15, 2), @logsize)) * 8192 / 1048576, 15, 2) + ' MB'),
                           DatabaseSpaceAvailable = LTRIM(STR((CASE
                                                                 WHEN @dbsize >= @reservedpages
                                                                   THEN (CONVERT(DEC(15, 2), @dbsize) - CONVERT(DEC(15, 2), @reservedpages)) * 8192 / 1048576
                                                                 ELSE 0
                                                               END), 15, 2) + ' MB'),
                           DatabasePrimaryFile    = DF.physical_name,

                           -- session
                           SessionID              = SES.session_id,
                           SessionLoginName       = SES.login_name,
                           SessionLoginTime       = SES.login_time,
                           --SessionAuthentication  = CON.auth_scheme,
                           SessionDatabase        = DB_NAME(),
                           SessionUserName        = USER_NAME(),
                           SessionHostNamePID     = ISNULL(SES.host_name, '') + ISNULL(' (PID: ' + CONVERT(VARCHAR(20), SES.host_process_id) + ')', ''),
                           SessionAppNameInterf   = ISNULL(SES.program_name, '') + ISNULL(' (' + SES.client_interface_name + ')', ''),
                           SessionLanguage        = SES.language,
                           SessionDateformat      = SES.date_format,
                           SessionDateFirst       = SES.date_first,
                           SessionCPUTime         = SES.cpu_time,
                           SessionMemoryUsage     = SES.memory_usage,
                           SessionReads           = SES.reads,
                           SessionWrites          = SES.writes,
                           SessionLogicalReads    = SES.logical_reads,
                           SessionPreviousError   = SES.prev_error
                           --SessionNetProtocol     = CON.net_transport,
                           --SessionNetPacketSize   = CON.net_packet_size,
                           --SessionNetClientIPPort = ISNULL(CON.client_net_address, '?.?.?.?') + ':' + ISNULL(CONVERT(VARCHAR(20), CON.client_tcp_port), '?'),
                           --SessionNetServerIPPort = ISNULL(CON.local_net_address, '?.?.?.?') + ':' + ISNULL(CONVERT(VARCHAR(20), CON.local_tcp_port), '?')

                    FROM master.sys.databases                AS DTB
                      LEFT JOIN sys.master_files             AS DF  ON df.database_id = dtb.database_id
                                                                   AND 1 = df.data_space_id
                                                                   AND 1 = df.file_id
                      LEFT JOIN sys.database_recovery_status AS DRS ON DRS.database_id = DTB.database_id
                      LEFT JOIN sys.database_mirroring       AS DMI ON DMI.database_id = DTB.database_id
                      --LEFT JOIN #tmp_sp_db_vardecimal_storage_format AS VARDEC ON dtb.name = vardec.dbname

                      -- session
                      LEFT JOIN sys.dm_exec_sessions         AS SES ON SES.session_id = @@SPID
                      --LEFT JOIN sys.dm_exec_connections      AS CON ON CON.session_id = SES.session_id
                    WHERE DTB.name = DB_NAME();");

                // validate information
                if (qryServerDbInfo == null || qryServerDbInfo.IsEmpty)
                {
                    // no session, cannot show any data
                    AddErrorInformationToEdit(edtAboutDatabase, "No information returned from database, cannot show content.");

                    // done
                    return;
                }
            }
            catch (Exception ex)
            {
                // show message
                KissMsg.ShowError(Name, "ErrorGettingDatabaseInformation", "Es ist ein Fehler beim Laden der Datenbank Informationen aufgetreten.", ex);

                // set error text
                AddErrorInformationToEdit(edtAboutDatabase, ex.Message);

                // done
                return;
            }

            #endregion

            #region Set information

            // server information
            AddTitleInformationToEdit(edtAboutDatabase, "Server information");

            // ----

            // server information content
            AddInformationToEdit(edtAboutDatabase, "Name", ConvertToString(qryServerDbInfo, "ServerName"), false);
            AddInformationToEdit(edtAboutDatabase, "Product", ConvertToString(qryServerDbInfo, "ServerProduct"), false, isUserAdmin);
            AddInformationToEdit(edtAboutDatabase, "Operating System", ConvertToString(qryServerDbInfo, "ServerOperatingSystem"), false, isUserAdmin);
            AddInformationToEdit(edtAboutDatabase, "Platform", ConvertToString(qryServerDbInfo, "ServerPlatform"), false, isUserAdmin);
            AddInformationToEdit(edtAboutDatabase, "Edition", ConvertToString(qryServerDbInfo, "ServerEdition"), false, isUserAdmin);
            AddInformationToEdit(edtAboutDatabase, "Version", ConvertToString(qryServerDbInfo, "ServerVersion"), false, isUserAdmin);
            AddInformationToEdit(edtAboutDatabase, "Product Level", ConvertToString(qryServerDbInfo, "ServerProductLevel"), false, isUserAdmin);
            AddInformationToEdit(edtAboutDatabase, "Language", ConvertToString(qryServerDbInfo, "ServerLanguage"), false);
            AddInformationToEdit(edtAboutDatabase, "Memory", ConvertToString(qryServerDbInfo, "ServerMemory"), false, isUserAdmin);
            AddInformationToEdit(edtAboutDatabase, "Processors", ConvertToString(qryServerDbInfo, "ServerProcessors"), false, isUserAdmin);
            AddInformationToEdit(edtAboutDatabase, "Root Directory", ConvertToString(qryServerDbInfo, "ServerRootDirectory"), false, isUserAdmin);
            AddInformationToEdit(edtAboutDatabase, "Server Collation", ConvertToString(qryServerDbInfo, "ServerCollation"), false);
            AddInformationToEdit(edtAboutDatabase, "Is Clustered", ConvertToString(qryServerDbInfo, "ServerIsClustered"), false, isUserAdmin);
            AddInformationToEdit(edtAboutDatabase, "DateTime", ConvertToString(qryServerDbInfo, "ServerDateTime"), false);

            // append new line for separating content
            edtAboutDatabase.SelectedText = Environment.NewLine;

            // ----

            // database information
            AddTitleInformationToEdit(edtAboutDatabase, "Database information");

            // ----

            // database information content
            AddInformationToEdit(edtAboutDatabase, "Name", ConvertToString(qryServerDbInfo, "DatabaseName"), false);
            AddInformationToEdit(edtAboutDatabase, "Collation", ConvertToString(qryServerDbInfo, "DatabaseCollation"), false);
            AddInformationToEdit(edtAboutDatabase, "Recovery Model", ConvertToString(qryServerDbInfo, "DatabaseRecoveryModel"), false, isUserAdmin);
            AddInformationToEdit(edtAboutDatabase, "Compatiblity Level", ConvertToString(qryServerDbInfo, "DatabasseCompatibility"), false, isUserAdmin);
            AddInformationToEdit(edtAboutDatabase, "Page Verify", ConvertToString(qryServerDbInfo, "DatabasePageVerify"), false, isUserAdmin);
            AddInformationToEdit(edtAboutDatabase, "Database Read-Only", ConvertToString(qryServerDbInfo, "DatabaseReadOnly"), false);
            AddInformationToEdit(edtAboutDatabase, "Restrict Access", ConvertToString(qryServerDbInfo, "DatabaseRestrictAccess"), false);
            AddInformationToEdit(edtAboutDatabase, "Date Created", ConvertToString(qryServerDbInfo, "DatabaseDateCreated"), false, isUserAdmin);
            AddInformationToEdit(edtAboutDatabase, "Last Database Backup", ConvertToString(qryServerDbInfo, "DatabaseLastBackup"), false, isUserAdmin);
            AddInformationToEdit(edtAboutDatabase, "Last Database Log Backup", ConvertToString(qryServerDbInfo, "DatabaseLastLogBackup"), false, isUserAdmin);
            AddInformationToEdit(edtAboutDatabase, "Owner", ConvertToString(qryServerDbInfo, "DatabaseOwner"), false, isUserAdmin);
            AddInformationToEdit(edtAboutDatabase, "Status", ConvertToString(qryServerDbInfo, "DatabaseStatus"), false);
            AddInformationToEdit(edtAboutDatabase, "Number of Users", ConvertToString(qryServerDbInfo, "DatabaseNumberOfUsers"), false, isUserAdmin);
            AddInformationToEdit(edtAboutDatabase, "Active Connections", ConvertToString(qryServerDbInfo, "DatabaseActiveConn"), false, isUserAdmin);
            AddInformationToEdit(edtAboutDatabase, "Size", ConvertToString(qryServerDbInfo, "DatabaseSize"), false, isUserAdmin);
            AddInformationToEdit(edtAboutDatabase, "Space Available", ConvertToString(qryServerDbInfo, "DatabaseSpaceAvailable"), false, isUserAdmin);
            AddInformationToEdit(edtAboutDatabase, "Primary-File Path", ConvertToString(qryServerDbInfo, "DatabasePrimaryFile"), false, isUserAdmin);

            // append new line for separating content
            edtAboutDatabase.SelectedText = Environment.NewLine;

            // ----

            // database information
            AddTitleInformationToEdit(edtAboutDatabase, "Session information");

            // ----

            AddInformationToEdit(edtAboutDatabase, "Session ID", ConvertToString(qryServerDbInfo, "SessionID"), false);
            AddInformationToEdit(edtAboutDatabase, "Login Name", ConvertToString(qryServerDbInfo, "SessionLoginName"), false, isUserAdmin); // can be changed to non-admins as soon as we use WinAuth.
            AddInformationToEdit(edtAboutDatabase, "Login Time", ConvertToString(qryServerDbInfo, "SessionLoginTime"), false);
            ////AddInformationToEdit(edtAboutDatabase, "Authentication", ConvertToString(qryServerDBInfo, "SessionAuthentication"), false, isUserAdmin);
            AddInformationToEdit(edtAboutDatabase, "Database", ConvertToString(qryServerDbInfo, "SessionDatabase"), false);
            AddInformationToEdit(edtAboutDatabase, "User Name", ConvertToString(qryServerDbInfo, "SessionUserName"), false, isUserAdmin);
            AddInformationToEdit(edtAboutDatabase, "Host", ConvertToString(qryServerDbInfo, "SessionHostNamePID"), false);
            AddInformationToEdit(edtAboutDatabase, "Application", ConvertToString(qryServerDbInfo, "SessionAppNameInterf"), false);
            AddInformationToEdit(edtAboutDatabase, "Language", ConvertToString(qryServerDbInfo, "SessionLanguage"), false);
            AddInformationToEdit(edtAboutDatabase, "Date Format", ConvertToString(qryServerDbInfo, "SessionDateformat"), false);
            AddInformationToEdit(edtAboutDatabase, "Date First", ConvertToString(qryServerDbInfo, "SessionDateFirst"), false);
            AddInformationToEdit(edtAboutDatabase, "CPU Time", ConvertToString(qryServerDbInfo, "SessionCPUTime"), false);
            AddInformationToEdit(edtAboutDatabase, "Memory Usage", ConvertToString(qryServerDbInfo, "SessionMemoryUsage"), false);
            AddInformationToEdit(edtAboutDatabase, "Reads", ConvertToString(qryServerDbInfo, "SessionReads"), false);
            AddInformationToEdit(edtAboutDatabase, "Writes", ConvertToString(qryServerDbInfo, "SessionWrites"), false);
            AddInformationToEdit(edtAboutDatabase, "Logical Reads", ConvertToString(qryServerDbInfo, "SessionLogicalReads"), false);
            AddInformationToEdit(edtAboutDatabase, "Previous Error", ConvertToString(qryServerDbInfo, "SessionPreviousError"), false, false);
            ////AddInformationToEdit(edtAboutDatabase, "Network Protocol", ConvertToString(qryServerDBInfo, "SessionNetProtocol"), false, isUserAdmin);
            ////AddInformationToEdit(edtAboutDatabase, "Network Packet Size", ConvertToString(qryServerDBInfo, "SessionNetPacketSize"), false, isUserAdmin);
            ////AddInformationToEdit(edtAboutDatabase, "Client IP:Port", ConvertToString(qryServerDBInfo, "SessionNetClientIPPort"), false);
            ////AddInformationToEdit(edtAboutDatabase, "Server IP:Port", ConvertToString(qryServerDBInfo, "SessionNetServerIPPort"), false, isUserAdmin);

            #endregion
        }

        /// <summary>
        /// Init some GUI and control properties
        /// </summary>
        private void InitGui()
        {
            // set minimum size
            MinimumSize = new Size(520, 450);

            // hide team-info-panel by default
            panAboutTeam.Visible = false;

            // set control-color here because of better visibility in designer
            edtAboutKiSS.BackColor = BackColor;
            edtAboutDatabase.BackColor = BackColor;
            edtMemoryInfo.BackColor = BackColor;

            // center close-button
            CenterCloseButton();

            // init label
            lblAboutTeam.Font = _fontAboutDefault;

            // init enlarge/shrink timer
            tmrEnlargeShrink.Interval = 75;

            // init scrolling timer
            tmrScrollingLabel.Interval = 120;

            // show/hide btnGarbageCollector
            btnGarbageCollector.Visible = Debugger.IsAttached;

            // select first tpg
            tabSystemInfo.SelectTab(tpgAbout);

            // setup tabpages
            tpgDatabase.HideTab = (!Session.Active);
            tpgDatabaseVersions.HideTab = (!Session.Active || !Session.User.IsUserAdmin);

            // init gui for enlarged/shrinked
            InitGuiEnlargeShrink(true);
        }

        /// <summary>
        /// Init gui for enlarging/shrinking gui by timer or reset settings when done
        /// </summary>
        /// <param name="done"><c>True</c> if timed enlarging/shrinking is done, <c>False</c> if enlarging/shrinking gets started</param>
        private void InitGuiEnlargeShrink(bool done)
        {
            if (done)
            {
                // done enlarging or shrinking form > reset gui settings for resizeable

                // unlock resize form (resize is only allowed when not enlarged)
                FormBorderStyle = _isEnlarged ? FormBorderStyle.FixedDialog : FormBorderStyle.Sizable;

                // set anchors for resizing form by user
                edtAboutKiSS.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                panAboutTeam.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            }
            else
            {
                // enlarge/shrink form

                // lock resize form
                FormBorderStyle = FormBorderStyle.FixedDialog;

                // set anchors for enlarge/shrink
                edtAboutKiSS.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                panAboutTeam.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            }
        }

        /// <summary>
        /// Init the developer hidden info text
        /// </summary>
        private void InitTeamInfoLabel()
        {
            // team string
            string teamInfo = "";

            // hold team names
            var teamNames = new List<string>
                                {
                                    "Abegglen Thomas",
                                    "Boss Alain",
                                    "Boss Markus",
                                    "Berger Thomas",
                                    "Brügger Ruedi",
                                    "Custode Domenico",
                                    "Durtschi Martin",
                                    "Dittrich Patrick",
                                    "Edelmann Beat",
                                    "Fässler Gilles",
                                    "Faller Tom",
                                    "Feist Damien",
                                    "Fuchs Andreas",
                                    "Glauser Claude",
                                    "Greulich Leonhard",
                                    "Heimgartner Walter",
                                    "Hesterberg Rolf",
                                    "Jacober Raphael",
                                    "Jäggi Christoph",
                                    "Käser Christian",
                                    "Kappert Beat",
                                    "Klopfenstein Alfred",
                                    "Koch Ernst",
                                    "Loreggia Lucas",
                                    "Lusenti Michael",
                                    "Marghitola Marcel",
                                    "Marino Rahel",
                                    "Mast Daniel",
                                    "Mathys Wolfram",
                                    "Meister Arno",
                                    "Minder Daniel",
                                    "Minder Mathias",
                                    "Mittag Michael",
                                    "Meuwly Corinne",
                                    "Nguyen Quac",
                                    "Psota Samuel",
                                    "Rossel Nathanaël",
                                    "Salajan Peter",
                                    "Spengler Jutta",
                                    "Stahel Reto",
                                    "Stucki Conny",
                                    "Urwyler Daniel",
                                    "Weber Marcel",
                                    "Weber Nicolas",
                                    "Wittwer André",
                                    "Zimmermann Florian"
                                };

            // add all developer of KiSS (non-AZ-sorting required)
            // möchte seinen Namen nicht erwähnt haben: teamNames.Add("Van der Floe Urs");

            // sort the names AZ
            teamNames.Sort();

            // add all names to string
            foreach (string teamName in teamNames)
            {
                // add name with new line
                teamInfo += string.Format("{0}{1}", teamName, Environment.NewLine);
            }

            // spacers
            string spacerTop = string.Format("{0}{0}{0}{0}{0}", Environment.NewLine);           // this has to be at least the delta for height when form is enlarged to prevent showing some text without scrolling top
            string spacerBottom = string.Format("", Environment.NewLine);                       // this gives the delay (with spacerTop) for new run

            // setup label with spacers
            lblAboutTeam.Text = string.Format("{0}The KiSS Team:{1}{1}{2}{3}", spacerTop, Environment.NewLine, teamInfo, spacerBottom);

            CenterAboutTeamLabel();

            // setup flag
            _isTeamLabelSet = true;
        }

        /// <summary>
        /// Do reset the team-info-label position for next scrolling through
        /// </summary>
        private void ResetLabelPosition()
        {
            // reset position of team-info-label
            lblAboutTeam.Top = 0;
        }

        /// <summary>
        /// Load or refresh list of available assemblies
        /// </summary>
        private void SetupAvailableAssemblies()
        {
            try
            {
                // setup cursor
                Cursor.Current = Cursors.WaitCursor;

                // remove any bindings
                grdAvailableAssemblies.DataBindings.Clear();
                grdAvailableAssemblies.DataSource = null;

                // try to free memory
                if (_availableAssemblies != null)
                {
                    _availableAssemblies.Clear();
                    _availableAssemblies.ResetBindings();
                    _availableAssemblies = null;
                }

                // get list of all *.exe and *.dll files within application directory and subfolders
                var fileList = UtilsGui.FindFiles(Session.ApplicationStartupPath, "*.exe;*.dll", true);

                // create new list
                _availableAssemblies = new SortableBindingList<AvailableAssembly>();

                // create error list
                int errCounter = 0;
                var sbFailedAssemblies = new StringBuilder();

                // loop found files
                foreach (FileInfo fileInfo in fileList)
                {
                    // FILTER: handle known exceptions (non .NET assemblies)
                    string fileNameLower = fileInfo.Name.ToLower();

                    // compare
                    if (fileNameLower.Equals("touch.exe") || fileNameLower.Equals("ibankernel.dll") ||
                        fileNameLower.Equals("nv_o2o_teilnehmer_de.exe") || fileNameLower.Equals("genimpex.dll") ||
                        fileNameLower.Equals("plausexplausidoc.dll"))
                    {
                        // do not handle this file and go on with next file
                        continue;
                    }

                    try
                    {
                        // create new available assembly and add to databinding-list
                        _availableAssemblies.Add(new AvailableAssembly(fileInfo));
                    }
                    catch (Exception ex)
                    {
                        // count up
                        errCounter++;

                        // add error to string
                        sbFailedAssemblies.AppendFormat("{1}: '{2}'{0}{3}: '{4}'{0}{0}",
                            Environment.NewLine,                                            // {0}
                            KissMsg.GetMLMessage(Name, "Assembly", "Assembly"),        // {1}
                            fileInfo.FullName,                                              // {2}
                            KissMsg.GetMLMessage(Name, "Error", "Fehler"),             // {3}
                            ex.Message);                                                    // {4}
                    }
                }

                // check if we have a valid binding source
                if (_availableAssemblies.Count < 1)
                {
                    // no available assemblies
                    throw new NullReferenceException("Error loading available assemblies, no assemblies applied.");
                }

                // set databinding and sort by first column
                grdAvailableAssemblies.DataSource = _availableAssemblies;
                SetupAvailableAssembliesColumns();
                grdAvailableAssemblies.Sort(grdAvailableAssemblies.Columns[0], ListSortDirection.Ascending);

                // autosize columns
                AutoSizeColumnsAndAllowSorting(grdAvailableAssemblies);

                // setup counter
                lblAvailableAssembliesCount.Text = KissMsg.GetMLMessage(Name,
                    "CountAvailableAssemblies",
                    "Anzahl Assemblies: {0}",
                    KissMsgCode.Text,
                    _availableAssemblies.Count);

                // check if we have any failed assemblies
                if (errCounter > 0)
                {
                    // create message for failed assemblies
                    KissMsg.ShowError(Name,
                        "ErrorLoadingSomeAssemblies_v01",
                        "Es gab '{0}' Fehler beim Analysieren der Assemblies.{1}{1}Wahrscheinlich werden nicht alle vorhandenen Dateien aufgelistet.",
                        sbFailedAssemblies.ToString(),
                        null,
                        errCounter,
                        Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                // show error
                KissMsg.ShowError(Name, "ErrorSetupAvailableAssemblies", "Es ist ein Fehler beim Laden der verfügbaren Assemblies aufgetreten.", ex);
            }
            finally
            {
                // reset cursor
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Add columns to grid of available assemblies
        /// </summary>
        private void SetupAvailableAssembliesColumns()
        {
            // check if we already have columns
            if (grdAvailableAssemblies.Columns.Count > 0)
            {
                // do nothing
                return;
            }

            // add columns in proper order as defined in ToString() of class AvailableAssembly
            grdAvailableAssemblies.Columns.Add(CreateGridColumn("Name", typeof(string), 0, true));
            grdAvailableAssemblies.Columns.Add(CreateGridColumn("Version", typeof(Version), 1));
            grdAvailableAssemblies.Columns.Add(CreateGridColumn("CompanyName", typeof(string), 2));
            grdAvailableAssemblies.Columns.Add(CreateGridColumn("Description", typeof(string), 3));
            grdAvailableAssemblies.Columns.Add(CreateGridColumn("RuntimeVersion", typeof(string), 4));
            grdAvailableAssemblies.Columns.Add(CreateGridColumn("DateCreated", typeof(DateTime), 5));
            grdAvailableAssemblies.Columns.Add(CreateGridColumn("DateModified", typeof(DateTime), 6));
            grdAvailableAssemblies.Columns.Add(CreateGridColumn("DateBuilded", typeof(string), 7));
            grdAvailableAssemblies.Columns.Add(CreateGridColumn("Location", typeof(string), 8));
        }

        /// <summary>
        /// Setup the database versions grid with information from table XDatabaseVersion
        /// </summary>
        private void SetupDatabaseVersions()
        {
            try
            {
                // check if we have a session
                if (!Session.Active)
                {
                    // no version information possible
                    return;
                }

                // setup cursor
                Cursor.Current = Cursors.WaitCursor;

                // get data from database
                qryDatabaseVersions.Fill(@"
                    DECLARE @ActiveDBVersionID INT;
                    SET @ActiveDBVersionID = dbo.fnXDBVersionGetCurrentDBVersionID();

                    SELECT Id                         = XDBVersionID,
                           Active                     = CASE
                                                          WHEN XDBVersionID = @ActiveDBVersionID THEN 1
                                                          ELSE 0
                                                        END,
                           Version                    = CONVERT(VARCHAR(10), MajorVersion) + '.' +
                                                        CONVERT(VARCHAR(10), MinorVersion) + '.' +
                                                        CONVERT(VARCHAR(10), Build) + '.' +
                                                        CONVERT(VARCHAR(10), Revision),
                           VersionDate                = VersionDate,
                           BackwardCompatibleToClient = BackwardCompatibleDownToClientVersion,
                           Description                = Description,
                           DateCreated                = Created,
                           DateModified               = Modified,
                           --
                           ChangesSinceLastVersion    = REPLACE(REPLACE(ChangesSinceLastVersion, ', ', CHAR(13) + CHAR(10)),
                                                                ': ', CHAR(13) + CHAR(10) + '--------------------------------------------------' + CHAR(13) + CHAR(10))
                    FROM dbo.XDBVersion WITH (READUNCOMMITTED);");

                // setup bindings
                grdDatabaseVersions.DataSource = qryDatabaseVersions;

                // setup columns
                SetupDatabaseVersionsColumns();

                // sort columns
                grdDatabaseVersions.Sort(grdDatabaseVersions.Columns[0], ListSortDirection.Ascending);

                // autosize columns
                AutoSizeColumnsAndAllowSorting(grdDatabaseVersions);

                // setup counter
                lblDatabaseVersionsCount.Text = KissMsg.GetMLMessage(Name, "CountDatabaseVersions", "Anzahl Einträge: {0}", KissMsgCode.Text, qryDatabaseVersions.Count);
            }
            catch (Exception ex)
            {
                // show error
                KissMsg.ShowError(Name, "ErrorSetupDatabaseVersions", "Es ist ein Fehler beim Laden der Datenbank-Versionen aufgetreten.", ex);
            }
            finally
            {
                // reset cursor
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Add columns to grid of database versions
        /// </summary>
        private void SetupDatabaseVersionsColumns()
        {
            // clear columns first
            grdDatabaseVersions.Columns.Clear();

            // add columns in proper order as defined in ToString() of class AvailableAssembly
            grdDatabaseVersions.Columns.Add(CreateGridColumn("Id", typeof(int), 0));
            grdDatabaseVersions.Columns.Add(CreateGridColumn("Active", typeof(bool), 1));
            grdDatabaseVersions.Columns.Add(CreateGridColumn("Version", typeof(string), 2));
            grdDatabaseVersions.Columns.Add(CreateGridColumn("VersionDate", typeof(string), 3));
            grdDatabaseVersions.Columns.Add(CreateGridColumn("BackwardCompatibleToClient", typeof(string), 4));
            grdDatabaseVersions.Columns.Add(CreateGridColumn("Description", typeof(string), 5));
            grdDatabaseVersions.Columns.Add(CreateGridColumn("DateCreated", typeof(DateTime), 6));
            grdDatabaseVersions.Columns.Add(CreateGridColumn("DateModified", typeof(DateTime), 7));
            grdDatabaseVersions.Columns.Add(CreateGridColumn("ChangesSinceLastVersion", typeof(string), 8, false, false));
        }

        /// <summary>
        /// Setup the memory information text well formated and loded assemblies
        /// </summary>
        private void SetupMemoryInformation()
        {
            try
            {
                // setup cursor
                Cursor.Current = Cursors.WaitCursor;

                // get processinformation
                Process currentProcess = Process.GetCurrentProcess();

                #region Setup Text on edtMemoryInfo

                // reset text
                edtMemoryInfo.Text = "";

                // Processinformation
                AddTitleInformationToEdit(edtMemoryInfo, "Process information");

                // ----

                // process
                AddInformationToEdit(edtMemoryInfo,
                    "Process",
                    string.Format("{0} (PID: {1}, SessionID: {2})",
                        currentProcess.ProcessName,
                        currentProcess.Id,
                        currentProcess.SessionId),
                    false);

                // memory
                AddInformationToEdit(edtMemoryInfo,
                    "Memory usage",
                    string.Format("{0} (Peak: {1}, Paged: {2}, Virtual: {3})",
                        ConvertLongToByteInfo(currentProcess.WorkingSet64),
                        ConvertLongToByteInfo(currentProcess.PeakWorkingSet64),
                        ConvertLongToByteInfo(currentProcess.PagedMemorySize64),
                        ConvertLongToByteInfo(currentProcess.VirtualMemorySize64)),
                    false);

                // start time
                AddInformationToEdit(edtMemoryInfo, "StartTime", currentProcess.StartTime.ToString(), false, false, true);

                // ---- done ----

                // cleanup edit
                edtMemoryInfo.Rtf = edtMemoryInfo.Rtf.TrimEnd();

                #endregion

                #region Loaded modules

                // remove any bindings
                grdLoadedModules.DataBindings.Clear();
                grdLoadedModules.DataSource = null;

                // try to free memory
                if (_loadedModules != null)
                {
                    _loadedModules.Clear();
                    _loadedModules.ResetBindings();
                    _loadedModules = null;
                }

                // create new list
                _loadedModules = new SortableBindingList<LoadedModule>();

                // create new list for filenames to compare later on
                var loadedModulesFileNamesLower = new List<String>();

                // loop foreach module within current process
                foreach (ProcessModule module in currentProcess.Modules)
                {
                    try
                    {
                        // create instance
                        var lmodule = new LoadedModule(module);

                        // add loaded module to list
                        _loadedModules.Add(lmodule);

                        // add name to list if valid filename
                        if (!string.IsNullOrEmpty(lmodule.FileName))
                        {
                            loadedModulesFileNamesLower.Add(lmodule.FileName.ToLower());
                        }
                    }
                    catch (Exception ex)
                    {
                        // show error
                        KissMsg.ShowError(Name,
                            "ErrorLoadingSingleModuleInformation",
                            "Es ist ein Fehler beim Anzeigen der geladenen Module aufgetreten. Betroffenes Modul: '{0}'",
                            null,
                            ex,
                            0,
                            0,
                            module.FileName);
                    }
                }

                // add assemblies (if not yet in list)
                Assembly[] loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();

                // loop assemblies
                foreach (Assembly asm in loadedAssemblies)
                {
                    try
                    {
                        // create instance
                        var lmoduleAsm = new LoadedModule(asm);

                        // check if not yet in list (if empty filename, add anyway)
                        if (string.IsNullOrEmpty(lmoduleAsm.FileName) || !loadedModulesFileNamesLower.Contains(lmoduleAsm.FileName.ToLower()))
                        {
                            // add item
                            _loadedModules.Add(lmoduleAsm);
                        }
                    }
                    catch (Exception ex)
                    {
                        // show error
                        KissMsg.ShowError(Name,
                            "ErrorLoadingSingleModuleAsmInformation_v03",
                            "Es ist ein Fehler beim Anzeigen der geladenen Assemblies aufgetreten.\r\n\r\nBetroffenes Assembly:\r\n '{0}'",
                            null,
                            ex,
                            0,
                            0,
                            asm.IsDynamic ? asm.ToString() : asm.Location);
                    }
                }

                // check if we have a valid binding source
                if (_loadedModules.Count < 1)
                {
                    // no loaded modules
                    throw new NullReferenceException("Error showing loaded modules, no module applied.");
                }

                // set databinding and sort by first column
                grdLoadedModules.DataSource = _loadedModules;
                SetupMemoryInformationColumns();
                grdLoadedModules.Sort(grdLoadedModules.Columns[0], ListSortDirection.Ascending);	// sort by name

                // autosize columns
                AutoSizeColumnsAndAllowSorting(grdLoadedModules);

                // setup counter
                lblMemoryCount.Text = KissMsg.GetMLMessage(Name,
                    "CountMemoryModules_v01",
                    "Anzahl geladener Module/Assemblies: {0}",
                    KissMsgCode.Text,
                    _loadedModules.Count);

                #endregion
            }
            catch (Exception ex)
            {
                // show error
                KissMsg.ShowError(Name, "ErrorSetupMemoryInformation", "Es ist ein Fehler beim Laden der Speicherinformationen aufgetreten.", ex);
            }
            finally
            {
                // reset cursor
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Add columns to grid of loaded modules
        /// </summary>
        private void SetupMemoryInformationColumns()
        {
            // check if we already have columns
            if (grdLoadedModules.Columns.Count > 0)
            {
                // do nothing
                return;
            }

            // add columns in proper order as defined in ToString() of class LoadedModule
            grdLoadedModules.Columns.Add(CreateGridColumn("Name", typeof(string), 0));
            grdLoadedModules.Columns.Add(CreateGridColumn("Type", typeof(char), 1));
            grdLoadedModules.Columns.Add(CreateGridColumn("Version", typeof(string), 2));
            grdLoadedModules.Columns.Add(CreateGridColumn("CompanyName", typeof(string), 3));
            grdLoadedModules.Columns.Add(CreateGridColumn("Description", typeof(string), 4));
            grdLoadedModules.Columns.Add(CreateGridColumn("RuntimeVersion", typeof(string), 5));
            grdLoadedModules.Columns.Add(CreateGridColumn("MemorySize", typeof(DateTime), 6));
            grdLoadedModules.Columns.Add(CreateGridColumn("FileName", typeof(string), 7));
        }

        private void SetupTempFilesInformation()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var appDataDirectory = Session.GetKissAppDataFolder();

                grdTempFiles.DataBindings.Clear();
                grdTempFiles.DataSource = null;
                _tempFiles = new SortableBindingList<FileEntry>();

                foreach (var file in appDataDirectory.GetFiles())
                {
                    _tempFiles.Add(new FileEntry(file));
                }

                grdTempFiles.DataSource = _tempFiles;
                SetupTempFilesInformationColumns();

                // sort by name
                grdTempFiles.Sort(grdTempFiles.Columns[0], ListSortDirection.Ascending);
                AutoSizeColumnsAndAllowSorting(grdTempFiles);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void SetupTempFilesInformationColumns()
        {
            // check if we already have columns
            if (grdTempFiles.Columns.Count > 0)
            {
                return;
            }

            grdTempFiles.Columns.Add(CreateGridColumn("Name", typeof(string), 0));
            grdTempFiles.Columns.Add(CreateGridColumn("Size", typeof(string), 1));
            grdTempFiles.Columns.Add(CreateGridColumn("LastWriteTime", typeof(DateTime), 2));
        }

        /// <summary>
        /// Start enlarge or shrink form to show or hide team-info-label
        /// </summary>
        private void StartEnlargeOrShrinkForm()
        {
            // check if we need to enable timer (or already running)
            if (tmrEnlargeShrink.Enabled)
            {
                // do nothing, timer is already running
                return;
            }

            // set original height if not enlarged
            if (!_isEnlarged)
            {
                OriginalHeight = Height;
            }

            // init gui for enlarging/shrinking
            InitGuiEnlargeShrink(false);

            // enable timer
            tmrEnlargeShrink.Enabled = true;
        }

        /// <summary>
        /// Start or stop scrolling the team-info-label
        /// </summary>
        private void StartStopScrolling()
        {
            // depending on current state, we show or hide panel
            panAboutTeam.Visible = _isEnlarged;

            // reset position of team-info-label
            ResetLabelPosition();

            // depending on current state, enable or disable timer
            tmrScrollingLabel.Enabled = _isEnlarged;
        }

        private void ViewTempFile()
        {
            if (grdTempFiles.SelectedCells.Count == 0)
            {
                KissMsg.ShowInfo(Name, "SelectTempFile", "Bitte eine Datei auswählen.");
                return;
            }

            try
            {
                // Write buffered log values to the file system.
                FlushLogFiles();

                var file = (FileEntry)grdTempFiles.SelectedCells[0].OwningRow.DataBoundItem;

                // open the file
                string content;

                // using FileShare.ReadWrite lets us read the file even if it is already opened and locked
                using (var reader = new FileStream(file.FileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    content = new StreamReader(reader).ReadToEnd();
                }

                using (var dlg = new DlgMemoEdit())
                {
                    dlg.MemoEditor.Properties.ReadOnly = true;
                    dlg.MemoEditor.EditValue = content;
                    dlg.RestoreLayout();
                    dlg.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(Name, "ErrorOpenTempFile", "Die Datei konnte nicht geöffnet werden.", ex);
            }
        }

        #endregion

        #endregion
    }
}