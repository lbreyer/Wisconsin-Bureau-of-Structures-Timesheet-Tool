using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Configuration;
using System.Data;
using Oracle.DataAccess.Client;

namespace WisDot.Bos.Spr.Core.Data
{
    internal class OracleDatabaseConnection : DatabaseConnection
    {
        public OracleConnection OracleConnection { get; set; }
    }
}
