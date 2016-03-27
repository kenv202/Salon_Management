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
    public partial class History : Form
    {
        StringBuilder textToPrint = new StringBuilder();
        public History(string _userName)
        {
            InitializeComponent();
            LoadTicket(_userName);
        }

        void LoadTicket(string _userName)
        {
            //try and get the ticket number if it exists
            int ticketNumber = 0;
            try
            {
                ticketNumber = Convert.ToInt32(QueryCommands.QueryDBMax("Activity", "Ticket_Number", _userName, DateTime.Now.ToShortDateString()));
            }
            catch
            {
                MessageBox.Show(_userName + " does not appear to have printed any ticket yet today.");
            }
            int total = 0;
            //loop through each tickets
            for (int i = 1; i <= ticketNumber; i++)
            {
                //header
                textToPrint.Append(Receipt_Format.Header(_userName, i.ToString(),DateTime.Now.ToShortDateString() + " " + QueryCommands.QueryDB("select Timestamp from Activity where Ticket_Number = " + i ,"Timestamp")));
                //the actual items
                string sql = "select * from Activity where UserID = " + "\"" + _userName + "\"" + " and Date = " + "\"" + DateTime.Now.ToShortDateString() + "\"" + " and Ticket_Number = " + "\"" + i.ToString()+ "\"";
                int subTotal = 0;
                SQLiteCommand command = new SQLiteCommand(sql, SQL_Setup.m_dbConnection); 
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    textToPrint.AppendLine(string.Format("{0,-24}{1,3}", reader["Service"], reader["Price"]));
                    subTotal += Convert.ToInt32(reader["Price"]);
                }
                textToPrint.AppendLine();
                textToPrint.AppendLine(string.Format("{0,-24}{1,3}", "SUBTOTAL", subTotal));
                textToPrint.AppendLine(string.Format("{0,-24}{1,3}", "TOTAL", total+=subTotal));
                //next receipt
                textToPrint.AppendLine();
            }

            //display it
            pbPrintPreview.Invalidate();
        }

        private void pbPrintPreview_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.DrawString(textToPrint.ToString(), new Font("Courier New", 8),
         new SolidBrush(Color.Black), 0, 0);
        }
    }
}
