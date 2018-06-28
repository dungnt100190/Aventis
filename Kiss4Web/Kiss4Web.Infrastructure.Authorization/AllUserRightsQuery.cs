using System.Collections.Generic;
using Kiss4Web.Infrastructure.Mediator;

namespace Kiss4Web.Infrastructure.Authorization
{
    public class AllUserRightsQuery : Message<IEnumerable<Kiss4UserRight>>
    {
    }
}