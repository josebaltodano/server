using DepreciationDBApp.Domain.DepreciationDBEntities;
using DepreciationDBApp.Domain.Entities;
using DepreciationDBApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepreciationDBApp.Infrastructure.Repositories
{
    public class EFAEmployeeRepository : IEmployee
    {
        private DepreciationDBContext depreciationDB;
        public EFAEmployeeRepository(DepreciationDBContext dBContext)
        {
            this.depreciationDB = dBContext;
        } 
        public void Create(Employee t)
        {
            try
            {
                ValidateEmployee(t);
                depreciationDB.Employees.Add(t);
                depreciationDB.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValidateEmployee(Employee employee)
        {
           if(employee == null)
            {
                throw new ArgumentException("El objeto empleado no puede ser null");
            }
            if (string.IsNullOrEmpty(employee.Email))
            {
                throw new ArgumentException("El Email no puede estar vacio");
            }
        }

       
        public bool Delete(Employee t)
        {
            try
            {
                if (t == null)
                {
                    throw new ArgumentNullException("EL objeto Empleado no puede ser null");
                }
                Employee employee = FinByDni(t.Dni);
                if(employee == null)
                {
                    throw new Exception($"El objeto con id{t.Dni} no existe.");
                }
                depreciationDB.Employees.Remove(t);
                int result = depreciationDB.SaveChanges();
                return result > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Employee FinByDni(string DNi)
        {
            try
            {
                if(DNi.Length <= 0)
                {
                    throw new Exception($"El id{DNi} no puede ser igual a cero");
                }
                return depreciationDB.Employees.FirstOrDefault(x => x.Dni == DNi);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Employee FInbyName(string email)
        {
            try
            {
                List<Employee> employees = GetAll();
                return employees.First(x => x.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Employee> FindLastNames(string lasnames)
        {
            try
            {
                List<Employee> employees = GetAll();
                return (List<Employee>)employees.Where(x => x.Lastnames.Equals(lasnames, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Employee> GetAll()
        {
            return depreciationDB.Employees.ToList();
        }

        public bool SetAssetEmployee(Employee employee, Asset asset)
        {
            if(employee == null && asset == null)
            {
                throw new ArgumentException("Los Objetos no pueden ser null");
            }
            Employee vaemployee = FinByDni(employee.Dni);
            if(vaemployee == null)
            {
                throw new ArgumentException($"EL Objeto {employee.Dni} no puede ser null");
            }
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
