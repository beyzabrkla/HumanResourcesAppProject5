using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;

namespace HumanResourcesApp.Models
{
    public class Dal
    {

        public DateTime lastQueryTime;
        public String lastQuerySQL;

        public SqlConnection myConnection = new SqlConnection("");


        public DataSet CommandExecuteReader(String sql, SqlConnection conn)
        {

            lastQueryTime = DateTime.Now;
            lastQuerySQL = sql;
            DataSet ds = new DataSet();
            privateOpen(conn);
            try
            {
                SqlCommand myCommand = new SqlCommand(sql, conn);
                myCommand.CommandTimeout = 600;

                SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand);

                dataAdapter.Fill(ds);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            finally
            {
                privateClose(conn);
            }

            return ds;
        }


        public SqlDataReader CommandExecuteSQLReader(String sql, SqlConnection conn, int errC)
        {

            lastQueryTime = DateTime.Now;
            lastQuerySQL = sql;
            SqlDataReader r;
            privateOpen(conn);
            try
            {
                SqlCommand myCommand = new SqlCommand(sql, conn);
                myCommand.CommandTimeout = 600;

                r = myCommand.ExecuteReader();
                return r;

            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            finally
            {
            }


            return null;
        }


        public string CommandExecuteSQLScalar(String sql, SqlConnection conn, int errC)
        {

            lastQueryTime = DateTime.Now;
            lastQuerySQL = sql;
            string r;
            privateOpen(conn);
            try
            {
                SqlCommand myCommand = new SqlCommand(sql, conn);
                myCommand.CommandTimeout = 600;

                r = myCommand.ExecuteScalar().ToString();
                return r;

            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            finally
            {
                privateClose(conn);
            }


            return null;
        }

        public void CommandExecuteNonQuery(String sql, SqlConnection conn)
        {
            lastQueryTime = DateTime.Now;
            lastQuerySQL = sql;

            privateOpen(conn);
            try
            {
                SqlCommand myCommand = new SqlCommand(sql, conn);
                myCommand.CommandTimeout = 600;
                myCommand.ExecuteNonQuery();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);

                try
                {
                    string sqllog = $"insert into ms_sql_log(log_text) values('{exp.Message}') ";
                    SqlCommand myCommand = new SqlCommand(sqllog, conn);
                    myCommand.CommandTimeout = 600;
                    myCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            finally
            {
                privateClose(conn);
            }
        }

        public bool BoolCommandExecuteNonQuery(String sql, SqlConnection conn)
        {
            lastQueryTime = DateTime.Now;
            lastQuerySQL = sql;

            privateOpen(conn);
            try
            {


                SqlCommand myCommand = new SqlCommand(sql, conn);
                myCommand.CommandTimeout = 600;
                myCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);


                return false;
            }
            finally
            {
                privateClose(conn);
            }
        }


        private void privateOpen(SqlConnection connection)
        {
            try
            {
                ConControl(connection);
            }
            catch (Exception)
            {
            }
        }
        private void privateClose(SqlConnection connection)
        {
            try
            {
                connection.Close();
            }
            catch (Exception)
            {
            }
        }


        public void OpenSQLConnection(String ConnectionString, SqlConnection conn)
        {
            myConnection = new SqlConnection(ConnectionString);

            ConControl(myConnection);

        }

        public void ConControl(SqlConnection c)
        {
            if (c.State != ConnectionState.Open)
            {
                c.Open();
            }
        }

        public void closeConnection()
        {
            myConnection.Close();
        }

        ~Dal()
        {
            privateClose(myConnection);
            try
            {
                myConnection.Dispose();
            }
            catch (Exception)
            {
            }
        }
    }
}
