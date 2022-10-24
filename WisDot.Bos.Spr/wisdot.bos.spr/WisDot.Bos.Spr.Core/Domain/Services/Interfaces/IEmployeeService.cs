using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WisDot.Bos.Spr.Core.Domain.Models;
using WisDot.Bos.Spr.Core.Infrastructure.Interfaces;

namespace WisDot.Bos.Spr.Core.Domain.Services.Interfaces
{
    public interface IEmployeeService
    {
        Employee GetEmployeeById(int id);
        Employee GetEmployeeByName(string firstName, string lastName);
        IEnumerable<Employee> GetEmployees();
        Employee LoginGetEmployee(string userId, string password);
        bool LoginEmployee(string userId, string password);
    }
}
