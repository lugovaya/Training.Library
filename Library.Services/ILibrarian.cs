using System.Threading.Tasks;
using Library.Domain.Models;

namespace Library.Services
{
    public interface ILibrarian
    {
        Task Take<TBook>(TBook book, Employee employee, Visitor visitor);

        Task Give<TBook>(TBook book, Employee employee, Visitor visitor);

        Task ApplyFees(LibraryItem book, Visitor visitor);

        Task CheckAccess();
    }
}