using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using WisDot.Bos.Spr.Core.Domain.Models;
using WisDot.Bos.Spr.Core.Data;
using WisDot.Bos.Spr.Core.Data.Interfaces;
using WisDot.Bos.Spr.Core.Infrastructure.Interfaces;

namespace WisDot.Bos.Spr.Core.Infrastructure
{
    internal class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeQuery employeeQuery = new EmployeeQuery();

        public List<Employee> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeById(int id)
        {
            Employee employee = convertDataTableToEmployee(employeeQuery.GetEmployee(id));
            return employee;
        }

        public Employee GetEmployeeByName(string firstName, string lastName)
        {
            throw new NotImplementedException();
        }

        public Employee LoginEmployee(string userId, string password)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateEmployee(string userId, string password)
        {
            return employeeQuery.AuthenticateEmployee(userId, password);
        }

        public Employee LoginGetEmployee(string userName, string userPassword)
        {
            throw new NotImplementedException();
        }

        private Employee convertDataTableToEmployee(DataTable dt)
        {
            Employee employee = null;

            return employee;
        }

        
    }
}
