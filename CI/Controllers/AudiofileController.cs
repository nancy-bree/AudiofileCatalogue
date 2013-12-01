using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CI.Entities;
using CI.DAL;
using CI.ViewModels;
using CI.Services;
using System.Data;
using PagedList;
using CI.Properties;

namespace CI.Controllers
{
    [HandleError]
    public class AudiofileController : Controller
    {
        private readonly IUnitOfWork unitOfWork = new UnitOfWork();
        //
        // GET: /AudioFile/

        public ActionResult Index(int page = 1)
        {
            return View(unitOfWork.AudiofileRepository.Get(orderBy: x => x.OrderBy(y => y.Title)).ToPagedList(page, Settings.Default.ItemsPerPage));
        }

        public ActionResult Details(int id = 1)
        {
            Audiofile audiofile = unitOfWork.AudiofileRepository.GetByID(id);
            ViewBag.Title = audiofile.Author.Name + " - " + audiofile.Title;
            return View(audiofile);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Upload()
        {
            ViewBag.AuthorID = new SelectList(unitOfWork.AuthorRepository.Get(orderBy: x => x.OrderBy(y => y.Name)), "ID", "Name");
            ViewBag.GenreID = new SelectList(unitOfWork.GenreRepository.Get(orderBy: x => x.OrderBy(y => y.Name)), "ID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(AudiofileUploadViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AddAudiofile(model);
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
                    "Файл, который вы пытаетесь добавить уже содержится в базе.");
            }
            ViewBag.AuthorID = new SelectList(unitOfWork.AuthorRepository.Get(orderBy: x => x.OrderBy(y => y.Name)), "ID", "Name");
            ViewBag.GenreID = new SelectList(unitOfWork.GenreRepository.Get(orderBy: x => x.OrderBy(y => y.Name)), "ID", "Name");
            
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            ViewBag.AuthorID = new SelectList(unitOfWork.AuthorRepository.Get(orderBy: x => x.OrderBy(y => y.Name)), "ID", "Name");
            ViewBag.GenreID = new SelectList(unitOfWork.GenreRepository.Get(orderBy: x => x.OrderBy(y => y.Name)), "ID", "Name");
            return View(unitOfWork.AudiofileRepository.GetByID(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Audiofile model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EditAudiofile(model);
                    return RedirectToAction("Audiofiles", "Admin");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("",
                    "Не удалось сохранить изменения. Повторите попытку.");
            }
            ViewBag.AuthorID = new SelectList(unitOfWork.AuthorRepository.Get(orderBy: x => x.OrderBy(y => y.Name)), "ID", "Name");
            ViewBag.GenreID = new SelectList(unitOfWork.GenreRepository.Get(orderBy: x => x.OrderBy(y => y.Name)), "ID", "Name");

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public JsonResult Delete(int id)
        {
            DeleteAudiofile(id);
            return Json(new {success = true});
        }

        public ActionResult SearchResults(string searchString, int page = 1)
        {
            var result = new List<Audiofile>();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                ViewBag.Title = searchString;
                result = unitOfWork.AudiofileRepository.Get().Where(x => x.Title.ToUpper().Contains(searchString.ToUpper())).OrderBy(x => x.Title).ToList();
            }
            return View(result.ToPagedList(page, Settings.Default.ItemsPerPage));
        }

        #region tmp
        private void AddAudiofile(AudiofileUploadViewModel model)
        {
            Audiofile audiofile = new Audiofile
            {
                Title = model.Name,
                AuthorID = model.AuthorID,
                GenreID = model.GenreID,
                Year = model.Year,
                Description = model.Description,
                Filename = FileService.SaveFile(model.File)
            };
            bool exist = unitOfWork.AudiofileRepository.Get().FirstOrDefault(
                x => x.Title.ToUpper() == audiofile.Title.ToUpper() &&
                x.AuthorID == audiofile.AuthorID &&
                x.GenreID == audiofile.GenreID &&
                x.Year == audiofile.Year &&
                x.Description.ToUpper() == audiofile.Description.ToUpper() ) != null;
            if (exist)
            {
                throw new Exception();
            }
            unitOfWork.AudiofileRepository.Insert(audiofile);
            unitOfWork.Save();
        }

        private void EditAudiofile(Audiofile model)
        {
            var audiofileToUpdate = unitOfWork.AudiofileRepository.GetByID(model.ID);
            audiofileToUpdate.Title = model.Title;
            audiofileToUpdate.Genre = unitOfWork.GenreRepository.GetByID(model.GenreID);
            audiofileToUpdate.Author = unitOfWork.AuthorRepository.GetByID(model.AuthorID);
            audiofileToUpdate.Description = model.Description;
            audiofileToUpdate.Year = model.Year;
            unitOfWork.AudiofileRepository.Update(audiofileToUpdate);
            unitOfWork.Save();
        }

        private void DeleteAudiofile(int id)
        {
            var audiofileToDelete = unitOfWork.AudiofileRepository.GetByID(id);
            var files = System.IO.Directory.GetFiles(Server
                .MapPath(Settings.Default.AudiofilePath), audiofileToDelete.Filename);
            foreach (var file in files)
            {
                if (System.IO.File.Exists(file))
                {
                    System.IO.File.Delete(file);
                }
            }
            unitOfWork.AudiofileRepository.Delete(audiofileToDelete);
            unitOfWork.Save();
        }

        #endregion
    }
}
