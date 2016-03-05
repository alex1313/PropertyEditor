namespace PropertyEditor
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Models;
    using Services;
    using Services.Implementations;

    public partial class PropertyEditorForm : Form
    {
        private readonly List<PropertyControlBase> _propertyControls;

        public PropertyEditorForm(object objectToEdit)
        {
            InitializeComponent();

            ObjectPropertiesService = new ObjectPropertiesService(); //add IoC container

            _propertyControls = ObjectPropertiesService.GetObjectProperties(objectToEdit);
            CreateControlsForEditObject();

            EditedObject = objectToEdit;
        }

        private IObjectPropertiesService ObjectPropertiesService { get; }

        public object EditedObject { get; set; }

        private void CreateControlsForEditObject()
        {
            var currentPosition = 0;
            foreach (var property in _propertyControls)
            {
                Controls.Add(property.GetLabel(currentPosition));

                var control = property.GetControl();
                Controls.Add(control);

                currentPosition = control.Bottom + 20;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            foreach (var property in _propertyControls)
            {
                var value = Controls[property.Name].Text;
                ObjectPropertiesService.SetPropertyValue(EditedObject, property.Name, Convert.ChangeType(value, property.Type));
            }

            DialogResult = DialogResult.OK;
        }
    }
}