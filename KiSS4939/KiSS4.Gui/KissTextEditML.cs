using System;
using System.ComponentModel;
using System.Windows.Forms;

using Kiss.Interfaces.UI;
using KiSS4.DB;

namespace KiSS4.Gui
{
    /// <summary>
    /// Summary description for KissTextEditML.
    /// </summary>
    public class KissTextEditML : KissButtonEdit
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
        private int _currentTid;

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
        public KissTextEditML()
        {
            Properties.ButtonClick += Properties_ButtonClick;
            Properties.EditValueChanged += KissTextEditML_EditValueChanged;
            Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
        }

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
        /// Get current used tid for actual EditValue
        /// </summary>
        [Browsable(false)]
        [DefaultValue(-1)]
        [Description("Get current used tid for actual EditValue")]
        public int CurrentTID
        {
            get { return _currentTid; }
        }

        /// <summary>
        /// Gets or sets the name of the column in the DB table that contains the TID connected to the column specified in DataMember
        /// </summary>
        [Browsable(true)]
        [DefaultValue(null)]
        [Description("The column that contains the Text in the default language")]
        public string DataMemberDefaultText
        {
            get
            {
                return _dataMemberDefaultText;
            }
            set
            {
                _dataMemberDefaultText = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the column in the DB table that contains the TID connected to the column specified in DataMember
        /// </summary>
        [Browsable(true)]
        [DefaultValue(null)]
        [Description("The column that contains the TextID for the Text provided by DataMember")]
        public string DataMemberTID
        {
            get
            {
                return _dataMemberTID;
            }
            set
            {
                _dataMemberTID = value;
            }
        }

        /// <summary>
        /// Gets or sets the DataSource
        /// </summary>
        public new SqlQuery DataSource
        {
            get
            {
                return base.DataSource;
            }
            set
            {
                if (base.DataSource != value)
                {
                    if (base.DataSource != null)
                    {
                        base.DataSource.PositionChanged -= DataSource_PositionChanged;
                        base.DataSource.BeforePost -= DataSource_BeforePost;
                    }

                    if (value != null)
                    {
                        value.PositionChanged += DataSource_PositionChanged;
                        value.BeforePost += DataSource_BeforePost;
                    }

                    base.DataSource = value;
                }
            }
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
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            Properties.ButtonClick -= Properties_ButtonClick;
            base.Dispose(disposing);
        }

        /// <summary>
        /// Change "..."-button to multilanguage-button
        /// </summary>
        protected override void OnLoaded()
        {
            base.OnLoaded();
            if (Properties.Buttons[0] != null)
            {
                System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(KissTextEditML));

                Properties.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
                Properties.Buttons[0].Image = ((System.Drawing.Bitmap)(resources.GetObject("Button0.Image")));
                Properties.Buttons[0].Width = 8;
            }
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
        /// Eventhandler: A DataRow is being added/updated
        /// Updates the corresponding text in XLangText
        /// </summary>
        /// <param name="sender">event source</param>
        /// <param name="e">event parameters</param>
        private void DataSource_BeforePost(object sender, EventArgs e)
        {
            if (_currentTid == 0 && !DBUtil.IsEmpty(EditValue))
            {
                // if there was no text at the beginning (OnPositionChanged) we dont have a TID yet. now we get one
                _currentTid = GetCurrentTID();
            }

            if (_currentTid > 0)
            {
                DBUtil.ExecSQL(@"
                    --SQLCHECK_IGNORE--
                    DECLARE @Count INT;

                    SELECT @Count = COUNT(1)
                    FROM dbo.XLangText WITH (READUNCOMMITTED)
                    WHERE TID = {1}
                      AND LanguageCode = {2};

                    IF (@Count = 0)
                    BEGIN
                      SET IDENTITY_INSERT dbo.XLangText ON;

                      INSERT INTO dbo.XLangText (TID, LanguageCode, [Text])
                      VALUES ({1}, {2}, {0});

                      SET IDENTITY_INSERT XLangText OFF;
                    END
                    ELSE
                    BEGIN
                      UPDATE dbo.XLangText
                      SET Text = {0}
                      WHERE TID = {1}
                        AND LanguageCode = {2};
                    END;
                    ", EditValue, _currentTid, _currentLanguageCode);

                if (base.DataSource != null && !DBUtil.IsEmpty(_dataMemberTID))
                {
                    base.DataSource[_dataMemberTID] = _currentTid;
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

                _currentTid = GetCurrentTID();
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

            if (DBUtil.IsEmpty(tid) && CanChangeDataOnDataSource()) // apply new tid only if source can be changed (update or insert only)
            {
                // No TID yet, get one
                try
                {
                    tid = DBUtil.ExecuteScalarSQL(@"
                        DECLARE @ResultTID INT;
                        EXEC dbo.spXSetXLangText NULL, {0}, {1}, NULL, NULL, NULL, NULL, @ResultTID OUT;
                        SELECT @ResultTID;", 1, GetDefaultText());
                }
                catch { }

                if (DBUtil.IsEmpty(tid))
                {
                    // Still received no TID, probably because the EditValue is empty
                    tid = 0;
                }
                else
                {
                    // we received a new TID, mark the Row as changed
                    // DONT assign the TID to the row now, because this might cause a Post() on the SqlQuery!
                    base.DataSource.RowModified = true;
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
        /// Eventhandler: The EditValue was changed
        /// Notify the DataSource
        /// </summary>
        /// <param name="sender">event source</param>
        /// <param name="e">event parameters</param>
        private void KissTextEditML_EditValueChanged(object sender, EventArgs e)
        {
            // validate
            if (!_isPositionChanging && DataSource != null)
            {
                if (ApplyChangesToDefaultText && DataSource.DataTable.Columns.Contains(DataMemberDefaultText))
                {
                    // apply changed edit value
                    base.DataSource[DataMemberDefaultText] = EditValue;
                }
                else
                {
                    // set only row modified
                    base.DataSource.RowModified = true;
                }
            }
        }

        /// <summary>
        /// Set EditValue from XLangText depending on current tid
        /// </summary>
        private void LookupTranslatedText()
        {
            if (_currentTid < 1)
            {
                if (DataSource != null &&
                    !DBUtil.IsEmpty(_dataMemberDefaultText) &&
                    !CanChangeDataOnDataSource())
                {
                    // we are not allowed to change text and do not have a TID > apply default value
                    EditValue = DataSource[_dataMemberDefaultText];
                }
                else
                {
                    // we do not have a valid tid and no default text --> reset editvalue (update is allowed)
                    EditValue = null;
                }
            }
            else
            {
                //get new editvalue
                object newValue = DBUtil.ExecuteScalarSQL(@"
                    SELECT Text
                    FROM dbo.XLangText WITH (READUNCOMMITTED)
                    WHERE TID = {0}
                      AND LanguageCode = {1}", _currentTid, _currentLanguageCode);

                if (DBUtil.IsEmpty(newValue))
                {
                    // no text found for current language, take default text (=leave the text fetched through DataMamber)
                    if (DataSource != null && !DBUtil.IsEmpty(_dataMemberDefaultText))
                    {
                        EditValue = DataSource[_dataMemberDefaultText];

                        DBUtil.ExecuteScalarSQL(@"
                            --SQLCHECK_IGNORE--
                            DECLARE @Count INT;

                            SELECT @Count = COUNT(1)
                            FROM dbo.XLangText WITH (READUNCOMMITTED)
                            WHERE TID = {0}
                              AND LanguageCode = 1;

                            IF (@Count = 0)
                            BEGIN
                              SET IDENTITY_INSERT XLangText ON;

                              INSERT INTO dbo.XLangText (TID, LanguageCode, Text)
                              VALUES ({0}, {1}, {2});

                              SET IDENTITY_INSERT XLangText OFF;
                            END;", _currentTid, 1, EditValue);
                    }
                }
                else if (EditValue != newValue)
                {
                    EditValue = newValue;
                }
            }
        }

        /// <summary>
        /// Eventhandler: The user wants to edit the text in other languages
        /// </summary>
        /// <param name="sender">event source</param>
        /// <param name="e">event parameters</param>
        private void Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            // check if is readonly
            if (EditMode == EditModeType.ReadOnly || !CanChangeDataOnDataSource())
            {
                // don't show dialog if readonly
                return;
            }

            // validate necessary TID before showing dialog
            if (_currentTid < 1)
            {
                _currentTid = GetCurrentTID();
            }

            if (_currentTid < 1)
            {
                if (GetDefaultText() == "")
                {
                    KissMsg.ShowError("KissTextEditML", "EmptyValueInBtnShowML", "Das Übersetzungsfenster kann nicht angezeigt werden, da kein Standardwert angegeben wurde.", "Current default value is empty (base.DataSource[ dataMemberDefaultText ]).");
                }
                else
                {
                    KissMsg.ShowError("KissTextEditML", "InvalidValueInBtnShowML", "Ungültiger Aufruf, Übersetzungsfenster kann nicht angezeigt werden.", string.Format("Current TID is invalid: TID='{0}'.", _currentTid.ToString()));
                }

                return;
            }

            if (DataSource.RowModified)
            {
                // row is modified, save data in order to ensure having changend content in dialog
                if (!DataSource.Post())
                {
                    KissMsg.ShowError("KissTextEditML", "PostFailedShowDialog", "Der Dialog wird nicht angezeigt, da die Daten nicht gespeichert werden konnten.");
                    return;
                }
            }

            if (new DlgTranslateMemoEdit(_currentTid, false).ShowDialog() == DialogResult.OK)
            {
                LookupTranslatedText();
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
                _currentLanguageCode = Session.User.LanguageCode;
            }
        }
    }
}