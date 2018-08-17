using System;

namespace Kiss.Infrastructure
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class SearchFieldAttribute : Attribute
    {
        public SearchFieldAttribute(string name)
        {
            Name = name;
        }

        public string FollowedBy { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Specifies the name of a resource string in <see cref="Kiss.UI.Controls.LocalResources.SearchParamsTextRes"/> to use instead of <see cref="Name"/>.
        /// </summary>
        public string ResourceName { get; set; }
    }
}