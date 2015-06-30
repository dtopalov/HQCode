namespace PersonCreator
{
    using System;

    public class PersonCreatorMain
    {
        public static void Main()
        {
            Person firstPerson = new Person(2);
            Person secondPerson = new Person(3);

            Console.WriteLine("Name: {0}, age: {1}, gender {2}", firstPerson.Name, firstPerson.Age, firstPerson.PersonGender);
            Console.WriteLine("Name: {0}, age: {1}, gender {2}", secondPerson.Name, secondPerson.Age, secondPerson.PersonGender);
        }
    }
}
