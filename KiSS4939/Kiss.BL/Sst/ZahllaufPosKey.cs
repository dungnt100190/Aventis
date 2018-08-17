namespace Kiss.BL.Sst
{
    /// <summary>
    /// Key-Klasse, für eine Position in einem Zahlstapel.
    /// </summary>
    internal class ZahllaufPosKey
    {
        #region Properties

        public string PAYMENT_LOT
        {
            get; set;
        }

        public string PAYMENT_LOT_POS
        {
            get; set;
        }

        #endregion

        #region Methods

        #region Public Methods

        public override bool Equals(object obj)
        {
            var other = obj as ZahllaufPosKey;
            if (other == null)
            {
                return false;
            }
            if (PAYMENT_LOT == other.PAYMENT_LOT && PAYMENT_LOT_POS == other.PAYMENT_LOT_POS)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hashCode = PAYMENT_LOT == null ? 127 : PAYMENT_LOT.GetHashCode();
            if (PAYMENT_LOT_POS != null)
            {
                hashCode = 31*hashCode + PAYMENT_LOT_POS.GetHashCode();
            }
            return hashCode;
        }

        #endregion

        #endregion
    }
}