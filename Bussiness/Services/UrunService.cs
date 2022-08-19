using AppCorev1.Business.Models;
using AppCorev1.Business.Services.Bases;
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
    public class UrunService : IUrunService
    {
        private readonly KonusarakOgrenContext _db;
        public RepoBase<Urun, KonusarakOgrenContext> Repo { get; set; } = new Repo<Urun, KonusarakOgrenContext>();        
        public RepoBase<Marka, KonusarakOgrenContext> MarkaRepo { get; set; } = new Repo<Marka, KonusarakOgrenContext>();

        public UrunService()
        {
            _db = new KonusarakOgrenContext();
            Repo = new Repo<Urun, KonusarakOgrenContext>(_db);            
            MarkaRepo = new Repo<Marka, KonusarakOgrenContext>(_db);            
        }
        public Result Add(UrunModel model)
        {
            if (Repo.Query().Any(u => u.Adi.ToLower() == model.Adi.ToLower().Trim()))
                return new ErrorResult("Bu isime sahip ürün bulunmaktadýr!");
            Urun urun = new Urun()
            {
                Adi = model.Adi.Trim(),
                Aciklamasi = model.Aciklamasi?.Trim(),
                Renk = model.Renk?.Trim(),
                Boyut = model.Boyut?.Trim(),
                MarkaId = model.MarkaId.Value,                
            };

            Repo.Add(urun);            
            return new SuccessResult("Ýþlem baþarýlý.");
        }

        public Result Delete(int id)
        {
            Repo.Delete(u => u.Id == id);
            return new SuccessResult("Ýþlem baþarýlý.");
        }

        public void Dispose()
        {
            Repo.Dispose();
        }

        public IQueryable<UrunModel> Query()
        {
            return Repo.Query("Marka").OrderBy(u => u.Adi).Select(u => new UrunModel()
            {
                Id = u.Id,
                Adi = u.Adi,
                Aciklamasi = u.Aciklamasi,
                Renk = u.Renk,
                Boyut = u.Boyut,
                MarkaId = u.MarkaId,
                MarkaAdiDisplay = u.Marka.Adi,               

            });
        }

        public Result Update(UrunModel model)
        {
            if (Repo.Query().Any(u => u.Adi.ToLower() == model.Adi.ToLower().Trim() && u.Id != model.Id))
                return new ErrorResult("Bu isime sahip ürün bulunmaktadýr!");

            Urun urun = Repo.Query().SingleOrDefault(u => u.Id == model.Id);
            
            urun.Adi = model.Adi.Trim();
            urun.Aciklamasi = model.Aciklamasi?.Trim();
            urun.Renk = model.Renk?.Trim();
            urun.Boyut = model.Boyut?.Trim();
            urun.MarkaId = model.MarkaId.Value;
            
            Repo.Update(urun);
            return new SuccessResult("Ýþlem baþarýlý.");
        }
    }
}
