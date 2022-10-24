using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WisDot.Bos.Spr.Core.Data
{
    internal class SqlDatabaseConnection : DatabaseConnection
    {
        public SqlConnection SqlConnection { get; set; }
    }
}
