using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Repositories.EFCore;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public readonly RepositoryContext _context;

        public BooksController(RepositoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            try
            {
                var books = _context.Books;
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
                var book = _context
                .Books
                .Where(x => x.Id.Equals(id))
                .SingleOrDefault();

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

                _context.Books.Add(book);
                _context.SaveChanges();
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
                var entity = _context.Books.Where(x => x.Id.Equals(id)).SingleOrDefault();

                if (entity is null)
                    return NotFound();

                // check id?
                if (id != book.Id)
                    return BadRequest();

                entity.Title = book.Title;
                entity.Price = book.Price;

                _context.SaveChanges();
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
            var entity = _context.Books.Where(x => x.Id == id).SingleOrDefault();

            if (entity is null)
                return NotFound(new
                {
                    StatusCode = 404,
                    message = $"Book with id: {id} could not found"
                });

            _context.Books.Remove(entity);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<Book> bookPatch)
        {
            var entity = _context.Books.Where(x => x.Id == id).SingleOrDefault();
            if (entity is null)
                return NotFound();

            bookPatch.ApplyTo(entity);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
