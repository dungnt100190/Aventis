using System;

namespace Kiss4Web.Infrastructure.Modularity
{
    public class ModuleAttribute : Attribute
    {
        public ModuleAttribute(string moduleName)
        {
            ModuleName = moduleName;
        }

        public string ModuleName { get; }
    }
}