namespace KiSS4.Schnittstellen.Newod.DTO
{
    public class BaPerson : Person
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        #endregion

        #endregion

        #region Constructors

        public BaPerson()
            : base(new PersonBasisDaten(), new PersonAdressDaten())
        {
        }

        public BaPerson(PersonBasisDaten basisdaten, PersonAdressDaten addressdaten)
            : base(basisdaten, addressdaten)
        {
        }

        public BaPerson(BaPersonNewodFlags newodflags, PersonBasisDaten basisdaten, PersonAdressDaten addressdaten)
            : base(basisdaten, addressdaten)
        {
            NewodFlags = newodflags;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets Type Newod
        /// </summary>
        public BaPersonNewodFlags NewodFlags { get; private set; }

        #endregion
    }
}