using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CI.DAL;
using CI.Properties;
using PagedList;

namespace CI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork unitOfWork = new UnitOfWork();

        public ActionResult Index(int page = 1)
        {
            var popular = unitOfWork.AudiofileRepository.Get()
                .Where(x => x.Votes.Count > 0)
                .OrderByDescending(x => x.Votes.Count)
                .ToPagedList(page, 2);
            return View(popular);
        }

    }
}
