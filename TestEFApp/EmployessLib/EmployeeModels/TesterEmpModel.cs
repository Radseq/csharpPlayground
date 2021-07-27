using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployessLib
{
    public class TesterEmpModel : IPersonModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public IAccounts AccountProcces { get; set; } = new TesterEmpAccount();
    }
}
