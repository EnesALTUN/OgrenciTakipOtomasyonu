using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EnesALTUN.OgrTakip.Dal.Interfaces
{
    // Repository nin oluşturulma nedeni, Entitylerin Select, Update, Insert... işlemlerini tek bir yerden yönetmek
    // IDisposable : class ile işimiz bitince hafızadan atılması için
    public interface IRepository<T> : IDisposable where T : class // T parametresinin tipi sadece class olabilir
    {
        void Insert(T entity);
        void Insert(IEnumerable<T> entities);   // Birden çok entity gönderildiği durum
        void Update(T entity);
        void Update(T entity, IEnumerable<string> fields);  // Gönderilen entity nin sadece "fields" ile gelen alanlarını güncelle
        void Update(IEnumerable<T> entities);
        void Delete(T entity);
        void Delete(IEnumerable<T> entities);
        TResult Find<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector);    // T türünde bir sorgu göndericez bunun sonucunda true değer dönerse bunu geri gönder. "TResult" ile veriyi hangi tipte göndereceği belirtildi. selector Expression işlemi T tipinde Entity alıyor fieldları arasında gezerek ihtiyacımız olanları TResult ile döndürüyor. 
        IQueryable<TResult> Select<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector);  // T türünde bir filtre göndericez. Bu filtre ile sorgulamaları yapacak. Sorgu sonucunda true dönüyorsa kayıt vardır ve bunları gönderir. Ancak "IQueryable" bize bir sorgu gönderir. Bu sorguyu ".ToList()", "AsEnumerable" gibi eklentilerle çalıştıracaz.
    }
}
