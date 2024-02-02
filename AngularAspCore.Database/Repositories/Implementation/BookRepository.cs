using AngularAspCore.Database.Data.Models;
using AngularAspCore.Database.Data.Models.Dto;
using AngularAspCore.Database.Repositories.DbContextData;
using AngularAspCore.Database.Repositories.Interface;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AngularAspCore.Database.Repositories.Implementation
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext
            _mDbContext;
        public BookRepository(ApplicationDbContext dbContext)
        {
           _mDbContext = dbContext;
        }
        public async Task<BookDataModel> CreateAsync(BookDto bookData)
        {
            var fModel = ConvertToDataModel(bookData);
            await _mDbContext.AddAsync(fModel);
            await _mDbContext.SaveChangesAsync();
            return fModel;
        }
        public Task<List<BookDataModel>> GetBooks()
        {
            return _mDbContext.BookData.Where(aBook => aBook.Title != string.Empty).ToListAsync();
        }

        public async Task<List<BookDataModel>> GetBooksById(int fId)
        {
            IQueryable<BookDataModel> GetItems = _mDbContext.BookData;
            return await GetItems.Where(book => book.Id == fId).ToListAsync();

        }
        public async Task<ActionResult<BookDataModel>> UpdateBookById(int fId, BookDto model)
        {
            var fConvert = ConvertToDataModel(model);
            _mDbContext.BookData.Update(fConvert);
            await _mDbContext.SaveChangesAsync();
            var fExist = await _mDbContext.BookData.FindAsync(fId);

            return fExist;
        }
        public BookDataModel ConvertToDataModel(BookDto bookDto)
        {
            var bookData = new BookDataModel();
            bookData.Title = bookDto.Title;    
            bookData.Description = bookDto.Description;
            bookData.Author = bookDto.Author;
            bookData.Rate = bookDto.Rate;
            bookData.DateStart = string.IsNullOrEmpty(bookDto.DateStart) ? null : DateTime.Parse(bookDto.DateStart); DateTime.Parse(bookDto.DateStart);
            bookData.DateFinish = string.IsNullOrEmpty(bookDto.DateFinish) ? null : DateTime.Parse(bookDto.DateFinish); ;
            
            return bookData;
            
        }
        public async Task<bool> DeleteBook(int fId)
        {
            var fBook = _mDbContext.BookData.Where(book => book.Id == fId).FirstOrDefault();

            if(fBook != null)
            {
                _mDbContext.Remove(fBook);
                await _mDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        //public ActionResult<Thing> Get(int id) =>     GetThingFromDB() ?? NotFound();
    }
}
