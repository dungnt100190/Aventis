using Kiss.Infrastructure;

namespace Kiss.Model
{
    public partial class WshGrundbudgetPositionDebitor
    {
        #region Constructors

        public WshGrundbudgetPositionDebitor()
        {
            // Ich baue mir mein eigenes ChangeTracking
            // Grund: ChangeTracker.OriginalValues merkt sich leider nur Fremdschlüssel
            // Alternative: STE/ChangeTracker umbauen
            SubscribePropertyName(PropertyName.GetPropertyName(() => BaPersonID));
            SubscribePropertyName(PropertyName.GetPropertyName(() => BaInstitutionID));
        }

        #endregion
    }
}