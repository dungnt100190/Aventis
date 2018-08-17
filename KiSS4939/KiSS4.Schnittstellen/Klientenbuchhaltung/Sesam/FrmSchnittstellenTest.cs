using System;
using System.Collections;
using Interop.FibuSDK;
using KiSS4.DB;

namespace KiSS4.Schnittstellen.Sesam
{
    public partial class FrmSchnittstellenTest : KiSS4.Gui.KissChildForm
    {
        private static readonly log4net.ILog LOG = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region Constructors

        public FrmSchnittstellenTest()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Private Methods

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {

                //Type type = Type.GetTypeFromProgID("FibuNT.Mandant", true);
                //Type type = Type.GetTypeFromProgID("FibuNT.Mandant", "chbevw001", true);
                //object o = 
                Mandant mandant = new Interop.FibuSDK.OMandantClass();

                mandant.Login(1, null, null);

                if (String.IsNullOrEmpty(mandant.Name))
                {
                    mandant.Login(1, @"\\chbevw001\SesamDaten\Rewe\Test2", "1234");
                }

                //Type type = Type.GetTypeFromProgID("FibuNT.Mandant", true);
                //mandant = (Mandant) Activator.CreateInstance(type);
                //mandant.Login(1, null, null);

                this.Text = mandant.Name;

                this.GetKostenstelle(mandant);

            }
            catch (Exception ex)
            {
                KissMsg.ShowError("Error occured!", ex);
            }
        }


        protected void GetKostenstelle(Mandant mandant)
        {
            Konto konto = (Konto)mandant.NeuKonto();

            if (konto == null)
            {
                return;
            }

            for (int iK = konto.LesenRel(0); iK == 0; iK = konto.LesenRel(3))
            {
                string kontoNr = konto.KontoNr;

                int nr = kontoNr.IndexOf('.');
                if (nr >= 0)
                    try { nr = int.Parse(kontoNr.Substring(0, nr)); }
                    catch { continue; }
                else
                    try { nr = int.Parse(kontoNr); }
                    catch { continue; }


                string nameInhaber = konto.Bezeichnung + " " + konto.Bezeichnung2;
                nameInhaber.Trim();

            }
        }


        #endregion

        private void btnTransferKreditoren_Click(object sender, EventArgs e)
        {
            this.TransferKreditoren();
        }

