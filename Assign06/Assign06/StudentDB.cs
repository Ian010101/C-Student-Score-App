using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign06
{
    public static class StudentDB
    {

        private const string dir = @"C:\C#\Files\";
        private const string path = dir + "StudentScores.txt";

        public static List<Student> GetStudents()
        {
            // if the directory doesn't exist, create it
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);


            //create the object for the input stream for a text file
            StreamReader textIn = new StreamReader(
                new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read));

            // create the array list for students
            List<Student> students = new List<Student>();

           // int i = 0;
            while (textIn.Peek() != -1)
            {
                //i++;
                string row = textIn.ReadLine();
                string[] columns = row.Split('|');
                Student student = new Student();
                student.name = columns[0];
                List<double> scores = new List<double>();
                
                for(int i = 1; i < columns.Length-1; i++)
                {
                    
                    //Console.WriteLine(columns[i]);
                    double studentScore = Convert.ToDouble(columns[i]);
                    
                    scores.Add(studentScore);
                } 
                student.allScores = scores;
                students.Add(student);
            }

            textIn.Close();
            return students;
        }
        /*
        public static void SaveStudents(List<Student> students)
        {
            // Create the output stream for a text file
            StreamWriter textOut =
                new StreamWriter(
                new FileStream(path, FileMode.Create, FileAccess.Write));

            // Write each student
            foreach (Student student in students)
            {
                textOut.Write(student.name + "|");
                for (int i = 0; i < student.allScores.Count; i++)
                {
                    textOut.Write(student.allScores[i]);
                    if (i < student.allScores.Count - 1)
                    {
                        textOut.Write(",");
                    }
                }
                textOut.WriteLine();
            }
        } */
        
        public static void SaveStudents(List<Student> students)
        {
            // create the output stream for a text file
            StreamWriter textOut =
                new StreamWriter(
                new FileStream(path, FileMode.Create, FileAccess.Write));

            // write each student
            foreach (Student student in students)
            {
                textOut.Write(student.name + "|");
                for(int i = 0; i < student.allScores.Count; i++) { 
                textOut.Write(student.allScores[i] + "|");
                    Console.WriteLine(student.allScores[i]);
                }
                
                textOut.WriteLine();
            }

            // write the end of the document
            textOut.Close();
        }
        



    }
}
