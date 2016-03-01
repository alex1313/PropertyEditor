namespace PropertyEditor
{
    using System;
    using System.Windows.Forms;

    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var testObject = new TestObject(1990, "Alex", "Smith", 79, 99);
            var propertyEditorForm = new PropertyEditorForm(testObject);
            if (propertyEditorForm.ShowDialog() == DialogResult.OK)
            {
                var result = propertyEditorForm.EditedObject;
            }
        }
    }
}