using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.VIewModel
{
    public class RegisterDataVM
    {

        public string NIK { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string Degree { get; set; }
        public string GPA { get; set; }
        public string U_Name { get; set; }
    }
}
