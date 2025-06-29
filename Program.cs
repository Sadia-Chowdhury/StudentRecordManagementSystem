using Student_Record_Management_System.Models;
using StudentRecordManagementSystem.Data;

namespace Student_Record_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                while (true)
                {
                    Console.WriteLine(" Student Record Management System");
                    Console.WriteLine("1. Add Student");
                    Console.WriteLine("2. View All Students");
                    Console.WriteLine("3. Update Student");
                    Console.WriteLine("4. Delete Student Info");
                    Console.WriteLine("5. Exit");

                    Console.Write("Enter your choice: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            AddStudent(context);
                            break;
                        case "2":
                            ViewStudents(context);
                            break;
                        case "3":
                            UpdateStudent(context);
                            break;
                        case "4":
                            Console.Write("Enter Student ID to delete: ");
                            int deleteId = Convert.ToInt32(Console.ReadLine());

                            var studentToDelete = context.Students.FirstOrDefault(s => s.Id == deleteId);

                            if (studentToDelete != null)
                            {
                                context.Students.Remove(studentToDelete);
                                context.SaveChanges();
                                Console.WriteLine(" Student deleted successfully.");
                            }
                            else
                            {
                                Console.WriteLine(" Student not found.");
                            }
                            break;
                        case "5":
                            Console.WriteLine("Goodbye!");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Try again.");
                            break;
                    }
                }
            }
        }

        static void AddStudent(AppDbContext context)
        {
            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Student Age: ");
            bool isValidAge = int.TryParse(Console.ReadLine(), out int age);

            if (!isValidAge || age <= 0)
            {
                Console.WriteLine("❌ Invalid age.");
                return;
            }

            var student = new Student { Name = name, Age = age };
            context.Students.Add(student);
            context.SaveChanges();
            Console.WriteLine(" Student added successfully!");
            Console.WriteLine();
        }

        static void ViewStudents(AppDbContext context)
        {
            var students = context.Students.ToList();
            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            Console.WriteLine("\n All Students:");
            foreach (var s in students)
            {
                Console.WriteLine($" ID: {s.Id} |  Name: {s.Name} |  Age: {s.Age}");
                Console.WriteLine();
            }
        }

        static void UpdateStudent(AppDbContext context)
        {
            Console.Write("Enter ID of the student to update: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var student = context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                Console.WriteLine(" Student not found.");
                Console.WriteLine();
                return;
            }

            Console.Write("Enter new name (leave blank to keep unchanged): ");
            string newName = Console.ReadLine();
            Console.Write("Enter new age (or press Enter to skip): ");
            string ageInput = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(newName))
                student.Name = newName;

            if (int.TryParse(ageInput, out int newAge) && newAge > 0)
                student.Age = newAge;

            context.SaveChanges();
            Console.WriteLine(" Student updated successfully!");
            Console.WriteLine();
        }
    }
}
