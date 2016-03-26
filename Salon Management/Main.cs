using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Salon_Management
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            
            //start SQL Connection
            SQL_Setup.openSQL();

            //clear the table
            flpUser.Controls.Clear();

            //load the user table
            string sql = "select * from Users";
            SQLiteCommand command = new SQLiteCommand(sql, SQL_Setup.m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Button newButton = new Button();
                newButton.Size = new Size(293, 59);
                newButton.Font = new Font(newButton.Font.FontFamily, 20);
                newButton.Text = reader["Username"].ToString();
                newButton.Click += newButton_Click;
                flpUser.Controls.Add(newButton);
            }
        }

        void newButton_Click(object sender, EventArgs e)
        {
           String userName = (sender as Button).Text;
            using(Receipt_Main rm = new Receipt_Main(userName))
            {
                rm.ShowDialog();
            }
        }

        private void bTotal_Click(object sender, EventArgs e)
        {
            using(Current_Running_Total crt = new Current_Running_Total())
            {
                crt.ShowDialog();
            }
        }
    }
}
