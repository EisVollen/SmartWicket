using System;

namespace SmartWicket.DataBase.Objects
{
    /// <summary>
    /// Базовый класс для возможножности агрегации CRUD операций
    /// </summary>
    public abstract class Entity
    {
        public Guid Id { get; set; }
    }
}
