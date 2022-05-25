using DepreciationDBApp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepreciationDBApp.Domain.Interfaces
{
     public interface IEmployee : IRepository<Employee>
    {
        Employee FinByDni(string DNi);
        Employee FInbyName(string email);
        IEnumerable<Employee> FindLastNames(string lasnames);
       
        bool SetAssetEmployee(Employee employee, Asset asset);
        bool SetToEmployee(Employee employee, List<Asset> assets);
        IDbContextTransaction GetTransaction();

    }
}
