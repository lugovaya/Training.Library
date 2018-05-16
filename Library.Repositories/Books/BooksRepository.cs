using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Domain;
using Library.Domain.Models;

namespace Library.Repositories.Books
{
    public class BooksRepository : BaseRepository<LibraryItem>, IBooksRepository
    {
        public BooksRepository(LibraryContext context) : base(context)
        {
        }
    }
}