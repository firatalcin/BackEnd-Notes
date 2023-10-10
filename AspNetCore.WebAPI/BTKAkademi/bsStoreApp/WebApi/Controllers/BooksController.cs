using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using Repositories.EFCore;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public readonly IRepositoryManager _manager;

        public BooksController(IRepositoryManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            try
            {
                var books = _manager.Book.GetAllBooks(false);
                return Ok(books);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetBook([FromRoute(Name = "id")] int id)
        {
            try
            {
                var book = _manager
                .Book
                .GetOneBookById(id, false);

                if (book is null)
                    return NotFound(); //404

                return Ok(book);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateOneBook([FromBody] Book book)
        {
            try
            {
                if (book is null)
                    return BadRequest();

                _manager.Book.CreateOneBook(book);
                _manager.Save();
                return StatusCode(201, book);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] Book book)
        {
            try
            {
                // check book?
                var entity = _manager.Book.GetOneBookById(id, true);

                if (entity is null)
                    return NotFound();

                // check id?
                if (id != book.Id)
                    return BadRequest();

                entity.Title = book.Title;
                entity.Price = book.Price;

                _manager.Save();
                return Ok(book);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
        {
            var entity = _manager.Book.GetOneBookById(id, false);

            if (entity is null)
                return NotFound(new
                {
                    StatusCode = 404,
                    message = $"Book with id: {id} could not found"
                });

            _manager.Book.DeleteOneBook(entity);
            _manager.Save();
            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<Book> bookPatch)
        {
            var entity = _manager.Book.GetOneBookById(id, true);
            if (entity is null)
                return NotFound();

            bookPatch.ApplyTo(entity);
            _manager.Book.Update(entity);
            return NoContent();
        }
    }
}
