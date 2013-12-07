using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CI.DAL;
using CI.Entities;

namespace CI.Controllers
{
    public class UserApiController : ApiController
    {
        private readonly IUnitOfWork unitOfWork = new UnitOfWork();

        // GET api/userapi
        public IEnumerable<User> Get()
        {
            return unitOfWork.UserRepository.Get();
        }

        // GET api/userapi/5
        public User Get(int id)
        {
            var user = unitOfWork.UserRepository.GetByID(id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return user;
        }
    }
}
