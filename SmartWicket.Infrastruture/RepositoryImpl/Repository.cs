using SmartWicket.Infrastruture.IRepository;
using System;
using System.Data.Entity;
using System.Linq;
using SmartWicket.DataBase;
using SmartWicket.DataBase.Objects;


namespace SmartWicket.Infrastruture.RepositoryImpl
{
    /// <summary>
    /// Родительский класс для работы с CRUD операциями непосредственно в бд.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public abstract class Repository<T1, T2> : IRepository<T1, T2>, IDisposable
        where T1 : Entity
        where T2 : System.Data.Entity.DbContext

    {

        private readonly T2 _context;
        private readonly DbSet<T1> _entity;

        public Repository(T2 context, DbSet<T1> entity)
        {
            _context = context;
            _entity = entity;
        }
        
        /// <summary>
        /// Возращает объект по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T1 Get(Guid id)
        {
            return _entity.FirstOrDefault(o => o.Id == id);
        }

        /// <summary>
        /// Удаляет сущность
        /// </summary>
        /// <returns></returns>
        public void Delete(T1 obj)
        {
            try
            {
                _entity.Remove(obj);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new ApplicationException("Ошибка! Объект не удален.");
            }
        }

        /// <summary>
        /// Удаляет сущность, но сначала ищет объект
        /// </summary>
        public void Delete(Guid id)
        {
            var visitor = Get(id);

            if (visitor != null)
            {
                Delete(visitor);
            }
        }
        /// <summary>
        /// Сохраняет или обновляет сущность
        /// </summary>
        public void SaveOrUpdate(T1 obj)
        {
            try
            {
                var original = _entity.Find(obj.Id);
                if (original != null)
                {
                    _context.Entry(original).CurrentValues.SetValues(obj);
                }
                else
                {
                    _entity.Add(obj);
                  
                }
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new ApplicationException("Ошибка! Объект не был сохранен.");
            }
        }
       
        /// <summary>
        /// Возращает колекцию для последующей работы
        /// </summary>
        /// <returns></returns>
        public IQueryable<T1> List()
        {
            return _entity;
        }

        public void Attach(T1 obj)
        {
            _entity.Attach(obj);
            _context.SaveChanges();
        }
       
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
