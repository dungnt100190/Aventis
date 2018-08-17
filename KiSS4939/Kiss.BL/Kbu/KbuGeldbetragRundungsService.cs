using Kiss.Interfaces.BL;
using Kiss.Model;

namespace Kiss.BL.Kbu
{
    /// <summary>
    /// Service zum Runden von Geldbeträgen.
    /// </summary>
    public class KbuGeldbetragRundungsService : ServiceBase
    {
        #region Constructors

        private KbuGeldbetragRundungsService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Rundet den Geldbetrag auf 5 Rappen.
        /// Es wid auf oder abgerundet:
        /// 99.91 -> 99.90
        /// 99.94 -> 99.95
        /// 99.99 -> 100
        /// </summary>
        /// <param name="betrag"></param>
        /// <returns></returns>
        public decimal GeldbetragRunden(decimal betrag)
        {
            return (System.Math.Round(betrag*2, 1)/2);
        }

        /// <summary>
        /// Siehe GeldbetragRunden(deciaml betrag).
        /// Anstatt decimal kann double übergeben werden.
        /// </summary>
        /// <param name="betrag"></param>
        /// <returns></returns>
        public decimal  GeldbetragRunden(double betrag)
        {
            decimal decimalBetrag = (decimal) betrag;
            return GeldbetragRunden(decimalBetrag);
        }

        #endregion

        #endregion
    }
}