using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Domain;
using Library.Domain.Models;

namespace Library.Repositories
{
    public class UsersRepository : BaseRepository<User, string>, IUsersRepository
    {
        public UsersRepository(LibraryContext context) : base(context)
        {
        }
    }
}