        //protected override KiSS4.FibuLink.Kreditor[] GetKreditorListCore(CancelProvider cp)
        protected void TransferKreditoren()
        {
            Mandant mandant = new Interop.FibuSDK.OMandantClass();
            // open new mandant with type 3 (Kreditor)
            mandant.Login(3, @"\\chbevw001\SesamDaten\Rewe\Test2", null);

            //PK pk = m.NeuPK();
            //Adresse pkAdr = m.NeuAdresse();
            //BankStamm pkBankStamm = m.NeuBankStamm();

            PkSet pk = (PkSet)mandant.NeuPK();
            Adresse pkAdr = (Adresse)mandant.NeuAdresse();
            //Bank bank = mandant.
            //BankStamm pkBankStamm = m.NeuBankStamm();

            object o = mandant.NeuObjekt(14);

            BankLSet bankStamm = (BankLSet) mandant.NeuObjekt(14);
            ArrayList krediAL = new ArrayList();
            for (int iPK = pk.LesenRel(0); iPK == 0; iPK = pk.LesenRel(3))
            {
                //    string pkAdressID = pk.AdressID;
                //    string pkBankId = pk.BankId;
                //    string pkBankKto = pk.BankKto;
                //    string pkBankNr = pk.BankNr;
                //    string pkIndex = pk.PkIndex;
                //    int pkNr = pk.PkNr;

                //    bool hasAdr = false;
                //    if (pkAdressID != string.Empty)
                //        try { pkAdr.Lesen(pkAdressID); hasAdr = true; }
                //        catch (Exception) { }

                //    bool hasBankStamm = false;
                //    if (pkBankId != string.Empty)
                //        try { pkBankStamm.Lesen(pkBankId); hasBankStamm = true; }
                //        catch (Exception) { }

                //    //Zahlungsweg zw;
                //    #region zw
                //    if (hasBankStamm)
                //    {
                //        string plz = string.Empty;
                //        string ort = pkBankStamm.Text4;
                //        Match match = rxPlzOrt.Match(ort);
                //        if (match.Success)
                //        {
                //            plz = match.Groups["PLZ"].Value;
                //            ort = match.Groups["Ort"].Value;
                //        }

                //        string bankPcKonto = KiSS4.Common.Utils.FormatPCKontoNummerToUserFormat(pk.PkIndex);

                //        //zw = new Zahlungsweg(pkNr, pkBankStamm.Text1, pk.BankKto, bankPcKonto, pk.PkIndex, pkBankStamm.Text2, plz, ort, pk.BankId, "Bank");
                //    }
                //    else if (pkBankKto != string.Empty)
                //    {
                //        string esr = string.Empty;
                //        try { esr = Utils.FormatPCKontoNummerToDBFormat(pkBankKto); }
                //        catch { }
                //        if (hasAdr)
                //            zw = new Zahlungsweg(pkNr, pkAdr.Firma, pkBankKto, string.Empty, esr, pkAdr.Strasse, pkAdr.PLZ, pkAdr.Ort, string.Empty, "Post");
                //        else
                //            zw = new Zahlungsweg(pkNr, pkAdr.Firma, pkBankKto, string.Empty, esr, string.Empty, string.Empty, string.Empty, string.Empty, "Post");
                //    }
                //    else
                //        zw = null;
                //    #endregion

                //    Kreditor kredi;
                //    if (hasAdr)
                //        kredi = new Kreditor(pkNr, pkAdr.Firma, string.Empty, pkAdr.Strasse, pkAdr.PLZ, pkAdr.Ort, pkNr, zw);
                //    else
                //        kredi = new Kreditor(pkNr, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, pkNr, zw);

                //    krediAL.Add(kredi);
                //}

                //ret = (Kreditor[])krediAL.ToArray(typeof(Kreditor));
            }
        }

        private void btnBuchen_Click(object sender, EventArgs e)
        {
            this.ErstelleBuchungInSesam();
        }

        private void ErstelleBuchungInSesam()
        {
            //open new mandant with type 3 (Kreditor) --> //TODO ck warum 3 Kreditor?
            Mandant mandant = new Interop.FibuSDK.OMandantClass();
            mandant.Login(3, @"\\chbevw001\SesamDaten\Rewe\Test2009", null);


            int AnzBuchungen = mandant.AnzBuchungen();
            for (int i = 0; i < AnzBuchungen; i++)
            {
                mandant.BelegLoeschen(i);
            }


            //Beleg beleg = (Beleg)mandant.NeuBeleg();
            int result = -1;
            //result = beleg.Buchen(DateTime.Today, true, "6000", "Sesam öffne Dich!", 666);
            //result = beleg.Buchen(DateTime.Today, false, "6000", "Sesam öffne Dich!", 666);
            //beleg.Einfuegen(mandant);

            //result = beleg.BuchenSt(DateTime.Today, true, "6100", null, "Sesam öffne Dich!", 666, 0, 0, 0);
            //result = beleg.BuchenSt(DateTime.Today, false, "6100", null, "Sesam öffne Dich!", 666, 0, 0, 0);
            //beleg.Einfuegen(mandant);

            //result = beleg.Buchen2(DateTime.Today, true, "6101", null, "Sesam öffne Dich!", 666, 0);
            //result = beleg.Buchen2(DateTime.Today, false, "6101", null, "Sesam öffne Dich!", 666, 0);
            //beleg.Einfuegen(mandant);

            //result = beleg.BuchungAufOP(mandant, "1", true);
            //result = beleg.BuchungAufOP(mandant, "1", false);
            //beleg.Einfuegen(mandant);

            //result = beleg.BuchungAufOP(mandant, "2", false);
            //beleg.Einfuegen(mandant);

            //result = beleg.BuchungAufOP(mandant, "3", true);
            //beleg.Einfuegen(mandant);

            
            //Interop.FibuSDK.OOpSet op = mandant.NeuOP();
            object o = mandant.NeuOP();

            try
            {
                Interop.FibuSDK.OOpSet op = (OOpSet)o;
                op.Initialisieren(6000);
                op.Initialisieren(2);
                op.OpNr = mandant.FreieOpNr("0");
                op.Datum = DateTime.Today;

                result = op.Einfuegen();

                op.Faellig =DateTime.Today.AddDays(30);
                result = op.Schreiben();
            }
            catch (Exception ex)
            {
                // Eintrag ins Log.
                LOG.ErrorFormat("Fehler in: [{0}]. Exception: [{1}]", GetType().FullName, ex.Message);

                // Eintrag ins Log (Ansicht unter Anwendung/Newod Schnittstelle/Protokolle)
                XLog.Create(GetType().FullName, LogLevel.ERROR, ex.Message);
            }

            //result = beleg.AnzBuchungen();

        }
    }
}

