using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLib.Models
{
    public class Address
    {
        public int ID { get; set; }

        [Required] // not null values on table
        [MaxLength(200)] //max char is set to 200
        public string StreetAddress { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; }

        [Required]
        [MaxLength(50)]
        public string State { get; set; }

        [Required]
        [MaxLength(10)]
        [Column(TypeName = "varchar(10)")] //there is no need for utf-16, istead of 2 bytes we use 1
        public string ZipCode { get; set; }
    }
}
