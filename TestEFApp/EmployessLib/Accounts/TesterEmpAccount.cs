using EFDataAccessLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemLib;
using SystemLib.Logging;

namespace EmployessLib
{
    public class TesterEmpAccount : IAccounts
    {
        private ILog m_logger { get; set; } = new ConsoleLogger();

        public void SetLogger(ILog logger)
        {
            m_logger = logger;
        }

        public Person Create(IPersonModel personModel)
        {
            Person personDbModel = new Person
            {
                FirstName = personModel.FirstName,
                LastName = personModel.LastName,
                Age = personModel.Age,
            };

            EmployeeType empType = new EmployeeType();
            empType.IsTester = true;

            personDbModel.EmployeeTypes.Add(empType);

            m_logger.INFO($"Created new tester employee!" + "\n" +
                $"Name: {personDbModel.FirstName}, LastName: {personDbModel.LastName}");

            return personDbModel;
        }
    }
}
