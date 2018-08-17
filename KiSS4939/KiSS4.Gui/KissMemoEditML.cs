using System;
using System.ComponentModel;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS4.DB;

namespace KiSS4.Gui
{
    /// <summary>
    /// Summary description for KissMemoEditML.
    /// </summary>
    public partial class KissMemoEditML : KissComplexControl, IKissEditable
    {
        /// <summary>
        /// Apply changes on editvalue to dataMemberDefaultText column in datasource
        /// </summary>
        private bool _applyChangesToDefaultText = true;

        /// <summary>
        /// Language code at the time when the OnPositionChanged event occured
        /// Prevents confusion when the language is changed and the mask doesn't get notified
        /// </summary>
        private int _currentLanguageCode;

        /// <summary>
        /// TID of the current edited DataRow/DataMember
        /// </summary>
        private int _currentTID;

        /// <summary>
        /// The column that contains the Text in the default language
        /// </summary>
        private string _dataMemberDefaultText;

        /// <summary>
        /// The column in the DB table that contains the TID connected to the DataMember
        /// </summary>
        private string _dataMemberTID;

        /// <summary>
        /// Used to prevent set row-modified = true when changing position in datasource
        /// </summary>
        private bool _isPositionChanging;

        /// <summary>
        /// Show only default language or user language specific content
        /// </summary>
        private bool _showOnlyDefaultLanguage;

        /// <summary>
        /// Constructor
        /// </summary>
        public KissMemoEditML()
        {
            // init components
            InitializeComponent();

            // do not show writelock by default
            ShowWriteLock = false;
        }

        /// <summary>
        /// Event is fired when any data in translation dialog or memofield has changed
        /// </summary>
        public event EventHandler DataHasChanged;

        /// <summary>
        /// Get and set if changes to EditValue have to be applied to DataMemberDefaultText row on DataSource
        /// </summary>
        [Browsable(true)]
        [DefaultValue(true)]
        [Description("Get and set if changes to EditValue have to be applied directly to DataMemberDefaultText row on DataSource")]
        public bool ApplyChangesToDefaultText
        {
            get { return _applyChangesToDefaultText; }
            set { _applyChangesToDefaultText = value; }
        }

        /// <summary>
        /// Gets or sets the name of the column in the DB table that contains the TID connected to the column specified in DataMember
        /// </summary>
        [Browsable(true)]
        [DefaultValue(null)]
        [Description("The column that contains the Text in the default language")]
        public string DataMemberDefaultText
        {
            get { return _dataMemberDefaultText; }
            set { _dataMemberDefaultText = value; }
        }

        /// <summary>
        /// Gets or sets the name of the column in the DB table that contains the TID connected to the column specified in DataMember
        /// </summary>
        [Browsable(true)]
        [DefaultValue(null)]
        [Description("The column that contains the TextID for the Text provided by DataMember")]
        public string DataMemberTID
        {
            get { return _dataMemberTID; }
            set { _dataMemberTID = value; }
        }

        /// <summary>
        /// Gets or sets the DataSource of the control
        /// </summary>
        [Browsable(true)]
        [DefaultValue(null)]
        [Description("Gets or sets the DataSource of the control")]
        public SqlQuery DataSource
        {
            get { return edtMemoEdit.DataSource; }
            set
            {
                if (edtMemoEdit.DataSource != value)
                {
                    if (edtMemoEdit.DataSource != null)
                    {
                        edtMemoEdit.DataSource.PositionChanged -= DataSource_PositionChanged;
                        edtMemoEdit.DataSource.BeforePost -= DataSource_BeforePost;
                        edtMemoEdit.DataSource.PostCompleted -= DataSource_PostCompleted;
                    }
                    if (value != null)
                    {
                        value.PositionChanged += DataSource_PositionChanged;
                        value.BeforePost += DataSource_BeforePost;
                        value.PostCompleted += DataSource_PostCompleted;
                    }
                    edtMemoEdit.DataSource = value;
                }
            }
        }

