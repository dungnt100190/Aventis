namespace Kiss.UI.ViewModel
{
    /// <summary>
    /// Delegate for "handles the another entity is selected event."
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity</typeparam>
    /// <param name="selectedEntity">The new selected entity</param>
    /// <param name="deselectedEntity">The previous selected entity. Might be null if there is no selected entity.</param>
    public delegate void SelectedEntityChanged<in TEntity>(TEntity selectedEntity, TEntity deselectedEntity);
}