#region kiss3  sst GetKreditorListCore
        //protected override KiSS4.FibuLink.Kreditor[] GetKreditorListCore(CancelProvider cp)
        //{
        //    MandantPeriode mp = (MandantPeriode) this.SelectedManPer;
        //    if (mp == null) throw new ApplicationException("Mandant/Periode nicht selektiert.");

        //    Kreditor[] ret;

        //    // open new mandant with type 3 (Kreditor)
        //    Mandant m = new Mandant();
        //    using (m)
        //    {
        //        m.Login(3, mp.SesamMandant.Pfad, mp.SesamMandant.Passwort);

        //        PK pk = m.NeuPK();
        //        Adresse pkAdr = m.NeuAdresse();
        //        BankStamm pkBankStamm = m.NeuBankStamm();

        //        ArrayList krediAL = new ArrayList();
        //        for (int iPK = pk.LesenRel(0); iPK == 0; iPK = pk.LesenRel(3))
        //        {
        //            if (cp != null && cp()) return null;

        //            string pkAdressID = pk.AdressID;
        //            string pkBankId = pk.BankId;
        //            string pkBankKto = pk.BankKto;
        //            string pkBankNr = pk.BankNr;
        //            string pkIndex = pk.PkIndex;
        //            int pkNr = pk.PKNr;

        //            bool hasAdr = false;
        //            if (pkAdressID != string.Empty)
        //                try { pkAdr.Lesen(pkAdressID); hasAdr = true;}
        //                catch (SesamException) {}

        //            bool hasBankStamm = false;
        //            if (pkBankId != string.Empty)
        //                try { pkBankStamm.Lesen(pkBankId); hasBankStamm = true; }
        //                catch (SesamException) {}

        //            Zahlungsweg zw;
        //            #region zw
        //            if (hasBankStamm )
        //            {
        //                string plz = string.Empty;
        //                string ort = pkBankStamm.Text4;
        //                Match match = rxPlzOrt.Match(ort);
        //                if (match.Success)
        //                {
        //                    plz = match.Groups["PLZ"].Value; 
        //                    ort = match.Groups["Ort"].Value;
        //                }
						
        //                string bankPcKonto = KiSS4.Common.Utils.FormatPCKontoNummerToUserFormat(pk.PkIndex);

        //                zw = new Zahlungsweg(pkNr, pkBankStamm.Text1, pk.BankKto, bankPcKonto, pk.PkIndex, pkBankStamm.Text2, plz, ort, pk.BankId, "Bank");
        //            }
        //            else if (pkBankKto != string.Empty) 
        //            {
        //                string esr = string.Empty;
        //                try { esr = Utils.FormatPCKontoNummerToDBFormat(pkBankKto); } catch {}
        //                if (hasAdr)
        //                    zw = new Zahlungsweg(pkNr, pkAdr.Firma, pkBankKto, string.Empty, esr, pkAdr.Strasse, pkAdr.PLZ, pkAdr.Ort, string.Empty, "Post");
        //                else
        //                    zw = new Zahlungsweg(pkNr, pkAdr.Firma, pkBankKto, string.Empty, esr, string.Empty, string.Empty, string.Empty, string.Empty, "Post");
        //            }
        //            else
        //                zw = null;
        //            #endregion

        //            Kreditor kredi;
        //            if (hasAdr)
        //                kredi = new Kreditor(pkNr, pkAdr.Firma, string.Empty, pkAdr.Strasse, pkAdr.PLZ, pkAdr.Ort, pkNr, zw);
        //            else
        //                kredi = new Kreditor(pkNr, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, pkNr, zw);
				
        //            krediAL.Add(kredi);
        //        }

        //        ret = (Kreditor[]) krediAL.ToArray(typeof(Kreditor));
        //    }
        //    return ret;
        //}
