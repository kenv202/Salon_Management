using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salon_Management
{
    public static class QueryCommands
    {
        public static string QueryDBForPrice(string table, string serviceName)
        {
            string sql = "select Price from " + table + " where Service_Name = " + "\"" + serviceName + "\"";
            SQLiteCommand command = new SQLiteCommand(sql, SQL_Setup.m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Read();
            return reader["Price"].ToString();
        }

        public static string QueryDB(string table, string selectWhat, string whereColumn, string equalsValue)
        {
            string sql = "select " + selectWhat + " from " + table + " where " + whereColumn + " = " + "\"" + equalsValue + "\"";
            SQLiteCommand command = new SQLiteCommand(sql, SQL_Setup.m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Read();
            return reader[selectWhat].ToString();
        }
        public static string QueryDB(string cmd,string column)
        {
            string sql = cmd;
            SQLiteCommand command = new SQLiteCommand(sql, SQL_Setup.m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Read();
            return reader[column].ToString();
        }
        public static string QueryDBMax(string table, string selectWhat, string userName)
        {
            string sql = "select max(" + selectWhat + ") from " + table + " where UserID = " + "\"" + userName + "\"";
            SQLiteCommand command = new SQLiteCommand(sql, SQL_Setup.m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Read();
            return reader["max(" + selectWhat + ")"].ToString();
        }
        public static string QueryDBMax(string table, string selectWhat, string userName, string date)
        {
            string sql = "select max(" + selectWhat + ") from " + table + " where UserID = " + "\"" + userName + "\"" + " and Date = " + "\"" + date + "\"";
            SQLiteCommand command = new SQLiteCommand(sql, SQL_Setup.m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Read();
            return reader["max(" + selectWhat + ")"].ToString();
        }
        public static string QueryDBSum(string table, string selectWhat, string Date)
        {
            string sql = "select sum(" + selectWhat + ") from " + table + " where Date = " + "\"" + Date + "\"";
            SQLiteCommand command = new SQLiteCommand(sql, SQL_Setup.m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Read();
            return reader["sum(" + selectWhat + ")"].ToString();
        }
        public static string QueryDBSum(string table, string selectWhat, string Date, string username)
        {
            string sql = "select sum(" + selectWhat + ") from " + table + " where Date = " + "\"" + Date + "\"" + " and UserID = " + "\"" + username + "\"";
            SQLiteCommand command = new SQLiteCommand(sql, SQL_Setup.m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Read();
            return reader["sum(" + selectWhat + ")"].ToString();
        }
    }
}
