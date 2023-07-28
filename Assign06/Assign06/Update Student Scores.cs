using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assign06
{
    public partial class Update_Student_Scores : Form
    {
        private Student student;
        private Student updatedStudent;
        private double scoreUpdate;

        public Update_Student_Scores(Student student)
        {
            InitializeComponent();
            this.student = student;
            updatedStudent = (Student)student.Clone();
        }

        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add_Score f = new Add_Score();
            double newScore = f.newestScore();
            
                updatedStudent.allScores.Add(newScore);
                lstData.Items.Add(newScore);
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           // Update_Score f = new Update_Score();
            int i = lstData.SelectedIndex;
            if (i != -1)
            {
                scoreUpdate = updatedStudent.allScores[i];
                Update_Score f = new Update_Score(scoreUpdate);
                double updateScore = f.updatedScore();
                //scoreUpdate = f.score;
                lstData.Items.RemoveAt(i);
                lstData.Items.Insert(i, updateScore);
                updatedStudent.allScores[i] = updateScore;
            }
            else
            {
                MessageBox.Show("Please select a name before selecting update.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //closes current form
            this.Close();
        }

        private void Update_Student_Scores_Load(object sender, EventArgs e)
        {
            //String studentName = student.name;
            txtName.Text = updatedStudent.name;
            lstData.Items.Clear();
            for(int i = 0; i < updatedStudent.allScores.Count; i++)
            {
                lstData.Items.Add(updatedStudent.allScores[i]);
            }
        }

        private void lstData_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            student.name = updatedStudent.name;
            student.allScores = updatedStudent.allScores;
            

            this.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int i = lstData.SelectedIndex;
            if (i != -1)
            {
                    updatedStudent.allScores.Remove(updatedStudent.allScores[i]);
                    lstData.Items.RemoveAt(i);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < updatedStudent.allScores.Count; i++)
            {
                updatedStudent.allScores.Remove(updatedStudent.allScores[i]);
                lstData.Items.RemoveAt(i);
            }
        }

        /*
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
            foreach (Student s in students)
            {
                FirstStudent.Items.Add(s.GetDisplayText());
            }
        } */

    }
}
