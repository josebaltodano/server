using DepreciationDBApp.Domain.Entities;
using DepreciationDBApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepreciationDBApp.Infrastructure.Repositories
{
    public class EFAssetRepository : IAssetRepository
    {
        public IDepreciationDbContext depreciationDbContext;

        public EFAssetRepository(IDepreciationDbContext depreciationDbContext)
        {
            this.depreciationDbContext = depreciationDbContext;
        }
        public void Create(Asset t)
        {
            try
            {
                depreciationDbContext.Assets.Add(t);
                depreciationDbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public bool Delete(Asset t)
        {
            try
            {
                if(t == null)
                {
                    throw new ArgumentNullException("EL objeto Activo no puede ser null");
                }
                Asset asset = FindById(t.Id);
                if(asset== null)
                {
                    throw new Exception($"El objeto con id{t.Id} no existe.");
                }
                depreciationDbContext.Assets.Remove(t);
                int result = depreciationDbContext.SaveChanges();
                return result > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Asset FindByCode(string code)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                {
                    throw new Exception($"El parametro {code} no tiene el formato correcto");
                }
                return depreciationDbContext.Assets.FirstOrDefault(x => x.Code.Equals(code));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Asset FindById(int id)
        {

            try
            {
                if(id <=0)
                {

                    throw new Exception($"El id{id} no puede ser igual a cero");
                }

                return depreciationDbContext.Assets/*.Where(x => x.Id == id)*/
            .FirstOrDefault(x => x.Id == id);
            }
            catch (Exception) {
                throw;
            }

       
        }

        public List<Asset> FindByName(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new Exception($"El parametro {name} no tiene el formato correcto.");
                }
                return depreciationDbContext.Assets.Where(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<Asset> GetAll()
        {
            return depreciationDbContext.Assets.ToList();
        }

        public int Update(Asset t)
        {
            try
            {
                if (t == null)
                {
                    throw new ArgumentNullException("El objeto no puede ser null.");
                }
                Asset asset = FindById(t.Id);
                if(asset == null)
                {
                    throw new Exception($"El objeto Activo con {t.Id}no puede ser null.");
                }
                asset.Name = t.Name;
                asset.Description = t.Description;
                asset.AmountResidual = t.AmountResidual;
                asset.Amount = t.Amount;
                asset.IsActive = t.IsActive;
                asset.Status = t.Status;
                depreciationDbContext.Assets.Update(asset);
                return depreciationDbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new ArgumentNullException($"El objeto no puede ser null");
            }
        }
    }
}
