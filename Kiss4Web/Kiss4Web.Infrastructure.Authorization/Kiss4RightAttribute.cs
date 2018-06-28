using System;

namespace Kiss4Web.Infrastructure.Authorization
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class Kiss4RightAttribute : Attribute
    {
        public Kiss4RightAttribute(string rightName, bool insert = false, bool update = false, bool delete = false)
        {
            RightName = rightName;
            Insert = insert;
            Update = update;
            Delete = delete;
        }

        public string RightName { get; set; }
        public bool Insert { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
    }
}