        /// <summary>
        /// The EditMode of the control. On ReadOnly, the dialog can not be shown
        /// </summary>
        [Browsable(true)]
        [DefaultValue(EditModeType.Normal)]
        [Description("The EditMode of the control. On ReadOnly, the dialog can not be shown")]
        public EditModeType EditMode
        {
            get { return edtMemoEdit.EditMode; }
            set
            {
                edtMemoEdit.EditMode = value;
                cmdOpenDialog.Enabled = value != EditModeType.ReadOnly;
                WriteLocked = !cmdOpenDialog.Enabled;
            }
        }

        /// <summary>
        /// The EditValue of the memofield
        /// </summary>
        [Browsable(true)]
        [DefaultValue(null)]
        [Description("The EditValue of the memofield")]
        public object EditValue
        {
            get { return edtMemoEdit.EditValue; }
            set { edtMemoEdit.EditValue = value; }
        }

        /// <summary>
        /// Show only default language or user language specific content
        /// </summary>
        [Browsable(true)]
        [DefaultValue(false)]
        [Description("Show only default language or user language specific content")]
        public bool ShowOnlyDefaultLanguage
        {
            get { return _showOnlyDefaultLanguage; }
            set
            {
                _showOnlyDefaultLanguage = value;
                SetCurrentLanguageCode();
            }
        }

        /// <summary>
        /// Set and get if checkbox for writelock is visible
        /// </summary>
        [Browsable(true)]
        [DefaultValue(false)]
        [Description("Set and get if checkbox for writelock is visible")]
        public bool ShowWriteLock
        {
            get { return chkWriteLock.Visible; }
            set
            {
                if (value)
                {
                    // show writelock
                    chkWriteLock.Visible = true;
                    edtMemoEdit.Height = Height - 24;
                }
                else
                {
                    // disable and hide writelock
                    WriteLocked = false;
                    chkWriteLock.Visible = false;
                    edtMemoEdit.Height = Height;
                }
            }
        }

        /// <summary>
        /// Get and set if the writelock is active or not
        /// </summary>
        [Browsable(false)]
        [Description("Get and set if memoedit can be changed")]
        public bool WriteLocked
        {
            get { return chkWriteLock.Checked; }
            set { chkWriteLock.Checked = value; }
        }

