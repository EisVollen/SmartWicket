using System.Data.Entity;
using SmartWicket.Infrastruture.DbContext;
using SmartWicket.ObjectModel.Core;

namespace SmartWicket.Infrastruture.RepositoryImpl
{
    /// <summary>
    /// Класс для работы с CRUD операция непоследственно в бд. Для класса Visitor
    /// </summary>
    public class VisitorRepository: Repository<Visitor, SmartWicketEntities>
    {
        public VisitorRepository(SmartWicketEntities context, DbSet<Visitor>  entity) 
            : base(context, entity)
        {

        }
        
    }
}
