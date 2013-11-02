using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CI.Models;
using CI.ViewModels;
using CI.DAL;
using CI.Services;
using System.Data;
using PagedList;
using CI.Properties;

namespace CI.Controllers
{
    public class AuthorController : Controller
    {
        private IUnitOfWork unitOfWork = new UnitOfWork();
        //
        // GET: /Author/

        public ActionResult Index(int? page)
        {
            int pageSize = Settings.Default.ItemsPerPage;
            int pageNumber = (page ?? 1);
            return View(unitOfWork.AuthorRepository.Get(orderBy: x => x.OrderBy(y => y.Name)).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Details(int id = 1)
        {
            Author author = unitOfWork.AuthorRepository.GetByID(id);
            return View(author);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddAuthorViewModel viewmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Author author = new Author();
                    author.Name = viewmodel.Name;
                    if (viewmodel.Image != null)
                    {
                        author.Image = FileService.SaveFile(viewmodel.Image);
                    }
                    unitOfWork.AuthorRepository.Insert(author);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View(viewmodel);
        }
    }
}
