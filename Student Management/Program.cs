using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();
            bool running = true;

            // Add some default courses
            manager.AddCourse(new Course("CS101", "Intro to Programming"));
            manager.AddCourse(new Course("MATH201", "Calculus"));
            manager.AddCourse(new Course("ENG102", "English Literature"));

            while (running)
            {
                Console.WriteLine("\nStudent Management Menu:");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Grade to Student");
                Console.WriteLine("3. Display All Students");
                Console.WriteLine("4. List Courses");
                Console.WriteLine("5. Add New Course");
                Console.WriteLine("6. Show Students by Course");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");

                string option = Console.ReadLine();
                Console.WriteLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Enter student name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter student ID: ");
                        string id = Console.ReadLine();
                        manager.AddStudent(new Student(name, id));
                        Console.WriteLine("Student added.");
                        break;

                    case "2":
                        Console.Write("Enter student ID: ");
                        string sid = Console.ReadLine();
                        Console.Write("Enter course code: ");
                        string code = Console.ReadLine();
                        Console.Write("Enter grade: ");
                        if (double.TryParse(Console.ReadLine(), out double grade))
                        {
                            manager.AddGradeToStudent(sid, code, grade);
                        }
                        else
                        {
                            Console.WriteLine("Invalid grade input.");
                        }
                        break;

                    case "3":
                        manager.DisplayAllStudents();
                        break;

                    case "4":
                        manager.ListCourses();
                        break;

                    case "5":
                        Console.Write("Enter new course code: ");
                        string newCode = Console.ReadLine();
                        Console.Write("Enter new course name: ");
                        string newName = Console.ReadLine();
                        manager.AddCourse(new Course(newCode, newName));
                        Console.WriteLine("Course added.");
                        break;

                    case "6":
                        Console.Write("Enter course code to filter students: ");
                        string filterCode = Console.ReadLine();
                        manager.DisplayStudentsInCourse(filterCode);
                        break;

                    case "0":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }

            Console.WriteLine("Goodbye!");
        }
    }
    }
