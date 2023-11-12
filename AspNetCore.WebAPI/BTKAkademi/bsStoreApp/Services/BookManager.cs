using AutoMapper;
using Entities.DTOs;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;
using static Entities.Exceptions.NotFoundException;

namespace Services
{
	public class BookManager : IBookService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;

        public BookManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<BookDto> CreateOneBookAsync(BookDtoForInsertion book)
        {
            var entity = _mapper.Map<Book>(book);
            _manager.Book.CreateOneBook(entity);
            await _manager.SaveAsync();
            return _mapper.Map<BookDto>(entity);
        }

        public async Task DeleteOneBookAsync(int id, bool trackChanges)
        {
            var entity = await GetOneBookAndCheckExits(id, trackChanges);

			_manager.Book.DeleteOneBook(entity);
            await _manager.SaveAsync();
        }

        public async Task<(IEnumerable<BookDto> books, MetaData metadata)> GetAllBooksAsync(BookParameters bookParameters, bool trackChange)
        {
            var booksWithMetaData = await _manager.Book.GetAllBooksAsync(bookParameters, trackChange);
            var booksDto = _mapper.Map<IEnumerable<BookDto>>(booksWithMetaData);

            return (booksDto, booksWithMetaData.MetaData);
        }

        public async Task<BookDto> GetOneBookByIdAsync(int id, bool trackChange)
        {
			var entity = await GetOneBookAndCheckExits(id, trackChange);

			return _mapper.Map<BookDto>(entity);
        }

        public async Task UpdateOneBookAsync(int id, BookDtoForUpdate bookDto, bool trackChange)
        {
			var entity = await GetOneBookAndCheckExits(id, trackChange);

			entity = _mapper.Map<Book>(bookDto);

            _manager.Book.Update(entity);
            await _manager.SaveAsync();
        }

        private async Task<Book> GetOneBookAndCheckExits(int id, bool trackChanges)
        {
			var entity = await _manager.Book.GetOneBookByIdAsync(id, false);

			if (entity is null)
				throw new BookNotFoundException(id);

            return entity;
		}
	}
}
