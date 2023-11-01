﻿using AutoMapper;
using Entities.DTOs;
using Entities.Models;
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
                throw new BookNotFoundException(id);

			_manager.Book.DeleteOneBook(entity);
            _manager.Save();
        }

        public IEnumerable<BookDto> GetAllBooks(bool trackChange)
        {
            var books = _manager.Book.GetAllBooks(trackChange);
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public Book GetOneBookById(int id, bool trackChange)
        {
            var book = _manager.Book.GetOneBookById(id, trackChange);
            if (book is null)
                throw new BookNotFoundException(id);

            return book;
        }

        public void UpdateOneBook(int id, BookDtoForUpdate bookDto, bool trackChange)
        {
            var entity = _manager.Book.GetOneBookById(id, false);
            if (entity is null)
                throw new BookNotFoundException(id);

            //entity.Title = book.Title;
            //entity.Price = book.Price;
            entity = _mapper.Map<Book>(bookDto);

            _manager.Book.Update(entity);
            _manager.Save();
        }
    }
}
