namespace Kiss.DbContext
{
    public partial class XIcon : IAutoIdentityEntity<int>
    {
        #region Properties

        // HACK
        public int AutoIdentityID
        {
            get { return XIconID; }
        }

        #endregion
    }
}