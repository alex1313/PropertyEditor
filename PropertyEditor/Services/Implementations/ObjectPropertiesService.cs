namespace PropertyEditor.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;

    public class ObjectPropertiesService : IObjectPropertiesService
    {
        public Dictionary<string, TResult> GetObjectProperties<TResult>(object obj)
        {
            var fieldValues = obj.GetType()
                .GetProperties()
                .Where(x => x.PropertyType == typeof(TResult) && x.CanRead && x.CanWrite)
                .ToDictionary(x => x.Name, x => (TResult)x.GetValue(obj));

            return fieldValues;
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