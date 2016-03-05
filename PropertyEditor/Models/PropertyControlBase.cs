namespace PropertyEditor.Models
{
    using System;
    using System.Windows.Forms;

    public abstract class PropertyControlBase
    {
        protected Position LabelPosition = new Position();

        protected PropertyControlBase(string name, object value, Type type)
        {
            Name = name;
            Value = value;
            Type = type;
        }

        public string Name { get; set; }
        public object Value { get; set; }
        public Type Type { get; set; }

        public Label GetLabel(int labelTop)
        {
            var label = new Label
            {
                Text = Name,
                Top = labelTop
            };

            LabelPosition.Top = label.Top;
            LabelPosition.Bottom = label.Bottom;
            LabelPosition.Left = label.Left;
            LabelPosition.Right = label.Right;

            return label;
        }

        public abstract Control GetControl();
    }
}