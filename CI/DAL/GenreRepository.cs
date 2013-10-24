using System;
using System.Collections.Generic;
using System.Linq;
using CI.Models;

namespace CI.DAL
{
    public class GenreRepository : Repository<Genre>
    {
        public GenreRepository(CIContext context) : base(context) { }
    }
}