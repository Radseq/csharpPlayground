using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLib.Models
{
    public class Email
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string EmailAddress { get; set; }
    }
}
