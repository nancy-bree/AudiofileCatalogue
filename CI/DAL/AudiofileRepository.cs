using System;
using System.Collections.Generic;
using System.Linq;
using CI.Models;

namespace CI.DAL
{
    public class AudiofileRepository : Repository<Audiofile>
    {
        public AudiofileRepository(CIContext context) : base(context) { }
    }
}