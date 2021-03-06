﻿using System.Data.Entity;
using SmartWicket.DataBase;


namespace SmartWicket.Infrastruture.RepositoryImpl
{
    /// <summary>
    /// Класс для работы с CRUD операция непоследственно в бд. Для класса Visit
    /// </summary>
    public class VisitRepository : Repository<Visit, SmartWicketEntities>
    {
        public VisitRepository(SmartWicketEntities context, DbSet<Visit> entity)
            : base(context, entity)
        {

        }
    }
}
