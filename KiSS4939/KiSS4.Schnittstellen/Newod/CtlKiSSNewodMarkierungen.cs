using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Kiss.Infrastructure;
using KiSS4.DB;
using KiSS4.Schnittstellen.Newod.DTO;
using KiSS4.Schnittstellen.Newod.Service;

namespace KiSS4.Schnittstellen.Newod
{
    internal class CtlKiSSNewodMarkierungen : KiSS4.Gui.KissUserControl
    {
        private KiSS4.Gui.KissButton edtStart;

        private KiSS4.Gui.KissLabel edtCurrentTaskText;

        private KiSS4.Gui.KissLabel edtCurrentTask;

        private PersonService _svc;

        public CtlKiSSNewodMarkierungen()
        {
            this.InitializeComponent();
            edtCurrentTaskText.Text = "";
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.edtStart = new KiSS4.Gui.KissButton();
            this.edtCurrentTaskText = new KiSS4.Gui.KissLabel();
            this.edtCurrentTask = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.edtCurrentTaskText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCurrentTask)).BeginInit();
            this.SuspendLayout();
            //
            // edtStart
            //
            this.edtStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.edtStart.Location = new System.Drawing.Point(3, 3);
            this.edtStart.Name = "edtStart";
            this.edtStart.Size = new System.Drawing.Size(701, 24);
            this.edtStart.TabIndex = 0;
            this.edtStart.Text = "Markierungslauf starten";
            this.edtStart.UseVisualStyleBackColor = false;
            this.edtStart.Click += new System.EventHandler(this.edtStart_Click);
            //
            // edtCurrentTaskText
            //
            this.edtCurrentTaskText.Location = new System.Drawing.Point(123, 30);
            this.edtCurrentTaskText.Name = "edtCurrentTaskText";
            this.edtCurrentTaskText.Size = new System.Drawing.Size(327, 24);
            this.edtCurrentTaskText.TabIndex = 7;
            this.edtCurrentTaskText.Text = "Start";
            //
            // edtCurrentTask
            //
            this.edtCurrentTask.Location = new System.Drawing.Point(3, 30);
            this.edtCurrentTask.Name = "edtCurrentTask";
            this.edtCurrentTask.Size = new System.Drawing.Size(103, 24);
            this.edtCurrentTask.TabIndex = 6;
            this.edtCurrentTask.Text = "Task:";
            //
            // CtlKiSSNewodMarkierungen
            //
            this.Controls.Add(this.edtCurrentTaskText);
            this.Controls.Add(this.edtCurrentTask);
            this.Controls.Add(this.edtStart);
            this.Name = "CtlKiSSNewodMarkierungen";
            this.Size = new System.Drawing.Size(707, 436);
            ((System.ComponentModel.ISupportInitialize)(this.edtCurrentTaskText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCurrentTask)).EndInit();
            this.ResumeLayout(false);
        }

        /// <summary>
        /// Handles the Click event of the edtStart control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void edtStart_Click(object sender, EventArgs e)
        {
            edtCurrentTaskText.Text = "";
            AddStatusMessage("Starte Verarbeitung");

            Cursor.Current = Cursors.WaitCursor;

            PersonSearchCriteria criteria = new PersonSearchCriteria();
            criteria.IsMapped = true;

            _svc = new PersonService();
            _svc.SearchPerson(true, false, criteria);

            List<BaPerson> mappedPersons = _svc.KissPersons;

            ProcessList(mappedPersons);

            Cursor.Current = Cursors.Default;

            AddStatusMessage("Verarbeitung beendet.");
        }

        /// <summary>
        /// Processes the Request.
        /// </summary>
        /// <param name="req">GetPersonRequest[].</param>
        private void ProcessList(List<BaPerson> lst)
        {
            string logComment;
            string logMessage;
            LogLevel loglevel;

            int i = 1;
            foreach (BaPerson person in lst)
            {
                loglevel = LogLevel.INFO;
                logMessage = "Markierungslauf";
                logComment = "Keine Änderung vorgenommen";

                BaPersonNewodFlags flags = _svc.CalculateNewodFlags(person.ID);

                if (!person.NewodFlags.Equals(flags))
                {
                    try
                    {
                        flags.kiSS = true;
                        _svc.UpdateNewodFlags(person.ID, flags, true, true);
                        logMessage = "Flags aktualisiert";
                        logComment = String.Format("AS({0}), CHV({1})", flags.AuslaenderAktiveSozialHilfe.ToString(), flags.AktiveVormundschaft.ToString());
                    }
                    catch (Exception ex)
                    {
                        loglevel = LogLevel.ERROR;
                        logMessage = "Fehler";

                        logComment = String.Format("BaPersonID: {0}:" + ex.Message, person.ID);
                    }

                    // Eintrag ins Log (Ansicht unter Anwendung/Newod Schnittstelle/Protokolle)
                    XLog.Create(this.GetType().FullName, 2, loglevel, logMessage, logComment, "BaPerson", Convert.ToInt32(person.ID));
                }

                AddStatusMessage(String.Format(@"{0} von {1} Personen verarbeitet", i, lst.Count));
                i++;
            }
        }

        /// <summary>
        /// Adds the status message.
        /// </summary>
        /// <param name="message">The message.</param>
        private void AddStatusMessage(string message)
        {
            edtCurrentTaskText.Text = message;
            ApplicationFacade.DoEvents();
        }
    }
}