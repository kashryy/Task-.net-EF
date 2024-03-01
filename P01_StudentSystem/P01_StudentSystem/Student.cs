using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem
{
    internal class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string RegisteredOn { get; set; }
        public string Birthday { get; set; }
        public ICollection<Homework> Homeworks { get; set; }
        public ICollection<Course> Courses { get; set; }

    }
}
