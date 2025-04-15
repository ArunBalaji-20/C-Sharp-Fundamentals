using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context=context;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
             return (await _context.books.ToListAsync());
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return (await _context.books.FindAsync(id));
        }

        public async Task<Book> AddAsync(Book book)
        {
            _context.books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book?> UpdateAsync(int id, Book book)
        {
            var existing = await _context.books.FindAsync(id);
            if (existing == null) return null;

            existing.Title = book.Title;
            existing.Author = book.Author;
            existing.year = book.year;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var book = await _context.books.FindAsync(id);
            if (book == null) return false;

            _context.books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
