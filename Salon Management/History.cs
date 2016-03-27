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
        string _userName = "";
        int ticketNumber = 0;
        public History(string userName)
        {
            InitializeComponent();
            _userName = userName;
            LoadTicket();
        }

        void LoadTicket()
        {
            //try and get the ticket number if it exists
            try
            {
                ticketNumber = Convert.ToInt32(QueryCommands.QueryDBMax("Activity", "Ticket_Number", _userName, DateTime.Now.ToShortDateString()));
                for(int i = 1 ; i <= ticketNumber; i++)
                {
                    cbTicketNumber.Items.Add(i);
                }
                cbTicketNumber.Items.Add("ALL");
                cbTicketNumber.SelectedIndex = 0;
            }
            catch
            {
                MessageBox.Show(_userName + " does not appear to have printed any ticket yet today.");
            }
        }

        private void pbPrintPreview_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.DrawString(textToPrint.ToString(), new Font("Courier New", 8),
         new SolidBrush(Color.Black), 0, 0);
        }

        private void bShow_Click(object sender, EventArgs e)
        {
            textToPrint.Clear();
            int total = 0;
            int additonal_length = 0;
            int height_add = 20;
            //loop through each tickets
            for (int i = 1; i <= ticketNumber; i++)
            {
                if(cbTicketNumber.SelectedItem.ToString().Equals("ALL"))
                {
                    //header
                    textToPrint.Append(Receipt_Format.Header(_userName, i.ToString(), DateTime.Now.ToShortDateString() + " " + QueryCommands.QueryDB("select Timestamp from Activity where Ticket_Number = " + i, "Timestamp")));
                    additonal_length += height_add;
                }
                else if (Convert.ToInt32(cbTicketNumber.SelectedItem.ToString()) == i)
                {
                    //header
                    textToPrint.Append(Receipt_Format.Header(_userName, i.ToString(), DateTime.Now.ToShortDateString() + " " + QueryCommands.QueryDB("select Timestamp from Activity where Ticket_Number = " + i, "Timestamp")));
                    additonal_length += height_add;
                }
                //the actual items
                string sql = "select * from Activity where UserID = " + "\"" + _userName + "\"" + " and Date = " + "\"" + DateTime.Now.ToShortDateString() + "\"" + " and Ticket_Number = " + "\"" + i.ToString() + "\"";
                int subTotal = 0;
                SQLiteCommand command = new SQLiteCommand(sql, SQL_Setup.m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (cbTicketNumber.SelectedItem.ToString().Equals("ALL"))
                    {
                        textToPrint.AppendLine(string.Format("{0,-24}{1,3}", reader["Service"], reader["Price"]));
                        additonal_length += height_add;
                    }
                    else if (Convert.ToInt32(cbTicketNumber.SelectedItem.ToString()) == i)
                    {
                        textToPrint.AppendLine(string.Format("{0,-24}{1,3}", reader["Service"], reader["Price"]));
                        additonal_length += height_add;
                    }
                    subTotal += Convert.ToInt32(reader["Price"]);                
                }
                total += subTotal;
                if (cbTicketNumber.SelectedItem.ToString().Equals("ALL"))
                {
                    textToPrint.AppendLine();
                    additonal_length += height_add;
                    textToPrint.AppendLine(string.Format("{0,-24}{1,3}", "SUBTOTAL", subTotal));
                    additonal_length += height_add;
                    textToPrint.AppendLine(string.Format("{0,-24}{1,3}", "TOTAL", total));
                    additonal_length += height_add;
                    //next receipt
                    textToPrint.AppendLine();
                    additonal_length += height_add;
                }
                else  if (Convert.ToInt32(cbTicketNumber.SelectedItem.ToString()) == i)
                {
                    textToPrint.AppendLine();
                    additonal_length += height_add;
                    textToPrint.AppendLine(string.Format("{0,-24}{1,3}", "SUBTOTAL", subTotal));
                    additonal_length += height_add;
                    textToPrint.AppendLine(string.Format("{0,-24}{1,3}", "TOTAL", total));
                    additonal_length += height_add;
                    //next receipt
                    textToPrint.AppendLine();
                    additonal_length += height_add;
                }
            }
            //resize the picturebox based on how much text we added
            pbPrintPreview.Size = new System.Drawing.Size(213, additonal_length);
            //display it
            pbPrintPreview.Invalidate();

        }
    }
}
