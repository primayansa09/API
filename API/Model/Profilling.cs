using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Model
{
    public class Profilling
    {

        [Key, ForeignKey("NIK")]
        public string NIK { get; set; }
        [ForeignKey("Education")]
        public int Education_Id { get; set; }
        public virtual Account Account { get; set; }
        public virtual Education Education { get; set; }
    }
}
