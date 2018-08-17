namespace Kiss.Interfaces.UI
{
    public interface IViewRight
    {
        bool CanDelete { get; }

        bool CanInsert { get; }

        bool CanUpdate { get; }
    }
}