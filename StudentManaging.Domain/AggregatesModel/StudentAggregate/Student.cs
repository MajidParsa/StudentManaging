using System.Net.Sockets;
using StudentManaging.Domain.SeedWork;

namespace StudentManaging.Domain.AggregatesModel.StudentAggregate
{
    public class Student : Entity, IAggregateRoot
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Address Address { get; private set; }
        public string PhoneNumber { get; private set; }

        public Student()
        {
            
        }

        private Student(int id, string name, Address address, string phoneNumber)
        {
	        Id = id;
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        public static Student AddStudent(string name, Address address, string phoneNumber) => 
            new Student(0, name,address,phoneNumber);

        public static Student UpdateStudent(int id, string name, Address address, string phoneNumber) =>
	        new Student(id, name, address, phoneNumber);
    }
}