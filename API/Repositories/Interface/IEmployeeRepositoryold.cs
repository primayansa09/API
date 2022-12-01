using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositorys.Interface
{
    interface IEmployeeRepositoryold
    {

        IEnumerable<Employee> Get();

        Employee Get(String NIK);
        int Insert(Employee employee);
        int Update(Employee employee);
        int Delete(Employee employee);
    }
}
