using EFDataAccessLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployessLib
{
    public class ManagerEmpAccount : IAccounts
    {
        public Person Create(IPersonModel personModel)
        {
            Person empModel = new Person
            {
                FirstName = personModel.FirstName,
                LastName = personModel.LastName,
                Age = personModel.Age,
            };

            EmployeeType empType = new EmployeeType();
            empType.IsManager = true;

            empModel.EmployeeTypes.Add(empType);

            return empModel;
        }
    }
}
