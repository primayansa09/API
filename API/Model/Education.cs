using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    public class Education
    {
        [Key]
        [NotNull]
        public int Id { get; set; }
        [NotNull]
        public string Degree { get; set; }
        [NotNull]
        public string GPA { get; set; }
        [ForeignKey("University")]
        public int University_Id { get; set; }
        public Profilling Profilling { get; set; }
        public University University { get; set; }
    }
}
