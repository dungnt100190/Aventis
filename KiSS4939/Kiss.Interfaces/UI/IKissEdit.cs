namespace Kiss.Interfaces.UI
{
    public interface IKissEdit : IAuthorizable
    {
        #region Properties

        bool IsReadOnly
        {
            get;
            set;
        }

        bool IsRequired
        {
            get;
            set;
        }

        #endregion
    }
}