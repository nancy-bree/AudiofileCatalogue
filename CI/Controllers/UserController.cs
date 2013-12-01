using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CI.DAL;
using WebMatrix.WebData;

namespace CI.Controllers
{
    public class UserController : Controller
    {
        [HttpPost]
        public JsonResult Delete(string username)
        {
            var membership = (SimpleMembershipProvider)Membership.Provider;
            Roles.RemoveUserFromRoles(username, Roles.GetRolesForUser(username));
            bool wasDeleted = membership.DeleteAccount(username);
            wasDeleted = membership.DeleteUser(username, true);
            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult ChangeUserRole(string username, string act)
        {
            switch (act)
            {
                case "add":
                    Roles.AddUserToRole(username, "Admin");
                    break;
                case "exclude":
                    Roles.RemoveUserFromRole(username, "Admin");
                    break;
            }
            return Json(new { success = true });
        }

    }
}
