using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WisDot.Bos.Spr.Core.Data
{
    internal class DatabaseConnection
    {
        public string DatabaseName { get; set; }
        public Constants.DatabaseType DatabaseType { get; set; }
        public string ProviderName { get; set; }
        public string ConnectionString { get; set; }
    }
}
