using Library_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Services
{
    public interface IBookService
    {
        Task AddBookAsync(Book book);

        Task<List<Book>> GetBookAsync();

        Task<List<Book>> SearchBookAsync(int? id,string? title, string? author);

        Task<bool> BorrowBookAsync(int id);
        Task<bool> ReturnBookAsync(int id);
        Task<bool> EditBookAsync(int id, string newTitle, string newAuthor);
        Task<bool> DeleteBookAsync(int id);

    }
}
