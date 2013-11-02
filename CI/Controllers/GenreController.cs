using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CI.Models;
using CI.DAL;
using System.Data;
using PagedList;
using CI.Properties;

namespace CI.Controllers
{
    public class GenreController : Controller
    {
        private IUnitOfWork unitOfWork = new UnitOfWork();
        //
        // GET: /Genre/

        public ActionResult Index(int? page)
        {
            int pageSize = Settings.Default.ItemsPerPage;
            int pageNumber = (page ?? 1);
            return View(unitOfWork.GenreRepository.Get(orderBy: x => x.OrderBy(y => y.Name)).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Details(int? page, int id = 1)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            ViewBag.Title = unitOfWork.GenreRepository.GetByID(id).Name;
            ViewBag.GenreID = id;
            var list = unitOfWork.AudiofileRepository.Get().Where(x => x.GenreID == id);
            return View(list.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genre genre)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.GenreRepository.Insert(genre);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View(genre);
        }

    }
}
