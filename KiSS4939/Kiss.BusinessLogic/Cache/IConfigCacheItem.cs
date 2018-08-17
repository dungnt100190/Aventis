using System;

namespace Kiss.BusinessLogic.Cache
{
    interface IConfigCacheItem
    {
        DateTime DatumVon { get; }
        DateTime DatumBis { get; }
    }
}
