using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    public class Account
    {
        [Key]
        public string NIK { get; set; }
        public string Pssword { get; set; }
        public Employee Employee { get; set; }
        public Profilling Profilling { get; set; }
    }
}
