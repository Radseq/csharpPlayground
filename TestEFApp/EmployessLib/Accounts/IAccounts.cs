using EFDataAccessLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployessLib
{
    public interface IAccounts
    {
        Person Create(IPersonModel personModel);
    }
}
