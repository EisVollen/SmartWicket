using System;
using System.ComponentModel.DataAnnotations;

namespace SmartWicket.DataBase.Objects
{
    public class VisitDTO
    {
        public VisitDTO()
        {
        }

        public VisitDTO(Visit visit)
        {
            Id = visit.Id;
            VisitDate = visit.VisitDate;
            CreatedDate = visit.CreatedDate;
            VisitorId = visit.VisitorId;
            VisitorName = $"{visit.Visitor.FirstName} {visit.Visitor.LastName}";
        }
      
        public Guid Id { get; set; }

        public Guid VisitorId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата посещения")]
        public DateTime VisitDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата создания посещения")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Посетитель")]
        [StringLength(101)]
        public string VisitorName { get; set; }

        public Visit ToEntity()
        {
            return new Visit
            {
                Id = Id,
                VisitDate = VisitDate,
                CreatedDate = CreatedDate,
                VisitorId = VisitorId,

            };
        }
    }
}