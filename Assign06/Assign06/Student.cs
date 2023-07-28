using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign06
{
    public class Student : ICloneable, IComparable<Student>
    {

        public Student()
        {

        }

        public Student(string name, List<double> allScores)
        {
            this.name = name;
         
            this.allScores = allScores;
        }

        public string name { get; set; }

       

        public List<double> allScores { get; set; }

        public object Clone()
        {
            return new Student(name, new List<double>(allScores));
        }

        public int CompareTo(Student other)
        {
            return name.CompareTo(other.name);
        }

        public string GetDisplayText() =>
            name;



    }
}