        private bool CanChangeDataOnDataSource()
        {
            if (DataSource == null || !(DataSource.CanInsert || DataSource.CanUpdate))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Event checked changed for writelock
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkWriteLock_CheckedChanged(object sender, EventArgs e)
        {
            EditMode = chkWriteLock.Checked ? EditModeType.ReadOnly : EditModeType.Normal;
        }

        /// <summary>
        /// Eventhandler: The user wants to edit the text in other languages
        /// </summary>
        /// <param name="sender">event source</param>
        /// <param name="e">event parameters</param>
        private void cmdOpenDialog_Click(object sender, EventArgs e)
        {
            // check if is readonly
            if (EditMode == EditModeType.ReadOnly || !CanChangeDataOnDataSource())
            {
                // don't show dialog if readonly
                return;
            }

            // validate necessary TID before showing dialog
            if (_currentTID < 1)
            {
                _currentTID = GetCurrentTID();
            }
            if (_currentTID < 1)
            {
                if (GetDefaultText() == "")
                {
                    KissMsg.ShowError("KissMemoEditML", "EmptyValueInBtnShowML", "Das Übersetzungsfenster kann nicht angezeigt werden, da kein Standardwert angegeben wurde.", "Current default value is empty (base.DataSource[ dataMemberDefaultText ]).");
                }
                else
                {
                    KissMsg.ShowError("KissMemoEditML", "InvalidValueInBtnShowML", "Ungültiger Aufruf, Übersetzungsfenster kann nicht angezeigt werden.", string.Format("Current TID is invalid: TID='{0}'.", _currentTID.ToString()));
                }
                return;
            }
            if (DataSource.RowModified)
            {
                // row is modified, save data in order to ensure having changend content in dialog
                if (!DataSource.Post())
                {
                    KissMsg.ShowError("KissMemoEditML", "PostFailedShowDialog", "Der Dialog wird nicht angezeigt, da die Daten nicht gespeichert werden konnten.");
                    return;
                }
            }

            // create dialog
            DlgTranslateMemoEdit dlg = new DlgTranslateMemoEdit(_currentTID, true);

            // show dialog
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                LookupTranslatedText();

                // check if data has changed
                if (dlg.DataHasChanged)
                {
                    // raise event that data has changed
                    OnDataHasChanged(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Eventhandler: A DataRow is being added/updated
        /// Updates the corresponding text in XLangText
        /// </summary>
        /// <param name="sender">event source</param>
        /// <param name="e">event parameters</param>
        private void DataSource_BeforePost(object sender, EventArgs e)
        {
            if (_currentTID == 0 && !DBUtil.IsEmpty(EditValue))
            {
                // if there was no text at the beginning (OnPositionChanged) we dont have a TID yet. now we get one
                _currentTID = GetCurrentTID();
            }

            if (_currentTID > 0)
            {
                DBUtil.ExecSQL(@"--SQLCHECK_IGNORE--
                                  DECLARE @Count int
                                  SELECT @Count = COUNT( * )
                                  FROM XLangText
                                  WHERE TID = {1} AND LanguageCode = {2}

                                  IF( @Count = 0 )
                                  BEGIN
                                    SET IDENTITY_INSERT XLangText ON
                                    INSERT INTO XLangText( TID, LanguageCode, [Text] )
                                    VALUES( {1}, {2}, {0} )
                                    SET IDENTITY_INSERT XLangText OFF
                                  END
                                  ELSE
                                  BEGIN
                                    UPDATE XLangText
                                    SET Text = {0}
                                    WHERE TID = {1} AND LanguageCode = {2}
                                  END", EditValue, _currentTID, _currentLanguageCode);

                if (DataSource != null && !DBUtil.IsEmpty(_dataMemberTID))
                {
                    DataSource[_dataMemberTID] = _currentTID;
                }
            }
        }

        /// <summary>
        /// Eventhandler: A row was selected
        /// Gets the existing TID or gets a new one
        /// Looks up the text for the current language in XLangText
        /// </summary>
        /// <param name="sender">event source</param>
        /// <param name="e">event parameters</param>
        private void DataSource_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                // set flag
                _isPositionChanging = true;

                // reset editvalue
                EditValue = null;

                _currentTID = GetCurrentTID();
                LookupTranslatedText();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(ex.Message);
            }
            finally
            {
                // reset flag
                _isPositionChanging = false;
            }
        }

        /// <summary>
        /// Eventhandler: Post on datasource completed
        /// Raise event DataHasChanged to notify any registered target
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void DataSource_PostCompleted(object sender, EventArgs e)
        {
            // raise event that data has changed
            OnDataHasChanged(this, EventArgs.Empty);
        }

        /// <summary>
        /// Eventhandler: The EditValue was changed
        /// Notify the DataSource
        /// </summary>
        /// <param name="sender">event source</param>
        /// <param name="e">event parameters</param>
        private void edtMemoEdit_EditValueChanged(object sender, EventArgs e)
        {
            // validate
            if (!_isPositionChanging && DataSource != null)
            {
                if (ApplyChangesToDefaultText && DataSource.DataTable.Columns.Contains(DataMemberDefaultText))
                {
                    // apply changed edit value
                    DataSource[DataMemberDefaultText] = EditValue;
                }
                else
                {
                    // set only row modified
                    DataSource.RowModified = true;
                }
            }
        }

        /// <summary>
        /// Gets the existing TID or tries to obtain a new one
        /// </summary>
        /// <returns>Valid TID or 0</returns>
        private int GetCurrentTID()
        {
            // update language code
            SetCurrentLanguageCode();

            if (DataSource == null || DBUtil.IsEmpty(_dataMemberTID))
            {
                return 0;
            }

            object tid = DataSource[_dataMemberTID];

            if (DBUtil.IsEmpty(tid) && CanChangeDataOnDataSource())
            {
                // No TID yet, get one
                try
                {
                    tid = DBUtil.ExecuteScalarSQL(@"DECLARE @result int
                                                     EXEC spXSetXLangText NULL, {0}, {1}, NULL, NULL, NULL, NULL, @result out
                                                     SELECT @result", 1, GetDefaultText());
                }
                catch
                {
                }

                if (DBUtil.IsEmpty(tid))
                {
                    // Still received no TID, probably because the EditValue is empty
                    tid = 0;
                }
                else
                {
                    // we received a new TID, mark the Row as changed
                    // DONT assign the TID to the row now, because this might cause a Post() on the SqlQuery!
                    DataSource.RowModified = true;
                }
            }

            return DBUtil.IsEmpty(tid) ? 0 : Convert.ToInt32(tid);
        }

        /// <summary>
        /// Get default text from datasource
        /// </summary>
        /// <returns>Valid default text or ""</returns>
        private string GetDefaultText()
        {
            if (DBUtil.IsEmpty(_dataMemberDefaultText) || DBUtil.IsEmpty(DataSource[_dataMemberDefaultText] as string))
            {
                return DBUtil.IsEmpty(EditValue) ? "" : EditValue as string;
            }

            return DataSource[_dataMemberDefaultText] as string;
        }

        /// <summary>
        /// Set EditValue from XLangText depending on current tid
        /// </summary>
        private void LookupTranslatedText()
        {
            if (_currentTID < 1)
            {
                // we do not have a valid tid --> reset editvalue
                EditValue = null;
            }
            else
            {
                //get new editvalue
                object newValue = DBUtil.ExecuteScalarSQL(@"SELECT Text
                                                             FROM XLangText
                                                             WHERE TID = {0} AND LanguageCode = {1}", _currentTID, _currentLanguageCode);
                if (DBUtil.IsEmpty(newValue))
                {
                    // no text found for current language, take default text (=leave the text fetched through DataMamber)
                    if (DataSource != null && !DBUtil.IsEmpty(_dataMemberDefaultText))
                    {
                        EditValue = DataSource[_dataMemberDefaultText];
                        DBUtil.ExecuteScalarSQL(@"--SQLCHECK_IGNORE--
                                                   DECLARE @Count int
                                                   SELECT @Count = count( * )
                                                   FROM XLangText
                                                   WHERE TID = {0} and LanguageCode = 1

                                                   IF( @Count = 0 )
                                                   BEGIN
                                                     SET IDENTITY_INSERT XLangText ON
                                                     INSERT INTO XLangText( TID, LanguageCode, Text )
                                                     VALUES ( {0}, {1}, {2} )
                                                     SET IDENTITY_INSERT XLangText OFF
                                                   END", _currentTID, 1, EditValue);
                    }
                }
                else if (EditValue != newValue)
                {
                    EditValue = newValue;
                }
            }
        }

        /// <summary>
        /// The event handling method <see cref="DataHasChanged"/>
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void OnDataHasChanged(object sender, EventArgs e)
        {
            // check if any registered target has to be notified
            if (DataHasChanged != null)
            {
                // fire event
                DataHasChanged(sender, e);
            }
        }

        /// <summary>
        /// Update var currentLanguageCode depending on settings
        /// </summary>
        private void SetCurrentLanguageCode()
        {
            if (ShowOnlyDefaultLanguage)
            {
                _currentLanguageCode = 1;
            }
            else
            {
                if (Session.User == null)
                {
                    _currentLanguageCode = 1;
                    return;
                }

                _currentLanguageCode = Session.User.LanguageCode;
            }
        }
    }
}