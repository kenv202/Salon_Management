using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Salon_Management
{
    public partial class PriceEditor : Form
    {
        public PriceEditor()
        {
            InitializeComponent();
        }

        public double Evaluate(string expression)
        {
            DataTable table = new DataTable();
            table.Columns.Add("expression", typeof(string), expression);
            DataRow row = table.NewRow();
            table.Rows.Add(row);
            return double.Parse((string)row["expression"]);
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            tbUserInput.Text = "";
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            if (tbUserInput.Text != string.Empty && !tbUserInput.Text.Equals("") && tbUserInput.Text.Length > 0)
            {
                tbUserInput.Text = tbUserInput.Text.Remove(tbUserInput.Text.Length-1, 1);
            }
        }

        private void bDivide_Click(object sender, EventArgs e)
        {
            tbUserInput.Text += "/";
        }

        private void bMultiply_Click(object sender, EventArgs e)
        {
            tbUserInput.Text += "*";
        }

        private void bSubtract_Click(object sender, EventArgs e)
        {
            tbUserInput.Text += "-";
        }

        private void bPlus_Click(object sender, EventArgs e)
        {
            tbUserInput.Text += "+";
        }

        private void bEqual_Click(object sender, EventArgs e)
        {
            if (tbUserInput.Text != string.Empty && !tbUserInput.Text.Equals("") && tbUserInput.Text.Length > 0)
            {
                lCurrentPriceValue.Text = Evaluate(tbUserInput.Text).ToString();
                tbUserInput.Text = "";
            }
        }

        private void bOne_Click(object sender, EventArgs e)
        {
            tbUserInput.Text += "1";
        }

        private void bTwo_Click(object sender, EventArgs e)
        {
            tbUserInput.Text += "2";
        }

        private void bThree_Click(object sender, EventArgs e)
        {
            tbUserInput.Text += "3";
        }

        private void bFour_Click(object sender, EventArgs e)
        {
            tbUserInput.Text += "4";
        }

        private void bFive_Click(object sender, EventArgs e)
        {
            tbUserInput.Text += "5";
        }

        private void bSix_Click(object sender, EventArgs e)
        {
            tbUserInput.Text += "6";
        }

        private void bSeven_Click(object sender, EventArgs e)
        {
            tbUserInput.Text += "7";
        }

        private void bEight_Click(object sender, EventArgs e)
        {
            tbUserInput.Text += "8";
        }

        private void bNine_Click(object sender, EventArgs e)
        {
            tbUserInput.Text += "9";
        }

        private void bZero_Click(object sender, EventArgs e)
        {
            tbUserInput.Text += "0";
        }

        private void bPeriod_Click(object sender, EventArgs e)
        {
            tbUserInput.Text += ".";
        }

        private void bDone_Click(object sender, EventArgs e)
        {
            if (tbUserInput.Text != string.Empty && !tbUserInput.Text.Equals("") && tbUserInput.Text.Length > 0)
            {
                lCurrentPriceValue.Text = Evaluate(tbUserInput.Text).ToString();
                tbUserInput.Text = "";
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }


    }
}
