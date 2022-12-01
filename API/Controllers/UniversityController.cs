using API.Base;
using API.Context;
using API.Model;
using API.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class UniversityController : BaseController<University, UniversityRepository, int>
    {
        public UniversityController(UniversityRepository universityRepository) : base(universityRepository)
        {
            
        }
    }
}
