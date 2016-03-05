namespace PropertyEditor.Services
{
    using System.Collections.Generic;
    using Models;

    public interface IObjectPropertiesService
    {
        List<PropertyControlBase> GetObjectProperties(object obj);
        void SetPropertyValue(object obj, string propertyName, object propertyValue);
    }
}