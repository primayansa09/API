using API.Base;
using API.Model;
using API.Repositories.Data;

namespace API.Controllers
{
    public class EducationController : BaseController<Education, EducationRepository, int>
    {
        public EducationController(EducationRepository educationRepository) : base(educationRepository)
        {

        }
    }
}
