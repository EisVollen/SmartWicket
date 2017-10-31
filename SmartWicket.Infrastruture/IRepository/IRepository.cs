using System;
using System.Linq;

namespace SmartWicket.Infrastruture.IRepository
{
    public interface IRepository<T1, T2>
    {       
        T1 Get(Guid id);
        void Delete(T1 obj);
        void Delete(Guid id);
        void SaveOrUpdate(T1 obj);
        IQueryable<T1> List();

        void Attach(T1 obj);

    }
}
