using System;

namespace EnesALTUN.OgrTakip.Dal.Interfaces
{
    // UnitOfWork yapılan işlemleri toplu olarak database e gönderir. IRepository den gelen işlemleri çalıştırır.
    public interface IUnitOfWork<T> : IDisposable where T : class
    {
        IRepository<T> Rep { get; } // Repository deki tüm içeriğe ulaştık
        bool Save();    // database de yapılan işlemler başarılı mı oldu başarısız mı oldu?
    }
}
