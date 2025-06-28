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
                bool exit = false;

                while (!exit)
                {
                    Console.WriteLine("\n Student Record Management");
                    Console.WriteLine("1. Add Student");
                    Console.WriteLine("2. View All Students");
                    Console.WriteLine("3. Exit");
                    Console.Write("Enter your choice: ");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            AddStudent(context);
                            break;
                        case "2":
                            ViewAllStudents(context);
                            break;
                        case "3":
                            exit = true;
                            Console.WriteLine(" Exiting... Goodbye!");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }
        }

        static void AddStudent(AppDbContext context)
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();

            Console.Write("Enter student age: ");
            bool validAge = int.TryParse(Console.ReadLine(), out int age);

            if (!validAge || age <= 0)
            {
                Console.WriteLine(" Invalid age. Try again.");
                return;
            }

            var student = new Student { Name = name, Age = age };

            context.Students.Add(student);
            context.SaveChanges();

            Console.WriteLine("Student added successfully!");
        }

        static void ViewAllStudents(AppDbContext context)
        {
            var students = context.Students.ToList();

            if (students.Count == 0)
            {
                Console.WriteLine(" No students found.");
                return;
            }

            Console.WriteLine("\n Student List:");
            foreach (var s in students)
            {
                Console.WriteLine($" {s.Id} | 👤 Name: {s.Name} | 🎂 Age: {s.Age}");
            }
        }
    }
}
