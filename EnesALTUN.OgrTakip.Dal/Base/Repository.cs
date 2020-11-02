using EnesALTUN.OgrTakip.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace EnesALTUN.OgrTakip.Dal.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Variables
        private readonly DbContext _context;    // readonly değişkenlere ya ilk tanımlandığında değer atanabilir ya da tanımlandığı class ın constructure ında değer atanabilir. Onun dışında değer ataması yapılamaz.
        private readonly DbSet<T> _dbSet;   // Entity ler için 
        #endregion

        public Repository(DbContext context)    // işlem yapacağımız database i aldık. Tam olarak database in karşılığı değil ama aynı mantıkta
        {
            if (context == null) return;    // boş gelmişse işlem yapma
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Insert(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;   // Ekleme işleminin yapılacağını bildirdik
        }

        public void Insert(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                _context.Entry(entity).State = EntityState.Added;
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Update(T entity, IEnumerable<string> fields)
        {
            _dbSet.Attach(entity);  // hangi Entity ile işlem yapılacak
            var entry = _context.Entry(entity); // yukarıda belirtilen entity nin fields ları arasında güncelleme yapılacak
            foreach (var field in fields)
                entry.Property(field).IsModified = true;    // hangi alanda değişiklik varsa onları modified yap
        }

        public void Update(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public void Delete(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                _context.Entry(entity).State = EntityState.Deleted;
        }

        public TResult Find<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector)
        {
            return filter == null ? _dbSet.Select(selector).FirstOrDefault() : _dbSet.Where(filter).Select(selector).FirstOrDefault();
        }

        public IQueryable<TResult> Select<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector) // IQueryable bize sql sorgusu hazırlar
        {
            return filter == null ? _dbSet.Select(selector) : _dbSet.Where(filter).Select(selector);
        }

        #region Dispose

        private bool _disposedValue = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
