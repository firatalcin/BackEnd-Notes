using Entities.DTOs;
using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IBookService
    {
        Task<(IEnumerable<BookDto> books, MetaData metadata)> GetAllBooksAsync(BookParameters bookParameters, bool trackChange);
		Task<BookDto> GetOneBookByIdAsync(int id, bool trackChange);
		Task<BookDto> CreateOneBookAsync(BookDtoForInsertion book);
        Task UpdateOneBookAsync(int id, BookDtoForUpdate bookDto, bool trackChange);
        Task DeleteOneBookAsync(int id, bool trackChanges); 
    }
}
