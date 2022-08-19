using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AppCorev1.DataAccess.Entityframework.Bases
{
    //TEntity:class, new() diyerek sadece new leyebildi�in referanslar gelmesi i�in bunu yazd�k (yani sadece entity ler gelsin diye) 
    //dbContext i�inde ayn�s�n� yap�yoruz//class yerine de dbContext yazd�k ki dbContext den gelen context class lar� kullanal�m                                                                
    // generic bir yap� olu�turduk ve hangi tip entity i g�nderirsek �al���r // IRepoBase<Ogrenci> gibi
    // en son IDisposable ekledik ki kullan�lmayan objeleri garbage collector silsin diye yapt�k
    public interface IRepoBase<TEntity, TDbContext> : IDisposable where TEntity:class,new() where TDbContext:DbContext,new()
    {
        TDbContext DbContext { get; set; }
        IQueryable<TEntity> Query(params string[] entitiesToInclude);//Read  // select sorgusu i�in tan�m // select * from 
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate, params string[] entitiesToInclude); //�stteki metodu overload ettik
        
        void Add(TEntity entity, bool save = true); // Create
        void Update(TEntity entity, bool save = true); // Update
        void Delete(TEntity entity, bool save = true); // Delete
        void Delete(Expression<Func<TEntity, bool>> predicate, bool save = true);
        int Save();
    }
}
