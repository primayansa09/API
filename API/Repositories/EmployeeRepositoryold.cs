/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Repositorys.Interface;
using API.Model;
using API.Context;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class EmployeeRepositoryold : IEmployeeRepositoryold
    {
        private readonly MyContext context;

        public EmployeeRepositoryold(MyContext context)
        {
            this.context = context;
        }

        public Employee Get(string NIK)
        {
            return context.Employees.Find(NIK);
        }

        public int Insert(Employee employee)
        {
            context.Employees.Add(employee);
            var result =  context.SaveChanges();
            return result;
        }

        public int Update(Employee employee)
        {
            context.Entry(employee).State = EntityState.Modified;
            var result = context.SaveChanges();
            return result;
        }
        public int Delete(string NIK)
        {
            var entity = context.Employees.Find(NIK);
            context.Remove(entity);
            var result = context.SaveChanges();
            return result;
        }

        public int Delete(Employee employee)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> Get()
        {
            return context.Employees.ToList();
        }

    }
}
*/