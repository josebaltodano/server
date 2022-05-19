using DepreciationDBApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepreciationDBApp.Applications.Interfaces
{
     public interface Iemployeeservice : IService<Employee>
    {
        Employee FinByDni(string DNi);
        Employee FInbyName(string email);
        IEnumerable<Employee> FindLastNames(string lasnames);

        bool SetAssetEmployee(Employee employee, Asset asset);
        bool SetToEmployee(Employee employee, List<Asset> assets);
    }
}
