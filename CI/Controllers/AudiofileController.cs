using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CI.Models;
using CI.DAL;
using CI.ViewModels;
using CI.Services;
using System.Data;
using PagedList;

namespace CI.Controllers
{
    public class AudiofileController : Controller
    {
        private IUnitOfWork unitOfWork = new UnitOfWork();
        //
        // GET: /AudioFile/

        public ActionResult Index(int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(unitOfWork.AudiofileRepository.Get(orderBy: x => x.OrderBy(y => y.Title)).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Details(int id = 1)
        {
            Audiofile audiofile = unitOfWork.AudiofileRepository.GetByID(id);
            ViewBag.Title = audiofile.Author.Name + " - " + audiofile.Title;
            return View(audiofile);
        }

        public ActionResult Upload()
        {
            ViewBag.AuthorID = new SelectList(unitOfWork.AuthorRepository.Get(orderBy: x => x.OrderBy(y => y.Name)), "ID", "Name");
            ViewBag.GenreID = new SelectList(unitOfWork.GenreRepository.Get(orderBy: x => x.OrderBy(y => y.Name)), "ID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(AudiofileUploadViewModel viewmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Audiofile audiofile = new Audiofile
                    {
                        Title = viewmodel.Name,
                        AuthorID = viewmodel.AuthorID,
                        GenreID = viewmodel.GenreID,
                        Year = viewmodel.Year,
                        Description = viewmodel.Description,
                        Filename = FileService.SaveFile(viewmodel.File)
                    };

                    unitOfWork.AudiofileRepository.Insert(audiofile);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch(DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            ViewBag.AuthorID = new SelectList(unitOfWork.AuthorRepository.Get(orderBy: x => x.OrderBy(y => y.Name)), "ID", "Name");
            ViewBag.GenreID = new SelectList(unitOfWork.GenreRepository.Get(orderBy: x => x.OrderBy(y => y.Name)), "ID", "Name");
            
            return View(viewmodel);
        }

        public ActionResult SearchResults(string searchString, int? page)
        {
            int pageSize = 2;
            int pageNumber = (page ?? 1);

            var result = unitOfWork.AudiofileRepository.Get();

            if (!string.IsNullOrEmpty(searchString))
            {
                ViewBag.Title = searchString;
                result = result.Where(x => x.Title.ToUpper().Contains(searchString.ToUpper())).OrderBy(x => x.Title);
            }
            return View(result.ToPagedList(pageNumber, pageSize));
        }

    }
}
