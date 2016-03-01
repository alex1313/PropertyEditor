namespace PropertyEditor.Services
{
    using System.Collections.Generic;

    public interface IObjectPropertiesService
    {
        Dictionary<string, TResult> GetObjectProperties<TResult>(object obj);
        void SetPropertyValue(object obj, string propertyName, object propertyValue);
    }
}