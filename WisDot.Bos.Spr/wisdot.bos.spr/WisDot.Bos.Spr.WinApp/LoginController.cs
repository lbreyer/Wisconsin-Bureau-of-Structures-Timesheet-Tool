using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WisDot.Bos.Spr.Core.Domain.Models;
using WisDot.Bos.Spr.Core.Domain.Services;

namespace WisDot.Bos.Spr.WinApp
{
    public class LoginController
    {
        ILoginView _loginView;
        Employee employee;
        EmployeeService employeeService;

        public LoginController(ILoginView loginView)
        {
            this._loginView = loginView; // give you ability to invoke the View/Form methods
            loginView.SetController(this);
            employeeService = new EmployeeService();
        }

        public void Login(string userId, string password)
        {
            employee = employeeService.LoginGetEmployee(userId, password);
            this._loginView.UpdateAuthentication(employee != null ? true : false);
        }
    }
}
