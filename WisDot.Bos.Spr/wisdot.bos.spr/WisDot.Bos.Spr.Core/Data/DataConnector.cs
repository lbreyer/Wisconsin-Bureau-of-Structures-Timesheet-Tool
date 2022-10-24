using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using Oracle.DataAccess.Client;
using System.Data.OleDb;

namespace WisDot.Bos.Spr.Core.Data
{
    internal class DataConnector
    {
        #region Fields
        private static List<DatabaseConnection> databaseConnections;
        private static readonly string hsisDatabase = ConfigurationManager.AppSettings["HsisDatabase"].ToString();
        private static readonly string wisamsDatabase = ConfigurationManager.AppSettings["WisamsDatabase"].ToString();
        private static readonly string fiipsDatabase = ConfigurationManager.AppSettings["FiipsDatabase"].ToString();
        private static readonly string structuresProgressReportDatabase = ConfigurationManager.AppSettings["StructuresProgressReportDatabase"].ToString();
        private static readonly string hsisFileDirectory = ConfigurationManager.ConnectionStrings["HsisFileDirectory"].ConnectionString;
        private static readonly string timesheetFilePath = ConfigurationManager.ConnectionStrings["TimesheetDataFile"].ConnectionString;
        private static readonly string outputDirectory = ConfigurationManager.ConnectionStrings["OutputDirectory"].ConnectionString;
        #endregion Fields

        #region Constructors
        public DataConnector()
        {
            if (databaseConnections == null)
            {
                databaseConnections = getDatabaseConnectionStringsFromConfigurationFile();
            }
        }
        #endregion Constructors

        #region General methods
        public string GetTimesheetFilePath()
        {
            return timesheetFilePath;
        }

        public string GetProgressReportFilePath()
        {
            return RequestOleConnection(Constants.DatabaseType.structuresProgressReportDatabase).OleDbConnection.DataSource;
        }

        public string GetOutputDirectory()
        {
            return outputDirectory;
        }

        public DatabaseConnection RequestDatabaseConnection(Constants.DatabaseType databaseType)
        {
            DatabaseConnection dbConn = null;

            if (databaseConnections.Where(item => item.DatabaseType == databaseType).Count() > 0)
            {
                dbConn = databaseConnections.Where(item => item.DatabaseType == databaseType).First();

                if (dbConn is SqlDatabaseConnection)
                {
                    dbConn = (SqlDatabaseConnection)dbConn;
                }
                else if (dbConn is OracleDatabaseConnection)
                {
                    dbConn = (OracleDatabaseConnection)dbConn;
                }
                else if (dbConn is OleDatabaseConnection)
                {
                    dbConn = (OleDatabaseConnection)dbConn;
                }
            }

            return dbConn;
        }

        private List<DatabaseConnection> getDatabaseConnectionStringsFromConfigurationFile()
        {
            List<DatabaseConnection> connections = new List<DatabaseConnection>();

            foreach (ConnectionStringSettings connectionStringSettings in ConfigurationManager.ConnectionStrings)
            {
                var connectionString = connectionStringSettings.ConnectionString.Trim();
                var name = connectionStringSettings.Name.Trim().ToLower();

                if (!string.IsNullOrEmpty(connectionString)
                    && (name.Equals(hsisDatabase, StringComparison.CurrentCultureIgnoreCase)
                        || name.Equals(wisamsDatabase, StringComparison.CurrentCultureIgnoreCase)
                        || name.Equals(fiipsDatabase, StringComparison.CurrentCultureIgnoreCase)
                        || name.Equals(structuresProgressReportDatabase, StringComparison.CurrentCultureIgnoreCase)
                        ))
                {
                    DatabaseConnection dbConn = null;

                    if (name.Equals(hsisDatabase, StringComparison.CurrentCultureIgnoreCase)
                        || name.Equals(wisamsDatabase, StringComparison.CurrentCultureIgnoreCase)
                        || name.Equals(fiipsDatabase, StringComparison.CurrentCultureIgnoreCase))
                    {
                        SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder(connectionStringSettings.ConnectionString);

                        if (!string.IsNullOrEmpty(csb.Password))
                        {
                            string decryptedPassword = CryptorEngine.Decrypt(csb.Password, true);
                            connectionString = connectionString.Replace(csb.Password, decryptedPassword);

                            if (connectionStringSettings.ProviderName.Equals("Sql"))
                            {
                                var conn = new SqlDatabaseConnection();
                                conn.SqlConnection = new SqlConnection(connectionString);
                                dbConn = conn;

                            }
                            else if (connectionStringSettings.ProviderName.Equals("Oracle"))
                            {
                                var conn = new OracleDatabaseConnection();
                                conn.OracleConnection = new OracleConnection(connectionString);
                                dbConn = conn;
                            }
                            else if (connectionStringSettings.ProviderName.Equals("Access"))
                            {
                                var conn = new OleDbConnection();
                            }

                            dbConn.ConnectionString = connectionString;
                            dbConn.ProviderName = connectionStringSettings.ProviderName;
                            dbConn.DatabaseName = connectionStringSettings.Name;

                            if (name.ToLower().Equals(hsisDatabase.ToLower()))
                            {
                                dbConn.DatabaseType = Constants.DatabaseType.hsisDatabase;
                            }
                            else if (name.ToLower().Equals(wisamsDatabase.ToLower()))
                            {
                                dbConn.DatabaseType = Constants.DatabaseType.wisamsDatabase;
                            }
                            else if (name.ToLower().Equals(fiipsDatabase.ToLower()))
                            {
                                dbConn.DatabaseType = Constants.DatabaseType.fiipsDatabase;
                            }
                        }
                    }
                    else if (name.Equals(structuresProgressReportDatabase, StringComparison.CurrentCultureIgnoreCase))
                    {
                        var conn = new OleDatabaseConnection();
                        conn.OleDbConnection = new OleDbConnection(connectionString);
                        dbConn = conn;
                        dbConn.ConnectionString = connectionString;
                        dbConn.ProviderName = connectionStringSettings.ProviderName;
                        dbConn.DatabaseName = connectionStringSettings.Name;
                        dbConn.DatabaseType = Constants.DatabaseType.structuresProgressReportDatabase;
                    }

                    connections.Add(dbConn);
                }
            }

            return connections;
        }
        #endregion General methods

