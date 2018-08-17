namespace Kiss.DbContext
{
    public partial class XModul : IAutoIdentityEntity<int>
    {
        #region Properties

        // HACK
        public int AutoIdentityID
        {
            get { return ModulID; }
        }

        #endregion
    }
}