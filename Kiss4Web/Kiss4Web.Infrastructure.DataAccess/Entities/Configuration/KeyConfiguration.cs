using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kiss4Web.Infrastructure.DataAccess.Entities.Configuration
{
    public class KeyConfiguration
    {
        private readonly List<Action<KeyBuilder>> _actions = new List<Action<KeyBuilder>>();

        public KeyConfiguration HasAnnotation(string annotation, object value)
        {
            _actions.Add(kb => kb.HasAnnotation(annotation, value));
            return this;
        }

        internal void Apply(KeyBuilder builder)
        {
            foreach (var a in _actions)
            {
                a(builder);
            }
        }
    }
}