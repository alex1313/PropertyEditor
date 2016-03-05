namespace PropertyEditor.Models
{
    using System.Windows.Forms;

    public class StringPropertyControl : PropertyControlBase
    {
        public StringPropertyControl(string name, object value)
            : base(name, value, typeof (string))
        {
        }

        public override Control GetControl()
        {
            return new TextBox
            {
                Name = Name,
                Text = Value.ToString(),
                Top = LabelPosition.Bottom,
                Left = LabelPosition.Left
            };
        }
    }
}