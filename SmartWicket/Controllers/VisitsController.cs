using System;
using System.Linq;
using System.Web.Mvc;
using SmartWicket.DataBase;
using SmartWicket.DataBase.Objects;
using SmartWicket.Infrastruture.RepositoryImpl;

namespace SmartWicket.Controllers
{
    public class VisitsController : Controller
    {
        private SmartWicketEntities db = new SmartWicketEntities();
        private readonly VisitRepository _visitRepository;

        public VisitsController()
        {
            var visitContext = new SmartWicketEntities();
            this._visitRepository = new VisitRepository(visitContext, visitContext.Visits);
        }
        // GET: Visits
        public ActionResult Index()
        {
            return View(_visitRepository.List()
                .ToList()
                .Select(visit => new VisitDTO
                {
                    Id = visit.Id,
                    VisitDate = visit.VisitDate,
                    CreatedDate = visit.CreatedDate,
                    VisitorName = $"{visit.Visitor.LastName} {visit.Visitor.FirstName}",
                }));
        }

        // GET: Visits/Details/5
        public ActionResult Details(Guid id)
        {
            VisitDTO visitDTO = new VisitDTO( _visitRepository.Get(id));
           
            return View(visitDTO);
        }

        // GET: Visits/Create
        public ActionResult Create()
        {
            ViewBag.VisitorId = new SelectList(db.Visitors, "Id", "LastName");
            return View();
        }

        // POST: Visits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,VisitorId,VisitDate,CreatedDate")] Visit visit)
        {
            if (ModelState.IsValid)
            {
                visit.Id = Guid.NewGuid();
                _visitRepository.SaveOrUpdate(visit);
                return RedirectToAction("Index");
            }
            ViewBag.VisitorId = new SelectList(db.Visitors, "Id", "LastName", visit.VisitorId);
            return View(visit);
        }

        // GET: Visits/Edit/5
        public ActionResult Edit(Guid id)
        {
            var visit = _visitRepository.Get(id);

            if (visit == null)
            {
                return HttpNotFound();
            }
            ViewBag.VisitorId = new SelectList(db.Visitors, "Id", "LastName", visit.VisitorId);
            
            return View(visit);
        }

        // POST: Visits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VisitorId,VisitDate,CreatedDate,VisitorName")] VisitDTO visitDTO)
        {
            var visit = visitDTO.ToEntity();
            if (ModelState.IsValid)
            {
                _visitRepository.SaveOrUpdate(visit);
                return RedirectToAction("Index");
            }
            ViewBag.VisitorId = new SelectList(db.Visitors, "Id", "LastName", visit.VisitorId);

            return View(visit);
        }

        // GET: Visits/Delete/5
        public ActionResult Delete(Guid id)
        {
            var visit = _visitRepository.Get(id);
           
            if (visit == null)
            {
                return HttpNotFound();
            }
            VisitDTO visitDTO = new VisitDTO(visit);
            return View(visitDTO);
        }

        // POST: Visits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _visitRepository.Delete(id);
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