#endregion

#region KiSS3 SST TransferBeleg
        //public override KiSS4.FibuLink.FibuEnvironment.TransferBelegResult TransferBeleg(KiSS4.FibuLink.FibuEnvironment.IBeleg beleg, bool autoBelegnummer)
        //        {
        //            // TODO: test. this code has never run successfully because of incomplete date in FibuNT.
        //            bool inserted = false;
        //            try
        //            {
        //                MandantPeriode mp = (MandantPeriode) this.SelectedManPer;
        //                if (mp == null) throw new ApplicationException("Mandant/Periode nicht selektiert.");

        //                // open new mandant with type 3 (Kreditor)
        //                Mandant m = new Mandant();
        //                using (m)
        //                {
        //                    string opNr = string.Empty;
        //                    int laufNr = 0;

        //                    m.Login(3, mp.SesamMandant.Pfad, mp.SesamMandant.Passwort);

        //                    switch (beleg.Transfer)
        //                    {
        //                        case FlTransfer.Elektronisch:
        //                            // open OP object
        //                            OP op = m.NeuOP();
        //                            op.Initialisieren(beleg.IdKreditor);

        //                            if (!autoBelegnummer) // this should always be the case
        //                                opNr = beleg.Belegnummer;
        //                            else if (beleg.TypSource == 105)
        //                                opNr = m.FreieOpNr(this.opNrBase_Einzelzahlung);
        //                            else
        //                                opNr = m.FreieOpNr(this.opNrBase);

        //                            op.OPNr = opNr;
        //                            op.BetragFaktura = beleg.Betrag;
        //                            op.Referenz = beleg.ESR;
        //                            op.Text = beleg.Buchungstext.Length <= 31 ? beleg.Buchungstext : beleg.Buchungstext.Substring(0, 31);
        //                            op.Faellig = beleg.Verfalldatum;
        //                            op.FibuDatum = beleg.Buchungsdatum;

        //                            op.Einfügen();
        //                            laufNr = int.Parse(opNr);
        //                            break;

        //                        case FlTransfer.Kasse:
        //                            laufNr = m.FreieBelegNr(belegNrBase);
        //                            break;
        //                    }
        //                    inserted = true; // from here on, exceptions are rethrown

        //                    Wrappers.Beleg sesamBel = m.NeuBeleg();

        //                    foreach (IBelegKostenart ka in beleg.Kostenarten)
        //                        foreach (IBelegKostenstelle kst in ka.Kostenstellen)
        //                        {
        //                            // Die Soll-Buchung geht auf ein Fibu-Konto
        //                            sesamBel.Buchen2(beleg.Rechnungsdatum, false, kst.NrmKonto, kst.NameFbKostenstelle, ka.Intern, kst.Betrag, 0);

        //                            switch (beleg.Transfer)
        //                            {
        //                                case FlTransfer.Elektronisch:
        //                                    // Die Haben-Buchung geht auf den Kreditor (OP)
        //                                    sesamBel.BuchungAufOP(m, opNr, false); // false: Beleg ist keine Entstehungsbuchung für den OP
        //                                    sesamBel.Buchen(beleg.Rechnungsdatum, true, string.Empty, ka.Intern, kst.Betrag);
        //                                    break;

        //                                case FlTransfer.Kasse:
        //                                    sesamBel.Buchen(beleg.Rechnungsdatum, true, this.kontoKasse, ka.Intern, kst.Betrag);
        //                                    break;
        //                            }
        //                        }

        //                    sesamBel.SetBelegNr(laufNr);
        //                    sesamBel.Einfügen(m);
        //                    sesamBel.Leeren();

        //                    return TransferBelegResult.OK(laufNr, laufNr.ToString());
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                if (inserted) throw; // uncertain result
        //                return TransferBelegResult.Error(ex.Message);
        //            }
        //        }
#endregion