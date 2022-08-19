using AppCorev1.Business.Services.Bases;
using Bussiness.Models;
using DataAccess.Contexts;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Bases
{
    public interface IUrunService : IService<UrunModel, Urun, KonusarakOgrenContext>
    {

    }
}
