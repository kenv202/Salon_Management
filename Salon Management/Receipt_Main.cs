using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Salon_Management
{
    public partial class Receipt_Main : Form
    {
        System.Timers.Timer mouseDownTimer = new System.Timers.Timer();
        List<KeyValuePair<String,List<String>>> final_services = new List<KeyValuePair<string,List<string>>>();

        StringBuilder textToPrint = new StringBuilder();
        //String
        String _userName = "";
        String currentCategory = "";
        String currentButtonService = "";
        //Enum
        enum Cycle
        {
            Initial,
            Category_Selected,
            Service_Selected,
            Additional_Service_Selected
        }
        //int
        int fontSize = 12;

        Cycle state = Cycle.Initial;
        public Receipt_Main(String userName)
        {
            InitializeComponent();
            _userName = userName;
            this.Text = "Log in as " + _userName;
            flpServices.Controls.Clear();
            populateCategoryTable("Category", "Service_Type");
            mouseDownTimer.Interval = 500;
            mouseDownTimer.Elapsed += mouseDownTimer_Elapsed;
        }

        void mouseDownTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            mouseDownTimer.Stop();
            //bring up edit window
            using(PriceEditor pe = new PriceEditor())
            {
                if(pe.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        dgvDisplayTable.Rows.Add(currentButtonService, pe.lCurrentPriceValue.Text);
                        sumColumn(1);
                        currentButtonService = "";
                    }));          
                }
            }
        }

        void populateCategoryTable(string table, string columnName)
        {
            //clear control
            flpCategory.Controls.Clear();

            //Load category
            string sql = "select * from " + table;
            SQLiteCommand command = new SQLiteCommand(sql, SQL_Setup.m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Button newButton = new Button();
                newButton.Size = new Size(290, 59);
                newButton.Font = new Font(newButton.Font.FontFamily, fontSize);
                newButton.UseMnemonic = false; //allow display of &
                newButton.Text = reader[columnName].ToString();
                newButton.Click += newButton_Click;
                newButton.MouseDown += newButton_MouseDown;
                newButton.MouseUp += newButton_MouseUp;
                flpCategory.Controls.Add(newButton);
            }
        }

        void newButton_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDownTimer.Stop();
        }

        void newButton_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownTimer.Start();
            currentButtonService = (sender as Button).Text;
        }

        void populateServiceTable(string table, string columnName)
        {
            //clear panel
            flpServices.Controls.Clear();
            //Load category
            string sql = "select * from " + table;
            SQLiteCommand command = new SQLiteCommand(sql, SQL_Setup.m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Button serviceButton = new Button();
                serviceButton.Size = new Size(290, 59);
                serviceButton.Font = new Font(serviceButton.Font.FontFamily, fontSize);
                serviceButton.UseMnemonic = false; //allow display of &
                serviceButton.Text = reader[columnName].ToString();
                serviceButton.Click += serviceButton_Click;
                serviceButton.MouseUp += serviceButton_MouseUp;
                serviceButton.MouseDown += serviceButton_MouseDown;
                flpServices.Controls.Add(serviceButton);
            }
        }

        void serviceButton_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownTimer.Start();
            currentButtonService = (sender as Button).Text;
        }

        void serviceButton_MouseUp(object sender, MouseEventArgs e)
        {
             mouseDownTimer.Stop();
        }    

        void serviceButton_Click(object sender, EventArgs e)
        {
            if (state == Cycle.Initial)
            {
                state = Cycle.Service_Selected;
                //update category
                populateCategoryTable(currentCategory, "Service_Name");
                //update the additional services
                if (currentCategory.Equals("Hand") || currentCategory.Equals("Feet") || currentCategory.Equals("Acrylic") || currentCategory.Equals("Monthly_Coupon"))
                {
                    populateServiceTable("Additional_Services", "Service_Name");
                }
                else
                {
                    flpServices.Controls.Clear();
                }
                //add it as the first item to the recipt
                dgvDisplayTable.Rows.Add((sender as Button).Text, QueryCommands.QueryDBForPrice(currentCategory,(sender as Button).Text));
                sumColumn(1);
            }
            else if (state == Cycle.Service_Selected)
            {
                //Here we would add the additional services selected to the reciept
                dgvDisplayTable.Rows.Add("  +" + (sender as Button).Text, QueryCommands.QueryDBForPrice("Additional_Services", (sender as Button).Text));
                sumColumn(1);
            }
        }

        void newButton_Click(object sender, EventArgs e)
        {
            updateServiceLayoutPanel((sender as Button).Text);
        }

        void sumColumn(int columnIndex)
        {
            int sum = 0;
            for (int i = 0; i < dgvDisplayTable.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dgvDisplayTable.Rows[i].Cells[columnIndex].Value);
            }
            lTotal.Text = sum.ToString();
        }

        void updateServiceLayoutPanel(string category)
        {
            if (state == Cycle.Initial)
            {
                currentCategory = category;
                populateServiceTable(category, "Service_Name");
            }
            else if(state == Cycle.Service_Selected)
            {
                dgvDisplayTable.Rows.Add(category, QueryCommands.QueryDBForPrice(currentCategory, category));
                sumColumn(1);
            }
        }

        private void bDone_Click(object sender, EventArgs e)
        {
            if (state == Cycle.Service_Selected)
            {
                state = Cycle.Initial;
                flpServices.Controls.Clear();
                populateCategoryTable("Category", "Service_Type");
            }
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            if (dgvDisplayTable.Rows.Count > 0)
            {
                dgvDisplayTable.Rows.RemoveAt(dgvDisplayTable.Rows.Count - 1);
            }
            sumColumn(1);
        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            //try and get the ticket number if it exists
            int ticketNumber = 0;
            try
            {
                ticketNumber = Convert.ToInt32(QueryCommands.QueryDBMax("Activity", "Ticket_Number", _userName,DateTime.Now.ToShortDateString()));
            }
            catch
            {
                //no ticket exist yet so lets set it to '1'
                ticketNumber = 0;
            }
            ticketNumber++;
            //get header which is date time, username and ticket #
            textToPrint.Append(Receipt_Format.Header(_userName, ticketNumber.ToString()));
            //now lets gather all the services in the table
            for(int i = 0 ; i < dgvDisplayTable.Rows.Count; i++)
            {
                try
                {
                    //insert into DB
                    InsertIntoDB("Activity", "\"" + _userName + "\",\"" + DateTime.Now.ToShortDateString() + "\",\"" + dgvDisplayTable.Rows[i].Cells[0].Value.ToString() + "\",\"" + dgvDisplayTable.Rows[i].Cells[1].Value.ToString() + "\",\"" + ticketNumber + "\"");
                }
                catch(Exception e1)
                {
                    MessageBox.Show("Error Inserting into DB: " + e1.Message);
                }
                //append to printing text
                textToPrint.AppendLine(string.Format("{0,-24}{1,3}", dgvDisplayTable.Rows[i].Cells[0].Value.ToString(), dgvDisplayTable.Rows[i].Cells[1].Value.ToString()));
            }
            //now do the ending of the ticket
            textToPrint.AppendLine();
            textToPrint.AppendLine(string.Format("{0,-20}{1,7}", "TIP", "________"));
            textToPrint.AppendLine();
            textToPrint.AppendLine(string.Format("{0,-24}{1,3}", "SUBTOTAL", lTotal.Text));
            //gather the total from the table base on same date
            textToPrint.AppendLine(string.Format("{0,-24}{1,3}", "TOTAL", QueryCommands.QueryDBSum("Activity", "Price", DateTime.Now.ToShortDateString(), _userName) == string.Empty ? "0" : QueryCommands.QueryDBSum("Activity", "Price", DateTime.Now.ToShortDateString(), _userName)));

            //start print
            var doc = new PrintDocument();
            doc.PrintPage += new PrintPageEventHandler(ProvideContent);
            doc.Print();
            this.Close(); 
        }

        void InsertIntoDB(string table, string arguments)
        {
            string sql = "insert into " + table + " values (" + arguments + ")";
            SQLiteCommand command = new SQLiteCommand(sql, SQL_Setup.m_dbConnection);
            command.ExecuteNonQuery();
        }

        public void ProvideContent(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawString(textToPrint.ToString(), new Font("Courier New", 8), new SolidBrush(Color.Black), 0, 0);
        }
    }
}
