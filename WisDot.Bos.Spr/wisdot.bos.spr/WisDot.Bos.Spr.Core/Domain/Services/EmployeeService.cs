using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WisDot.Bos.Spr.Core.Domain.Models;
using WisDot.Bos.Spr.Core.Domain.Services.Interfaces;
using WisDot.Bos.Spr.Core.Infrastructure.Interfaces;
using WisDot.Bos.Spr.Core.Infrastructure;

namespace WisDot.Bos.Spr.Core.Domain.Services
{
    public class EmployeeService : IEmployeeService
    {
        private EmployeeRepository employeeRepository = new EmployeeRepository();

        public EmployeeService()
        {
            //this.employeeRepository = employeeRepository;
        }

        public Employee GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeByName(string firstName, string lastName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public bool LoginEmployee(string userId, string password)
        {
            return employeeRepository.AuthenticateEmployee(userId, password);
            //throw new NotImplementedException();
        }

        public Employee LoginGetEmployee(string userId, string password)
        {
            return employeeRepository.LoginGetEmployee(userId, password);
        }
    }
}
