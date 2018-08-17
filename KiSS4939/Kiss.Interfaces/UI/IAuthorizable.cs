namespace Kiss.Interfaces.UI
{
    public interface IAuthorizable
    {
        #region Properties

        bool IsAuthorized
        {
            get;
            set;
        }

        #endregion
    }
}