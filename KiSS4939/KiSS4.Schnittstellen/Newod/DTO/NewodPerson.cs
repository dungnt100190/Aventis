namespace KiSS4.Schnittstellen.Newod.DTO
{
    public class NewodPerson : Person
    {
        #region Constructors

        public NewodPerson()
            : base(new PersonBasisDaten(), new PersonAdressDaten())
        {
        }

        public NewodPerson(PersonBasisDaten basisdaten, PersonAdressDaten addressdaten)
            : base(basisdaten, addressdaten)
        {
        }

        #endregion

        #region Properties


        #endregion
    }
}