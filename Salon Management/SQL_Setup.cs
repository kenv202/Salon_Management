using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Salon_Management
{
    public static class SQL_Setup
    {
        static string dB_Name = "MyDatabase.sqlite";
        public static SQLiteConnection m_dbConnection;

        public static void openSQL()
        {
            if (!File.Exists(dB_Name))
            {
                SQLiteConnection.CreateFile(dB_Name);
            }

            try
            {
                m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
                m_dbConnection.Open();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

    }
}
