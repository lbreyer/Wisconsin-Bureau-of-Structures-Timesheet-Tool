using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WisDot.Bos.Spr.Core.Data.Interfaces
{
    internal interface IEmployeeQuery
    {
        DataTable GetEmployee(int userDbId);
        DataTable GetEmployees();
        DataTable LoginGetEmployee(string userName, string userPassword);
        bool AuthenticateEmployee(string userName, string userPassword);
    }
}
