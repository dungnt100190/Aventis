using System;
using System.Collections.Specialized;
using System.Windows.Forms;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Pendenzen
{
    public partial class DlgPendenzErfassen : KissDialog
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string QRY_TASK_TYPE_DESCRIPTION = "Description";

        private const string QRY_TASK_TYPE_SUBJECT = "Subject";

        /// <summary>
        /// Dieser Wert wird auf true gesetzt, wenn es sich um eine Person hadelt,
        /// die keine FaLeistung hat. Es handelts sich um eine schlichte
        /// "Bezugsperson".
        /// </summary>
        private readonly bool _isBezugsPerson;

        private readonly bool _maskHasStandardWert;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DlgPendenzErfassen"/> class.
        /// </summary>
        public DlgPendenzErfassen()
        {
            InitializeComponent();

            edtFallLeistungBetrifftPerson.edtFaLeistungID.EditValueChanged += edtFallLeistungPerson_FaLeistungIDEditValueChanged;

            qryXTask.Fill();
            qryXTask.Insert(qryXTask.TableName);

            KissChildForm frm = Session.MainForm.ActiveMdiChild as KissChildForm;

            if (frm == null && !Session.IsKiss5Mode)
            {
                edtFallLeistungBetrifftPerson.ShowFaFallDropDown = false;
                return;
            }

            //ask for default values (possible Dictionary-Keys are: Typ, Betreff, Beschreibung, Empfaenger, FaLeistungID, Faellig, BetrifftPerson)
            var defaultValues = FormController.GetMessage(frm, "Action", "GetPendenzStandardWerte") as HybridDictionary;

            if (defaultValues != null && defaultValues.Count > 0)
            {
                _maskHasStandardWert = true;
                qryXTask[DBO.XTask.TaskTypeCode] = defaultValues["Typ"];
                qryXTask[DBO.XTask.Subject] = defaultValues["Betreff"];
                qryXTask[DBO.XTask.TaskDescription] = defaultValues["Beschreibung"];
                qryXTask[DBO.XTask.ReceiverID] = defaultValues["Empfaenger"];
                qryXTask[DBO.XTask.ExpirationDate] = defaultValues["Faellig"];
            }

            //ask for JumpToPath
            var dic = FormController.GetMessage(frm, "Action", "GetJumpToPath") as HybridDictionary;

            if (dic == null)
            {
                return;
            }

            qryXTask[DBO.XTask.JumpToPath] = FormController.ConvertToString(dic);

            if (!DBUtil.IsEmpty(dic["BaPersonID"]))
            {
                //Überprüfen, ob die BaPerson ein Fallträger ist:
                //Es existiert irgend eine FaLeistung zu dieser Person.
                int isFalltraeger =
                    (int)DBUtil.ExecuteScalarSQL(@"
                        SELECT CASE
                                 WHEN EXISTS (SELECT 1 FROM dbo.FaLeistung WITH(READUNCOMMITTED) WHERE BaPersonID = {0})
                                   THEN 1
                                 ELSE 0
                               END",
                        Convert.ToInt32(dic["BaPersonID"]));

                //Es handelt sich um einen Fallträger.
                if (isFalltraeger == 1 || !DBUtil.IsEmpty(dic["FaFallID"]))
                {
                    if (DBUtil.IsEmpty(dic["FaFallID"]))
                    {
                        qryXTask[DBO.XTask.FaFallID] = dic["BaPersonID"];
                    }
                    else
                    {
                        qryXTask[DBO.XTask.FaFallID] = dic["FaFallID"];
                    }

                    qryXTask["FaFall"] =
                        DBUtil.ExecuteScalarSQL(@"
                            SELECT PRS.NameVorname
                            FROM dbo.FaFall                   FAL WITH (READUNCOMMITTED)
                                INNER JOIN dbo.vwPersonSimple PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = FAL.BaPersonID
                            WHERE FAL.FaFallID = {0}",
                            Convert.ToInt32(qryXTask[DBO.XTask.FaFallID]));
                    edtFallLeistungBetrifftPerson.edtFaFall.EditValue = qryXTask["FaFall"];
                    edtFallLeistungBetrifftPerson.Init(qryXTask[DBO.XTask.FaFallID] as int?, null);

                    qryXTask[DBO.XTask.FaLeistungID] = dic["FaLeistungID"];

                    SetUpGuiDefault();

                    //#4399: no more autoselected: qryXTask["BaPersonID"] = dic["BaPersonID"];
                }
                else
                {
                    //Es ist eine Bezugsperson, ohne ein Fallträger zu sein.
                    edtFallLeistungBetrifftPerson.Init(null, Convert.ToInt32(dic["BaPersonID"]));

                    edtFallLeistungBetrifftPerson.InitFalltraegerDropDown(Convert.ToInt32(dic["BaPersonID"]));

                    SetUpGuiBezugspersonen();

                    _isBezugsPerson = true;
                }
            }
            else
            {
                SetUpGuiDefault();
            }

            if (!DBUtil.IsEmpty(dic["ModulID"]))
            {
                int? modulId = dic["ModulID"] as int?;

                // Basis
                if (modulId == 1)
                {
                    edtFallLeistungBetrifftPerson.SetFaLeistungFallfuehrung();
                }
            }

            if (!DBUtil.IsEmpty(dic["FaLeistungID"]))
            {
                qryXTask[DBO.XTask.FaLeistungID] = dic["FaLeistungID"];
            }
        }

        private void edtFallLeistungPerson_FaLeistungIDEditValueChanged(object sender, EventArgs eventArgs)
        {
            int? faLeistungID = edtFallLeistungBetrifftPerson.edtFaLeistungID.EditValue as int?;
            //do we have to find the default empfänger?
            if (DBUtil.IsEmpty(qryXTask[DBO.XTask.ReceiverID])
                && faLeistungID.HasValue)
            {
                var qryUserID = DBUtil.OpenSQL(
                    @"
                    SELECT
                        USR.UserID,
                        USR.DisplayText
                    FROM dbo.FaLeistung LEI
                      INNER JOIN dbo.vwUser USR ON USR.UserID = LEI.UserID
                    WHERE LEI.FaLeistungID = {0}",
                    faLeistungID.Value);

                if (!qryUserID.IsEmpty)
                {
                    edtReceiverID.EditValue = qryUserID[DBO.vwUser.DisplayText];
                    qryXTask[DBO.XTask.ReceiverID] = qryUserID[DBO.vwUser.UserID];
                    qryXTask[DBO.XTask.TaskReceiverCode] = 1; //1: Person
                }
            }
        }

        #endregion

        #region EventHandlers

        private void btnErfassen_Click(Object sender, EventArgs e)
        {
            if (qryXTask.Post())
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void DlgPendenzErfassen_Load(object sender, EventArgs e)
        {
            if (_isBezugsPerson)
            {
                //In dem Fall gibt es nur zwei Einträge:
                // - keie Auswahl
                // - Bezugsperson
                edtFallLeistungBetrifftPerson.edtBaPersonID.ItemIndex = 1;

                //Wenn es zur Bezugsperson nur einen
                //Fallträger gibt, dann wählen wir
                //diesen. Der erste Eintrag ist "keine Auswahl".
                edtFallLeistungBetrifftPerson.SelectFalltraegerDropDown();
            }
        }

        /// <summary>
        /// Handles the UserModifiedFld event of the edtReceiverID control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KiSS4.Gui.UserModifiedFldEventArgs"/> instance containing the event data.</param>
        private void edtReceiverID_UserModifiedFld(Object sender, UserModifiedFldEventArgs e)
        {
            // create a new dialog and show it
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.PendenzEmpfaengerSuchen(edtReceiverID.Text, false, e.ButtonClicked);

            // if not canceled, apply values
            if (!e.Cancel)
            {
                edtReceiverID.EditValue = dlg["DisplayText$"];

                qryXTask[DBO.XTask.ReceiverID] = dlg["ID$"];
                qryXTask[DBO.XTask.TaskReceiverCode] = dlg["TypeCode$"];
            }
        }

        private void edtTaskTypeCode_EditValueChanged(object sender, EventArgs e)
        {
            var taskTypeCode = edtTaskTypeCode.EditValue;

            qryTaskType.Fill(taskTypeCode, Session.User.LanguageCode);

            var subject = qryTaskType[QRY_TASK_TYPE_SUBJECT];
            var description = qryTaskType[QRY_TASK_TYPE_DESCRIPTION];

            if (!_maskHasStandardWert)
            {
                qryXTask[DBO.XTask.TaskTypeCode] = taskTypeCode;
                qryXTask[DBO.XTask.Subject] = subject;
            }

            if (!_maskHasStandardWert)
            {
                qryXTask[DBO.XTask.TaskTypeCode] = taskTypeCode;
                qryXTask[DBO.XTask.TaskDescription] = description;
            }
        }

        /// <summary>
        /// Handles the AfterInsert event of the qryXTask control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void qryXTask_AfterInsert(object sender, EventArgs e)
        {
            qryXTask[DBO.XTask.TaskStatusCode] = 1;  // pendent
            qryXTask[DBO.XTask.TaskTypeCode] = 6;    // Anfrage
            qryXTask[DBO.XTask.CreateDate] = DateTime.Now;

            qryXTask[DBO.XTask.SenderID] = Session.User.UserID;
            qryXTask[DBO.XTask.TaskSenderCode] = 1;  // Person

            edtTaskTypeCode.Focus();
        }

        /// <summary>
        /// Handles the BeforePost event of the qryXTask control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void qryXTask_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtTaskTypeCode, lblTaskTypeCode.Text);
            DBUtil.CheckNotNullField(edtSubject, lblSubject.Text);
            DBUtil.CheckNotNullField(edtReceiverID, lblReceiverID.Text);

            edtFallLeistungBetrifftPerson.CheckNotNullFields();

            if (DBUtil.IsEmpty(qryXTask[DBO.XTask.FaLeistungID]))
            {
                //wenn wir einen Wert für FaLeistungID haben, müssen wir nicht noch FaFallID speichern
                //(Information wäre redundant, da bereits in FaLeistung enthalten)
                qryXTask[DBO.XTask.FaFallID] = null;
            }
        }

        #endregion

        #region Methods

        #region Private Methods

        /// <summary>
        /// Setup GUI Bezugsbersonen (nicht Fallträger).
        /// In diesem Fall ist in der Dropdown der Fallträger auszuwählen.
        /// </summary>
        private void SetUpGuiBezugspersonen()
        {
            edtFallLeistungBetrifftPerson.ShowFaFallDropDown = true;
        }

        /// <summary>
        /// Setup für Fallträger und Institutionen
        /// </summary>
        private void SetUpGuiDefault()
        {
            edtFallLeistungBetrifftPerson.ShowFaFallDropDown = false;
        }

        #endregion

        #endregion
    }
}