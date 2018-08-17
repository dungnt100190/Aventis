using System.ComponentModel;

namespace Kiss.Infrastructure
{
    public static class PropertyValue
    {
        public static object GetPropertyValue(object item, string propertyPath)
        {
            var propertyNames = propertyPath.Split('.');

            foreach (var propertyName in propertyNames)
            {
                var type = item.GetType();
                var propertyInfo = type.GetProperty(propertyName);
                if (propertyInfo != null)
                {
                    item = propertyInfo.GetValue(item, new object[0]);
                }
            }

            return item;
        }

        public static void SetPropertyValue(object item, string propertyPath, object value)
        {
            var propertyNames = propertyPath.Split('.');

            for (int i = 0; i < propertyNames.Length; i++)
            {
                var propertyName = propertyNames[i];
                var type = item.GetType();
                var propertyInfo = type.GetProperty(propertyName);

                if (propertyInfo != null)
                {
                    if (i == propertyNames.Length - 1)
                    {
                        propertyInfo.SetValue(item, value, new object[0]);
                    }
                    else
                    {
                        item = propertyInfo.GetValue(item, new object[0]);
                    }
                }
            }
        }
    }
}