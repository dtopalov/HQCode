namespace Methods
{
    using System;

    internal class Student
    {
        private string firstName;

        private string lastName;

        public Student(string firstName, string lastName, DateTime dateOfBirth, string otherInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.OtherInfo = otherInfo;
        }

        /// <exception cref="ArgumentException" accessor="set">First name must be between 3 and 30 characters long</exception>
        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (!this.ValidateName(value))
                {
                    throw new ArgumentException("First name must be between 3 and 30 characters long");
                }

                this.firstName = value;
            }
        }

        /// <exception cref="ArgumentException" accessor="set">Last name must be between 3 and 30 characters long</exception>
        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (!this.ValidateName(value))
                {
                    throw new ArgumentException("Last name must be between 3 and 30 characters long");
                }

                this.lastName = value;
            }
        }

        public string OtherInfo { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool IsOlderThan(Student otherStudent)
        {
            DateTime firstDate = this.DateOfBirth;
            DateTime secondDate = otherStudent.DateOfBirth;
                
            return firstDate < secondDate;
        }

        private bool ValidateName(string name)
        {
            if (name == null)
            {
                return false;
            }

            if (name.Length < 3 || name.Length > 30)
            {
                return false;
            }

            return true;
        }
    }
}
