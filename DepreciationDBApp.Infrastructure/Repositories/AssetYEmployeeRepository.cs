using DepreciationDBApp.Domain.Entities;
using DepreciationDBApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepreciationDBApp.Infrastructure.Repositories
{
    public class AssetYEmployeeRepository : IAssetYEmployeRepository
    {
        public IDepreciationDbContext depreciationDb;
        public AssetYEmployeeRepository( IDepreciationDbContext depreciationDbContext)
        {
            this.depreciationDb = depreciationDbContext;
        }
        public void Create(AssetEmployee t)
        {
            try
            {
                depreciationDb.AssetEmployees.Add(t);
                depreciationDb.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            throw new NotImplementedException();
        }

        public bool Delete(AssetEmployee t)
        {
            try
            {

                if (t == null)
                {
                    throw new ArgumentNullException("El objeto assetEmployee no puede ser null");
                }
                AssetEmployee assetEmployee = FindByAssetEmployeeId(t.EmployeeId, t.AssetId);
                if (assetEmployee == null)
                {
                    throw new ArgumentNullException("assetEmployee no puede ser null");
                }
                depreciationDb.AssetEmployees.Remove(assetEmployee);
                int result = depreciationDb.SaveChanges();
                return result > 0;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public AssetEmployee FindByAssetEmployeeId(int employeeId, int assetId)
        {
            try
            {
                if (employeeId <= 0)
                {
                    throw new ArgumentException($"EL Id{employeeId} del empleado no puede ser null  ");
                }
                if(assetId <= 0)
                {
                    throw new ArgumentException($"EL Id {assetId} Del Activo no puede ser null");

                }
                return depreciationDb.AssetEmployees.FirstOrDefault(x => x.EmployeeId == employeeId && x.AssetId == assetId);
            }
            catch (Exception)
            {
                throw;
            }
        
        }

        public List<AssetEmployee> FindByAssetId(int assetId)
        {
            try
            {
                if (assetId <= 0)
                {
                    throw new ArgumentException("El AssetId no puede se null");
                }
                return depreciationDb.AssetEmployees.Where(x => x.AssetId == assetId).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<AssetEmployee> FindByEmployeeId(int employeeId)
        {
            throw new NotImplementedException();
        }

        public List<AssetEmployee> GetAll()
        {
            return depreciationDb.AssetEmployees.ToList();
        }

        public int Update(AssetEmployee t)
        {
            throw new NotImplementedException();
        }
    }
}
