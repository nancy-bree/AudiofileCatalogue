using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CI.Entities;
using CI.DAL;
using System.Data;
using PagedList;
using CI.Properties;

namespace CI.Controllers
{
    [HandleError]
    public class GenreController : Controller
    {
        private IUnitOfWork unitOfWork = new UnitOfWork();
        //
        // GET: /Genre/

        public ActionResult Index(int page = 1)
        {
            return View(unitOfWork.GenreRepository.Get(orderBy: x => x.OrderBy(y => y.Name)).ToPagedList(page, Settings.Default.ItemsPerPage));
        }

        public ActionResult Details(int page = 1, int id = 1)
        {
            ViewBag.Title = unitOfWork.GenreRepository.GetByID(id).Name;
            ViewBag.GenreID = id;
            var list = unitOfWork.AudiofileRepository.Get().Where(x => x.GenreID == id);
            return View(list.ToPagedList(page, Settings.Default.ItemsPerPage));
        }

        [Authorize(Roles = "Admin")]
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
                    AddGenre(genre);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Не удалось сохранить изменения. Повторите попытку.");
            }
            catch (Exception)
            {
                ModelState.AddModelError("",
                    "Такой жанр уже содержится в базе.");
            }
            return View(genre);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            return View(unitOfWork.GenreRepository.GetByID(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Genre genre)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EditGenre(genre);
                    return RedirectToAction("Genres", "Admin");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Не удалось сохранить изменения. Повторите попытку.");
            }
            catch (Exception)
            {
                ModelState.AddModelError("",
                    "Такой жанр уже содержится в базе.");
            }
            return View(genre);
        }

        #region tmp
        private void AddGenre(Genre genre)
        {
            if (IsExist(genre))
            {
                throw new Exception();
            }
            unitOfWork.GenreRepository.Insert(genre);
            unitOfWork.Save();
        }

        private bool IsExist(Genre genre)
        {
            bool exist = unitOfWork.GenreRepository.Get().FirstOrDefault(
                x => x.Name.ToUpper() == genre.Name.ToUpper()) != null;
            return exist;
        }

        private void EditGenre(Genre genre)
        {
            var genreToUpdate = unitOfWork.GenreRepository.GetByID(genre.ID);
            genreToUpdate.Name = genre.Name;
            unitOfWork.GenreRepository.Update(genreToUpdate);
            unitOfWork.Save();
        }

        #endregion
    }
}
