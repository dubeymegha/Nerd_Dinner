using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nerd_Dinner.Models;

namespace Nerd_Dinner.Controllers
{
    public class DController : Controller
    {
        //
        // GET: /D/
        DinnerRepository dnr_repository = new DinnerRepository();
        NerdDinnerDataContext context = new NerdDinnerDataContext();
        public ActionResult Index()
        {
            IEnumerable<tbl_Dinner> results = dnr_repository.ShowUpcomingDinners().ToList();
            IList<D_Model> eventlist = new List<D_Model>();

            foreach (var mylist in results)
            {
                eventlist.Add(new D_Model()
                {
                    Dinner_ID = mylist.Dinner_ID,
                    Title = mylist.Title,
                    EventDate = mylist.EventDate,
                    Description = mylist.Description,
                    HostedBy = mylist.HostedBy,
                    Contact = mylist.Contact,
                    Address = mylist.Address

                });
            }

            return View(eventlist);
        }
        public ActionResult Create()
        {
            D_Model mddl = new D_Model();
            return View(mddl);
        }
        [HttpPost]
        public ActionResult Create(D_Model mdl)
        {
            if (ModelState.IsValid)
            {
                
                    tbl_Dinner obj = new tbl_Dinner()
                    {
                        
                        Title = mdl.Title,
                        EventDate = mdl.EventDate,
                        Description = mdl.Description,
                        HostedBy = mdl.HostedBy,
                        Contact = mdl.Contact,
                        Address = mdl.Address
                    };
                    dnr_repository.Insert(obj);
                    dnr_repository.Save();
                    return RedirectToAction("Index");

                
                
                

            }
            return View(mdl);

        }
        public ActionResult Edit(int id)
        {
            D_Model mdl = context.tbl_Dinners.Where(x => x.Dinner_ID == id).Select(x => new D_Model()
                {
                    Dinner_ID=x.Dinner_ID,
                    Title=x.Title,
                    EventDate=x.EventDate,
                    Description=x.Description,
                    HostedBy=x.HostedBy,
                    Contact=x.Contact,
                    Address=x.Address

                }).SingleOrDefault();
            return View(mdl);

        }
        [HttpPost]
        public ActionResult Edit(D_Model mdl)
        {
            try
            {
                tbl_Dinner dnr = context.tbl_Dinners.Where(x => x.Dinner_ID == mdl.Dinner_ID).Single<tbl_Dinner>();
                dnr.Dinner_ID=mdl.Dinner_ID;
                dnr.Title = mdl.Title;
                dnr.EventDate = mdl.EventDate;
                dnr.Description = mdl.Description;
                dnr.HostedBy = mdl.HostedBy;
                dnr.Contact=mdl.Contact;
                dnr.Address = mdl.Address;
                dnr_repository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(mdl);
            }

        }
        public ActionResult Details(int id)
        {
            D_Model mymodel = context.tbl_Dinners.Where(x => x.Dinner_ID == id).Select(x => new D_Model()
                {
                    Dinner_ID=x.Dinner_ID,
                    Title=x.Title,
                    EventDate=x.EventDate,
                    Description=x.Description,
                    HostedBy=x.HostedBy,
                    Contact=x.Contact,
                    Address=x.Address,

                }
                ).SingleOrDefault();
            return View(mymodel);
        }

        public ActionResult Delete(int id)
        {
            D_Model mymodel = context.tbl_Dinners.Where(x => x.Dinner_ID == id).Select(x => new D_Model()
            {
                Dinner_ID = x.Dinner_ID,
                Title = x.Title,
                EventDate = x.EventDate,
                Description = x.Description,
                HostedBy = x.HostedBy,
                Contact = x.Contact,
                Address = x.Address,

            }
               ).SingleOrDefault();
            return View(mymodel);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(D_Model mdl)
        {
            try
            {
                tbl_Dinner dnr = context.tbl_Dinners.Where(x => x.Dinner_ID == mdl.Dinner_ID).Single<tbl_Dinner>();
                dnr_repository.Delete(dnr);
                dnr_repository.Save();
                return RedirectToAction("Index");
                
            }
            catch
            {
                return RedirectToAction("Index");
            }
            
        }
    }
}
