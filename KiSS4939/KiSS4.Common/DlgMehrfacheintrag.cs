using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using KiSS4.DB;
using KiSS4.Gui;
using log4net;

namespace KiSS4.Common
{
    public class DlgMehrfacheintrag : KissDialog
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Fields

        private KissButton btnAbbrechen;
        private KissButton btnOk;
        private KissDateEdit edtDatumBis;
        private KissDateEdit edtDatumVon;
        private MonthCalendar edtKalender;
        private KissLabel lblAnzahlTage;
        private KissLabel lblDatumBis;
        private KissLabel lblDatumVon;
        private KissLabel lblEinzeltageAuswaehlen;

        #endregion

        #endregion

        #region Constructors

        public DlgMehrfacheintrag()
        {
            InitializeComponent();
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgMehrfacheintrag));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblAnzahlTage = new KiSS4.Gui.KissLabel();
            this.lblDatumBis = new KiSS4.Gui.KissLabel();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblEinzeltageAuswaehlen = new KiSS4.Gui.KissLabel();
            this.edtKalender = new System.Windows.Forms.MonthCalendar();
            this.btnOk = new KiSS4.Gui.KissButton();
            this.btnAbbrechen = new KiSS4.Gui.KissButton();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahlTage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinzeltageAuswaehlen)).BeginInit();
            this.SuspendLayout();
            //
            // lblDatumVon
            //
            this.lblDatumVon.Location = new System.Drawing.Point(10, 12);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(75, 24);
            this.lblDatumVon.TabIndex = 0;
            this.lblDatumVon.Text = "Datum von";
            this.lblDatumVon.UseCompatibleTextRendering = true;
            //
            // edtDatumVon
            //
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(91, 12);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(96, 24);
            this.edtDatumVon.TabIndex = 1;
            //
            // lblAnzahlTage
            //
            this.lblAnzahlTage.Anchor = ((((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                                           | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAnzahlTage.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblAnzahlTage.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblAnzahlTage.Location = new System.Drawing.Point(10, 241);
            this.lblAnzahlTage.Name = "lblAnzahlTage";
            this.lblAnzahlTage.Size = new System.Drawing.Size(342, 24);
            this.lblAnzahlTage.TabIndex = 2;
            this.lblAnzahlTage.Text = "Anzahl gewählter Tage: <x>";
            this.lblAnzahlTage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblAnzahlTage.UseCompatibleTextRendering = true;
            //
            // lblDatumBis
            //
            this.lblDatumBis.Location = new System.Drawing.Point(204, 12);
            this.lblDatumBis.Name = "lblDatumBis";
            this.lblDatumBis.Size = new System.Drawing.Size(30, 24);
            this.lblDatumBis.TabIndex = 2;
            this.lblDatumBis.Text = "bis";
            this.lblDatumBis.UseCompatibleTextRendering = true;
            //
            // edtDatumBis
            //
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(240, 12);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(96, 24);
            this.edtDatumBis.TabIndex = 3;
            //
            // lblEinzeltageAuswaehlen
            //
            this.lblEinzeltageAuswaehlen.Anchor = ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                                                     | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEinzeltageAuswaehlen.Location = new System.Drawing.Point(10, 53);
            this.lblEinzeltageAuswaehlen.Name = "lblEinzeltageAuswaehlen";
            this.lblEinzeltageAuswaehlen.Size = new System.Drawing.Size(342, 24);
            this.lblEinzeltageAuswaehlen.TabIndex = 4;
            this.lblEinzeltageAuswaehlen.Text = "Einzeltage auswählen:";
            this.lblEinzeltageAuswaehlen.UseCompatibleTextRendering = true;
            //
            // edtKalender
            //
            this.edtKalender.CalendarDimensions = new System.Drawing.Size(2, 1);
            this.edtKalender.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKalender.Location = new System.Drawing.Point(10, 77);
            this.edtKalender.MaxSelectionCount = 1;
            this.edtKalender.Name = "edtKalender";
            this.edtKalender.TabIndex = 5;
            this.edtKalender.TitleBackColor = System.Drawing.Color.FromArgb(((((190)))), ((((176)))), ((((134)))));
            this.edtKalender.DateSelected += this.edtKalender_DateSelected;
            this.edtKalender.KeyDown += this.edtKalender_KeyDown;
            //
            // btnOk
            //
            this.btnOk.Anchor = (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(168, 273);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(88, 24);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "OK";
            this.btnOk.UseCompatibleTextRendering = true;
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += this.btnOk_Click;
            //
            // btnAbbrechen
            //
            this.btnAbbrechen.Anchor = (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAbbrechen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbbrechen.Location = new System.Drawing.Point(264, 273);
            this.btnAbbrechen.Name = "btnAbbrechen";
            this.btnAbbrechen.Size = new System.Drawing.Size(88, 24);
            this.btnAbbrechen.TabIndex = 7;
            this.btnAbbrechen.Text = "Abbruch";
            this.btnAbbrechen.UseCompatibleTextRendering = true;
            this.btnAbbrechen.UseVisualStyleBackColor = false;
            //
            // DlgMehrfacheintrag
            //
            this.AcceptButton = this.btnOk;
            this.CancelButton = this.btnAbbrechen;
            this.ClientSize = new System.Drawing.Size(364, 310);
            this.Controls.Add(this.btnAbbrechen);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.edtKalender);
            this.Controls.Add(this.lblEinzeltageAuswaehlen);
            this.Controls.Add(this.edtDatumBis);
            this.Controls.Add(this.lblDatumBis);
            this.Controls.Add(this.lblAnzahlTage);
            this.Controls.Add(this.edtDatumVon);
            this.Controls.Add(this.lblDatumVon);
            this.Name = "DlgMehrfacheintrag";
            this.Text = "Mehrfacheintrag";
            this.Load += this.DlgMehrfacheintrag_Load;
            this.Layout += this.DlgMehrfacheintrag_Layout;
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahlTage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinzeltageAuswaehlen)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        #region Properties

        public bool AllowSaturdaySunday
        {
            get;
            set;
        }

        #endregion

        #region EventHandlers

        private void btnOk_Click(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            try
            {
                // check if we have entered a first date
                if (!DBUtil.IsEmpty(edtDatumVon.EditValue))
                {
                    // we need a last date
                    if (DBUtil.IsEmpty(edtDatumBis.EditValue))
                    {
                        // no last date
                        throw new KissInfoException(KissMsg.GetMLMessage(Name, "FeldXYLeer", "Das Feld '{0}' darf nicht leer bleiben !", KissMsgCode.MsgInfo, lblDatumBis.Text), edtDatumBis);
                    }

                    if (Convert.ToDateTime(edtDatumVon.EditValue) > Convert.ToDateTime(edtDatumBis.EditValue))
                    {
                        // invalid range
                        throw new KissInfoException(KissMsg.GetMLMessage(Name, "InvalidDateOrder", "Das Datum 'bis' ist ungültig - es darf nicht kleiner als 'Datum von' sein."), edtDatumBis);
                    }
                }
                else
                {
                    // we need at least one date selected in calendar
                    if (edtKalender.BoldedDates.Length < 1)
                    {
                        KissMsg.ShowInfo(Name, "NoDateSelected", "Es ist kein Datum selektiert, bitte wählen Sie einen Datums-Bereich oder einzelne Kalendertage.");
                        return;
                    }
                }
            }
            catch (KissInfoException exi)
            {
                // show message
                KissMsg.ShowInfo(exi.Message);

                // focus
                edtDatumBis.Focus();

                // cancel and do not close dialog
                return;
            }

            // if we are here, everything is ok
            DialogResult = DialogResult.OK;
            Close();

            // logging
            _logger.Debug("done");
        }

        private void DlgMehrfacheintrag_Layout(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // fix width, possibly too large depending on language...
            Width = edtKalender.Left + edtKalender.Width + edtKalender.Left + 6;

            // logging
            _logger.Debug("done");
        }

        private void DlgMehrfacheintrag_Load(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // setup width (show two calendar months)
            edtKalender.CalendarDimensions = new Size(2, 1);

            // setup label
            UpdateCountLabel();

            // logging
            _logger.Debug("done");
        }

        private void edtKalender_DateSelected(object sender, DateRangeEventArgs e)
        {
            // logging
            _logger.Debug("enter");

            try
            {
                // remove data if already selected
                if (edtKalender.BoldedDates.Any(dt => dt.Date.Equals(e.Start.Date)))
                {
                    edtKalender.RemoveBoldedDate(e.Start);
                    return;
                }

                // add date if not yet selected
                edtKalender.AddBoldedDate(e.Start);
            }
            finally
            {
                // update display
                edtKalender.BeginInvoke(new MethodInvoker(() => edtKalender.UpdateBoldedDates()));
                UpdateCountLabel();
            }

            // logging
            _logger.Debug("done");
        }

        private void edtKalender_KeyDown(object sender, KeyEventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // catch key only if space
            if (!e.Alt && !e.Shift && !e.Control)
            {
                // set var for label
                if (e.KeyCode == Keys.Space)
                {
                    // switch date (simulate click)
                    edtKalender_DateSelected(this, new DateRangeEventArgs(edtKalender.SelectionStart, edtKalender.SelectionEnd));
                    e.Handled = true;
                }
            }

            // logging
            _logger.Debug("done");
        }

        #endregion

        #region Methods

        #region Public Methods

        public DateTime[] GetSelectedDates()
        {
            // logging
            _logger.Debug("enter");

            try
            {
                // check if we have a date range
                if (!DBUtil.IsEmpty(edtDatumVon.EditValue) && !DBUtil.IsEmpty(edtDatumBis.EditValue))
                {
                    // logging
                    _logger.Debug("generate all dates using from-to range");

                    // the user entered a range, kalender is not handled (dates are already validated
                    var list = new List<DateTime>();

                    var dateFrom = Convert.ToDateTime(edtDatumVon.EditValue);
                    var dateTo = Convert.ToDateTime(edtDatumBis.EditValue);

                    // logging
                    _logger.Debug(String.Format("dateFrom='{0}', dateTo='{1}'", dateFrom, dateTo));

                    // add all dates (from-to) to array (from: http://www.dotnetspider.com/forum/ViewForum.aspx?ForumId=29565)
                    while (true)
                    {
                        // logging
                        _logger.Debug(string.Format("while: dateFrom='{0}'", dateFrom));

                        // check if all days are allowed
                        if (AllowSaturdaySunday)
                        {
                            // logging
                            _logger.Debug(string.Format("AllowSaturdaySunday=true, add dateFrom='{0}'", dateFrom));

                            // all days allowed: mon-sun, add from date to list
                            list.Add(dateFrom);
                        }
                        else
                        {
                            // check if weekday is mon-fri, sat/son won't be added anymore
                            if (dateFrom.DayOfWeek != DayOfWeek.Saturday && dateFrom.DayOfWeek != DayOfWeek.Sunday)
                            {
                                // logging
                                _logger.Debug(string.Format("AllowSaturdaySunday=false, add dateFrom='{0}'", dateFrom));

                                // only mon-fri allowed: mon-fri, add from date to list
                                list.Add(dateFrom);
                            }
                        }

                        // check if need to go on
                        if (DateTime.Compare(dateFrom, dateTo) >= 0)
                        {
                            // logging
                            _logger.Debug("stopped while");

                            // stop here
                            break;
                        }

                        // add a day to dateFrom
                        dateFrom = dateFrom.AddDays(1);
                    }

                    // logging
                    _logger.Debug("done, return list-array");

                    // return list as DateTime[]
                    return list.ToArray();
                }

                // logging
                _logger.Debug("done, get dates from calendar");

                // return array of bolded dates from calendar
                return edtKalender.BoldedDates;
            }
            catch (Exception ex)
            {
                // show error and cancel
                KissMsg.ShowError(Name, "ErrorGettingSelectedDates", "Es ist ein Fehler beim Auslesen der gewählten Daten aufgetreten.", ex);

                // logging
                _logger.Debug("done, return null");

                // return nothing
                return null;
            }
        }

        #endregion

        #region Private Methods

        private void UpdateCountLabel()
        {
            // logging
            _logger.Debug("enter");

            // update selection count
            lblAnzahlTage.Text = KissMsg.GetMLMessage(Name, "AnzahlGewaehlterTage", "Anzahl gewählter Tage: {0}", KissMsgCode.Text, edtKalender.BoldedDates.Length);

            // logging
            _logger.Debug("done");
        }

        #endregion

        #endregion
    }
}