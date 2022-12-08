using API.Context;
using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Data
{
    public class EducationRepository : GeneralRepository<MyContext, Education, int>
    {
       
        public EducationRepository(MyContext myContext) : base(myContext)
        {
        }
    }
}
