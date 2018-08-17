using System;
using KiSS4.DB;

namespace KiSS4.Klientenbuchhaltung.BL.Internal
{
    public class KlibuEnvironmentInternal : KlibuEnvironment
    {
        private int _kbMandantID = 0;
        private int _kbPeriodeID = 0;
        private string _mandantBezeichnung;
        private DateTime _periodeBis;
        private DateTime _periodeVon;

        public KlibuEnvironmentInternal()
        {
            this.GetData();
        }

        public override bool IsLoggedOn
        {
            get
            {
                return this.PeriodeID > 0;
            }
        }

        public override KlibuSystem KlibuSystem
        {
            get
            {
                return KlibuSystem.Integriert;
            }
        }

        public override string MandantBezeichnung
        {
            get
            {
                return _mandantBezeichnung;
            }
            protected set
            {
                _mandantBezeichnung = value;
            }
        }

        public override int MandantID
        {
            get
            {
                if (_kbMandantID <= 0)
                {
                    _kbMandantID = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                        SELECT PRD.KbMandantID
                        FROM KbPeriode_User    PUS
                          INNER JOIN KbPeriode PRD ON PRD.KbPeriodeID = PUS.KbPeriodeID
                        WHERE UserID = {0}", Session.User.UserID));
                }
                return _kbMandantID;
            }
            protected set
            {
                this._kbMandantID = value;
            }
        }

        public override DateTime PeriodeBis
        {
            get
            {
                return _periodeBis;
            }
            protected set
            {
                _periodeBis = value;
            }
        }

        public override int PeriodeID
        {
            get
            {
                if (_kbPeriodeID <= 0)
                {
                    _kbPeriodeID = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                        SELECT KbPeriodeID
                        FROM KbPeriode_User
                        WHERE UserID = {0}", Session.User.UserID));
                }
                return _kbPeriodeID;
            }
            protected set
            {
                _kbPeriodeID = value;
            }
        }

        public override DateTime PeriodeVon
        {
            get
            {
                return _periodeVon;
            }
            protected set
            {
                _periodeVon = value;
            }
        }

        public override void Reset()
        {
            this.PeriodeID = -1;
            this.GetData();
        }

        private void GetData()
        {
            SqlQuery qry = DBUtil.OpenSQL(@"SELECT
                                              KbMandantID        = MAN.KbMandantID,
                                              MandantBezeichnung = dbo.fnGetMLTextByDefault(MAN.MandantTID, {1}, MAN.Mandant),
                                              PeriodeVon         = PRD.PeriodeVon,
                                              PeriodeBis         = PRD.PeriodeBis
                                            FROM dbo.KbPeriode         PRD
                                              LEFT  JOIN dbo.KbMandant MAN ON MAN.KbMandantID = PRD.KbMandantID
                                            WHERE PRD.KbPeriodeID = {0}",
                                          PeriodeID,
                                          Session.User.LanguageCode);

            this.MandantID = Convert.ToInt32(qry["KbMandantID"]);
            this.MandantBezeichnung = Convert.ToString(qry["MandantBezeichnung"]);
            this.PeriodeVon = Convert.ToDateTime(qry["PeriodeVon"]);
            this.PeriodeBis = Convert.ToDateTime(qry["PeriodeBis"]);
        }
    }
}