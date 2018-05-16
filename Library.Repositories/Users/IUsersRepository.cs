using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Domain.Models;

namespace Library.Repositories
{
    public interface IUsersRepository : IBaseRepository<User, string>
    {
        
    }
}