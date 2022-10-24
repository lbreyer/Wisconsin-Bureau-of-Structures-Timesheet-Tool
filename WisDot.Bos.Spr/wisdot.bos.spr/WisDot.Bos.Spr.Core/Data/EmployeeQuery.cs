using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using WisDot.Bos.Spr.Core.Data.Interfaces;

namespace WisDot.Bos.Spr.Core.Data
{
    internal class EmployeeQuery : IEmployeeQuery
    {
        private static DataConnector dataConnector;
        private static SqlDatabaseConnection wisamsDbConn;
        private static OleDatabaseConnection progressReportDbConn;

        public EmployeeQuery()
        {
            dataConnector = new DataConnector();
            wisamsDbConn = dataConnector.RequestSqlConnection(Constants.DatabaseType.wisamsDatabase);
            progressReportDbConn = dataConnector.RequestOleConnection(Constants.DatabaseType.structuresProgressReportDatabase);
        }

        public DataTable GetEmployee(int userDbId)
        {
            DataTable dt = null;
            string qry =
                @"
                    select *
                    from Users
                    where UserDbId = @userDbId
                ";
            SqlParameter[] prms = new SqlParameter[1];
            prms[0] = new SqlParameter("@userDbId", SqlDbType.Int);
            prms[0].Value = userDbId;
            dt = dataConnector.ExecuteSelectSql(qry, prms, wisamsDbConn.SqlConnection);
            return dt;
        }

        public DataTable LoginGetEmployee(string userName, string userPassword)
        {
            DataTable dt = null;
            string qry =
                @"
                    select *
                    from Users
                    where UserName = @userName
                        and UserPassword = @userPassword
                ";
            SqlParameter[] prms = new SqlParameter[2];
            prms[0] = new SqlParameter("@userName", SqlDbType.VarChar);
            prms[0].Value = userName;
            prms[1] = new SqlParameter("@userPassword", SqlDbType.VarChar);
            prms[1].Value = userPassword;
            dt = dataConnector.ExecuteSelectSql(qry, prms, wisamsDbConn.SqlConnection);
            return dt;
        }

        public bool AuthenticateEmployee(string userName, string userPassword)
        {
            bool isAuthenticated = false;
            string qry =
                @"
                    select UserDbId
                    from Users
                    where UserName = @userName
                        and UserPassword = @userPassword
                ";
            SqlParameter[] prms = new SqlParameter[2];
            prms[0] = new SqlParameter("@userName", SqlDbType.VarChar);
            prms[0].Value = userName;
            prms[1] = new SqlParameter("@userPassword", SqlDbType.VarChar);
            prms[1].Value = userPassword;
            DataTable dt = dataConnector.ExecuteSelectSql(qry, prms, wisamsDbConn.SqlConnection);

            if (dt != null && dt.Rows.Count > 0)
            {
                isAuthenticated = true;
            }

            return isAuthenticated;
        }

        public DataTable GetEmployees()
        {
            throw new NotImplementedException();
        }
    }
}
