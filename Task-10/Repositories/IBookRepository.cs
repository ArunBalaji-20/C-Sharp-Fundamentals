using BookStore.Models;


namespace BookStore.Repositories
{
    public interface IBookRepository
    {
        Task <IEnumerable<Book>> GetAllAsync ();
        Task<Book?> GetByIdAsync(int id);

        Task<Book> AddAsync(Book book);

        Task<bool> DeleteByIdAsync(int id);

        Task<Book> UpdateAsync(int id,Book book);
    }
}
