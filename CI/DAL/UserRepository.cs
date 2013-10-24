using System;
using System.Collections.Generic;
using System.Linq;
using CI.Models;

namespace CI.DAL
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(CIContext context) : base(context) { }
    }
}