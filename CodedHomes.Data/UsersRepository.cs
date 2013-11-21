using System.Data.Entity;
using CodedHomes.Models;

namespace CodedHomes.Data
{
    public class UsersRepository : GenericRepository<User>
    {
        public UsersRepository(DbContext context) : base(context) {}
    }
}
