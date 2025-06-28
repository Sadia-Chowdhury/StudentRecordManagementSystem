using StudentRecordManagementSystem.Data;
using Student_Record_Management_System.Models;
namespace Student_Record_Management_System
{

    internal class Program
    {
    static void Main(string[] args)
    {
        using (var context = new AppDbContext())
        {
            // 1. Create a new student
            var student = new Student
            {
                Name = "Sadia Chowdhury",
                Age = 24
            };

            context.Students.Add(student);
            context.SaveChanges(); // Save to DB

            Console.WriteLine("Student added successfully!");

            // 2. Retrieve and show all students
            var students = context.Students.ToList();

            Console.WriteLine("\nAll Students in the DB:");
            foreach (var s in students)
            {
                Console.WriteLine($"ID: {s.Id}, Name: {s.Name}, Age: {s.Age}");
            }
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}

}