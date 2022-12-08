using API.Base;
using API.Model;
using API.Repositories.Data;
using API.VIewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class EmployeesController : BaseController<Employee, EmployeeRepository, string>
    {
        private readonly EmployeeRepository employeeRepository;
        public EmployeesController(EmployeeRepository employeeRepository) : base(employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        [HttpPost]
        [Route("Register")]
        [EnableCors("AllowOrigin")]
        public virtual ActionResult Register(RegisterVm registerVm)
        {
            var result = employeeRepository.Register(registerVm);

            switch (result)
            {
                case 1:
                    return Ok("Register sukses");
                    break;
                case 2:
                    return BadRequest("Email Sudah Terdaftar");
                    break;
                case 3:
                    return BadRequest("Phone Sudah Terdaftar");
                    break;
                default:
                    return BadRequest("Register Gagal");
                    break;
            }
        }
        [HttpGet]
        [Route("Register")]
        [EnableCors("AllowOrigin")]
        public virtual ActionResult GetRegister()
        {
            var get = employeeRepository.GetData();
            if (get.Count() != 0)
            {
                return StatusCode(200,
                    new
                    {
                        status = HttpStatusCode.OK,
                        message = get.Count() + " Data Berhasil Ditemukan",
                        Data = get
                    });
            }
            else
            {
                return StatusCode(404,
                    new
                    {
                        status = HttpStatusCode.InternalServerError,
                        message = "Data Tidak Ditemukan",
                        Data = get
                    });
            }

        }
        [HttpPost]
        [Route("Login")]
        public virtual ActionResult Login(LoginVm loginVm)
        {
            var login = employeeRepository.GetLogin(loginVm);

            switch (login)
            {
                case 1:
                    return Ok("Login Sukses");
                    break;
                case 2:
                    return BadRequest("Username Tidak Valid");
                    break;
                case 3:
                    return BadRequest("Password Tidak Valid");
                    break;

            }
            return BadRequest("Login Gagal");
        }
    }
}
