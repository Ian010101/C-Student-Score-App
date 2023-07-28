using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assign06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<Student> students = null;
        public Student studentUpdate = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            students = StudentDB.GetStudents(); 
            FillStudentListBox();
        }

        private void FillStudentListBox()
        {
            FirstStudent.Items.Clear();
            students.Sort();
            foreach (Student s in students)
            {

                FirstStudent.Items.Add(s.GetDisplayText());
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add_New_Student f = new Add_New_Student();
            Student student = f.GetNewStudent();
            if(student != null)
            {
                students.Add(student);
                StudentDB.SaveStudents(students);
                FillStudentListBox();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int i = FirstStudent.SelectedIndex;
            if(i != -1)
            {
                studentUpdate = students[i];
                Update_Student_Scores f = new Update_Student_Scores(studentUpdate);
                f.Show();
            }
            else
            {
                MessageBox.Show("Please select a name before selecting update.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = FirstStudent.SelectedIndex;
            if (i != -1)
            {
                Student student = students[i];
                string message = "Are you sure you want to delete "
                    + student.name;
                DialogResult button = MessageBox.Show(message, "Confirm Delete",
                    MessageBoxButtons.YesNo);
                if (button == DialogResult.Yes)
                {
                    students.Remove(student);
                    StudentDB.SaveStudents(students);
                    FillStudentListBox();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //closes the program when exit button is clicked
            StudentDB.SaveStudents(students);
            Close();
        }

       

        private void FirstStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            //inputs data into the count, average, and total textfields for each student
            int i = FirstStudent.SelectedIndex;
            if (i != -1) 
            {
                Student student = students[i];
                txtCount.Text = Convert.ToString(student.allScores.Count);
                double scoreTotal = 0;
                foreach(double score in student.allScores)
                {
                    scoreTotal += score;
                }
                txtTotal.Text = Convert.ToString(scoreTotal);
                double scoreAverage = scoreTotal / student.allScores.Count;
                txtAverage.Text = Convert.ToString(scoreAverage);
            }
        }
    }
}
