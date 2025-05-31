using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management
{
    class Course
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }

        public Course(string code, string name)
        {
            CourseCode = code;
            CourseName = name;
        }

        public override string ToString()
        {
            return $"{CourseCode} - {CourseName}";
        }
    }
}
