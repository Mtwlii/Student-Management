using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management
{
    class StudentManager
    {
        private List<Student> students = new List<Student>();
        private List<Course> courses = new List<Course>();

        public void AddCourse(Course course)
        {
            courses.Add(course);
        }

        public Course GetCourseByCode(string code)
        {
            return courses.Find(c => c.CourseCode.Equals(code, StringComparison.OrdinalIgnoreCase));
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void AddGradeToStudent(string studentId, string courseCode, double grade)
        {
            Student student = students.Find(s => s.ID == studentId);
            Course course = GetCourseByCode(courseCode);

            if (student != null && course != null)
            {
                student.AddGrade(course, grade);
                Console.WriteLine("Grade added.");
            }
            else
            {
                Console.WriteLine("Student or course not found.");
            }
        }

        public void DisplayAllStudents()
        {
            foreach (var student in students)
            {
                student.DisplayDetails();
                Console.WriteLine($"Average: {student.GetAverage():F2}\n");
            }
        }

        public void ListCourses()
        {
            Console.WriteLine("Available Courses:");
            foreach (var course in courses)
            {
                Console.WriteLine("- " + course);
            }
        }

        public void DisplayStudentsInCourse(string courseCode)
        {
            Course course = GetCourseByCode(courseCode);
            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }

            Console.WriteLine($"\nStudents enrolled in {course}:");
            bool any = false;
            foreach (var student in students)
            {
                if (student.Grades.ContainsKey(course))
                {
                    Console.WriteLine($"- {student.Name} (ID: {student.ID}), Grade: {student.Grades[course]}");
                    any = true;
                }
            }

            if (!any)
            {
                Console.WriteLine("No students enrolled in this course.");
            }
        }
    }
    }
