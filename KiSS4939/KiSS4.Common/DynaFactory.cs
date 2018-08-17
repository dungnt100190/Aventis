using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

using SharpLibrary.WinControls;

using Kiss.Infrastructure.Utils;
using Kiss.Interfaces.DocumentHandling;
using Kiss.Interfaces.UI;

using KiSS4.DB;
using KiSS4.Dokument;
using KiSS4.Gui;

using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;

namespace KiSS4.Common
{
    /// <summary>
    /// Summary description for DynaFactory.
    /// </summary>
    public class DynaFactory
    {
        #region Fields

        #region Private Fields

        private IKissContext _cp;
        private Control _ctlHost;
        private KissGrid _grdControl;
        private KissTabControlEx _tabControl;
        private string _maskName;

        #endregion

        #endregion

        #region Properties

        /// <summary>
        /// Gets the XML schema representing the subset of DB table DynaField that is used for
        /// report parameters.
        /// </summary>
        /// <returns></returns>
        public static Stream DynaFieldSchema
        {
            get
            {
                return typeof(DynaFactory).Assembly.GetManifestResourceStream("KiSS4.Common.DynaField.xml");

                /*
                SqlDataAdapter da = new SqlDataAdapter(@"
                    SELECT FieldName, FieldCode, DisplayText, TabPosition, X, Y, Width,
                           Height, Length, LOVName, DefaultValue, Mandatory, TabName, AppCode, SQL
                    FROM  DynaField
                    WHERE 1 = 0"
                    , Session.Connection);

                DataSet ds = new DataSet();
                da.FillSchema(ds, System.Data.SchemaType.Mapped); // Just get metadata
                ds.WriteXmlSchema(@"C:\KiSS4.Common.DynaField.xml");
                */
            }
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// If the control is an input field return its FieldName, otherwise null. The FieldName
        /// is of interest because in context-senstive situations it can be used to ask the
        /// IKissContextPrint for the value to be used as a report parameter.
        /// </summary>
        /// <param name="ctl">Control for which we want to set a default value</param>
        /// <returns></returns>
        public static string GetFieldNameOfInputFieldControl(Control ctl)
        {
            // Only controls which have Tag set need to be considered
            if (null == ctl.Tag)
            {
                return null;
            }

            // Controls that cannot read input values are ignored
            if (ctl is Label)
            {
                return null;
            }

            DataRow row = (DataRow)ctl.Tag;
            return (string)row["FieldName"];
        }

        /// <summary>
        /// Determines what type of control "c" is, extracts the data from it in an appropriate way
        /// for that type of control and returns it as an object. If the input is "empty" (nothing
        /// entered in this control) then the returned object will hold DBNull.Value.
        /// 
        /// Throws ApplicationException if invalid data was entered or if a mandatory input field
        /// was left empty. The exception contains the message to display to the user.
        /// </summary>
        /// <param name="ctl">Control from which input value will be read</param>
        /// <returns>object</returns>
        public static object GetInputValueFromControl(Control ctl)
        {
            // Only controls which have Tag set need to be considered
            if (null == ctl.Tag)
            {
                return null;
            }

            // Controls that cannot provide an input value must be ignored
            if (ctl is Label)
            {
                return null;
            }

            DataRow row = (DataRow)ctl.Tag;

            object p = DBNull.Value;

            // For every control that has no input value specified we set the SQL parameter to DBNull.Value.
            // This opens all the possibilities for formulating tolerant SQL queries like
            //   SELECT * FROM t WHERE f LIKE '%' + @parameter + '%' OR X IS NULL
            // For actual examples with ActiveReport syntax see header of FrmReportManager.cs
            if (ctl is KissCalcEdit)
            {
                KissCalcEdit kce = (KissCalcEdit)ctl;

                if (!kce.DoValidate())
                {
                    throw new ApplicationException("Ungültige Eingabe für " + row["DisplayText"]);
                }

                p = kce.EditValue;
            }
            else if (ctl is KissDateEdit)
            {
                KissDateEdit kde = (KissDateEdit)ctl;

                if (!DBUtil.IsEmpty(kde.EditValue))
                {
                    // TODO: '== DateTime.MinValue' means nothing entered, workaround because DoValidate does not work
                    if (kde.DateTime == DateTime.MinValue || !kde.DoValidate())
                    {
                        throw new ApplicationException("Ungültiges Datum für " + row["DisplayText"]);
                    }

                    // System.Data.SqlTypes.SqlDateTime can only hold a subset of System.DateTime
                    try
                    {
                        new SqlDateTime(kde.DateTime);
                        p = kde.DateTime;
                    }
                    catch (Exception)
                    {
                        throw new ApplicationException("Datum ausserhalb gültigem Bereich, " + row["DisplayText"]);
                    }
                }
            }
            else if (ctl is CheckBox)
            {
                CheckBox cb = (CheckBox)ctl;
                p = cb.Checked ? 1 : 0;
            }
            else if (ctl is KissCheckEdit)
            { // Unused, DynaFactory makes only regular CheckBoxes (March 2004)
                KissCheckEdit kce = (KissCheckEdit)ctl;
                p = kce.Checked;
            }
            else if (ctl is KissLookUpEdit)
            {
                KissLookUpEdit klue = (KissLookUpEdit)ctl;
                p = klue.EditValue;
            }
            else if (ctl is KissCheckedLookupEdit)
            {
                KissCheckedLookupEdit kcle = (KissCheckedLookupEdit)ctl;
                p = kcle.EditValue;
            }
            else if (ctl is KissButtonEdit)
            {
                KissButtonEdit kbe = (KissButtonEdit)ctl;

                if (!DBUtil.IsEmpty(kbe.LookupID))
                {
                    p = kbe.LookupID;
                }
                else
                {
                    p = kbe.EditValue;
                }
            }
            else if (ctl is KissPickList)
            {
                KissPickList kpl = (KissPickList)ctl;
                p = kpl.SelectedIds;

                if (string.IsNullOrEmpty((string)p) && (bool)row["Mandatory"])
                {
                    //wenn kein Element ausgewählt wurde, das Feld aber als Mandatory definiert ist: alle Elemente als ausgewählt betrachten
                    kpl.SelectAll();
                    p = kpl.SelectedIds;
                }
            }
            else
            {
                if (ctl.Text.Length > 0)
                {
                    p = ctl.Text;
                }
            }

            // Throw exception if mandatory field has no valid input
            bool mandatory = false;

            try
            {
                mandatory = (bool)row["Mandatory"];
            }
            catch { }

            if (mandatory && DBUtil.IsEmpty(p))
            {
                throw new ApplicationException("Eingabe obligatorisch für '" + row["DisplayText"] + "'");
            }

            return p;
        }

        /// <summary>
        /// Sets the specified control to the given value.
        /// </summary>
        /// <param name="ctl">Input control for which we want to set a value.</param>
        /// <param name="value">New value to be set in input control (as if the user had typed it).</param>
        public static void SetValueInputFieldControl(Control ctl, object value)
        {
            if (ctl is IKissBindableEdit)
            {
                IKissBindableEdit edt = (IKissBindableEdit)ctl;

                //reset Value to DBNull (data binding doesn't do that if query has no rows)
                try
                {
                    PropertyInfo prop = edt.GetType().GetProperty(edt.GetBindablePropertyName());
                    prop.SetValue(edt, value, null);
                }
                catch (Exception ex)
                {
                    KissMsg.ShowError("DynaFactory", "ErrorControlNull", "Error setting bound control to null.", "Control: " + ctl.Name + "\r\nProperty: " + edt.GetBindablePropertyName(), ex);
                }
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Builds the mask.
        /// </summary>
        /// <param name="tblFieldDef">The TBL field def.</param>
        /// <param name="host">The host.</param>
        /// <param name="titleName">Name of the title.</param>
        /// <param name="titleImage">The title image.</param>
        public void BuildMask(DataTable tblFieldDef, Control host, string titleName, Image titleImage)
        {
            KissGrid grd;
            KissTabControlEx tab;

            BuildMask(tblFieldDef, host, titleName, titleImage, 0, out grd, null, out tab);
        }

        /// <summary>
        /// Builds the mask.
        /// </summary>
        /// <param name="tblFieldDef">The TBL field def.</param>
        /// <param name="host">The host.</param>
        /// <param name="titleName">Name of the title.</param>
        /// <param name="titleImage">The title image.</param>
        /// <param name="gridHeight">Height of the grid.</param>
        /// <param name="grd">The GRD.</param>
        /// <param name="tabNames">The tab names.</param>
        /// <param name="tab">The tab.</param>
        public void BuildMask(DataTable tblFieldDef, Control host, string titleName, Image titleImage,
            int gridHeight, out KissGrid grd, string tabNames, out KissTabControlEx tab)
        {
            _ctlHost = host;
            _ctlHost.Controls.Clear();
            _ctlHost.SuspendLayout();

            if (_ctlHost is CtlDynaMask)
            {
                _maskName = ((CtlDynaMask)_ctlHost).MaskName;
            }

            DisplayTitle(titleName, titleImage);

            DisplayGridControl(gridHeight, tblFieldDef);

            DisplayTabControl(tabNames, gridHeight);

            foreach (DataRow row in tblFieldDef.Rows)
                CreateDataField(row);

            _ctlHost.ResumeLayout(false);

            tab = _tabControl;
            grd = _grdControl;

            // Translate title
            if (_maskName != null && _tabControl != null)
            {
                for (int i = 0; i < _tabControl.TabPages.Count; i++)
                {
                    _tabControl.TabPages[i].Title = KissMsg.GetMLMessage(_maskName, "tabPage" + i.ToString(), _tabControl.TabPages[i].Title);
                }
            }
        }

        /// <summary>
        /// Builds the mask.
        /// </summary>
        /// <param name="cp">The KiSSContext</param>
        /// <param name="tblFieldDef">The TBL field def.</param>
        /// <param name="host">The host.</param>
        /// <param name="titleName">Name of the title.</param>
        /// <param name="titleImage">The title image.</param>
        public void BuildMask(IKissContext cp, DataTable tblFieldDef, Control host, string titleName, Image titleImage)
        {
            _cp = cp;

            BuildMask(tblFieldDef, host, titleName, titleImage);
        }

        /// <summary>
        /// Creates the data field.
        /// </summary>
        /// <param name="row">The row.</param>
        public void CreateDataField(DataRow row)
        {
            if (row["FieldCode"] == DBNull.Value) return;

            int x = (row["X"] == DBNull.Value) ? 5 : Math.Max((int)row["X"], 5);
            int y = (row["Y"] == DBNull.Value) ? 5 : Math.Max((int)row["Y"], 5);
            int width = (row["Width"] == DBNull.Value) ? 15 : Math.Max((int)row["Width"], 15);
            int height = (row["Height"] == DBNull.Value) ? 20 : Math.Max((int)row["Height"], 20);

            // Feld ist sichtbar wenn es nicht explizit auf false gesetzt ist
            bool visible;
            var hasValue = row.TryGetValue("Visible", out visible);

            if (!hasValue)
            {
                visible = true;
            }

            switch ((int)row["FieldCode"])
            {
                case 1:
                    //Label
                    KissLabel label = new KissLabel();
                    int widthSafety = 2;
                    bool autosize = true;

                    if (Utils.AppCodeContainsToken(row["AppCode"], "fett"))
                    {
                        label.LabelStyle = LabelStyleType.Custom;
                        label.Font = new Font("Arial", 11F, FontStyle.Bold, GraphicsUnit.Pixel);
                        widthSafety = 5;
                    }

                    if (Utils.AppCodeContainsToken(row["AppCode"], "mehrzeilig"))
                    {
                        label.LabelStyle = LabelStyleType.Custom;
                        label.Font = new Font(GuiConfig.LabelFontName, GuiConfig.LabelFontSize,
                            GuiConfig.LabelFontStyle, GuiConfig.LabelFontGraphicUnit);
                        label.Size = new Size(width, height);
                        autosize = false;
                    }

                    if (Utils.AppCodeContainsToken(row["AppCode"], "Titel"))
                    {
                        label.LabelStyle = LabelStyleType.TitleLabel;
                    }

                    if (visible) label.Location = new Point(x, y);
                    label.Visible = visible;

                    label.Text = row.Table.Columns.Contains("MLText") ? row["MLText"].ToString() : row["DisplayText"].ToString();
                    if (label.Text == "") label.Text = "???";

                    //simulate AutoSize
                    if (autosize)
                        label.Width = (int)_ctlHost.CreateGraphics().MeasureString(label.Text, label.Font).Width + widthSafety;

                    AddControl(label, row);
                    break;

                case 2:
                    //textEdit
                    KissTextEdit textEdit = new KissTextEdit();
                    ((System.ComponentModel.ISupportInitialize)(textEdit.Properties)).BeginInit();

                    if (visible) textEdit.Location = new Point(x, y);
                    textEdit.Visible = visible;

                    textEdit.Size = new Size(width, 26);
                    ((System.ComponentModel.ISupportInitialize)(textEdit.Properties)).EndInit();
                    textEdit.Loaded();
                    textEdit.Text = row["DefaultValue"] as string;

                    AddControl(textEdit, row);
                    break;

                case 3:
                    //memoEdit
                    KissMemoEdit memoEdit = new KissMemoEdit();
                    ((System.ComponentModel.ISupportInitialize)(memoEdit.Properties)).BeginInit();

                    if (visible) memoEdit.Location = new Point(x, y);
                    memoEdit.Visible = visible;

                    memoEdit.Size = new Size(width, height);
                    ((System.ComponentModel.ISupportInitialize)(memoEdit.Properties)).EndInit();
                    memoEdit.Loaded();

                    AddControl(memoEdit, row);
                    break;

                case 4:
                    //CalcEdit (Zahl)
                    KissCalcEdit calcEdit = new KissCalcEdit();
                    ((System.ComponentModel.ISupportInitialize)(calcEdit.Properties)).BeginInit();

                    if (visible) calcEdit.Location = new Point(x, y);
                    calcEdit.Visible = visible;

                    calcEdit.Size = new Size(width, 26);

                    if (Utils.AppCodeContainsToken(row["AppCode"], "N2"))
                    {
                        calcEdit.Properties.DisplayFormat.FormatString = "N2";
                        calcEdit.Properties.EditFormat.FormatString = "N2";
                    }
                    else
                    {
                        calcEdit.Properties.DisplayFormat.FormatString = "N0";
                        calcEdit.Properties.EditFormat.FormatString = "N0";
                    }
                    calcEdit.Properties.DisplayFormat.FormatType = FormatType.Numeric;
                    calcEdit.Properties.EditFormat.FormatType = FormatType.Numeric;

                    ((System.ComponentModel.ISupportInitialize)(calcEdit.Properties)).EndInit();
                    calcEdit.Loaded();
                    string defaultValue = row["DefaultValue"] as string;

                    if (!DBUtil.IsEmpty(defaultValue))
                    {
                        try
                        {
                            float f = float.Parse(defaultValue);
                            calcEdit.Text = f.ToString();
                        }
                        catch (Exception ex)
                        {
                            KissMsg.ShowError("DynaFactory", "DefaultWertUngueltig", "Keine gültige Zahl als Default-Wert angegeben.", "Parse-Error", ex);
                        }
                    }

                    AddControl(calcEdit, row);
                    break;

                case 5:
                    //dateEdit
                    KissDateEdit dateEdit = new KissDateEdit();
                    ((System.ComponentModel.ISupportInitialize)dateEdit.Properties).BeginInit();
                    dateEdit.DateTime = new DateTime(0);

                    if (visible) dateEdit.Location = new Point(x, y);
                    dateEdit.Visible = visible;

                    dateEdit.Width = Math.Max(96, width);
                    dateEdit.EditValue = null;
                    ((System.ComponentModel.ISupportInitialize)(dateEdit.Properties)).EndInit();

                    dateEdit.Properties.Buttons.AddRange(new[]
                    {
                        new EditorButton(ButtonPredefines.Down,
                            "",
                            -1,
                            true,
                            true,
                            false,
                            HorzAlignment.Center,
                            null,
                            new ViewStyle("EditorButtonStyle",
                            null,
                            new Font("Microsoft Sans Serif", 8F),
                            "",
                            StyleOptions.StyleEnabled
                            | StyleOptions.UseBackColor
                            | StyleOptions.UseDrawEndEllipsis
                            | StyleOptions.UseDrawFocusRect
                            | StyleOptions.UseFont
                            | StyleOptions.UseForeColor
                            | StyleOptions.UseHorzAlignment
                            | StyleOptions.UseImage
                            | StyleOptions.UseWordWrap
                            | StyleOptions.UseVertAlignment,
                            true,
                            false,
                            false,
                            HorzAlignment.Default,
                            VertAlignment.Center,
                            null,
                            Color.Tan,
                            SystemColors.ControlText))
                    });

                    dateEdit.Properties.ButtonsStyle = BorderStyles.UltraFlat;
                    dateEdit.Loaded();
                    defaultValue = row["DefaultValue"] as string;

                    if (!DBUtil.IsEmpty(defaultValue))
                    {
                        if (defaultValue.ToLower().Equals("today") || defaultValue.ToLower().Equals("getdate()"))
                        {
                            dateEdit.Text = DateTime.Today.ToString();
                        }
                        else if (defaultValue.ToLower().Equals("firstdayofyear"))
                        {
                            dateEdit.Text = Convert.ToDateTime("01.01." + DateTime.Today.Year.ToString()).ToString();
                        }
                        else if (defaultValue.ToLower().Equals("firstdayweek"))
                        {
                            dateEdit.Text =
                                DBUtil.ExecuteScalarSQL(@"select convert(varchar, dateadd(dd, (datepart(dw, GetDate()) * -1) + 2, GetDate()), 104)").
                                    ToString();
                        }
                        else if (defaultValue.ToLower().Equals("lastdayweek"))
                        {
                            dateEdit.Text =
                                DBUtil.ExecuteScalarSQL(@"select convert(varchar, dateadd(dd, (datepart(dw, GetDate()) * -1) + 6, GetDate()), 104)").
                                    ToString();
                        }
                    }

                    AddControl(dateEdit, row);
                    break;

                case 6:
                    //timeEdit
                    KissTimeEdit timeEdit = new KissTimeEdit();
                    ((System.ComponentModel.ISupportInitialize)timeEdit.Properties).BeginInit();

                    if (visible) timeEdit.Location = new Point(x, y);
                    timeEdit.Visible = visible;

                    timeEdit.Width = Math.Max(55, width);
                    timeEdit.EditValue = null;
                    ((System.ComponentModel.ISupportInitialize)(timeEdit.Properties)).EndInit();
                    timeEdit.Loaded();

                    AddControl(timeEdit, row);
                    break;

                case 7:
                    //Checkbox
                    KissCheckEdit checkBox = new KissCheckEdit();

                    if (visible) checkBox.Location = new Point(x, y);
                    checkBox.Visible = visible;

                    checkBox.Size = new Size(width, height);
                    checkBox.RightToLeft = RightToLeft.No;
                    checkBox.Text = row.Table.Columns.Contains("MLText") ? row["MLText"].ToString() : row["DisplayText"].ToString();
                    checkBox.Loaded();
                    defaultValue = row["DefaultValue"] as string;

                    if (!DBUtil.IsEmpty(defaultValue) && (defaultValue == "1" || defaultValue.ToLower() == "true"))
                    {
                        checkBox.EditValue = true;
                    }

                    AddControl(checkBox, row);
                    break;

                case 8:
                    //Lookup
                    KissLookUpEdit lookupEdit = new KissLookUpEdit();
                    ((System.ComponentModel.ISupportInitialize)(lookupEdit.Properties)).BeginInit();

                    if (visible) lookupEdit.Location = new Point(x, y);
                    lookupEdit.Visible = visible;

                    lookupEdit.Width = width;
                    ((System.ComponentModel.ISupportInitialize)(lookupEdit.Properties)).EndInit();
                    lookupEdit.Properties.Buttons.AddRange(new[]
                    {
                        new EditorButton(ButtonPredefines.Combo,
                            "",
                            -1,
                            true,
                            true,
                            false,
                            HorzAlignment.Center,
                            null,
                            new ViewStyle("EditorButtonStyle",
                            null,
                            new Font("Microsoft Sans Serif", 8F),
                            "",
                            StyleOptions.StyleEnabled
                            | StyleOptions.UseBackColor
                            | StyleOptions.UseDrawEndEllipsis
                            | StyleOptions.UseDrawFocusRect
                            | StyleOptions.UseFont
                            | StyleOptions.UseForeColor
                            | StyleOptions.UseHorzAlignment
                            | StyleOptions.UseImage
                            | StyleOptions.UseWordWrap
                            | StyleOptions.UseVertAlignment,
                            true,
                            false,
                            false,
                            HorzAlignment.Default,
                            VertAlignment.Center,
                            null,
                            Color.Tan,
                            SystemColors.ControlText))
                    });

                    lookupEdit.Properties.Columns.AddRange(new[]
                    {
                        new LookUpColumnInfo("Text",
                            "",
                            lookupEdit.Width,
                            FormatType.None,
                            "",
                            true,
                            HorzAlignment.Default)
                    });

                    lookupEdit.Properties.PopupWidth = lookupEdit.Width;
                    lookupEdit.Properties.DisplayMember = "Text";
                    lookupEdit.Properties.NullText = "";
                    lookupEdit.Properties.PopupCellStyle = new ViewStyle("PopupCell",
                        null,
                        new Font(GuiConfig.EditFontName,
                            GuiConfig.EditFontSize,
                            GuiConfig.EditFontStyle,
                            GuiConfig.EditFontGraphicUnit),
                        "",
                        StyleOptions.StyleEnabled | StyleOptions.UseBackColor
                        | StyleOptions.UseDrawEndEllipsis
                        | StyleOptions.UseDrawFocusRect
                        | StyleOptions.UseFont
                        | StyleOptions.UseForeColor
                        | StyleOptions.UseHorzAlignment
                        | StyleOptions.UseImage
                        | StyleOptions.UseWordWrap
                        | StyleOptions.UseVertAlignment,
                        true,
                        false,
                        false,
                        HorzAlignment.Default,
                        VertAlignment.Center,
                        null,
                        SystemColors.Window,
                        SystemColors.WindowText);

                    lookupEdit.Properties.DisplayMember = "Text";
                    lookupEdit.Properties.NullText = " ";
                    lookupEdit.Properties.SearchMode = SearchMode.AutoComplete;
                    lookupEdit.Properties.ShowFooter = false;
                    lookupEdit.Properties.ShowHeader = false;
                    lookupEdit.Properties.ValueMember = "Code";

                    if (row["LOVName"].ToString() != "")
                    {
                        lookupEdit.LoadQuery(DBUtil.GetLOVQuery((string)row["LOVName"], true));
                    }
                    else if (row["SQL"].ToString() != "")
                    {
                        string sql = ReplaceParameters("SQL", row);
                        SqlQuery qry = DBUtil.OpenSQL(sql);
                        DataRow newRow = qry.DataTable.NewRow();
                        newRow["Text"] = "";
                        qry.DataTable.Rows.InsertAt(newRow, 0);
                        newRow.AcceptChanges();

                        lookupEdit.LoadQuery(qry);
                    }

                    //					if (!DBUtil.IsEmpty(row["DefaultValue"]))
                    defaultValue = row["DefaultValue"] as string;
                    if (!DBUtil.IsEmpty(defaultValue))
                    {
                        try
                        {
                            if (defaultValue.ToLower().Equals("actmonth"))
                                lookupEdit.EditValue = DateTime.Today.Month;
                            else
                            {
                                lookupEdit.EditValue = int.Parse((string)row["DefaultValue"]);
                            }
                        }
                        catch (Exception)
                        {
                            // Intended: Silently ignore DefaultValue which is not a valid int
                        }
                    }

                    lookupEdit.Loaded();

                    AddControl(lookupEdit, row);
                    break;

                case 9:
                    //Mehrfachauswahl
                    KissCheckedLookupEdit checkedLookupEdit = new KissCheckedLookupEdit();
                    ((System.ComponentModel.ISupportInitialize)checkedLookupEdit).BeginInit();

                    if (visible) checkedLookupEdit.Location = new Point(x, y);
                    checkedLookupEdit.Visible = visible;

                    checkedLookupEdit.Size = new Size(width, height);
                    ((System.ComponentModel.ISupportInitialize)checkedLookupEdit).EndInit();
                    checkedLookupEdit.LOVName = row["LOVName"].ToString();
                    checkedLookupEdit.Loaded();
                    AddControl(checkedLookupEdit, row);
                    break;

                case 12:
                    //Dokument
                    XDokument xDocument = new XDokument();
                    ((System.ComponentModel.ISupportInitialize)(xDocument.Properties)).BeginInit();

                    if (visible) xDocument.Location = new Point(x, y);
                    xDocument.Visible = visible;

                    xDocument.Size = new Size(width, height);
                    xDocument.BackColor = Color.FromArgb(247, 239, 231);
                    xDocument.Properties.BorderStyle = BorderStyles.HotFlat;
                    xDocument.Properties.ButtonsStyle = BorderStyles.UltraFlat;
                    xDocument.Properties.Style = new ViewStyle("ControlStyle", null, new Font("Arial", 13F, FontStyle.Bold, GraphicsUnit.Pixel), "", StyleOptions.StyleEnabled, true, false, false, HorzAlignment.Default, VertAlignment.Center, null, Color.AliceBlue, SystemColors.WindowText);
                    xDocument.Properties.StyleBorder = new ViewStyle("ControlStyleBorder",
                        null,
                        new Font("Microsoft Sans Serif", 8F),
                        "",
                        StyleOptions.StyleEnabled | StyleOptions.UseBackColor
                        | StyleOptions.UseDrawEndEllipsis
                        | StyleOptions.UseDrawFocusRect
                        | StyleOptions.UseFont
                        | StyleOptions.UseForeColor
                        | StyleOptions.UseHorzAlignment
                        | StyleOptions.UseImage
                        | StyleOptions.UseWordWrap
                        | StyleOptions.UseVertAlignment,
                        false,
                        false,
                        false,
                        HorzAlignment.Default,
                        VertAlignment.Center,
                        null,
                        Color.Linen,
                        SystemColors.Control);
                    ((System.ComponentModel.ISupportInitialize)(xDocument.Properties)).EndInit();

                    if (!DBUtil.IsEmpty(row["DefaultValue"]))
                        xDocument.Context = row["DefaultValue"].ToString();

                    xDocument.DokTypCode = DokTyp.Dokument;

                    xDocument.Loaded();

                    AddControl(xDocument, row);

                    break;

                case 13:
                    //KissDocumentButton
                    var kissDocumentButton = new KissDocumentButton();
                    kissDocumentButton.Text = row["DisplayText"].ToString();

                    if (visible) kissDocumentButton.Location = new Point(x, y);
                    kissDocumentButton.Visible = visible;

                    kissDocumentButton.Size = new Size(width, height);

                    if (!DBUtil.IsEmpty(row["DefaultValue"]))
                    {
                        kissDocumentButton.Context = row["DefaultValue"].ToString();
                    }

                    AddControl(kissDocumentButton, row);

                    break;

                case 14:
                    //Button Edit (Auswahl mit Dialog)
                    KissButtonEdit buttonEdit = new KissButtonEdit();
                    ((System.ComponentModel.ISupportInitialize)(buttonEdit.Properties)).BeginInit();

                    if (visible) buttonEdit.Location = new Point(x, y);
                    buttonEdit.Visible = visible;

                    buttonEdit.Width = width;
                    buttonEdit.LookupSQL = ReplaceParameters("SQL", row);
                    ((System.ComponentModel.ISupportInitialize)(buttonEdit.Properties)).EndInit();

                    buttonEdit.Properties.Buttons.AddRange(new[]
                    {
                        new EditorButton(ButtonPredefines.Ellipsis,
                            "",
                            -1,
                            true,
                            true,
                            false,
                            HorzAlignment.Center,
                            null,
                            new ViewStyle("EditorButtonStyle",
                            null,
                            new Font("Microsoft Sans Serif", 8F),
                            "",
                            StyleOptions.StyleEnabled | StyleOptions.UseBackColor
                            | StyleOptions.UseDrawEndEllipsis
                            | StyleOptions.UseDrawFocusRect
                            | StyleOptions.UseFont
                            | StyleOptions.UseForeColor
                            | StyleOptions.UseHorzAlignment
                            | StyleOptions.UseImage
                            | StyleOptions.UseWordWrap
                            | StyleOptions.UseVertAlignment,
                            true,
                            false,
                            false,
                            HorzAlignment.Default,
                            VertAlignment.Center,
                            null,
                            Color.Bisque,
                            SystemColors.ControlText))
                    });
                    buttonEdit.Properties.ButtonsStyle = BorderStyles.UltraFlat;

                    buttonEdit.Properties.Style = new ViewStyle("ControlStyle",
                        "BaseEdit",
                        new Font("Arial", 13F, FontStyle.Bold, GraphicsUnit.Pixel),
                        "",
                        StyleOptions.StyleEnabled
                        | StyleOptions.UseBackColor
                        | StyleOptions.UseDrawEndEllipsis
                        | StyleOptions.UseDrawFocusRect
                        | StyleOptions.UseFont
                        | StyleOptions.UseForeColor
                        | StyleOptions.UseHorzAlignment
                        | StyleOptions.UseImage
                        | StyleOptions.UseWordWrap
                        | StyleOptions.UseVertAlignment,
                        true,
                        false,
                        false,
                        HorzAlignment.Default,
                        VertAlignment.Default,
                        null,
                        Color.AliceBlue,
                        Color.Black);
                    buttonEdit.Properties.StyleBorder = new ViewStyle("ControlStyleBorder",
                        null,
                        new Font("Microsoft Sans Serif", 8F),
                        "",
                        StyleOptions.StyleEnabled
                        | StyleOptions.UseBackColor
                        | StyleOptions.UseDrawEndEllipsis
                        | StyleOptions.UseDrawFocusRect
                        | StyleOptions.UseFont
                        | StyleOptions.UseForeColor
                        | StyleOptions.UseHorzAlignment
                        | StyleOptions.UseImage
                        | StyleOptions.UseWordWrap
                        | StyleOptions.UseVertAlignment,
                        false,
                        false,
                        false,
                        HorzAlignment.Default,
                        VertAlignment.Center,
                        null,
                        Color.Linen,
                        SystemColors.Control);

                    //this.editErfasstX.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.editErfasstX_ButtonPressed);
                    //this.editErfasstX.Leave += new System.EventHandler(this.editErfasstX_Leave);

                    buttonEdit.Loaded();

                    AddControl(buttonEdit, row);
                    break;

                case 15:
                    //RTF-Memo
                    KissRTFEdit rtfEdit = new KissRTFEdit();
                    if (visible) rtfEdit.Location = new Point(x, y);
                    rtfEdit.Visible = visible;

                    rtfEdit.Size = new Size(width, height);

                    AddControl(rtfEdit, row);
                    break;

                case 16:
                    //Button
                    KissButton button = new KissButton();

                    if (visible) button.Location = new Point(x, y);
                    button.Visible = visible;

                    button.Size = new Size(width, height);
                    button.Text = row.Table.Columns.Contains("MLText") ? row["MLText"].ToString() : row["DisplayText"].ToString();

                    AddControl(button, row);
                    break;

                case 17:
                    KissPickList pickList = new KissPickList();

                    if (visible) pickList.Location = new Point(x, y);
                    pickList.Visible = visible;

                    pickList.Size = new Size(width, height);

                    //sourceTitle
                    string sourceTitle = row["Parameter0"] as string ?? "";
                    var sourceDictionary = new Dictionary<string, string>();
                    sourceDictionary.Add("Name", sourceTitle);

                    //targetTitle
                    string targetTitle = row["Parameter1"] as string ?? "";
                    var targetDictionary = new Dictionary<string, string>();
                    targetDictionary.Add("Name", targetTitle);

                    pickList.ColumnIDName = "Code";
                    pickList.FilterColumnName = "Name";

                    // kleiner Hack für die Spaltenbreite
                    pickList.ButtonSelectAll.Visible = true;
                    pickList.ButtonRemoveAll.Visible = true;
                    pickList.ColumnsByFieldNameAndCaptionForSourceGrid = sourceDictionary;
                    pickList.ColumnsByFieldNameAndCaptionForTargetGrid = targetDictionary;

                    //data source
                    string picklistSql = row["SQL"] as string ?? "SELECT Code = -1, Name = NULL";

                    //var sourceQuery = new SqlQuery();
                    //var targetQuery = new SqlQuery();

                    var sourceQuery = DBUtil.OpenSQL(picklistSql);
                    var targetQuery = DBUtil.OpenSQL(picklistSql);

                    sourceQuery.CanUpdate = true;
                    sourceQuery.CanInsert = true;
                    sourceQuery.CanDelete = true;
                    sourceQuery.BatchUpdate = true;
                    targetQuery.CanUpdate = true;
                    targetQuery.CanInsert = true;
                    targetQuery.CanDelete = true;
                    targetQuery.BatchUpdate = true;

                    pickList.DataSourceOfSourceGrid = sourceQuery;
                    pickList.DataSourceOfTargetGrid = targetQuery;

                    //sourceQuery.Fill(sourceSql);
                    //targetQuery.Fill(targetSql);
                    targetQuery.DataTable.Clear(); //empty the table

                    AddControl(pickList, row);
                    break;

                default:
                    //noch nicht unterstütze Controls: textEdit
                    KissTextEdit textEdit0 = new KissTextEdit();
                    ((System.ComponentModel.ISupportInitialize)(textEdit0.Properties)).BeginInit();
                    textEdit0.Location = new Point(x, y);
                    textEdit0.Size = new Size(width, 26);
                    ((System.ComponentModel.ISupportInitialize)(textEdit0.Properties)).EndInit();
                    textEdit0.Loaded();
                    AddControl(textEdit0, row);
                    break;
            }
        }

        /// <summary>
        /// Creates the data field.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="host">The host.</param>
        public void CreateDataField(DataRow row, Control host)
        {
            _ctlHost = host;
            _tabControl = null;
            CreateDataField(row);
        }

        /// <summary>
        /// Recreates the data field.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="fld">The FLD.</param>
        public void RecreateDataField(DataRow row, Control fld)
        {
            if (fld.Parent == null) return;

            _ctlHost = fld.Parent;
            _tabControl = null;

            fld.Parent = null;
            fld.Dispose();
            CreateDataField(row);
        }

        /// <summary>
        /// Sets the anchor.
        /// </summary>
        /// <param name="ctl">The CTL.</param>
        /// <param name="appCode">The app code.</param>
        public void SetAnchor(Control ctl, object appCode)
        {
            if (Utils.AppCodeContainsToken(appCode, "AutoHöhe"))
            {
                ctl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            }

            if (Utils.AppCodeContainsToken(appCode, "AutoBreite"))
            {
                ctl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            }

            if (Utils.AppCodeContainsToken(appCode, "AutoGrösse"))
            {
                ctl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Adds the control.
        /// </summary>
        /// <param name="ctl">The CTL.</param>
        /// <param name="row">The row.</param>
        private void AddControl(Control ctl, DataRow row)
        {
            string tabName = row["TabName"].ToString();
            int tabPosition = (int)row["TabPosition"];

            ctl.Name = "Control" + tabPosition.ToString();
            ctl.TabIndex = tabPosition;
            ctl.Tag = row;

            if (Utils.AppCodeContainsToken(row["AppCode"], "gesperrt"))
            {
                try
                {
                    PropertyInfo prop = ctl.GetType().GetProperty("EditMode");

                    if (prop != null)
                    {
                        prop.SetValue(ctl, EditModeType.ReadOnly, null);
                    }
                }
                catch { }
            }

            if (_tabControl == null)
            {
                _ctlHost.Controls.Add(ctl);
                SetAnchor(ctl, row["AppCode"]);
            }
            else
            {
                foreach (TabPageEx tabPage in _tabControl.TabPages)
                {
                    if (tabPage.Title.ToUpper() == tabName.ToUpper())
                    {
                        tabPage.Controls.Add(ctl);
                        SetAnchor(ctl, row["AppCode"]);
                        return;
                    }
                }
                // not found: put into first tabpage
                _tabControl.TabPages[0].Controls.Add(ctl);
            }
        }

        /// <summary>
        /// Displays the grid control.
        /// </summary>
        /// <param name="gridHeight">Height of the grid.</param>
        /// <param name="dt">The dt.</param>
        private void DisplayGridControl(int gridHeight, DataTable dt)
        {
            _grdControl = null;

            if (gridHeight <= 0)
            {
                return;
            }

            //KissGrid on Top, Anchors Top/Left/RightTitel Name
            _grdControl = new KissGrid();
            _grdControl.Location = new Point(5, 35);
            _grdControl.Size = new Size(_ctlHost.Width - 10, gridHeight);
            _grdControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            _grdControl.MainView = new DevExpress.XtraGrid.Views.Grid.GridView();
            _grdControl.GridStyle = GridStyleType.ReadOnly;
            _grdControl.Name = "Grid";
            _grdControl.TabIndex = 0;

            // add GridColumns

            // filter DataRows with GridColumn info and sort upon GridColPosition
            SortedList sl = new SortedList();

            foreach (DataRow row in dt.Rows)
            {
                if (!DBUtil.IsEmpty(row["GridColTitle"]) &&
                    !DBUtil.IsEmpty(row["GridColWidth"]) &&
                    !DBUtil.IsEmpty(row["GridColPosition"]) &&
                    !DBUtil.IsEmpty(row["FieldName"]) &&
                    ((int)row["FieldCode"]) > 1)
                {
                    try
                    {
                        sl.Add((int)row["GridColPosition"], row);
                    }
                    catch
                    {
                        KissMsg.ShowInfo("DynaFactory", "TabellenkolonneExistiertBereits", "Es gibt bereits eine Tabellenkolonne mit Index {0}", 0, 0, (int)row["GridColPosition"]);
                    }
                }
            }

            foreach (DataRow row in sl.Values)
            {
                GridColumn col = _grdControl.View.Columns.Add();
                col.Caption = row["GridColTitle"].ToString();
                col.FieldName = "Field" + row["DynaFieldID"];
                col.Name = "col" + col.FieldName;
                col.VisibleIndex = (int)row["GridColPosition"];
                col.Width = (int)row["GridColWidth"];
                col.OptionsColumn.AllowSort = DefaultBoolean.True;

                switch ((int)row["FieldCode"])
                {
                    case 4: // Zahl
                        if (row["AppCode"].ToString().IndexOf("[N2]") != -1)
                        {
                            col.DisplayFormat.FormatString = "n2";
                        }
                        else
                        {
                            col.DisplayFormat.FormatString = "n";
                        }

                        col.DisplayFormat.FormatType = FormatType.Numeric;
                        break;
                    case 5: // Datum
                        col.DisplayFormat.FormatString = "d";
                        col.DisplayFormat.FormatType = FormatType.DateTime;
                        break;
                    case 6: // Zeit
                        col.DisplayFormat.FormatString = "t";
                        col.DisplayFormat.FormatType = FormatType.DateTime;
                        break;
                    case 8: // Auswahl/Lookup
                        col.MinWidth = 18; //Mark as Auswahl for later use
                        break;
                    case 9: // Mehrfachauswahl
                        col.MinWidth = 19; //Mark as Mehrfachauswahl for later use
                        break;
                    case 14: // Auswahl/Lookup mit Dialog
                        col.MinWidth = 17; //Mark as Mehrfachauswahl for later use
                        col.DisplayFormat.Format = new GridColumnLookup(row["SQL"].ToString());
                        break;
                    case 15: //RTF-Feld
                        col.MinWidth = 15; //Mark as RFT-Feld for later use
                        col.DisplayFormat.Format = new GridColumnRTF();
                        break;
                }

                try
                {
                    string sortIndex = Utils.GetAppCodeNamedValue("SortIndex", (string)row["AppCode"]);

                    if (sortIndex != null)
                    {
                        col.SortIndex = int.Parse(sortIndex);

                        if (Utils.GetAppCodeNamedValue("SortOrder", (string)row["AppCode"]).ToUpper() == "DESC")
                        {
                            col.SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
                        }
                        else
                        {
                            col.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                        }
                    }
                }
                catch { }
            }
            _ctlHost.Controls.Add(_grdControl);
        }

        /// <summary>
        /// Displays the tab control.
        /// </summary>
        /// <param name="tabNames">The tab names.</param>
        /// <param name="gridHeight">Height of the grid.</param>
        private void DisplayTabControl(string tabNames, int gridHeight)
        {
            _tabControl = null;

            if (string.IsNullOrEmpty(tabNames))
            {
                return;
            }

            _tabControl = new KissTabControlEx();
            _tabControl.SuspendLayout();

            _tabControl.Anchor = (((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right);

            if (gridHeight >= 0)
            {
                _tabControl.Location = new Point(5, 25 + 10 + gridHeight);
            }
            else
            {
                _tabControl.Location = new Point(5, 25);
            }

            _tabControl.Name = "tabControl";
            _tabControl.Size = new Size(_ctlHost.Width - 10, _ctlHost.Height - 40);
            _tabControl.TabIndex = 0;
            _tabControl.TabsLocation = TabsLocation.Top;

            // add tab pages

            string[] tabPageNames = tabNames.Split(new[] { ',' }, 20);

            for (int i = 0; i < tabPageNames.Length; i++)
            {
                TabPageEx tabPage = new TabPageEx();
                tabPage.Location = new Point(4, 32);
                tabPage.Name = "tabPage" + i.ToString();
                tabPage.Size = new Size(_tabControl.Width - 8, _tabControl.Height - 36);
                tabPage.Title = tabPageNames[i].Trim();
                _tabControl.Controls.Add(tabPage);
                _tabControl.TabPages.Add(tabPage);
            }
            _tabControl.SelectedTabIndex = 0;
            _tabControl.ResumeLayout();
            _ctlHost.Controls.Add(_tabControl);
        }

        /// <summary>
        /// Displays the title.
        /// </summary>
        /// <param name="titleName">Name of the title.</param>
        /// <param name="titleImage">The title image.</param>
        private void DisplayTitle(string titleName, Image titleImage)
        {
            if (string.IsNullOrEmpty(titleName))
            {
                return;
            }

            //Titel Name
            Label lblTitel = new Label();
            lblTitel.AutoSize = true;
            lblTitel.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            lblTitel.ForeColor = Color.Black;
            lblTitel.Location = new Point(35, 10);
            lblTitel.Name = "lblTitel";
            lblTitel.Size = new Size(42, 21);
            lblTitel.TabIndex = 24;
            lblTitel.Text = titleName;
            _ctlHost.Controls.Add(lblTitel);

            //Title Image
            PictureBox picTitel = new PictureBox();
            picTitel.Image = titleImage;
            picTitel.Location = new Point(10, 9);
            picTitel.Name = "picTitel";
            picTitel.Size = new Size(25, 20);
            picTitel.TabIndex = 25;
            picTitel.TabStop = false;
            _ctlHost.Controls.Add(picTitel);
        }

        private string ReplaceParameter(string sql, string paramName)
        {
            string paramValue = _cp.GetContextValue(paramName).ToString();
            sql = sql.Replace("{" + paramName + "}", paramValue);
            return sql;
        }

        private string ReplaceParameters(string sqlFieldName, DataRow row)
        {
            string sql = row[sqlFieldName].ToString();
            if (_cp == null)
            {
                return sql;
            }

            int paramCount = 0;

            // Search all parameters definition
            if (!DBUtil.IsEmpty(row["ParameterCount"]))
            {
                paramCount = Convert.ToInt32(row["ParameterCount"]);
            }

            for (int i = 0; i < paramCount; i++)
            {
                string paramName = row["Parameter" + i].ToString();

                sql = ReplaceParameter(sql, paramName);
            }

            return sql;
        }

        #endregion

        #endregion
    }
}