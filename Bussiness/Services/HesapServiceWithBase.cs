using AppCorev1.Business.Models;
using Business.Models;
using Bussiness.Services.Bases;
using DataAccess.Enums;

namespace Business.Services
{
   
    public class HesapService : IHesapService 
    {
        private readonly IKullaniciService _kullaniciService;
        public HesapService(IKullaniciService kullaniciService)
        {
            _kullaniciService = kullaniciService;
        }

        public Result<KullaniciModel> Giris(KullaniciGirisModel model)
        {
            var kullanici = _kullaniciService.Query().SingleOrDefault(k => k.KullaniciAdi == model.KullaniciAdi && k.Sifre == model.Sifre && k.AktifMi);
            if (kullanici == null)
                return new ErrorResult<KullaniciModel>("Girdi�iniz kullan�c� ad� ve �ifreye ait kay�t bulunamad�!");
            return new SuccessResult<KullaniciModel>(kullanici);
        }              

        public Result Kayit(KullaniciKayitModel model)
        {
            KullaniciModel kullanici = new KullaniciModel()
            {
                AktifMi = true, // kullanici sisteme kay�t oldu�unda aktif olsun diye true yapt�k
                RolId = (int)Roller.Customer,
                KullaniciAdi = model.KullaniciAdi,
                Sifre = model.Sifre,
                KullaniciDetayi = new KullaniciDetayiModel()
                {
                    Adres = model.KullaniciDetayi.Adres.Trim(),
                    Eposta = model.KullaniciDetayi.Eposta.Trim(),
                    UlkeId = model.KullaniciDetayi.UlkeId,
                    SehirId = model.KullaniciDetayi.SehirId,
                    Cinsiyet = model.KullaniciDetayi.Cinsiyet
                }

            };
            return _kullaniciService.Add(kullanici);
        }
    }
}
