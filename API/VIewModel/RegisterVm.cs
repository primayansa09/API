﻿using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.VIewModel
{
    public class RegisterVm
    {
        public int Id { get; set; }
        public string NIK { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public int Salary { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string Degree { get; set; }
        public string GPA { get; set; }
        public int University_Id { get; set; }
    }
}
