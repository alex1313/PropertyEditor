namespace PropertyEditor.Models
{
    using System.Windows.Forms;

    public class IntegerPropertyControl : PropertyControlBase
    {
        public IntegerPropertyControl(string name, object value)
            : base(name, value, typeof (int))
        {
        }

        public override Control GetControl()
        {
            return new NumericUpDown
            {
                Name = Name,
                Value = (int) Value,
                Top = LabelPosition.Top,
                Left = LabelPosition.Right,
                Minimum = int.MinValue,
                Maximum = int.MaxValue
            };
        }
    }
}