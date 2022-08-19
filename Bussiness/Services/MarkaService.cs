using AppCorev1.Business.Models;
using AppCorev1.DataAccess.Entityframework;
using AppCorev1.DataAccess.Entityframework.Bases;
using Bussiness.Models;
using Bussiness.Services.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services
{
    public class MarkaService : IMarkaService
    {
        public RepoBase<Marka, KonusarakOgrenContext> Repo { get; set; } = new Repo<Marka, KonusarakOgrenContext>();

        public Result Add(MarkaModel model)
        {
            if (Repo.Query().Any(m => m.Adi.ToLower() == model.Adi.ToLower().Trim()))
                return new ErrorResult("Bu isimle marka bulunmaktad�r!");

            Marka marka = new Marka()
            {
                Adi = model.Adi.Trim()
            };
            Repo.Add(marka);
            return new SuccessResult("Marka ba�ar�yla eklendi.");
        }

        public Result Delete(int id)
        {
            Marka marka = Repo.Query(m => m.Id == id, "Urunler").SingleOrDefault();
            if (marka.Urunler != null && marka.Urunler.Count > 0)
            {
                return new ErrorResult("Marka silinemez! �nce markaya ait �r�nleri silmelisiniz!");
            }
            Repo.Delete(marka);
            return new SuccessResult("Marka ba�ar�yla silindi.");
        }

        public void Dispose()
        {
            Repo.Dispose();
        }

        public IQueryable<MarkaModel> Query()
        {
            return Repo.Query("Urunler").OrderBy(m => m.Adi).Select(m => new MarkaModel()
            {
                Id = m.Id,
                Adi = m.Adi,
                UrunSayisiDisplay = m.Urunler.Count
            });
        }

        public Result Update(MarkaModel model)
        {
            if (Repo.Query().Any(m => m.Adi.ToLower() == model.Adi.ToLower().Trim() && m.Id != model.Id))
                return new ErrorResult("Bu isimle marka bulunmaktad�r!");

            Marka marka = Repo.Query(m => m.Id == model.Id).SingleOrDefault();
            marka.Adi = model.Adi.Trim();
            Repo.Update(marka);
            return new SuccessResult("Marka ba�ar�yla g�ncellendi.");
        }
    }
}
