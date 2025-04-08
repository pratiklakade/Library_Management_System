using AutoMapper;
using Library_Management_System.Model;
using Library_Management_System.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
     .AddSingleton<IBookService, BookService>()
     .AddSingleton<IMapper>(new MapperConfiguration(cfg =>
     {
         cfg.CreateMap<Book, BookDTO>();
         cfg.CreateMap<BookDTO, Book>();
     }).CreateMapper())
     .BuildServiceProvider();

        var bookService = serviceProvider.GetService<IBookService>();

        if (bookService == null)
        {
            Console.WriteLine("⚠️ Failed to initialize the BookService.");
            return;
        }


        while (true)
        {
            Console.WriteLine("\n📚 Book Management System");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. View Books");
            Console.WriteLine("3. Search Book");
            Console.WriteLine("4. Borrow Book");
            Console.WriteLine("5. Return Book");
            Console.WriteLine("6. Edit Book");
            Console.WriteLine("7. Delete Book");
            Console.WriteLine("8. Exit");

            Console.Write("\nEnter your choice: ");
            string? choice = Console.ReadLine();

            switch(choice)
            {
                case "1":
                    // Add Book
                    Console.Write("\nEnter Book Title:");
                    string title = Console.ReadLine();

                    Console.Write("Enter Author Name: ");
                    string author = Console.ReadLine();

                    await bookService.AddBookAsync(new Book { Title = title, Author = author });
                    Console.WriteLine("\n✅ Book added successfully.");

                    break;

                case "2":
                    var books = await bookService.GetBookAsync();

                    if(books.Any())
                    {
                        Console.WriteLine("\n📚 Book List:");

                        foreach (var book in books )
                        {
                            Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}, Available: {book.IsAvailable}");
                        }
                    }

                    break;

                case "3":
                    // Search Books

                    int? searchId = null;
                    string? searchTitle = null;
                    string? searchAuthor = null;

                    Console.Write("\nEnter Book ID (or press Enter to skip): ");

                    string idInput = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(idInput))
                    {
                        if (int.TryParse(idInput, out int parsedId))
                        {
                            searchId = parsedId;
                        }
                        else
                        {
                            Console.WriteLine("\n⚠️ Invalid ID format. Please enter a valid integer.");
                            break;
                        }
                    }

                    if (searchId == null)
                    {
                        Console.Write("Enter Book Title (or press Enter to skip): ");
                        searchTitle = Console.ReadLine();

                        Console.Write("Enter Author Name (or press Enter to skip): ");
                        searchAuthor = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(searchTitle) || string.IsNullOrWhiteSpace(searchAuthor))
                        {
                            Console.WriteLine("\n⚠️ Please provide either an ID or both Title and Author.");
                            break;
                        }
                    }

                    var searchResults = await bookService.SearchBookAsync(searchId, searchTitle, searchAuthor);

                    if (searchResults.Any())
                    {
                        Console.WriteLine("\n🔍 Search Results:");
                        foreach (var book in searchResults)
                        {
                            Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}, Available: {book.IsAvailable}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n⚠️ No books found.");
                    }

                    break;

                case "4":
                    // Borrow Book
                    Console.Write("\nEnter Book ID to Borrow: ");
                    int borrowId = int.Parse(Console.ReadLine());

                    bool borrowSuccess = await bookService.BorrowBookAsync(borrowId);
                    Console.WriteLine(borrowSuccess ? "\n✅ Book borrowed successfully." : "\n⚠️ Book not available or doesn't exist.");
                    break;

                case "5":
                    // Return Book

                    Console.Write("\n Enter Book ID to Return Book");
                    int returnId = int.Parse(Console.ReadLine());

                    bool returnSuccess = await bookService.ReturnBookAsync(returnId);
                    Console.WriteLine(returnSuccess ? "\n✅ Book returned successfully." : "\n⚠️ Book not found or already available.");
                    break;

                case "6":
                    Console.Write("\nEnter Book ID to Edit: ");
                    int editId = int.Parse(Console.ReadLine());

                    Console.Write("Enter New Title: ");
                    string newTitle = Console.ReadLine();

                    Console.Write("Enter New Author: ");
                    string newAuthor = Console.ReadLine();

                    bool editSuccess = await bookService.EditBookAsync(editId, newTitle, newAuthor);
                    Console.WriteLine(editSuccess ? "\n✅ Book updated successfully." : "\n⚠️ Book not found.");
                    break;
                    

                case "7":
                    // Delete Book
                    Console.Write("\nEnter Book ID to Delete: ");
                    int deleteId = int.Parse(Console.ReadLine());

                    bool deleteSuccess = await bookService.DeleteBookAsync(deleteId);
                    Console.WriteLine(deleteSuccess ? "\n✅ Book deleted successfully." : "\n⚠️ Book not found.");
                    break;

                case "8":
                    // Exit the Application
                    Console.WriteLine("\n👋 Exiting the Book Management System. Goodbye!");
                    break;

                default:
                    Console.WriteLine("\n⚠️ Invalid choice. Please try again.");
                    break;
            }
        }

    }
}