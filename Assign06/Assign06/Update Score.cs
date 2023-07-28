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
    public partial class Update_Score : Form
    {
        private double score;
        public Update_Score(double score)
        {
            InitializeComponent();
            this.score = score;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //closes current form
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //checks to see if person inputted a valid score
            try
            {
                if (Convert.ToDouble(txtScore.Text) < 101 && Convert.ToDouble(txtScore.Text) > -1)
                {
                    score = Convert.ToDouble(txtScore.Text);
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("please input a number from 0 to 100");
            }
        }

        public double updatedScore()
        {
            //returns new score
            this.ShowDialog();
            return score;
        }
    }
}
