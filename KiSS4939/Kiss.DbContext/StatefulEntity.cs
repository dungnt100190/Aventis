using System.Data;

namespace Kiss.DbContext
{
    public class StatefulEntity : IStatefulEntity
    {
        public StatefulEntity()
        {
            EntityState = EntityState.Unchanged; // default, damit nicht alle GET-Methoden komplizierter werden. Bei neuen Entitäten muss Status Added explizit gesetzt werden
        }

        public EntityState EntityState { get; set; }
    }
}
