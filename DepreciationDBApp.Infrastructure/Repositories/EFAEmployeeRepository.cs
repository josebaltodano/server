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
                depreciationDB.employees.Add(t);
                depreciationDB.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValidateEmployee(Employee t)
        {
            throw new NotImplementedException();
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
                depreciationDB.employees.Remove(t);
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
                return depreciationDB.employees.FirstOrDefault(x => x.Dni == DNi);
            }
            catch (Exception)
            {
                throw;
            }
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
            return depreciationDB.employees.ToList();
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
