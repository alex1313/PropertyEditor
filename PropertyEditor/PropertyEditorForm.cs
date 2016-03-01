namespace PropertyEditor
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Services;

    public partial class PropertyEditorForm : Form
    {
        private Dictionary<string, int> _intProperties;
        private Dictionary<string, string> _stringProperties;

        public PropertyEditorForm(object objectToEdit)
        {
            InitializeComponent();

            ObjectPropertiesService = new ObjectPropertiesService(); //add IoC container

            CreateControlsForEditObject(objectToEdit);

            EditedObject = objectToEdit;
        }

        private IObjectPropertiesService ObjectPropertiesService { get; }

        public object EditedObject { get; set; }

        public void CreateControlsForEditObject(object objectToEdit)
        {
            _intProperties = ObjectPropertiesService.GetObjectProperties<int>(objectToEdit);
            _stringProperties = ObjectPropertiesService.GetObjectProperties<string>(objectToEdit);

            var i = 0;
            var controls = new Control[_intProperties.Count + _stringProperties.Count];

            foreach (var property in _stringProperties)
            {
                var label = new Label
                {
                    Text = property.Key,
                    Top = i > 0
                        ? controls[i - 1].Bottom + 20
                        : 0
                };
                Controls.Add(label);

                controls[i] = new TextBox
                {
                    Name = property.Key,
                    Text = property.Value,
                    Top = label.Bottom
                };
                Controls.Add(controls[i]);

                i++;
            }

            foreach (var property in _intProperties)
            {
                var label = new Label
                {
                    Text = property.Key,
                    Top = i > 0
                        ? controls[i - 1].Bottom + 20
                        : 0
                };
                Controls.Add(label);

                controls[i] = new NumericUpDown
                {
                    Name = property.Key,
                    Value = property.Value,
                    Top = label.Bottom
                };
                Controls.Add(controls[i]);

                i++;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            foreach (var property in _intProperties)
            {
                ObjectPropertiesService.SetPropertyValue(EditedObject, property.Key, int.Parse(Controls[property.Key].Text));
            }
            foreach (var property in _stringProperties)
            {
                ObjectPropertiesService.SetPropertyValue(EditedObject, property.Key, Controls[property.Key].Text);
            }

            DialogResult = DialogResult.OK;
        }
    }
}