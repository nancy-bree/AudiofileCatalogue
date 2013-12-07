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
    public class AuthorApiController : ApiController
    {
        private readonly IUnitOfWork unitOfWork = new UnitOfWork();

        // GET api/authorapi
        public IEnumerable<Author> Get()
        {
            return unitOfWork.AuthorRepository.Get();
        }

        // GET api/authorapi/5
        public Author Get(int id)
        {
            var author = unitOfWork.AuthorRepository.GetByID(id);
            if (author == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return author;
        }

        // POST api/authorapi
        public HttpResponseMessage Post(Author author)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.AuthorRepository.Insert(author);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Invalid Model");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // PUT api/authorapi/5
        public HttpResponseMessage Put(int id, Author author)
        {
            try
            {
                var authorToUpdate = unitOfWork.AuthorRepository.GetByID(id);
                authorToUpdate.Name = author.Name;
                unitOfWork.AuthorRepository.Update(authorToUpdate);
                unitOfWork.Save();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
