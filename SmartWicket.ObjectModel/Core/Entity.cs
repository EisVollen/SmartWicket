using System;

namespace SmartWicket.ObjectModel.Core
{
    /// <summary>
    /// Базовый класс для возможножности агрегации CRUD операций
    /// </summary>
    public class Entity
    {
        public Guid Id { get; set; }
    }
}
