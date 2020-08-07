using ValidationAttribute.Attributes;

namespace ValidationAttribute.Models
{
    public class Person
    {
        private const int MIN_VALUE = 12;
        private const int MAX_VALUE = 90;
        public Person(string name, int age)
        {
            this.FullName = name;
            this.Age = age;
        }
        [MyRequired]
        public string FullName { get; set; }

        [MyRange(MIN_VALUE,MAX_VALUE)]
        public int Age { get; set; }
    }
}
