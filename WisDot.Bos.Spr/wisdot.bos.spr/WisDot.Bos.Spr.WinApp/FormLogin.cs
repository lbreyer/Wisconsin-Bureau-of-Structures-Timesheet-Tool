using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WisDot.Bos.Spr.Core.Domain.Services;
using WisDot.Bos.Spr.Core.Domain.Models;

namespace WisDot.Bos.Spr.WinApp
{
    public partial class FormLogin : Form, ILoginView
    {
        LoginController _loginController;

        public FormLogin()
        {
            InitializeComponent();
            _loginController = new LoginController(this);
        }

        #region Events raised back to controller
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            _loginController.Login(textBoxUserId.Text.Trim(), textBoxUserPassword.Text.Trim());
        }
        #endregion

        #region ILoginView implementation
        public void SetController(LoginController loginController)
        {
            _loginController = loginController;
        }

        public void UpdateAuthentication(bool isAuthenticated)
        {
            checkBoxAuthenticated.Checked = isAuthenticated ? true : false;
        }

        public string UserId
        {
            get { return textBoxUserId.Text.Trim(); }
            set { this.textBoxUserId.Text = value; }
        }

        public string Password
        {
            get { return textBoxUserPassword.Text.Trim(); }
            set { this.textBoxUserPassword.Text = value; }
        }
        #endregion

    }
}
