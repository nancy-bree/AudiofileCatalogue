using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CI.Entities;
using CI.ViewModels;
using CI.DAL;
using CI.Services;
using System.Data;
using PagedList;
using CI.Properties;

namespace CI.Controllers
{
    [HandleError]
    public class AuthorController : Controller
    {
        private IUnitOfWork unitOfWork = new UnitOfWork();
        //
        // GET: /Author/

        public ActionResult Index(int page = 1)
        {
            return View(unitOfWork.AuthorRepository.Get(orderBy: x => x.OrderBy(y => y.Name)).ToPagedList(page, Settings.Default.ItemsPerPage));
        }

        public ActionResult Details(int id = 1, int page = 1)
        {
            ViewBag.AuthorID = id;
            Author author = unitOfWork.AuthorRepository.GetByID(id);
            var model = new AuthorDetailsViewModel(author.Name, author.Image, author.Files);
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddAuthorViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AddAuthor(model);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("",
                    "Не удалось сохранить изменения. Повторите попытку.");
            }
            catch (Exception)
            {
                ModelState.AddModelError("",
                    "Информация об авторе, которого вы хотите добавить, уже содержится в базе.");
            }
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            return View(unitOfWork.AuthorRepository.GetByID(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Author model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EditAuthor(model);
                    return RedirectToAction("Authors", "Admin");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("",
                    "Не удалось сохранить изменения. Повторите попытку.");
            }
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public JsonResult Delete(int id)
        {
            DeleteAuthor(id);
            return Json(new { success = true });
        }

        #region tmp
        private void AddAuthor(AddAuthorViewModel model)
        {
            Author author = new Author();
            author.Name = model.Name;
            if (model.Image != null)
            {
                author.Image = FileService.SaveFile(model.Image);
            }
            bool exist = unitOfWork.AuthorRepository.Get().FirstOrDefault(
                x => x.Name.ToUpper() == author.Name.ToUpper()) != null;
            if (exist)
            {
                throw new Exception();
            }
            unitOfWork.AuthorRepository.Insert(author);
            unitOfWork.Save();
        }

        private void EditAuthor(Author model)
        {
            var authorToUpdate = unitOfWork.AuthorRepository.GetByID(model.ID);
            authorToUpdate.Name = model.Name;
            unitOfWork.AuthorRepository.Update(authorToUpdate);
            unitOfWork.Save();
        }

        private void DeleteAuthor(int id)
        {
            var authorToDelete = unitOfWork.AuthorRepository.GetByID(id);
            var files = System.IO.Directory.GetFiles(Server
                .MapPath(Settings.Default.AuthorImagePath), authorToDelete.Image);
            foreach (var file in files)
            {
                if (System.IO.File.Exists(file))
                {
                    System.IO.File.Delete(file);
                }
            }
            unitOfWork.AuthorRepository.Delete(authorToDelete);
            unitOfWork.Save();
        }

        #endregion
    }
}
