using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Model
{
    public class Education
    {
        [Key]
        public int Id { get; set; }
        public string Degree { get; set; }
        public string GPA { get; set; }
        [ForeignKey("University")]
        public int University_Id { get; set; }
        public virtual Profilling Profilling { get; set; }
        public virtual University University { get; set; }
    }
}
