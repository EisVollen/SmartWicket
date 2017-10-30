using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using SmartWicket.Infrastruture.DbContext;
using SmartWicket.Infrastruture.RepositoryImpl;
using SmartWicket.ObjectModel.Core;

namespace SmartWicket.Controllers.WebApi
{
    /// <summary>
    /// CRUD контролер для работы с Посетителями
    /// </summary>
    public class VisitorsController : ApiController
    {
        private readonly VisitorRepository _visitorRepository;

        public VisitorsController()
        {
            var visitContext = new SmartWicketEntities();
            this._visitorRepository = new VisitorRepository(visitContext, visitContext.Visitors);
        }

        // GET: api/Visitors
        public string GetVisitors()
        {
            var objects = _visitorRepository.List().ToList().Select(o => new
            {
                o.Id ,
                o.LastName,
                o.FirstName,
                o.BirthDate,
                Sex = o.Sex? "Женский":"Мужской"
            });
            return JsonConvert.SerializeObject(objects);
        }

        // GET: api/Visitors/5
        public string GetVisit(Guid id)
        {
            var visitor = _visitorRepository.Get(id);
            var obj = new
            {
                visitor.Id,
                visitor.LastName,
                visitor.FirstName,
                visitor.BirthDate,
                Sex = visitor.Sex ? "Женский" : "Мужской"
            };
            return JsonConvert.SerializeObject(obj);
        }

        // POST: api/Visitors
        [ResponseType(typeof(Visit))]
        public IHttpActionResult SaveVisit(Visitor visitor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _visitorRepository.SaveOrUpdate(visitor);
           
            return CreatedAtRoute("DefaultApi", new { id = visitor.Id }, visitor);
        }

        // DELETE: api/Visitors/5
        [ResponseType(typeof(Visit))]
        public IHttpActionResult DeleteVisit(Guid id)
        {
            _visitorRepository.Delete(id);
            return Ok();
        }
      
    }
}