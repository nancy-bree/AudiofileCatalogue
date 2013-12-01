using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CI.DAL;
using CI.Properties;
using WebMatrix.WebData;
using PagedList;

namespace CI.Controllers
{
    [Authorize(Roles = "Admin")]
    [HandleError]
    public class AdminController : Controller
    {
        private readonly IUnitOfWork unitOfWork = new UnitOfWork();

        public ActionResult Users(int page = 1)
        {
            return View(unitOfWork.UserRepository.Get(orderBy: x => x.OrderBy(y => y.Username)).ToPagedList(page, Settings.Default.ItemsPerPage));
        }

        public ActionResult Genres(int page = 1)
        {
            return View(unitOfWork.GenreRepository.Get(orderBy: x => x.OrderBy(y => y.Name)).ToPagedList(page, Settings.Default.ItemsPerPage));
        }

        public ActionResult Audiofiles(int page = 1)
        {
            return View(unitOfWork.AudiofileRepository.Get(orderBy: x => x.OrderBy(y => y.Title)).ToPagedList(page, Settings.Default.ItemsPerPage));
        }

        public ActionResult Authors(int page = 1)
        {
            return View(unitOfWork.AuthorRepository.Get(orderBy: x => x.OrderBy(y => y.Name)).ToPagedList(page, Settings.Default.ItemsPerPage));
        }
    }
}
