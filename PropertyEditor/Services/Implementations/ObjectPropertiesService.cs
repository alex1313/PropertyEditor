namespace PropertyEditor.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Models;

    public class ObjectPropertiesService : IObjectPropertiesService
    {
        public List<PropertyControlBase> GetObjectProperties(object obj)
        {
            var properties = obj.GetType()
                .GetProperties()
                .Where(x => x.CanRead && x.CanWrite);

            return properties.Select<PropertyInfo, PropertyControlBase>(x =>
            {
                if (x.PropertyType == typeof (int))
                {
                    return new IntegerPropertyControl(x.Name, x.GetValue(obj));
                }

                if (x.PropertyType == typeof (string))
                {
                    return new StringPropertyControl(x.Name, x.GetValue(obj));
                }

                return null;
            })
                .Where(x => x != null)
                .ToList();
        }

        public void SetPropertyValue(object obj, string propertyName, object propertyValue)
        {
            obj.GetType()
                .GetProperties()
                .First(x => x.Name == propertyName)
                .SetValue(obj, propertyValue);
        }
    }
}