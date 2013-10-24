using System;
using System.Collections.Generic;
using System.Linq;
using CI.Models;

namespace CI.DAL
{
    public class RatingRepository : Repository<Rating>
    {
        public RatingRepository(CIContext context) : base(context) { }
    }
}