        #region SQL methods
        public SqlDatabaseConnection RequestSqlConnection(Constants.DatabaseType databaseType)
        {
            SqlDatabaseConnection dbConn = null;
            
            if (databaseConnections.Where(item => item.DatabaseType == databaseType).Count() > 0)
            {
                dbConn = (SqlDatabaseConnection)databaseConnections.Where(item => item.DatabaseType == databaseType).First();
                dbConn.SqlConnection = openSqlConnection(dbConn.SqlConnection);
            }

            return dbConn;
        }

        public DataTable ExecuteSelectSql(string qry, SqlConnection conn)
        {
            DataTable dt = null;
            DataSet ds = new DataSet();

            try
            {
                SqlCommand cmd1 = new SqlCommand(qry, conn);
                cmd1.CommandType = CommandType.Text;
                SqlDataAdapter adp1 = new SqlDataAdapter(cmd1);
                adp1.Fill(ds);
                adp1.Dispose();
                dt = ds.Tables[0];
            }
            catch (SqlException e)
            {
                Debug.Print("Error in query: {0} \nException: {1}", qry, e.StackTrace.ToString());
            }
            catch (Exception e)
            {
                Debug.Print("Error in query: {0} \nException: {1}", qry, e.StackTrace.ToString());
            }

            return dt;
        }

        public DataTable ExecuteSelectSql(string qry, SqlParameter[] prms, SqlConnection conn)
        {
            conn = openSqlConnection(conn);
            DataTable dt = null;
            DataSet ds = new DataSet();

            try
            {
                SqlCommand cmd1 = new SqlCommand(qry, conn);
                cmd1.CommandType = CommandType.Text;
                cmd1.Parameters.AddRange(prms);
                SqlDataAdapter adp1 = new SqlDataAdapter(cmd1);
                adp1.Fill(ds);
                adp1.Dispose();
                dt = ds.Tables[0];
            }
            catch (SqlException e)
            {
                Debug.Print("Error in query: {0} \nException: {1}", qry, e.StackTrace.ToString());
            }
            catch (Exception e)
            {
                Debug.Print("Error in query: {0} \nException: {1}", qry, e.StackTrace.ToString());
            }

            return dt;
        }

        public void ExecuteInsertUpdateDelete(string qry, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd1 = new SqlCommand(qry, conn);
                cmd1.CommandType = CommandType.Text;
                cmd1.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Debug.Print("Error in query: {0} \nException: {1}", qry, e.StackTrace.ToString());
            }
            catch (Exception e)
            {
                Debug.Print("Error in query: {0} \nException: {1}", qry, e.StackTrace.ToString());
            }
        }

