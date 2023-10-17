using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
	public class BookManager : IBookService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;

		public BookManager(IRepositoryManager manager, ILoggerService logger)
		{
			_manager = manager;
			_logger = logger;
		}

		public Book CreateOneBook(Book book)
        {
            _manager.Book.CreateOneBook(book);
            _manager.Save();
            return book;
        }

        public void DeleteOneBook(int id, bool trackChanges)
        {
            var entity = _manager.Book.GetOneBookById(id, false);
            if (entity is null)
            {
                string message = $"The book with id:{id} could not found";
				_logger.LogInfo(message);
				throw new Exception(message);
			}

			_manager.Book.DeleteOneBook(entity);
            _manager.Save();
        }

        public IEnumerable<Book> GetAllBooks(bool trackChange)
        {
            return _manager.Book.GetAllBooks(trackChange);
        }

        public Book GetOneBookById(int id, bool trackChange)
        {
            return _manager.Book.GetOneBookById(id, trackChange);
        }

        public void UpdateOneBook(int id, Book book, bool trackChange)
        {
            var entity = _manager.Book.GetOneBookById(id, false);
            if (entity is null)
            {
                string message = $"Book with id: {id} could not found";
                _logger.LogInfo(message);
				throw new Exception(message);
			}
               
            if(book is null)
                throw new ArgumentNullException(nameof(book));

            entity.Title = book.Title;
            entity.Price = book.Price;

            _manager.Book.Update(entity);
            _manager.Save();
        }
    }
}
