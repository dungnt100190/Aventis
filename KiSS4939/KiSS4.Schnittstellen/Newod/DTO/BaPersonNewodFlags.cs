using System;
using System.Collections.Generic;
using System.Text;

namespace KiSS4.Schnittstellen.Newod.DTO
{
    public class BaPersonNewodFlags
    {
        private string _newodID;
        private bool _kiss;
        private bool _auslAktiveSozialhilfe;
        private bool _schweizAktiveSozialhilfe;
        private bool _aktiveVormundschaft;

        public BaPersonNewodFlags(string newodid, bool auslsozialhilfe, bool schweizsozialhilfe, bool aktivevormundschaft)
        {
            _newodID = newodid;
            _auslAktiveSozialhilfe = auslsozialhilfe;
            _schweizAktiveSozialhilfe = schweizsozialhilfe;
            _aktiveVormundschaft = aktivevormundschaft;
        }

        public BaPersonNewodFlags()
            : this(null, false, false, false) { }

        /// <summary>
        /// Get/Set NewodID
        /// </summary>
        public string NewodID
        {
            get { return this._newodID; }
            set { this._newodID = value; }
        }

        /// <summary>
        /// Get/Set kiSS
        /// </summary>
        public bool kiSS
        {
            get { return this._kiss; }
            set { this._kiss = value; }
        }

        /// <summary>
        /// Get/Set AuslaenderAktiveSozialHilfe
        /// </summary>
        public bool AuslaenderAktiveSozialHilfe
        {
            get { return this._auslAktiveSozialhilfe; }
            set { this._auslAktiveSozialhilfe = value; }
        }

        /// <summary>
        /// Get/Set AuslaenderAktiveSozialHilfe
        /// </summary>
        public bool SchweizerAktiveSozialHilfe
        {
            get { return this._schweizAktiveSozialhilfe; }
            set { this._schweizAktiveSozialhilfe = value; }
        }

        /// <summary>
        /// Get/Set AuslaenderAktiveSozialHilfe
        /// </summary>
        public bool AktiveVormundschaft
        {
            get { return this._aktiveVormundschaft; }
            set { this._aktiveVormundschaft = value; }
        }


        public bool Equals(BaPersonNewodFlags obj)
        {
            return this.AktiveVormundschaft == obj.AktiveVormundschaft &&
                   this.AuslaenderAktiveSozialHilfe == obj.AuslaenderAktiveSozialHilfe &&
                   this.SchweizerAktiveSozialHilfe == obj.SchweizerAktiveSozialHilfe;

        }

    }
}
