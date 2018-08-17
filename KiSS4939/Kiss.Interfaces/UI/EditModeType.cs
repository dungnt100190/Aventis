
namespace Kiss.Interfaces.UI
{
    /// <summary>
    /// Edit Mode Type
    /// </summary>
    public enum EditModeType
    {
        /// <summary>
        /// Normal Edit Field
        /// </summary>
        Normal,

        /// <summary>
        /// Read Only Field
        /// </summary>
        ReadOnly,

        /// <summary>
        /// BFS voluntary Field
        /// </summary>
        BfsCan,

        /// <summary>
        /// BFS mandantory Field
        /// </summary>
        BfsMust,

        /// <summary>
        /// Required Field
        /// </summary>
        Required,

        /// <summary>
        /// Optional Field
        /// </summary>
        Optional
    }
}
