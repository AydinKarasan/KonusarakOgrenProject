using AppCorev1.Business.Models;
using AppCorev1.Business.Services.Bases;
using AppCorev1.DataAccess.Entityframework;
using AppCorev1.DataAccess.Entityframework.Bases;
using Business.Models;
using Bussiness.Services.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;

namespace Business.Services
{
       public class SehirService : ISehirService
    {
        public RepoBase<Sehir, KonusarakOgrenContext> Repo { get; set; } = new Repo<Sehir, KonusarakOgrenContext>();
        
        public Result Add(SehirModel model)
        {
            throw new NotImplementedException();
        }

        public Result Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Repo.Dispose();
        }

        public IQueryable<SehirModel> Query()
        {
            return Repo.Query().OrderBy(s => s.Adi).Select(s => new SehirModel()
            {
                Adi = s.Adi,
                Id = s.Id,
                UlkeId = s.UlkeId
            });
        }

        public Result Update(SehirModel model)
        {
            throw new NotImplementedException();
        }
    }
}
