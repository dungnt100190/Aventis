using System;
using System.Windows.Forms;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Main
{
    public partial class DlgErfassungPerson : KiSS4.Gui.KissDialog
    {
        #region Fields

        #region Private Fields

        private ISuchePerson _ctlSuchePerson;
        private int _falltraegerID;
        private int _newBaPersonID;

        #endregion

        #endregion

        #region Constructors

        public DlgErfassungPerson(int falltraegerID)
            : this()
        {
            _falltraegerID = falltraegerID;
            _ctlSuchePerson = AssemblyLoader.CreateInstance("CtlSuchePerson") as ISuchePerson;

            Control ctlSuchePersonControl = _ctlSuchePerson as Control;
            ctlSuchePersonControl.Dock = DockStyle.Fill;
            pnlFill.Controls.Add(ctlSuchePersonControl);
        }

        public DlgErfassungPerson()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Properties

        public int FalltraegerID
        {
            get { return _falltraegerID; }
        }

        public int NewBaPersonID
        {
            get { return _newBaPersonID; }
        }

        #endregion

        #region EventHandlers

        private void DlgErfassungPerson_Load(object sender, System.EventArgs e)
        {
            edtBaRelationID.LoadQuery(DBUtil.OpenSQL(@"
                SELECT Code = BaRelationID, 
                       Text = NameGenerisch1
                FROM dbo.BaRelation WITH (READUNCOMMITTED)

                UNION ALL

                SELECT Code = BaRelationID + 100, 
                       Text = NameGenerisch2 
                FROM dbo.BaRelation WITH (READUNCOMMITTED)
                WHERE NameGenerisch1 <> NameGenerisch2
                ORDER BY 2"));

            edtBaRelationID.EditValue = 29; //Unbekannt
        }

        private void btnNeuePerson_Click(object sender, EventArgs e)
        {
            if (DBUtil.IsEmpty(edtBaRelationID.EditValue))
            {
                throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                 "BeziehungFalltraegerLeer",
                                                                 "Das Feld 'Beziehung zu Fallträger/-in' darf nicht leer bleiben!",
                                                                 KissMsgCode.MsgInfo));
            }

            int? baRelatedPersonIDNillable = null;

            try
            {
                Cursor = Cursors.WaitCursor;
                baRelatedPersonIDNillable = _ctlSuchePerson.GetPersonIDCreateIfNecessary(false);

                if (!baRelatedPersonIDNillable.HasValue)
                {
                    // ctlSuchePerson notifiziert die Probleme bereits selber. Keine MsgBox nötig.
                    return;
                }
            }
            catch
            {
                return;
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            try
            {
                // check tabpage
                if (_ctlSuchePerson.SelectedTabIndex == 0)
                {
                    int selectedBaPersonID = baRelatedPersonIDNillable.Value;

                    //Prüfen, ob die neue Person die Fallträgerin selbst ist
                    if (selectedBaPersonID == this._falltraegerID)
                    {
                        throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                         "PersonIstFalltraeger",
                                                                         "Diese Person ist der/die Fallträger/-in!",
                                                                         KissMsgCode.MsgInfo));
                    }

                    //Prüfen, ob diese Person bereits im Klientensystem besteht
                    int count = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                        SELECT COUNT(1)
                        FROM dbo.BaPerson_Relation WITH (READUNCOMMITTED)
                        WHERE (BaPersonID_1 = {0} AND BaPersonID_2 = {1})
                           OR (BaPersonID_1 = {1} AND BaPersonID_2 = {0})", selectedBaPersonID, this._falltraegerID));

                    if (count > 0)
                    {
                        throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                         "PersonImKlientensystem",
                                                                         "Diese Person gehört bereits zum Klientensystem.",
                                                                         KissMsgCode.MsgInfo));
                    }
                }

                // apply value
                this._newBaPersonID = baRelatedPersonIDNillable.Value;

                //neue Person zu Klientensystem hinzufügen
                object baPersonID_1;
                object baPersonID_2;
                int baPersonRelationID;

                if (Convert.ToInt32(edtBaRelationID.EditValue) < 100)
                {
                    baPersonID_1 = this._newBaPersonID;
                    baPersonID_2 = this._falltraegerID;
                    baPersonRelationID = Convert.ToInt32(edtBaRelationID.EditValue);
                }
                else
                {
                    baPersonID_1 = this._falltraegerID;
                    baPersonID_2 = this._newBaPersonID;
                    baPersonRelationID = Convert.ToInt32(edtBaRelationID.EditValue) - 100;
                }

                // do this in a transaction
                Session.BeginTransaction();

                try
                {
                    // insert relation and create cost center
                    DBUtil.ExecSQLThrowingException(@"
                        INSERT INTO dbo.BaPerson_Relation (BaPersonID_1, BaPersonID_2, BaRelationID)
                        VALUES ({0}, {1}, {2})", baPersonID_1, baPersonID_2, baPersonRelationID);

                    DBUtil.ExecSQLThrowingException(@"
                        EXEC dbo.spKbKostenstelleAnlegen {0}, {1}", this._newBaPersonID, Session.User.UserID);

                    // commit changes
                    Session.Commit();

                    // done
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    // undo changes
                    Session.Rollback();

                    // throw exception further on
                    throw ex;
                }
            }
            catch (KissCancelException ex)
            {
                ex.ShowMessage();
            }
            catch (Exception ex)
            {
                throw new KissErrorException(KissMsg.GetMLMessage(this.Name,
                                                                  "FehlerBeiAnlegenPerson",
                                                                  "Beim Anlegen der neuen Person ist ein Fehler aufgetreten.",
                                                                  KissMsgCode.MsgError), ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        #endregion
    }
}