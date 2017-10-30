using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Newtonsoft.Json;
using SmartWicket.Infrastruture.DbContext;
using SmartWicket.Infrastruture.RepositoryImpl;
using SmartWicket.ObjectModel.Core;

namespace SmartWicket.Controllers.WebApi
{
    /// <summary>
    /// CRUD контролер для работы с Посещениями
    /// </summary>
    public class VisitsController : ApiController
    {
        private readonly VisitRepository _visitRepository;

        public VisitsController()
        {
            var visitContext = new SmartWicketEntities();
            this._visitRepository = new VisitRepository(visitContext, visitContext.Visits);
        }

        // GET: api/Visits
        public string GetVisit()
        {
            var objects = _visitRepository.List().ToList()
                .Select(o => new
                {
                    Id = o.Id,
                    Visitor = $"{o.Visitor.LastName} {o.Visitor.FirstName}",
                    VisitDate = o.VisitDate
                });
            return JsonConvert.SerializeObject(objects);
        }

        // GET: api/Visits/5
        public string GetVisit(Guid id)
        {
            var visit = _visitRepository.Get(id);
            var obj = new
            {
                Id = visit.Id,
                Visitor = $"{visit.Visitor.LastName} {visit.Visitor.FirstName}",
                VisitDate = visit.VisitDate
            };
            return JsonConvert.SerializeObject(obj);
        }
        
        // POST: api/Visits
        [ResponseType(typeof(Visit))]
        public IHttpActionResult SaveVisit(Visit visit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _visitRepository.SaveOrUpdate(visit);
           
            return CreatedAtRoute("DefaultApi", new { id = visit.Id }, visit);
        }

        // DELETE: api/Visits/5
        [ResponseType(typeof(Visit))]
        public IHttpActionResult DeleteVisit(Guid id)
        {
            _visitRepository.Delete(id);
            return Ok();
        }
      
    }
}