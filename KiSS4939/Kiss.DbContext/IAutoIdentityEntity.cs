
using System;

namespace Kiss.DbContext
{
    public interface IAutoIdentityEntity<T>
        where T : struct, IEquatable<T>
    {
        T AutoIdentityID { get; }
    }
}
