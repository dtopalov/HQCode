namespace PersonCreator
{
    public class Person
    {
        public Person(int age)
        {
            this.Age = age;
            if (age % 2 == 0)
            {
                this.Name = "John";
                this.PersonGender = Gender.Male;
            }
            else
            {
                this.Name = "Mary";
                this.PersonGender = Gender.Female;
            }
        }

        public enum Gender
        {
            Male,

            Female
        }

        public Gender PersonGender { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
