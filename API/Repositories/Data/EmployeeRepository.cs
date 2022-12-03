using API.Context;
using API.Model;
using API.VIewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Data
{
    public class EmployeeRepository : GeneralRepository<MyContext, Employee, string>
    {
        private readonly MyContext myContext;
        public EmployeeRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        public IEnumerable<RegisterDataVM> GetData()
        {

            var getAll = (from emp in myContext.Employees
                          join prof in myContext.Profillings
                            on emp.NIK equals prof.NIK
                          join edu in myContext.Educations
                            on prof.Education_Id equals edu.Id
                          join univ in myContext.Universities
                            on edu.University_Id equals univ.Id
                          select new RegisterDataVM()
                          {
                              NIK = emp.NIK,
                              FullName = emp.FirstName + " " + emp.LastName,
                              Phone = emp.Phone,
                              Email = emp.Email,
                              Salary = emp.Salary,
                              BirthDate = emp.BirthDate,
                              Gender = emp.Gender,
                              Degree = edu.Degree,
                              GPA = edu.GPA,
                              U_Name = univ.Name
                          }).ToList();

            return getAll;
        }

        public string FormatNIK()
        {
            var nikDate = DateTime.Today.ToString("yyyyddMM");
            var data = myContext.Employees.ToList();

            List<int> listId = new List<int>();
            for (int i = 0; i < data.Count; i++)
            {
                var newId = data[i].NIK;
                newId = newId.Substring(newId.Length - 4);
                listId.Add(Convert.ToInt32(newId));
            }

            int highestId = listId.Count() > 0 ? listId.Max() : 0;
            int incrementId = highestId + 1;
            string formatedNIk = incrementId.ToString().PadLeft(4, '0');
            formatedNIk = nikDate + formatedNIk;

            return formatedNIk;
        }

        public int Register(RegisterVm registerVM)
        {

            var CekDetailEmail = myContext.Employees.FirstOrDefault(e => e.Email == registerVM.Email);
            var CekDetailPhone = myContext.Employees.FirstOrDefault(p => p.Phone == registerVM.Phone);

            if (CekDetailEmail != null)
            {
                return 2;
            }
            else if (CekDetailPhone != null)
            {
                return 3;
            }
            else if (CekDetailEmail == null || CekDetailPhone == null)
            {

                var formatedNIk = FormatNIK();

                var emp = new Employee();
                emp.NIK = formatedNIk;
                emp.FirstName = registerVM.FirstName;
                emp.LastName = registerVM.LastName;
                emp.Phone = registerVM.Phone;
                emp.BirthDate = registerVM.BirthDate;
                emp.Salary = registerVM.Salary;
                emp.Gender = registerVM.Gender;
                emp.Email = registerVM.Email;
                myContext.Add(emp);
                myContext.SaveChanges();

                var acn = new Account();
                acn.NIK = formatedNIk;
                acn.Pssword = registerVM.Password;
                myContext.Add(acn);
                myContext.SaveChanges();

                var edu = new Education();
                edu.Degree = registerVM.Degree;
                edu.GPA = registerVM.GPA;
                edu.University_Id = registerVM.University_Id;
                myContext.Add(edu);
                myContext.SaveChanges();

                var prof = new Profilling();
                prof.NIK = formatedNIk;
                prof.Education_Id = edu.Id;
                myContext.Add(prof);
                var result = myContext.SaveChanges();
                return result;
            }
            else
            {
                return 0;
            }
        }

        public int GetLogin(LoginVm loginVm)
        {
            var userName = myContext.Accounts.FirstOrDefault(u => u.NIK == loginVm.NIK);
            var password = myContext.Accounts.FirstOrDefault(p => p.Pssword == loginVm.Password);

            if (userName == null)
            {
                return 2;

            }
            else if (password == null)
            {
                return 3;
            }
            return 1;
        }
    }
}
