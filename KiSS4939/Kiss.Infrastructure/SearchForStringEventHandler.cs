using System.Collections.Generic;

namespace Kiss.Infrastructure
{
    public delegate IList<object> SearchForStringEventHandler(string searchString, object searchParam = null);

    public delegate object SearchResultConverter(object searchedEntity);
}