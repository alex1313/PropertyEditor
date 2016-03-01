namespace PropertyEditor
{
    using System;

    public class TestObject
    {
        private readonly int _birthYear;

        public TestObject(int birthYear, string name, string surname, int weight, int height)
        {
            _birthYear = birthYear;
            Name = name;
            Surname = surname;
            Weight = weight;
            Height = height;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age => DateTime.Now.Year - _birthYear;
        public int Weight { get; set; }
        public int Height { get; set; }
    }
}