using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PracticeCarriers.DAL;
using PracticeCarriers.Models;

namespace PracticeCarriers.Controllers
{
    public class CarriersController : Controller
    {
        private CarriersContext db = new CarriersContext();

        // GET: Carriers
        public ActionResult Index()
        {
            
            return View(db.Carriers.ToList());
        }

        // GET: Carriers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carriers carriers = db.Carriers.Find(id);
            if (carriers == null)
            {
                return HttpNotFound();
            }
            return View(carriers);
        }

        // GET: Carriers/Create
        public ActionResult Create()
        {
            //ADD OUR CACHED STATES LIST
            ViewBag.StatesList = GetStates();

            return View();
        }

        // POST: Carriers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarrierID,MCNumber,DOTNumber,Address1,Address2,City,StateID,Zip,Email,WebURL")] Carriers carriers)
        {
            if (ModelState.IsValid)
            {
                //MANUALLY SET OUR DEFAULT VALUES WHEN CREATING A NEW RECORD
                carriers.Active = true;
                //SET DATES TO CURRENT DATETIME
                carriers.DateCreated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                carriers.LastModified = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                //SEND DATA TO DATABASE
                db.Carriers.Add(carriers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }//END IF MODELSTATE.ISVALID

            //ADD OUR CACHED STATES LIST
            ViewBag.StatesList = GetStates();

            return View(carriers);
        }

        // GET: Carriers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carriers carriers = db.Carriers.Find(id);
            if (carriers == null)
            {
                return HttpNotFound();
            }
            
            //GET OUR CACHED STATES LIST
            ViewBag.StatesList = GetStates();

            //SET THE STATEID ASSOCIATED WITH THIS CARRIER
            ViewBag.StateIDSelected = carriers.StateID.ToString();
            
            return View(carriers);
        }

        // POST: Carriers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarrierID,MCNumber,DOTNumber,Address1,Address2,City,StateID,Zip,Email,WebURL,Active")] Carriers carriers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carriers).State = EntityState.Modified;
                
                //UPDATE THE LAST EDIT DATE
                carriers.LastModified = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                //CARRY THROUGH THE CREATE DATETIME
                db.Entry(carriers).Property(d => d.DateCreated).IsModified = false;
                
                db.SaveChanges();
                return RedirectToAction("Index");
                
            }
            return View(carriers);
        }

        // GET: Carriers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carriers carriers = db.Carriers.Find(id);
            if (carriers == null)
            {
                return HttpNotFound();
            }
            return View(carriers);
        }

        // POST: Carriers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carriers carriers = db.Carriers.Find(id);
            db.Carriers.Remove(carriers);
            db.SaveChanges();
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

        //CREATE A CACHING METHOD TO GET STATES DATA
        private List<States> GetStates()
        {
            //GET VALUES FROM CACHE
            var states = System.Web.HttpContext.Current.Cache["states"] as List<States>;
            
            //DETERMINE IF WE HAVE A CACHE VALUE AVAILABLE, IF NOT BUILD ONE
            if (states == null) 
            {
                using (var context = new CarriersContext())
                {
                    //LINQ QUERY TO GET THE STATES FROM CARRIERSCONTECT(DB)
                    var statesResult = (from s in context.States select s);

                    states = statesResult.ToList();

                }//END USING CARRIERSCONTEXT
                
            }//END IF STATES == NULL
            
            return states;
        }//END FUNCTION GETSTATES

    }
}
