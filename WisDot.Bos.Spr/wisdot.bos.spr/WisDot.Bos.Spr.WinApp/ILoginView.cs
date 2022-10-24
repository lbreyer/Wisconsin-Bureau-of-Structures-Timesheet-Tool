using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WisDot.Bos.Spr.Core.Domain.Models;

namespace WisDot.Bos.Spr.WinApp
{
    public interface ILoginView
    {
        void SetController(LoginController controller);
        void UpdateAuthentication(bool isAuthenticated);

        string UserId { get; set; }
        string Password { get; set; }
    }
}
