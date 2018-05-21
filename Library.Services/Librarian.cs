using System;
using System.Threading.Tasks;
using Library.Domain.Models;

namespace Library.Services
{
    public class Librarian : ILibrarian
    {
        public Task Take<TBook>(TBook book, Employee employee, Visitor visitor)
        {
            throw new NotImplementedException();
        }

        public Task Give<TBook>(TBook book, Employee employee, Visitor visitor)
        {
            throw new NotImplementedException();
        }

        public Task ApplyFees(LibraryItem book, Visitor visitor)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CheckAccess()
        {
            return true;
        }
    }
}