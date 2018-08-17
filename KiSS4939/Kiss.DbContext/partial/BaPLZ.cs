

namespace Kiss.DbContext
{
    public partial class BaPLZ
    {
        public bool ArePropertiesSame(BaPLZ other)
        {
            return BFSCode == other.BFSCode &&
                   Name.Equals(other.Name) &&
                   PLZ == other.PLZ &&
                   PLZ6 == other.PLZ6 &&
                   PLZSuffix == other.PLZSuffix &&
                   DatumVon.Equals(other.DatumVon) &&
                   DatumBis.Equals(other.DatumBis) &&
                   Kanton.Equals(other.Kanton);
        }
    }
}
