using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WisDot.Bos.Spr.Core.Domain.Models
{
    public class Employee
    {
        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Employee(int id)
        {
            this.Id = id;
            initialize();
        }

        private void initialize()
        {
            this.FirstName = "";
            this.LastName = "";
        }
    }
}
