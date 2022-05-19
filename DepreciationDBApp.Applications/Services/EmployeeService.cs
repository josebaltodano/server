using DepreciationDBApp.Applications.Interfaces;
using DepreciationDBApp.Domain.Entities;
using DepreciationDBApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepreciationDBApp.Applications.Services
{
    public class EmployeeService : Iemployeeservice
    {
        public IEmployee employee1;
        public EmployeeService(IEmployee employee)
        {
            this.employee1 = employee;
        }
        public void Create(Employee t)
        {
            if (t == null)
            {
                throw new ArgumentNullException("El Empleado no puede ser null.");
            }
            employee1.Create(t);
        }

        public bool Delete(Employee t)
        {
            throw new NotImplementedException();
        }

        public Employee FinByDni(string DNi)
        {
            throw new NotImplementedException();
        }

        public Employee FInbyName(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> FindLastNames(string lasnames)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll()
        {
            return employee1.GetAll();
        }

        public bool SetAssetEmployee(Employee employee, Asset asset)
        {
            throw new NotImplementedException();
        }

        public bool SetToEmployee(Employee employee, List<Asset> assets)
        {
            throw new NotImplementedException();
        }

        public int Update(Employee t)
        {
            throw new NotImplementedException();
        }
    }
}
