using Kiss.Infrastructure;

namespace Kiss.Model
{
    public partial class WshGrundbudgetPositionKreditor
    {
        #region Constructors

        public WshGrundbudgetPositionKreditor()
        {
            // Ich baue mir mein eigenes ChangeTracking
            // Grund: ChangeTracker.OriginalValues merkt sich leider nur Fremdschlüssel
            // Alternative: STE/ChangeTracker umbauen
            SubscribePropertyName(PropertyName.GetPropertyName(() => ReferenzNummer));
            SubscribePropertyName(PropertyName.GetPropertyName(() => MitteilungZeile1));
            SubscribePropertyName(PropertyName.GetPropertyName(() => MitteilungZeile2));
            SubscribePropertyName(PropertyName.GetPropertyName(() => MitteilungZeile3));
            SubscribePropertyName(PropertyName.GetPropertyName(() => MitteilungZeile4));
            SubscribePropertyName(PropertyName.GetPropertyName(() => BaZahlungswegID));
        }

        #endregion
    }
}