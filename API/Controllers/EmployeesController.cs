using API.Base;
using API.Model;
using API.Repositories.Data;
using API.VIewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController<Employee, EmployeeRepository, string>
    {
        private readonly EmployeeRepository employeeRepository;
        public EmployeesController(EmployeeRepository employeeRepository) : base(employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        [HttpPost]
        [Route("Register")]
        public ActionResult Register(RegisterVm registerVm)
        {
            var result = employeeRepository.Register(registerVm);

            switch (result)
            {
                case 1:
                    return Ok("Register sukses");
                    break;
                case 2:
                    return Ok("Email Sudah Ada");
                    break;
                case 3:
                    return Ok("Phone Sudah Ada");
                    break;
                default:
                    return Ok("Register Gagal");
                    break;
            }

            //if(result == 1)
            //{
            //    return Ok("Register sukses");
            //}else if (result == 2)
            //{
            //    return Ok("Email Sudah Ada");
            //}else if (result == 3)
            //{
            //    return Ok("Phone Sudah Ada");
            //}
            //else
            //{
            //    return Ok("Register Gagal");
            //}
        }
    }
}
