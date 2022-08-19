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
    
    public class UlkeService : IUlkeService
    {
        public RepoBase<Ulke, KonusarakOgrenContext> Repo { get; set; } = new Repo<Ulke, KonusarakOgrenContext>();
        
        public Result Add(UlkeModel model)
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

        public IQueryable<UlkeModel> Query()
        {
           return Repo.Query().OrderBy(u => u.Adi).Select(u => new UlkeModel()
           {
               Id = u.Id,
               Adi = u.Adi
           });
        }

        public Result Update(UlkeModel model)
        {
            throw new NotImplementedException();
        }
    }
}