        public void ExecuteInsertUpdateDelete(string qry, SqlParameter[] prms, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd1 = new SqlCommand(qry, conn);
                cmd1.CommandType = CommandType.Text;
                cmd1.Parameters.AddRange(prms);
                cmd1.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Debug.Print("Error in query: {0} \nException: {1}", qry, e.StackTrace.ToString());
            }
            catch (Exception e)
            {
                Debug.Print("Error in query: {0} \nException: {1}", qry, e.StackTrace.ToString());
            }
        }

        private SqlConnection openSqlConnection(SqlConnection sqlConnection)
        {
            if (sqlConnection == null || sqlConnection.State == ConnectionState.Closed || sqlConnection.State == ConnectionState.Broken)
            {
                sqlConnection = new SqlConnection(sqlConnection.ConnectionString);

                if (sqlConnection.State == ConnectionState.Closed || sqlConnection.State == ConnectionState.Broken)
                {
                    try
                    {
                        sqlConnection.Open();
                    }
                    catch { }
                }
            }

            return sqlConnection;
        }
        #endregion SQL methods

        #region Ole methods
        public OleDatabaseConnection RequestOleConnection(Constants.DatabaseType databaseType)
        {
            OleDatabaseConnection dbConn = null;

            if (databaseConnections.Where(item => item.DatabaseType == databaseType).Count() > 0)
            {
                dbConn = (OleDatabaseConnection)databaseConnections.Where(item => item.DatabaseType == databaseType).First();
                dbConn.OleDbConnection = openOleDbConnection(dbConn.OleDbConnection);
            }

            return dbConn;
        }

        public DataTable ExecuteSelectOle(string qry, OleDbConnection conn)
        {
            conn = openOleDbConnection(conn);
            DataTable dt = null;
            DataSet ds = new DataSet();

            try
            {
                OleDbCommand cmd1 = new OleDbCommand(qry, conn);
                cmd1.CommandType = CommandType.Text;
                OleDbDataAdapter adp1 = new OleDbDataAdapter(cmd1);
                adp1.Fill(ds);
                adp1.Dispose();
                dt = ds.Tables[0];
            }
            catch (OleDbException e)
            {
                Debug.Print("Error in query: {0} \nException: {1}", qry, e.StackTrace.ToString());
            }
            catch (Exception e)
            {
                Debug.Print("Error in query: {0} \nException: {1}", qry, e.StackTrace.ToString());
            }
            finally { }

            return dt;
        }

        public DataTable ExecuteSelectOle(string qry, OleDbParameter[] prms, OleDbConnection conn)
        {
            conn = openOleDbConnection(conn);
            DataTable dt = null;
            DataSet ds = new DataSet();

            try
            {
                OleDbCommand cmd1 = new OleDbCommand(qry, conn);
                cmd1.CommandType = CommandType.Text;
                cmd1.Parameters.AddRange(prms);
                OleDbDataAdapter adp1 = new OleDbDataAdapter(cmd1);
                adp1.Fill(ds);
                adp1.Dispose();
                dt = ds.Tables[0];
            }
            catch (OleDbException e)
            {
                Debug.Print("Error in query: {0} \nException: {1}", qry, e.StackTrace.ToString());
            }
            catch (Exception e)
            {
                Debug.Print("Error in query: {0} \nException: {1}", qry, e.StackTrace.ToString());
            }
            finally { }

            return dt;
        }

        public void ExecuteInsertUpdateDelete(string qry, OleDbConnection conn)
        {
            try
            {
                OleDbCommand cmd1 = new OleDbCommand(qry, conn);
                cmd1.CommandType = CommandType.Text;
                cmd1.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Debug.Print("Error in query: {0} \nException: {1}", qry, e.StackTrace.ToString());
            }
            catch (Exception e)
            {
                Debug.Print("Error in query: {0} \nException: {1}", qry, e.StackTrace.ToString());
            }
        }

        public void ExecuteInsertUpdateDelete(string qry, OleDbParameter[] prms, OleDbConnection conn)
        {
            try
            {
                OleDbCommand cmd1 = new OleDbCommand(qry, conn);
                cmd1.CommandType = CommandType.Text;
                cmd1.Parameters.AddRange(prms);
                cmd1.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Debug.Print("Error in query: {0} \nException: {1}", qry, e.StackTrace.ToString());
            }
            catch (Exception e)
            {
                Debug.Print("Error in query: {0} \nException: {1}", qry, e.StackTrace.ToString());
            }
        }

        private OleDbConnection openOleDbConnection(OleDbConnection oleDbConnection)
        {
            if (oleDbConnection == null || oleDbConnection.State == ConnectionState.Closed || oleDbConnection.State == ConnectionState.Broken)
            {
                oleDbConnection = new OleDbConnection(oleDbConnection.ConnectionString);

                if (oleDbConnection.State == ConnectionState.Closed || oleDbConnection.State == ConnectionState.Broken)
                {
                    try
                    {
                        oleDbConnection.Open();
                    }
                    catch { }
                }
            }

            return oleDbConnection;
        }
        #endregion Ole methods
    }
}
