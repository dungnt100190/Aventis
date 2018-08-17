using System;

using KiSS4.DB;

namespace KiSS4.Klientenbuchhaltung.BL.None
{
    public class KlibuEnvironmentNone : KlibuEnvironment
    {
        #region Fields

        #region Private Fields

        private int _kbMandantID = 0;
        private int _kbPeriodeID = 0;
        private string _mandantBezeichnung = DB.KissMsg.GetMLMessage("KlibuEnvironmentNone", "MandantBezeichnung", "Kein Buchhaltungssystem");
        private DateTime _periodeBis;
        private DateTime _periodeVon;

        #endregion

        #endregion

        #region Constructors

        public KlibuEnvironmentNone()
        {
        }

        #endregion

        #region Properties

        public override bool IsLoggedOn
        {
            get
            {
                return true;
            }
        }

        public override KlibuSystem KlibuSystem
        {
            get
            {
                return KlibuSystem.Kein;
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
                        SELECT MAX(KbPeriodeID)
                        FROM KbPeriode"));
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

        #endregion

        #region Methods

        #region Public Methods

        public override void Reset()
        {
        }

        public override string ToString()
        {
            return _mandantBezeichnung;
        }

        #endregion

        #endregion
    }
}