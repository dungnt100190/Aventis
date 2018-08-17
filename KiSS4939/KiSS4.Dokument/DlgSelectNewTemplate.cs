using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Dokument
{
    /// <summary>
    /// Class for dialog, showing all available templates
    /// </summary>
    public partial class DlgSelectNewTemplate : KissDialog
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        /// <summary>
        /// The subfolder withing application path where all templates are given
        /// </summary>
        private const String TEMPLATESUBFOLDER = "Templates";

        #endregion

        #region Private Fields

        /// <summary>
        /// List containing all available templates, used for binding
        /// </summary>
        private BindingList<AvailableTemplate> _availableTemplates;

        /// <summary>
        /// Store the finally selected template
        /// </summary>
        private AvailableTemplate _selectedTemplate;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="DlgSelectNewTemplate"/>
        /// </summary>
        public DlgSelectNewTemplate()
        {
            InitializeComponent();

            LoadAvailableTemplates();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get selected template from Dialog
        /// </summary>
        public AvailableTemplate SelectedTemplate
        {
            get { return _selectedTemplate; }
        }

        #endregion

        #region EventHandlers

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // close dialog
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnUseTemplate_Click(object sender, EventArgs e)
        {
            // check if button is enabled
            if (!btnUseTemplate.Enabled)
            {
                // cancel
                return;
            }

            // check if any template is selected
            try
            {
                // get current selected entry
                _selectedTemplate = _availableTemplates[grdAvailableTemplates.BindingContext[_availableTemplates].Position];
            }
            catch (Exception ex)
            {
                // show error
                KissMsg.ShowError("DlgSelectNewTemplate", "ErrorGettingSelectedItem", "Es ist ein Fehler beim Auswerten der gewählten Vorlage aufgetreten.", ex);

                // do not continue
                return;
            }

            // close dialog
            DialogResult = DialogResult.OK;
            Close();
        }

        private void grdAvailableTemplates_DoubleClick(object sender, EventArgs e)
        {
            // call apply-button
            btnUseTemplate_Click(this, EventArgs.Empty);
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Check if template path exists
        /// </summary>
        /// <returns>True if path exists, otherwise false</returns>
        public static Boolean TemplatePathExists()
        {
            // check if template-folder exists
            return Directory.Exists(Path.Combine(Session.ApplicationStartupPath, TEMPLATESUBFOLDER));
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Load grid with all available templates
        /// </summary>
        private void LoadAvailableTemplates()
        {
            try
            {
                // setup cursor
                Cursor.Current = Cursors.WaitCursor;

                // remove any bindings
                grdAvailableTemplates.DataBindings.Clear();
                grdAvailableTemplates.DataSource = null;

                // try to free memory
                if (_availableTemplates != null)
                {
                    _availableTemplates.Clear();
                    _availableTemplates.ResetBindings();
                    _availableTemplates = null;
                }

                // check if template-folder exists
                if (!TemplatePathExists())
                {
                    // folder not found, cannot continue
                    throw new DirectoryNotFoundException(String.Format("The required path for searching available templates does not exist, please contact your administrator. Requested path is: '{0}'.", Path.Combine(Session.ApplicationStartupPath, TEMPLATESUBFOLDER)));
                }

                // get list of all *.dot* and *.xlt* files within application directory and subfolders
                ReadOnlyCollection<FileInfo> fileList = UtilsGui.FindFiles(Path.Combine(Session.ApplicationStartupPath, TEMPLATESUBFOLDER), "*.doc;*.dot*;*.xls;*.xlt*", true);

                // create new list
                _availableTemplates = new BindingList<AvailableTemplate>();

                // loop found files
                foreach (FileInfo fileInfo in fileList)
                {
                    try
                    {
                        // create new available template and add to databinding-list
                        _availableTemplates.Add(new AvailableTemplate(fileInfo));
                    }
                    catch (Exception ex)
                    {
                        // show error
                        KissMsg.ShowError("DlgSelectNewTemplate", "ErrorLoadingSingleAvailableTemplate", "Es ist ein Fehler beim Laden der verfügbaren Vorlagen aufgetreten. Betroffene Vorlage: '{0}'", null, ex, 0, 0, fileInfo.FullName);
                    }
                }

                // check if we have a valid binding source
                if (_availableTemplates == null || _availableTemplates.Count < 1)
                {
                    // disable button
                    btnUseTemplate.Enabled = false;

                    // no available template
                    throw new NullReferenceException("Error loading available templates, no templates applied.");
                }

                // enable button
                btnUseTemplate.Enabled = true;

                // set databinding
                grdAvailableTemplates.DataSource = _availableTemplates;

                // setup counter
                lblAvailableTemplatesCount.Text = KissMsg.GetMLMessage("DlgSelectNewTemplate", "CountAvailableAssemblies", "Anzahl Vorlagen: {0}", KissMsgCode.Text, _availableTemplates.Count);
            }
            catch (Exception ex)
            {
                // show error
                KissMsg.ShowError("DlgSelectNewTemplate", "ErrorSetupAvailableTemplates", "Es ist ein Fehler beim Laden der verfügbaren Vorlagen aufgetreten.", ex);
            }
            finally
            {
                // reset cursor
                Cursor.Current = Cursors.Default;
            }
        }

        #endregion

        #endregion
    }
}