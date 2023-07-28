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
    public partial class Add_New_Student : Form
    {
        public Add_New_Student()
        {
            InitializeComponent();
        }

        private Student student = null;
        
        public Student GetNewStudent()
        {
            this.ShowDialog();
            return student;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            //closes current form
            this.Close();
        }

        private List<double> scores = new List<double>();
        private int i = 0;

        private void btnOk_Click(object sender, EventArgs e)
        {
            student = new Student(txtName.Text, scores);
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //adds the score just inputted into the scores list, then takes that score and displays it in the Scores: textbox with all previous inputs
            //also checks to see if its a valid score
            try
            {
                if (Convert.ToDouble(txtScore.Text) < 101 && Convert.ToDouble(txtScore.Text) > -1)
                {
                    scores.Add(Convert.ToDouble(txtScore.Text));
                    txtScores.Text += Convert.ToString(scores[i]) + ",";
                    i++;
                }
            }

            catch
            {
                MessageBox.Show("please input a number from 0 to 100");
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < scores.Count; i++)
            {
                scores.Remove(scores[i]);
            }
            txtScores.Text = "";
        }
    }
        
}
