using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WisDot.Bos.Spr.Core.Domain.Models;

namespace WisDot.Bos.Spr.Core.Infrastructure.Interfaces
{
    internal interface IEmployeeRepository
    {
        Employee GetEmployeeById(int id);
        Employee GetEmployeeByName(string firstName, string lastName);
        Employee LoginGetEmployee(string userName, string userPassword);
        bool AuthenticateEmployee(string userId, string password);
        //IEnumerable<Employee> GetEmployees();
        //Employee LoginEmployee(string userId, string password);
    }
}
