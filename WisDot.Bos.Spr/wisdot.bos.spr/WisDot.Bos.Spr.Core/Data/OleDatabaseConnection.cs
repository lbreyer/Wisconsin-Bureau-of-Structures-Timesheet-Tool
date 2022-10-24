using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace WisDot.Bos.Spr.Core.Data
{
    internal class OleDatabaseConnection : DatabaseConnection
    {
        public OleDbConnection OleDbConnection { get; set; }
    }
}
