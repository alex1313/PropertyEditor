namespace PropertyEditor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Services;
    using Services.Implementations;

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

        private void CreateControlsForEditObject(object objectToEdit)
        {
            _intProperties = ObjectPropertiesService.GetObjectProperties<int>(objectToEdit);
            _stringProperties = ObjectPropertiesService.GetObjectProperties<string>(objectToEdit);

            var controls = new List<Control>();

            foreach (var property in _stringProperties)
            {
                var label = new Label
                {
                    Text = property.Key,
                    Top = (controls.LastOrDefault()?.Bottom ?? 0) + 20
                };
                controls.Add(label);

                controls.Add(new TextBox
                {
                    Name = property.Key,
                    Text = property.Value,
                    Top = label.Bottom
                });
            }

            foreach (var property in _intProperties)
            {
                var label = new Label
                {
                    Text = property.Key,
                    Top = (controls.LastOrDefault()?.Bottom ?? 0) + 20
                };
                controls.Add(label);

                controls.Add(new NumericUpDown
                {
                    Name = property.Key,
                    Value = property.Value,
                    Top = label.Bottom,
                    Minimum = decimal.MinValue,
                    Maximum = decimal.MaxValue
                });
            }

            Controls.AddRange(controls.ToArray());
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