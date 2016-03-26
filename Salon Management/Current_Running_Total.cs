using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Salon_Management
{
    public partial class Current_Running_Total : Form
    {
        public Current_Running_Total()
        {
            InitializeComponent();
            //add header
            dgvTotal.Columns.Add("1","Name");
            dgvTotal.Columns.Add("2", "Total");
            string sql = "select * from Users";
            SQLiteCommand command = new SQLiteCommand(sql, SQL_Setup.m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                dgvTotal.Rows.Add(reader["Username"], QueryCommands.QueryDBSum("Activity", "Price", DateTime.Now.ToShortDateString(), reader["UserName"].ToString()) == string.Empty ? "0" : QueryCommands.QueryDBSum("Activity", "Price", DateTime.Now.ToShortDateString(), reader["UserName"].ToString()));
            }              
        }
    }
}
