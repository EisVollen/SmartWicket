using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SmartWicket.DataBase;
using SmartWicket.Infrastruture.RepositoryImpl;

namespace SmartWicket.Controllers.WebApi
{
    public class VisitorsController : Controller
    {
        private readonly VisitorRepository _visitorRepository;

        public VisitorsController()
        {
            var visitContext = new SmartWicketEntities();
            this._visitorRepository = new VisitorRepository(visitContext, visitContext.Visitors);
        }
        // GET: Visitors
        public ActionResult Index()
        {
            return View(_visitorRepository.List().ToList());
        }

        // GET: Visitors/Details/5
        public ActionResult Details(Guid id)
        {
            Visitor visitor = _visitorRepository.Get(id);
            if (visitor == null)
            {
                return HttpNotFound();
            }
            return View(visitor);
        }

        // GET: Visitors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Visitors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LastName,FirstName,BirthDate,Sex")] Visitor visitor)
        {
            if (ModelState.IsValid)
            {
                visitor.Id = Guid.NewGuid();
                _visitorRepository.SaveOrUpdate(visitor);
                return RedirectToAction("Index");
            }

            return View(visitor);
        }

        // GET: Visitors/Edit/5
        public ActionResult Edit(Guid id)
        {
            Visitor visitor = _visitorRepository.Get(id);
            if (visitor == null)
            {
                return HttpNotFound();
            }
            return View(visitor);
        }

        // POST: Visitors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LastName,FirstName,BirthDate,Sex")] Visitor visitor)
        {
            if (ModelState.IsValid)
            {
               _visitorRepository.SaveOrUpdate(visitor);
                return RedirectToAction("Index");
            }
            return View(visitor);
        }

        // GET: Visitors/Delete/5
        public ActionResult Delete(Guid id)
        {
            Visitor visitor = _visitorRepository.Get(id);
            if (visitor == null)
            {
                return HttpNotFound();
            }
            return View(visitor);
        }

        // POST: Visitors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
           _visitorRepository.Delete(id);
            return RedirectToAction("Index");
        }
        
    }
}
