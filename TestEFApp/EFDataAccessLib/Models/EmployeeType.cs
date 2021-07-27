using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLib.Models
{
    public class EmployeeType
    {
        public int ID { get; set; }

        [MaxLength(1)]
        [Column(TypeName = "Bit")]
        public bool IsTester { get; set; }

        [MaxLength(1)]
        [Column(TypeName = "Bit")]
        public bool IsManager { get; set; }
    }
}
