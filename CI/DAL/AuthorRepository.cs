using System;
using System.Collections.Generic;
using System.Linq;
using CI.Models;

namespace CI.DAL
{
    public class AuthorRepository : Repository<Author>
    {
        public AuthorRepository(CIContext context) : base(context) { }
    }
}