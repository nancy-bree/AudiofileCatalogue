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
    public class GenreApiController : ApiController
    {
        private readonly IUnitOfWork unitOfWork = new UnitOfWork();

        // GET api/genreapi
        public IEnumerable<Genre> Get()
        {
            return unitOfWork.GenreRepository.Get();
        }

        // GET api/genreapi/5
        public Genre Get(int id)
        {
            var genre = unitOfWork.GenreRepository.GetByID(id);
            if (genre == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return genre;
        }

        // POST api/genreapi
        public HttpResponseMessage Post([FromBody] Genre genre)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.GenreRepository.Insert(genre);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Invalid Model");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // PUT api/genreapi/5
        public HttpResponseMessage Put(int id, Genre genre)
        {
            try
            {
                var genreToUpdate = unitOfWork.GenreRepository.GetByID(id);
                genreToUpdate.Name = genre.Name;
                unitOfWork.GenreRepository.Update(genreToUpdate);
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
