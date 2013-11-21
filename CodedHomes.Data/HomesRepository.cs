using System.Data.Entity;
using CodedHomes.Models;
using System.Collections.Generic;

namespace CodedHomes.Data
{
    public class HomesRepository : GenericRepository<Home>
    {
        public HomesRepository(DbContext context) : base(context) {}
    }
}
