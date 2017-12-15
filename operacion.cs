using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace nomina
{
    public class operacion
    {

        public string ExecuteNonQuery(string sql)
        {

            SQLiteConnection cnx = new SQLiteConnection("Data Source=C://bdnomina/tablanomina.db;Version=3;");

            try

            {

                cnx.Open();
                SQLiteCommand command = new SQLiteCommand(sql, cnx);
                command.ExecuteNonQuery();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                cnx.Close();
            }

        }

        public DataTable ExtraeData(string sql)
        {

            SQLiteDataAdapter ad;

            DataTable dt = new DataTable();
            SQLiteConnection cnx = new SQLiteConnection("Data Source=C://bdnomina/tablanomina.db;Version=3;");
            try
            {
                cnx.Open();
                SQLiteCommand cmd;
                cmd = cnx.CreateCommand();
                cmd.CommandText = sql;
                ad = new SQLiteDataAdapter(cmd);
                ad.Fill(dt);
            }
            catch (SQLiteException)
            {

            }
            cnx.Close();
            return dt;
        }

        internal DataTable ExtraeData(string v, operacion oper)
        {
            throw new NotImplementedException();
        }
    }
}
