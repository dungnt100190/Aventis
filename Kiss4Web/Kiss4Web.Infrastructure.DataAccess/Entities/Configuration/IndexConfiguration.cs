using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kiss4Web.Infrastructure.DataAccess.Entities.Configuration
{
    public class IndexConfiguration
    {
        private readonly List<Action<IndexBuilder>> _actions = new List<Action<IndexBuilder>>();

        public void Apply(IndexBuilder indexBuilder)
        {
            foreach (var act in _actions)
            {
                act(indexBuilder);
            }
        }

        public IndexConfiguration HasName(string name)
        {
            _actions.Add(ixb => ixb.HasName(name));
            return this;
        }

        public IndexConfiguration IsClustered(bool clustered = true)
        {
            _actions.Add(ixb => ixb.ForSqlServerIsClustered(clustered));
            return this;
        }

        public IndexConfiguration IsUnique()
        {
            _actions.Add(ixb => ixb.IsUnique());
            return this;
        }
    }
}