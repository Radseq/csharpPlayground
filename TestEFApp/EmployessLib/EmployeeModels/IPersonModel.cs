
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployessLib
{
    public interface IPersonModel
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        int Age { get; set; }

        IAccounts AccountProcces { get; set; }
    }
}
