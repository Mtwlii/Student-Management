using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management
{
    class Student
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public Dictionary<Course, double> Grades { get; set; }

        public Student(string name, string id)
        {
            Name = name;
            ID = id;
            Grades = new Dictionary<Course, double>();
        }

        public void AddGrade(Course course, double grade)
        {
            Grades[course] = grade;
        }

        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Student: {Name} (ID: {ID})");
            Console.WriteLine("Grades:");
            foreach (var item in Grades)
            {
                Console.WriteLine($"- {item.Key}: {item.Value}");
            }
        }

        public double GetAverage()
        {
            if (Grades.Count == 0) return 0;
            double total = 0;
            foreach (var grade in Grades.Values)
            {
                total += grade;
            }
            return total / Grades.Count;
        }
    }
}
