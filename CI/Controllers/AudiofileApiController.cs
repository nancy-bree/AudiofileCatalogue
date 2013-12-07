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
    public class AudiofileApiController : ApiController
    {
        private readonly IUnitOfWork unitOfWork = new UnitOfWork();

        // GET api/audiofileapi
        public IEnumerable<Audiofile> Get()
        {
            return unitOfWork.AudiofileRepository.Get();
        }

        // GET api/audiofileapi/5
        public Audiofile Get(int id)
        {
            var audiofile = unitOfWork.AudiofileRepository.GetByID(id);
            if (audiofile == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return audiofile;
        }
    }
}
