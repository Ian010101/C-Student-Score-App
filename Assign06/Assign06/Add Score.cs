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
    public partial class Add_Score : Form
    {

        private double newScore;
        public Add_Score()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //checks to see if person inputted a valid score
            try
            {
                if (Convert.ToDouble(txtScore.Text) < 101 && Convert.ToDouble(txtScore.Text) > -1)
                {
                    newScore = Convert.ToDouble(txtScore.Text);
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("please input a number from 0 to 100");
            }
        }

        public double newestScore()
        {
            this.ShowDialog();
            return newScore;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //closes current form
            this.Close();
        }
    }
}
