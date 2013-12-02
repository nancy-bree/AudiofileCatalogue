using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CI.DAL;
using CI.Entities;

namespace CI.Controllers
{
    public class RatingController : Controller
    {
        private readonly IUnitOfWork unitOfWork = new UnitOfWork();

        [HttpPost]
        public JsonResult HasVoted(int userId, int audiofileId)
        {
            var result = unitOfWork.RatingRepository.HasVoted(userId, audiofileId);
            return Json(new { result = result });
        }

        [HttpPost]
        public JsonResult AddRemoveVote(int userId, int audiofileId, string action)
        {
            switch (action)
            {
                case "add":
                    unitOfWork.RatingRepository.Insert(new Rating { UserID = userId, AudiofileID = audiofileId });
                    break;
                case "remove":
                    unitOfWork.RatingRepository.Delete(unitOfWork.RatingRepository.Get().FirstOrDefault(x => x.UserID == userId && x.AudiofileID == audiofileId));
                    break;
                default:
                    return Json(new { success = false });
            }
            unitOfWork.Save();
            return Json(new { success = true });
        }

    }
}
