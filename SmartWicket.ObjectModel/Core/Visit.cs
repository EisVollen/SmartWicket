using System;

namespace SmartWicket.ObjectModel.Core
{
    /// <summary>
    /// Посещения
    /// </summary>
    public class Visit: Entity
    {
        /// <summary>
        /// Посетитель
        /// </summary>
        public virtual Visitor Visitor { get; set; }

        public Guid VisitorId { get; set; }

        /// <summary>
        /// Дата посещения
        /// </summary>
        public DateTime VisitDate { get; set; }

        /// <summary>
        /// Дата создания посещения
        /// </summary>
        public DateTime CreatedDate { get; set; }
       
    }
}