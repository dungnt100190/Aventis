using System;
using System.Collections.Generic;
using System.Text;

namespace KiSS4.Schnittstellen.Newod.DTO
{
    public class GuiPerson : Person
    {
        private bool _isKiss;
        private bool _isNewod;

        public GuiPerson(bool isKiss, bool isNewod, PersonBasisDaten basisdaten, PersonAdressDaten addressdaten)
            : base(basisdaten, addressdaten)
        {
            _isKiss = isKiss;
            _isNewod = isNewod;
        }

        /// <summary>
        /// Gets/Sets isKiss
        /// </summary>
        public bool IsKiss
        {
            get { return this._isKiss; }
            set { _isKiss = value; }
        }

        /// <summary>
        /// Gets/Sets isNewod
        /// </summary>
        public bool IsNewod
        {
            get { return this._isNewod; }
            set { _isNewod = value; }
        }
    }
}
