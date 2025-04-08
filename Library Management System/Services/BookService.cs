using Library_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Services
{
    public class BookService : IBookService
    {
        private List<Book> books = new List<Book>();

        private int nextId = 1;
        public async Task AddBookAsync(Book book)
        {
            book.Id = nextId++;
            books.Add(book);
            await Task.CompletedTask;
        }

        public async Task<List<Book>> GetBookAsync()
        {
            return await Task.FromResult(books);
        }

        public async Task<List<Book>> SearchBookAsync(int? id, string? title, string? author)
        {
            if(id != null)
            {
                var book = books.FirstOrDefault(b => b.Id == id);
                return book != null ? new List<Book> { book } : new List<Book>();
              
            }
            else if(!string.IsNullOrEmpty(title)||!string.IsNullOrEmpty(author))
            {
                return books.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase) 
                && b.Author.Contains(author, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return new List<Book>();
        }

        public async Task<bool> BorrowBookAsync(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);

            if(book != null && book.IsAvailable)
            {
                book.IsAvailable = false;
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if(book != null)
            {
                books.Remove(book);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<bool> EditBookAsync(int id, string newTitle, string newAuthor)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                book.Title = newTitle;
                book.Author = newAuthor;
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

       

        public async Task<bool> ReturnBookAsync(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if(book != null && !book.IsAvailable)
            {
                book.IsAvailable = true;
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

       
    }
}
