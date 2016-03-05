namespace PropertyEditor.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class ObjectPropertiesService : IObjectPropertiesService
    {
        public List<PropertyControlBase> GetObjectProperties(object obj)
        {
            var intProperties = obj.GetType()
                .GetProperties()
                .Where(x => x.CanRead && x.CanWrite && x.PropertyType == typeof(int))
                .Select(x => new IntegerPropertyControl(x.Name, x.GetValue(obj)))
                .Cast<PropertyControlBase>();

            var stringProperties = obj.GetType()
                .GetProperties()
                .Where(x => x.CanRead && x.CanWrite && x.PropertyType == typeof(string))
                .Select(x => new StringPropertyControl(x.Name, x.GetValue(obj)));

            return intProperties.Union(stringProperties).ToList();
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