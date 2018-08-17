using System;
using System.ComponentModel;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Basis
{
    public partial class CtlBaPersonAdresse : KissUserControl
    {
        #region Enumerations

        /// <summary>
        /// Type of the address
        /// </summary>
        public enum AddressType
        {
            /// <summary>
            /// Wohn- und Meldeadresse
            /// </summary>
            WohnMeldeAdresse,

            /// <summary>
            /// Weitere Adressen
            /// </summary>
            WeitereAdresse
        }

        #endregion

        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CLASSNAME = "CtlBaPersonAdresse";

        #endregion

        #region Private Fields

        private int _baPersonID;
        private float _defaultHeightWohnsitzDetailsCell = -1;
        private bool _isInSaving;

        #endregion

        #endregion

        #region Constructors

        public CtlBaPersonAdresse()
        {
            InitializeComponent();

            // default property values
            AutoSetRights = true;
            IsWohnstatusVisible = true;

            // handle designer mode to prevent design-time-errors
            if (DesignerMode || Session.User == null)
            {
                return;
            }

            // LookupSQL setzen:
            edtInstitutionLookup.LookupSQL = @"
                DECLARE @SearchValue VARCHAR(255);
                DECLARE @UserID INT;
                DECLARE @LanguageCode INT;

                SET @SearchValue = {0};
                SET @UserID = {1};
                SET @LanguageCode = {2};

                SELECT ID$             = INS.BaInstitutionID,
                       Text$           = INS.NameVorname,
                       --
                       Institution     = INS.NameVorname,
                       Adresse         = ISNULL(INS.StrasseHausNr + ', ', '') + INS.PLZOrt,
                       Typen           = dbo.fnBaGetBaInstitutionTypen(INS.BaInstitutionID, 0, '; ', @UserID, @LanguageCode),
                       --
                       Zusatz$         = INS.Zusatz,
                       Strasse$        = INS.Strasse,
                       HausNr$         = INS.HausNr,
                       Postfach$       = INS.Postfach,
                       PostfachOhneNr$ = INS.PostfachOhneNr,
                       PLZ$            = INS.PLZ,
                       Ort$            = INS.Ort,
                       OrtschaftCode$  = INS.OrtschaftCode,
                       Bezirk$         = INS.Bezirk,
                       Kanton$         = INS.Kanton,
                       BaLandID$       = INS.BaLandID
                FROM dbo.vwInstitution INS WITH(READUNCOMMITTED)
                WHERE INS.NameVorname LIKE '%' + @SearchValue +'%'
                ORDER BY INS.NameVorname;";

            // Anzeige im Gitter steuern:
            colAufenthaltAdresstyp.ColumnEdit = grdBaAufenthaltAdresse.GetLOVLookUpEdit((SqlQuery)cboAdresstyp.Properties.DataSource);

            // Rechte der Qry setzen
            SetRights();
        }

        #endregion

        #region Delegates

        /// <summary>
        /// Handler for notification after deleting an existing address record
        /// </summary>
        public delegate void AfterDeleteHandler(AddressType addressType);

        /// <summary>
        /// Handler for notification after inserting a new address record
        /// </summary>
        public delegate void AfterInsertHandler(AddressType addressType);

        /// <summary>
        /// Handler for notification after changing position of address records
        /// </summary>
        public delegate void PositionChangedHandler(AddressType addressType);

        #endregion

        #region Events

        /// <summary>
        /// Notification after deleting an existing address record
        /// </summary>
        public event AfterDeleteHandler AfterDelete;

        /// <summary>
        /// Notification after inserting a new address record
        /// </summary>
        public event AfterInsertHandler AfterInsert;

        /// <summary>
        /// Notification after changing position of address records
        /// </summary>
        public event PositionChangedHandler PositionChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Get and set if rights will be handled automatically
        /// </summary>
        [DefaultValue(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Get and set if rights will be handled automatically")]
        public bool AutoSetRights
        {
            get;
            set;
        }

        [DefaultValue(0)]
        public int BaPersonID
        {
            set
            {
                // apply id
                _baPersonID = value;

                try
                {
                    // Wohnsitzadressen abfüllen
                    qryBaWohnsitzAdresse.Fill(_baPersonID);

                    // Aufenthaltsadressen abfüllen
                    qryBaWeitereAdressen.Fill(_baPersonID);

                    // Name, Vorname abfüllen
                    qryBaPerson.Fill(_baPersonID);
                }
                finally
                {
                    // apply rights
                    SetRights();
                }
            }
            get
            {
                return _baPersonID;
            }
        }

        /// <summary>
        /// Get and set the Wohnstatus control visibility and handle controls position
        /// </summary>
        [DefaultValue(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Get and set the Wohnstatus control visibility and handle controls position")]
        public bool IsWohnstatusVisible
        {
            get
            {
                return edtWohnsituationsCode.Visible;
            }
            set
            {
                // show/hide controls
                edtWohnsituationsCode.Visible = value;
                edtWohnsituationsCode.Enabled = value;
                lblWohnsitzWohnstatus.Visible = value;

                // validate as property can be called when control is not visible yet
                if (_defaultHeightWohnsitzDetailsCell > 0)
                {
                    // fix size depending on visibility
                    if (IsWohnstatusVisible)
                    {
                        pnlTableLayout.RowStyles[2].Height = _defaultHeightWohnsitzDetailsCell + edtWohnsituationsCode.Height;
                    }
                    else
                    {
                        pnlTableLayout.RowStyles[2].Height = _defaultHeightWohnsitzDetailsCell - edtWohnsituationsCode.Height;
                    }
                }
            }
        }

        /// <summary>
        /// Sucht in der UIKomponentenhierarchie das nächst
        /// höher gelegene KissUserControl. Gibt es keines,
        /// ist der Wert null.
        /// </summary>
        public KissUserControl ParentKissUserControl
        {
            get
            {
                var parentCntr = Parent;
                while (parentCntr != null)
                {
                    if (parentCntr is KissUserControl)
                    {
                        return (KissUserControl)parentCntr;
                    }
                    parentCntr = parentCntr.Parent;
                }
                return null;
            }
        }

        /// <summary>
        /// Get the residence country edit control
        /// </summary>
        [Browsable(false)]
        public KissLookUpEdit WohnsitzEdtLand
        {
            get
            {
                return edtPLZWohnsitz.EdtLand;
            }
        }

        /// <summary>
        /// Get the residence place edit control
        /// </summary>
        [Browsable(false)]
        public KissTextEdit WohnsitzEdtOrt
        {
            get
            {
                return edtPLZWohnsitz.EdtOrt;
            }
        }

        #endregion

        #region EventHandlers

        public bool CtlBaPersonAdresse_CanSaveData()
        {
            if (!qryBaWohnsitzAdresse.Post())
            {
                return false;
            }

            if (!qryBaWeitereAdressen.Post())
            {
                return false;
            }

            // check if is in saving to prevent recursive calls
            if (_isInSaving)
            {
                return true;
            }

            // Damit die Daten unten auch gespeichert werden !!!
            // Wir müssen die daten des umschliessenden Controls (z.B. CtlBaPerson) speichern!
            // done by mboss (with pleasure and cK)
            // >> Generic by cjaeggi
            if (ParentKissUserControl != null)
            {
                try
                {
                    // set flag
                    _isInSaving = true;

                    // save on parent control
                    // No, this goes to "kissDataNavigator.SaveData()"
                    //if (!ParentKissUserControl.OnSaveData())
                    if (ParentKissUserControl != null)
                    {
                        if (ParentKissUserControl.ActiveSQLQuery != null)
                        {
                            if (!ParentKissUserControl.ActiveSQLQuery.Post())
                            {
                                return false;
                            }
                        }
                    }
                }
                finally
                {
                    // reset flag
                    _isInSaving = false;
                }
            }

            return true;
        }

        private void chkAufenthaltPostfachOhneNr_CheckedChanged(object sender, EventArgs e)
        {
            AufenthaltPostfachOhneNrChanged();
        }

        private void chkWohnsitzPostfachOhneNr_CheckedChanged(object sender, EventArgs e)
        {
            WohnsitzPostfachOhneNrChanged();
        }

        private void CtlBaPersonAdresse_AddData(object sender, EventArgs e)
        {
            // Kontrolle, ob eingefügt werden darf
            if (!qryBaWeitereAdressen.CanInsert && !qryBaWohnsitzAdresse.CanInsert)
            {
                KissMsg.ShowInfo(CLASSNAME, "NoRightsToSaveData", "Sie besitzen keine Berechtigung zum Einfügen neuer Adressen.");
                return;
            }

            // validate person
            if (_baPersonID < 1)
            {
                // invalid person, cannot add a new record
                KissMsg.ShowInfo(CLASSNAME, "NoValidBaPersonIDAddData", "Es existiert kein gültiger Verweis auf eine Person, daher kann keine neue Adresse hinzugefügt werden.");
                return;
            }

            if (!qryBaWohnsitzAdresse.CanInsert)
            {
                // Wenn keine Berechtigung zum Einfügen von Wohnsitzen, dann automatisch einen neuen Aufenthalt einfügen
                if (!qryBaWeitereAdressen.Post())
                {
                    return;
                }

                qryBaWeitereAdressen.Insert();
            }
            else
            {
                if (!qryBaWeitereAdressen.CanInsert)
                {
                    // Wenn keine Berechtigung zum Einfügen von Aufenthalten, dann automatisch einen neuen Wohnsitz einfügen
                    if (!qryBaWohnsitzAdresse.Post())
                    {
                        return;
                    }

                    qryBaWohnsitzAdresse.Insert();
                }
                else
                {
                    // Hier muss abgefragt werden, bei welcher Gitter eine neue Zeile eingefügt werden soll
                    string msg = KissMsg.GetMLMessage(CLASSNAME,
                                                      "QuestionAddressType",
                                                      "Wollen Sie einen neuen Wohnsitz oder eine neue andere Adresse erstellen?");

                    int resultButtonIndex = KissMsg.ShowButtonDlg(msg, GetButtonList());

                    if (resultButtonIndex == 0)
                    {
                        // Zuerst speichern, damit nachfolgende Kontrolle auch korrekt ist:
                        if (!qryBaWohnsitzAdresse.Post())
                        {
                            return;
                        }

                        // Kontrollieren, ob es bereits einen Datensatz gibt, bei welchem Datum von und DatumBis leer sind.
                        // Wenn dies der Fall ist, dann kein neuer Wohnsitz mehr eingefügt werden:
                        SqlQuery qryDat = DBUtil.OpenSQL(@"
                            SELECT Strasse,
                                   PLZ,
                                   Ort
                            FROM dbo.BaAdresse
                            WHERE BaPersonID = {0}
                              AND AdresseCode = 1
                              AND DatumVon IS NULL
                              AND DatumBis IS NULL;", _baPersonID);

                        if (qryDat.Count > 0)
                        {
                            string msgPart1 = "";

                            if (!DBUtil.IsEmpty(qryDat[DBO.BaAdresse.Strasse]))
                            {
                                msgPart1 += string.Format("\r\n", qryDat[DBO.BaAdresse.Strasse]);
                            }

                            string msgPart2 = string.Format("{0} {1}\r\n\r\n", qryDat[DBO.BaAdresse.PLZ], qryDat[DBO.BaAdresse.Ort]);
                            string[] msgList = { msgPart1, msgPart2 };

                            KissMsg.ShowInfo(CLASSNAME,
                                             "CheckInsert",
                                             "Es gibt ein Datensatz mit leeren Daten von und bis:\r\n\r\n" +
                                             "{0}{1}" +
                                             "Es kann deshalb kein neuer Wohnsitz hinzugefügt werden.\r\n\r\n" +
                                             "Ändern Sie zuerst das Datum von oder das Datum bis des vorhandenen Datensatzes.",
                                             520,
                                             240,
                                             msgList);
                            return;
                        }

                        // Einfügen in zivilrechtlicher Wohnsitz:
                        qryBaWohnsitzAdresse.Insert();
                    }
                    else if (resultButtonIndex == 1)
                    {
                        // Einfügen in weitere Wohnsitz:
                        qryBaWeitereAdressen.Post();
                        qryBaWeitereAdressen.Insert();
                    }
                    else
                    {
                        // Es wurde abbrechen gedrückt, also hier nichts machen.
                        // Wenn notwendig, hier return aufrufen oder Exception erzeugen.
                    }
                }
            }
        }

        private void CtlBaPersonAdresse_DeleteData(object sender, EventArgs e)
        {
            if (qryBaWohnsitzAdresse.Count == 0)
            {
                // Wenn in zivilrechtlicher Wohnsitz nichts erfasst ist, dann löschen bei andere:
                qryBaWeitereAdressen.Delete();
            }
            else if (qryBaWeitereAdressen.Count == 0)
            {
                // Wenn bei anderen nichts erfasst ist, dann löschen bei Wohnsitz:
                qryBaWohnsitzAdresse.Delete();
            }
            else
            {
                // confirm
                string msg = KissMsg.GetMLMessage(CLASSNAME, "ConfirmDeleteType", "Wollen Sie die markierte Wohnadresse oder die markierte weitere Adresse löschen?");

                int resultButtonIndex = KissMsg.ShowButtonDlg(msg, GetButtonList());

                if (resultButtonIndex == 0)
                {
                    qryBaWohnsitzAdresse.Delete();
                }
                else if (resultButtonIndex == 1)
                {
                    qryBaWeitereAdressen.Delete();
                }
            }
        }

        private void CtlBaPersonAdresse_Load(object sender, EventArgs e)
        {
            // HACK: Ohne diesen kleinen Hack (Wechsel der Grid-Visibility) würde das Grid später die ausgewählte Zeile durch einen Visibility-Wechsel verändern
            grdBaWohnsitzAdresse.Visible = false;
            grdBaWohnsitzAdresse.Visible = true;
            grdBaAufenthaltAdresse.Visible = false;
            grdBaAufenthaltAdresse.Visible = true;

            qryBaWeitereAdressen.Last();
            qryBaWohnsitzAdresse.Last();

            // get default height and init property
            _defaultHeightWohnsitzDetailsCell = pnlTableLayout.RowStyles[2].Height;
            IsWohnstatusVisible = IsWohnstatusVisible;

            edtPLZWohnsitz.GetDatum = GetDatumWohnsitz;
            edtPLZAufenthalt.GetDatum = GetDatumAufenthalt;
        }

        private void CtlBaPersonAdresse_MoveFirst(object sender, EventArgs e)
        {
            if (LeftSideHasFokus())
            {
                qryBaWohnsitzAdresse.First();
            }
            else
            {
                qryBaWeitereAdressen.First();
            }
        }

        private void CtlBaPersonAdresse_MoveLast(object sender, EventArgs e)
        {
            if (LeftSideHasFokus())
            {
                qryBaWohnsitzAdresse.Last();
            }
            else
            {
                qryBaWeitereAdressen.Last();
            }
        }

        private void CtlBaPersonAdresse_MoveNext(object sender, EventArgs e)
        {
            if (LeftSideHasFokus())
            {
                qryBaWohnsitzAdresse.Next();
            }
            else
            {
                qryBaWeitereAdressen.Next();
            }
        }

        private void CtlBaPersonAdresse_MovePrevious(object sender, EventArgs e)
        {
            if (LeftSideHasFokus())
            {
                qryBaWohnsitzAdresse.Previous();
            }
            else
            {
                qryBaWeitereAdressen.Previous();
            }
        }

        private void CtlBaPersonAdresse_RefreshData(object sender, EventArgs e)
        {
            if (!qryBaWohnsitzAdresse.Post())
            {
                throw new KissCancelException();
            }

            qryBaWeitereAdressen.Post();

            qryBaWohnsitzAdresse.Refresh();
            qryBaWeitereAdressen.Refresh();
        }

        private void CtlBaPersonAdresse_SaveData(object sender, EventArgs e)
        {
            if (!CtlBaPersonAdresse_CanSaveData())
            {
                throw new KissCancelException();
            }
        }

        private void CtlBaPersonAdresse_UndoDataChanges(object sender, EventArgs e)
        {
            qryBaWohnsitzAdresse.Cancel();
            qryBaWeitereAdressen.Cancel();
        }

        private void edtInstitutionLookup_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            KissLookupDialog dlg = new KissLookupDialog();

            string searchString = edtAufenthaltInstitutionName.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (dlg.SearchData(string.Format(edtInstitutionLookup.LookupSQL, DBUtil.SqlLiteral(searchString), Session.User.UserID, Session.User.LanguageCode),
                               searchString,
                               e.ButtonClicked))
            {
                edtInstitutionLookup.EditValue = dlg[1]; //set EditValue first, because lookupID is reset setting EditValue
                edtInstitutionLookup.LookupID = dlg[0];

                qryBaWeitereAdressen[DBO.BaAdresse.CareOf] = dlg["Institution"];
                qryBaWeitereAdressen[DBO.BaAdresse.Zusatz] = dlg["Zusatz$"];
                qryBaWeitereAdressen[DBO.BaAdresse.Postfach] = dlg["Postfach$"];
                qryBaWeitereAdressen[DBO.BaAdresse.PostfachOhneNr] = dlg["PostfachOhneNr$"];
                qryBaWeitereAdressen[DBO.BaAdresse.Strasse] = dlg["Strasse$"];
                qryBaWeitereAdressen[DBO.BaAdresse.HausNr] = dlg["HausNr$"];
                qryBaWeitereAdressen[DBO.BaAdresse.PLZ] = dlg["PLZ$"];
                qryBaWeitereAdressen[DBO.BaAdresse.Ort] = dlg["Ort$"];
                qryBaWeitereAdressen[DBO.BaAdresse.OrtschaftCode] = dlg["OrtschaftCode$"];
                qryBaWeitereAdressen[DBO.BaAdresse.Bezirk] = dlg["Bezirk$"];
                qryBaWeitereAdressen[DBO.BaAdresse.Kanton] = dlg["Kanton$"];
                qryBaWeitereAdressen[DBO.BaAdresse.BaLandID] = dlg["BaLandID$"];

                qryBaWeitereAdressen.RefreshDisplay();
            }
            else
            {
                edtInstitutionLookup.CancelEdit();
                edtInstitutionLookup.Focus();
            }
        }

        private void edtWohnSituationCode_EditValueChanged(object sender, EventArgs e)
        {
            //filter wohnungsgrösse
            bool clearWG = edtWohnsituationsCode.EditValue != null &&
                           edtWohnsituationsCode.EditValue != DBNull.Value &&
                           (int)edtWohnsituationsCode.EditValue >= 4;

            ((IKissBindableEdit)edtWohnungsgroesseCode).AllowEdit(!clearWG & qryBaWohnsitzAdresse.CanUpdate);
            edtWohnungsgroesseCode.EditValue = clearWG ? null : edtWohnungsgroesseCode.EditValue;
        }

        private void qryBaWeitereAdressen_AfterDelete(object sender, EventArgs e)
        {
            // raise event
            OnAfterDelete(AddressType.WeitereAdresse);
        }

        private void qryBaWeitereAdressen_AfterFill(object sender, EventArgs e)
        {
            // Position funzt auch nicht nach dem Öffnen des Fensters, später schon???
            qryBaWeitereAdressen.Position = qryBaWeitereAdressen.Count - 1;
        }

        private void qryBaWeitereAdressen_AfterInsert(object sender, EventArgs e)
        {
            qryBaWeitereAdressen[DBO.BaAdresse.BaPersonID] = _baPersonID;
            qryBaWeitereAdressen[DBO.BaAdresse.BaLandID] = Session.BaLandCodeSchweiz;
            qryBaWeitereAdressen.SetCreator();

            cboAdresstyp.Focus();

            // raise event
            OnAfterInsert(AddressType.WeitereAdresse);
        }

        private void qryBaWeitereAdressen_BeforeDelete(object sender, EventArgs e)
        {
            DBUtil.NewHistoryVersion();
        }

        private void qryBaWeitereAdressen_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            string mainMsg = KissMsg.GetMLMessage(CLASSNAME, "ConfirmDeleteOtherAddress", "Wollen Sie die Adresse {0} wirklich löschen?");
            string partMsg = "\r\n\r\n";

            if (!DBUtil.IsEmpty(qryBaWeitereAdressen[DBO.BaAdresse.Strasse]))
            {
                partMsg += qryBaWeitereAdressen[DBO.BaAdresse.Strasse] + "\r\n";
            }

            partMsg += qryBaWeitereAdressen[DBO.BaAdresse.PLZ] + " " + qryBaWeitereAdressen[DBO.BaAdresse.Ort] + "\r\n\r\n";

            qryBaWeitereAdressen.DeleteQuestion = String.Format(mainMsg, partMsg);
        }

        private void qryBaWeitereAdressen_BeforePost(object sender, EventArgs e)
        {
            edtPLZAufenthalt.DoValidate();

            // Kontrollieren, ob Adresstyp erfasst ist:
            if (DBUtil.IsEmpty(qryBaWeitereAdressen[DBO.BaAdresse.AdresseCode]))
            {
                cboAdresstyp.Focus();
                KissMsg.ShowInfo(CLASSNAME, "AdressTypLeer", "Der Adressetyp darf nicht leer sein.");
                throw new KissCancelException();
            }

            // Kontrollieren, dass Datum von kleiner als Datum bis ist:
            if (!DBUtil.IsEmpty(qryBaWeitereAdressen[DBO.BaAdresse.DatumVon]) &&
                !DBUtil.IsEmpty(qryBaWeitereAdressen[DBO.BaAdresse.DatumBis]))
            {
                if ((DateTime)qryBaWeitereAdressen[DBO.BaAdresse.DatumVon] >= (DateTime)qryBaWeitereAdressen[DBO.BaAdresse.DatumBis])
                {
                    edtAufenthaltVon.Focus();
                    KissMsg.ShowInfo(CLASSNAME, "DatumsFehler", "Das Von-Datum muss kleiner sein als das Bis-Datum.");
                    throw new KissCancelException();
                }
            }

            // Kontrollieren, dass es keine Überschneidungen im Datum gibt.
            int aktID = 0;

            if (!DBUtil.IsEmpty(qryBaWeitereAdressen[DBO.BaAdresse.BaAdresseID]))
            {
                aktID = (int)qryBaWeitereAdressen[DBO.BaAdresse.BaAdresseID];
            }

            string sqlStatement = string.Format(@"
                SELECT DatumVon,
                       DatumBis,
                       Strasse,
                       PLZ,
                       Ort
                FROM dbo.BaAdresse
                WHERE BaPersonID = {0}
                  AND NOT BaAdresseID = {1}
                  AND AdresseCode = {2}", BaPersonID, aktID, qryBaWeitereAdressen["AdresseCode"]);

            if (DBUtil.IsEmpty(qryBaWeitereAdressen[DBO.BaAdresse.DatumVon]) &&
                DBUtil.IsEmpty(qryBaWeitereAdressen[DBO.BaAdresse.DatumBis]))
            {
                // Wenn beide Daten des aktuellen Datensatzes leer sind,
                // dann darf kein anderer Datensatz existieren:
            }
            else if ((!DBUtil.IsEmpty(qryBaWeitereAdressen[DBO.BaAdresse.DatumVon])) &&
                      DBUtil.IsEmpty(qryBaWeitereAdressen[DBO.BaAdresse.DatumBis]))
            {
                // Wenn Datum von nicht leer ist, DatumBis aber leer ist,
                // dann darf es kein anderer Datensatz geben,
                // bei welchem ein Datum grösser als das DatumVon des aktuellen Datensatzes ist:
                sqlStatement += string.Format(@"
                    AND (DatumBis IS NULL OR DatumVon >= '{0}' OR DatumBis >= '{0}') ",
                    ((DateTime)qryBaWeitereAdressen[DBO.BaAdresse.DatumVon]).ToString("yyyyMMdd"));
            }
            else if (DBUtil.IsEmpty(qryBaWeitereAdressen[DBO.BaAdresse.DatumVon]) &&
                     (!DBUtil.IsEmpty(qryBaWeitereAdressen[DBO.BaAdresse.DatumBis])))
            {
                // Wenn Datum bis nicht leer ist, DatumVon aber leer ist,
                // dann darf es kein anderer Datensatz geben,
                // bei welchem ein Datum kleiner als das DatumBis des aktuellen Datensatzes ist:
                sqlStatement += string.Format(@"
                    AND (DatumVon IS NULL OR DatumVon <= '{0}' OR DatumBis <= '{0}') ",
                    ((DateTime)qryBaWeitereAdressen[DBO.BaAdresse.DatumBis]).ToString("yyyyMMdd"));
            }
            else
            {
                // Wenn DatumBis und DatumVon nicht leer ist,
                // dann darf es keine Überschneidungen geben:
                sqlStatement += string.Format(@"
                    AND ((DatumVon <= '{1}' AND DatumBis IS NULL)
                      OR (DatumBis >= '{0}' AND DatumVon IS NULL)
                      OR (DatumBis >= '{0}' AND DatumBis <= '{1}')
                      OR (DatumVon >= '{0}' AND DatumVon <= '{1}')
                      OR ('{0}' BETWEEN DatumVon AND DatumBis)) ",
                  ((DateTime)qryBaWeitereAdressen[DBO.BaAdresse.DatumVon]).ToString("yyyyMMdd"),
                  ((DateTime)qryBaWeitereAdressen[DBO.BaAdresse.DatumBis]).ToString("yyyyMMdd"));
            }

            if ((int)qryBaWeitereAdressen[DBO.BaAdresse.AdresseCode] != 99)
            {
                SqlQuery qryDat = DBUtil.OpenSQL(sqlStatement);

                if (qryDat.Count > 0)
                {
                    string tmpMsg = "";

                    if (!DBUtil.IsEmpty(qryDat[DBO.BaAdresse.Strasse]))
                    {
                        tmpMsg += (string)qryDat[DBO.BaAdresse.Strasse] + "\r\n";
                    }

                    tmpMsg += (string)qryDat[DBO.BaAdresse.PLZ] + " " + (string)qryDat[DBO.BaAdresse.Ort] + "\r\n\r\n";

                    string tmpTyp = cboAdresstyp.GetDisplayText(cboAdresstyp.EditValue);
                    edtAufenthaltVon.Focus();

                    KissMsg.ShowInfo(CLASSNAME,
                                     "TimeCrossingOtherAddress",
                                     "Es gibt mind. eine zeitliche Überschneidung, z.B. mit der Zeile:\r\n\r\n{0}" +
                                     "Ändern Sie das Datum von oder Datum bis des aktuellen Datensatzes oder ändern Sie zuerst das Von-Datum oder das Bis-Datum anderer Zeilen, welche den Adresstyp '{1}' haben.",
                                     tmpMsg,
                                     tmpTyp);

                    throw new KissCancelException();
                }
            }

            // Kontrollieren, ob Name der Insitutuion erfasst ist ist:
            // nur wenn die Adresse eine Institution ist:
            if (Utils.ConvertToInt(qryBaWeitereAdressen[DBO.BaAdresse.AdresseCode]) == 13)
            {
                if (DBUtil.IsEmpty(qryBaWeitereAdressen[DBO.BaAdresse.CareOf]))
                {
                    edtAufenthaltInstitutionName.Focus();
                    KissMsg.ShowInfo(CLASSNAME, "InstitutionNameLeer", "Der Institutionsname darf nicht leer sein.");
                    throw new KissCancelException();
                }
            }

            if (DBUtil.IsEmpty(qryBaWeitereAdressen[DBO.BaAdresse.PLZ]) &&
                Utils.isSchweiz(qryBaWeitereAdressen[DBO.BaAdresse.BaLandID]))
            {
                edtPLZAufenthalt.Focus();
                KissMsg.ShowInfo(CLASSNAME, "AdressPLZLeer", "Die Postleitzahl der Adresse darf nicht leer sein.");
                throw new KissCancelException();
            }

            if (DBUtil.IsEmpty(qryBaWeitereAdressen[DBO.BaAdresse.Ort]))
            {
                edtPLZAufenthalt.Focus();
                KissMsg.ShowInfo(CLASSNAME, "AdressOrtLeer", "Die Ortschaft der Adresse darf nicht leer sein.");
                throw new KissCancelException();
            }

            if (qryBaWeitereAdressen.RowModified)
            {
                qryBaWeitereAdressen.SetModifierModified();
                DBUtil.NewHistoryVersion();
            }
        }

        private void qryBaWeitereAdressen_PositionChanged(object sender, EventArgs e)
        {
            // Editieren einstellen
            EditModeType editMode = EditModeType.Normal;

            cboAdresstyp.EditMode = editMode;
            edtAufenthaltVon.EditMode = editMode;
            edtAufenthaltBis.EditMode = editMode;
            edtAufenthaltInstitutionName.EditMode = editMode;
            edtInstitutionLookup.EditMode = editMode;
            edtAufenthaltStrasse.EditMode = editMode;
            edtAufenthaltHausNr.EditMode = editMode;
            edtAufenthaltPostfach.EditMode = editMode;
            edtPLZAufenthalt.EditMode = editMode;

            edtPLZAufenthalt.EdtLand.LOVFilterWhereAppend = true;
            edtPLZAufenthalt.EdtLand.LOVName = "BaLand";

            AufenthaltPostfachOhneNrChanged();

            // raise event
            OnPositionChanged(AddressType.WeitereAdresse);
        }

        private void qryBaWeitereAdressen_PostCompleted(object sender, EventArgs e)
        {
            string careOfOrt;

            if (DBUtil.IsEmpty(qryBaWeitereAdressen[DBO.BaAdresse.CareOf]))
            {
                careOfOrt = string.Format("{0} {1}", qryBaWeitereAdressen[DBO.BaAdresse.PLZ], qryBaWeitereAdressen[DBO.BaAdresse.Ort]);
            }
            else
            {
                careOfOrt = Convert.ToString(qryBaWeitereAdressen[DBO.BaAdresse.CareOf]);
            }

            qryBaWeitereAdressen["CareOfOrt"] = careOfOrt;
        }

        private void qryBaWohnsitzAdresse_AfterDelete(object sender, EventArgs e)
        {
            // raise event
            OnAfterDelete(AddressType.WohnMeldeAdresse);
        }

        private void qryBaWohnsitzAdresse_AfterFill(object sender, EventArgs e)
        {
            // Position funzt auch nicht nach dem Öffnen des Fensters, später schon???
            qryBaWohnsitzAdresse.Position = qryBaWohnsitzAdresse.Count - 1;
        }

        private void qryBaWohnsitzAdresse_AfterInsert(object sender, EventArgs e)
        {
            qryBaWohnsitzAdresse[DBO.BaAdresse.BaPersonID] = _baPersonID;
            qryBaWohnsitzAdresse[DBO.BaAdresse.AdresseCode] = 1;
            qryBaWohnsitzAdresse[DBO.BaAdresse.BaLandID] = Session.BaLandCodeSchweiz;
            qryBaWohnsitzAdresse.SetCreator();

            edtWohnsitzVon.Focus();

            // raise event
            OnAfterInsert(AddressType.WohnMeldeAdresse);
        }

        private void qryBaWohnsitzAdresse_BeforeDelete(object sender, EventArgs e)
        {
            DBUtil.NewHistoryVersion();
        }

        private void qryBaWohnsitzAdresse_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            string mainMsg = KissMsg.GetMLMessage(CLASSNAME, "ConfirmDeleteResidenceMain", "Wollen Sie den Wohnsitz{0}wirklich löschen?");
            string tmpMsg = "\r\n\r\n";

            if (!DBUtil.IsEmpty(qryBaWohnsitzAdresse[DBO.BaAdresse.Strasse]))
            {
                tmpMsg += qryBaWohnsitzAdresse[DBO.BaAdresse.Strasse] + "\r\n";
            }

            tmpMsg += qryBaWohnsitzAdresse[DBO.BaAdresse.PLZ] + " " + qryBaWohnsitzAdresse[DBO.BaAdresse.Ort] + "\r\n\r\n";

            qryBaWohnsitzAdresse.DeleteQuestion = String.Format(mainMsg, tmpMsg);
        }

        private void qryBaWohnsitzAdresse_BeforePost(object sender, EventArgs e)
        {
            edtPLZWohnsitz.DoValidate();

            // Kontrollieren, dass Datum von kleiner als Datum bis ist:
            if (!DBUtil.IsEmpty(qryBaWohnsitzAdresse[DBO.BaAdresse.DatumVon]) &&
                !DBUtil.IsEmpty(qryBaWohnsitzAdresse[DBO.BaAdresse.DatumBis]))
            {
                if ((DateTime)qryBaWohnsitzAdresse[DBO.BaAdresse.DatumVon] >= (DateTime)qryBaWohnsitzAdresse[DBO.BaAdresse.DatumBis])
                {
                    edtWohnsitzVon.Focus();
                    KissMsg.ShowInfo(CLASSNAME, "DatumsFehler", "Das Von-Datum muss kleiner sein als das Bis-Datum.");
                    throw new KissCancelException();
                }
            }

            // Kontrollieren, dass es keine Überschneidungen im Datum gibt.
            int aktID = 0;

            if (!DBUtil.IsEmpty(qryBaWohnsitzAdresse[DBO.BaAdresse.BaAdresseID]))
            {
                aktID = (int)qryBaWohnsitzAdresse[DBO.BaAdresse.BaAdresseID];
            }

            string sqlStatement = string.Format(@"
                SELECT DatumVon,
                       DatumBis,
                       Strasse,
                       PLZ,
                       Ort
                FROM dbo.BaAdresse
                WHERE AdresseCode = 1
                  AND BaPersonID = {0}
                  AND NOT BaAdresseID = {1}", BaPersonID, aktID);

            if (DBUtil.IsEmpty(qryBaWohnsitzAdresse[DBO.BaAdresse.DatumVon]) &&
                DBUtil.IsEmpty(qryBaWohnsitzAdresse[DBO.BaAdresse.DatumBis]))
            {
                // Wenn beide Daten des aktuellen Datensatzes leer sind,
                // dann darf kein anderer Datensatz existieren:
            }
            else if ((!DBUtil.IsEmpty(qryBaWohnsitzAdresse[DBO.BaAdresse.DatumVon])) &&
                      DBUtil.IsEmpty(qryBaWohnsitzAdresse[DBO.BaAdresse.DatumBis]))
            {
                // Wenn Datum von nicht leer ist, DatumBis aber leer ist,
                // dann darf es kein anderer Datensatz geben,
                // bei welchem ein Datum grösser als das DatumVon des aktuellen Datensatzes ist:
                sqlStatement += string.Format(@"
                    AND (DatumBis IS NULL OR DatumVon >= '{0}' OR DatumBis >= '{0}') ",
                    ((DateTime)qryBaWohnsitzAdresse[DBO.BaAdresse.DatumVon]).ToString("yyyyMMdd"));
            }
            else if (DBUtil.IsEmpty(qryBaWohnsitzAdresse[DBO.BaAdresse.DatumVon]) &&
                     (!DBUtil.IsEmpty(qryBaWohnsitzAdresse[DBO.BaAdresse.DatumBis])))
            {
                // Wenn Datum bis nicht leer ist, DatumVon aber leer ist,
                // dann darf es kein anderer Datensatz geben,
                // bei welchem ein Datum kleiner als das DatumBis des aktuellen Datensatzes ist:
                sqlStatement += string.Format(@"
                    AND (DatumVon IS NULL OR DatumVon <= '{0}' OR DatumBis <= '{0}') ",
                    ((DateTime)qryBaWohnsitzAdresse[DBO.BaAdresse.DatumBis]).ToString("yyyyMMdd"));
            }
            else
            {
                // Wenn DatumBis und DatumVon nicht leer ist,
                // dann darf es keine Überschneidungen geben:
                sqlStatement += string.Format(@"
                    AND ((DatumVon <= '{1}' AND DatumBis IS NULL)
                      OR (DatumBis >= '{0}' AND DatumVon IS NULL)
                      OR (DatumBis >= '{0}' AND DatumBis <= '{1}')
                      OR (DatumVon >= '{0}' AND DatumVon <= '{1}')) ",
                    ((DateTime)qryBaWohnsitzAdresse[DBO.BaAdresse.DatumVon]).ToString("yyyyMMdd"),
                    ((DateTime)qryBaWohnsitzAdresse[DBO.BaAdresse.DatumBis]).ToString("yyyyMMdd"));
            }

            SqlQuery qryDat = DBUtil.OpenSQL(sqlStatement);

            if (qryDat.Count > 0)
            {
                string tmpMsg = "";

                if (!DBUtil.IsEmpty(qryDat[DBO.BaAdresse.Strasse]))
                {
                    tmpMsg += (string)qryDat[DBO.BaAdresse.Strasse] + "\r\n";
                }

                tmpMsg += (string)qryDat[DBO.BaAdresse.PLZ] + " " + (string)qryDat[DBO.BaAdresse.Ort] + "\r\n\r\n";

                string[] msgList = { tmpMsg };

                edtWohnsitzVon.Focus();

                KissMsg.ShowInfo(CLASSNAME,
                                 "TimeCrossingResidence",
                                 "Es gibt mind. eine zeitliche Überschneidung, z.B. mit der Zeile:\r\n\r\n{0}" +
                                 "Ändern Sie das Datum von oder Datum bis des aktuellen Datensatzes oder ändern Sie zuerst das Von-Datum oder das Bis-Datum anderer Zeilen.",
                                 msgList);

                throw new KissCancelException();
            }

            if (DBUtil.IsEmpty(qryBaWohnsitzAdresse[DBO.BaAdresse.PLZ]) &&
                Utils.isSchweiz(qryBaWohnsitzAdresse[DBO.BaAdresse.BaLandID]))
            {
                // PLZ darf nicht leer sein:
                edtPLZWohnsitz.EdtPLZ.Focus();
                KissMsg.ShowInfo(CLASSNAME, "AdressPLZLeer", "Die Postleitzahl der Adresse darf nicht leer sein.");
                throw new KissCancelException();
            }

            if (DBUtil.IsEmpty(qryBaWohnsitzAdresse[DBO.BaAdresse.Ort]))
            {
                // Ort darf nicht leer sein:
                edtPLZWohnsitz.EdtOrt.Focus();
                KissMsg.ShowInfo(CLASSNAME, "AdressOrtLeer", "Die Ortschaft der Adresse darf nicht leer sein.");
                throw new KissCancelException();
            }

            if (qryBaWohnsitzAdresse.RowModified)
            {
                qryBaWohnsitzAdresse.SetModifierModified();
                DBUtil.NewHistoryVersion();
            }
        }

        private void qryBaWohnsitzAdresse_PositionChanged(object sender, EventArgs e)
        {
            WohnsitzPostfachOhneNrChanged();

            // raise event
            OnPositionChanged(AddressType.WohnMeldeAdresse);
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Activate()
        {
            if (edtWohnsitzVon.EditMode.Equals(EditModeType.Normal))
            {
                edtWohnsitzVon.Focus();
            }
            else
            {
                edtAufenthaltVon.Focus();
            }
        }

        public DateTime? GetDatumAufenthalt()
        {
            return edtAufenthaltVon.EditValue as DateTime?;
        }

        public DateTime? GetDatumWohnsitz()
        {
            return edtWohnsitzVon.EditValue as DateTime?;
        }

        /// <summary>
        /// Selects the address with the given <paramref name="baAdresseId"/>
        /// </summary>
        /// <param name="baAdresseId">ID of the address to search</param>
        /// <returns><c>true</c> if the address could be found, else <c>false</c></returns>
        public bool SelectBaAdresse(int baAdresseId)
        {
            var hasAdresse = qryBaWohnsitzAdresse.Find(string.Format("BaAdresseID={0}", baAdresseId));
            edtWohnsitzVon.Focus();

            if (!hasAdresse)
            {
                hasAdresse = qryBaWeitereAdressen.Find(string.Format("BaAdresseID={0}", baAdresseId));
                edtAufenthaltVon.Focus();
            }

            return hasAdresse;
        }

        public void SetNames(string vorname, string nachname)
        {
            edtName.Text = nachname;
            edtVorname.Text = vorname;
        }

        public void SetRights()
        {
            // check if need to set rights automatically
            if (!AutoSetRights)
            {
                return;
            }

            // apply rights
            qryBaWohnsitzAdresse.ApplyUserRights();
            qryBaWeitereAdressen.ApplyUserRights();

            // setup controls
            qryBaWohnsitzAdresse.EnableBoundFields();
            qryBaWeitereAdressen.EnableBoundFields();
        }

        /// <summary>
        /// Set rights manually and disable AutoSetRights
        /// </summary>
        /// <param name="canInsertUpdateDelete"><c>True</c> if user can insert, update and delete address records, otherwise <c>False</c></param>
        public void SetRights(bool canInsertUpdateDelete)
        {
            SetRights(canInsertUpdateDelete, canInsertUpdateDelete, canInsertUpdateDelete);
        }

        /// <summary>
        /// Set rights manually and disable AutoSetRights
        /// </summary>
        /// <param name="canInsert"><c>True</c> if user can insert new address records, otherwise <c>False</c></param>
        /// <param name="canUpdate"><c>True</c> if user can update existing address records, otherwise <c>False</c></param>
        /// <param name="canDelete"><c>True</c> if user can delete existing address records, otherwise <c>False</c></param>
        public void SetRights(bool canInsert, bool canUpdate, bool canDelete)
        {
            // disable auto-set-rights
            AutoSetRights = false;

            // setup queries
            qryBaWohnsitzAdresse.CanInsert = canInsert;
            qryBaWohnsitzAdresse.CanUpdate = canUpdate;
            qryBaWohnsitzAdresse.CanDelete = canDelete;

            qryBaWeitereAdressen.CanInsert = canInsert;
            qryBaWeitereAdressen.CanUpdate = canUpdate;
            qryBaWeitereAdressen.CanDelete = canDelete;

            // setup controls
            qryBaWohnsitzAdresse.EnableBoundFields();
            qryBaWeitereAdressen.EnableBoundFields();
        }

        #endregion

        #region Private Methods

        private void AufenthaltPostfachOhneNrChanged()
        {
            UtilsGui.TogglePostfachOhneNrEdit(chkAufenthaltPostfachOhneNr, edtAufenthaltPostfach, qryBaWeitereAdressen.CanUpdate);
        }

        /// <summary>
        /// Get list of buttons defined as 0:Residence, 1:OtherAddress, 2:Cancel
        /// </summary>
        /// <returns>Array of buttons suitable for dialog</returns>
        private string[] GetButtonList()
        {
            string btnResidence = KissMsg.GetMLMessage(CLASSNAME, "btnResidence", "&Wohnsitz");
            string btnOtherAddress = KissMsg.GetMLMessage(CLASSNAME, "btnOtherAddress", "Andere &Adresse");
            string btnCancel = KissMsg.GetMLMessage(CLASSNAME, "btnCancel", "A&bbrechen");

            string[] buttonList = { btnResidence, btnOtherAddress, btnCancel };

            return buttonList;
        }

        private bool LeftSideHasFokus()
        {
            return (grdBaWohnsitzAdresse.Focused ||
                    edtWohnsitzVon.Focused ||
                    edtWohnsitzBis.Focused ||
                    cboAdresstypWohnsitz.Focused ||
                    edtWohnsituationsCode.Focused ||
                    edtWohnungsgroesseCode.Focused ||
                    edtName.Focused ||
                    edtVorname.Focused ||
                    edtWohnsitzZusatz.Focused ||
                    edtWohnsitzStrasse.Focused ||
                    edtNummerWohnsitz.Focused ||
                    edtWohnsitzPostfach.Focused ||
                    chkWohnsitzPostfachOhneNr.Focused ||
                    edtPLZWohnsitz.Focused);
        }

        private void OnAfterDelete(AddressType addressType)
        {
            // notify if any assigned
            if (AfterDelete != null)
            {
                AfterDelete(addressType);
            }
        }

        private void OnAfterInsert(AddressType addressType)
        {
            // notify if any assigned
            if (AfterInsert != null)
            {
                AfterInsert(addressType);
            }
        }

        private void OnPositionChanged(AddressType addressType)
        {
            // notify if any assigned
            if (PositionChanged != null)
            {
                PositionChanged(addressType);
            }
        }

        private void WohnsitzPostfachOhneNrChanged()
        {
            UtilsGui.TogglePostfachOhneNrEdit(chkWohnsitzPostfachOhneNr, edtWohnsitzPostfach, qryBaWohnsitzAdresse.CanUpdate);
        }

        #endregion

        #endregion
    }
}
