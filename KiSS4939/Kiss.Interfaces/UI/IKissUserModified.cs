namespace Kiss.Interfaces.UI
{
    /// <summary>
    /// Ermöglicht festzustellen, ob ein User Änderungen vorgenommen hat
    /// </summary>
    public interface IKissUserModified
    {
        /// <summary>
        /// Value was modified by User
        /// </summary>
        bool UserModified { get; set; }

        /// <summary>
        /// Restore last Value
        /// </summary>
        void CancelEdit();
    }
}
