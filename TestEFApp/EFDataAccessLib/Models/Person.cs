using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLib.Models
{
    public class Person
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }

        public List<Address> Addresses { get; set; } = new List<Address>();
        public List<Email> EmailsAddresses { get; set; } = new List<Email>();
        public List<EmployeeType> EmployeeTypes { get; set; } = new List<EmployeeType>();
    }
}
