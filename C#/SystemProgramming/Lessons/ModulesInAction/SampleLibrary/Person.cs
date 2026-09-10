namespace SampleLibrary
{
    public enum PersonMaritalStatus
    { Married, Single }
    public class Person
    {
        string Name;
        string LastName;
        int Age;
        PersonMaritalStatus MaritalStatus;

        public Person(string name, string lastName, int age)
        {
            Name = name;
            LastName = lastName;
            Age = age;
            MaritalStatus = PersonMaritalStatus.Single;
        }
    }

    public class Employee: Person
    {
        string Position;
        decimal Salary;

        public Employee(string name, string lastName, int age,
                        string position, decimal salary)
            : base(name, lastName, age)
        {
            Position = position;
            Salary = salary;
        }
    }
}
