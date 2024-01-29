using AngularAspCore.Server.Data.Models;
using AngularAspCore.Server.Data.Models.Dto;
using AngularAspCore.Server.Repositories.DbContextData;
using AngularAspCore.Server.Repositories.Interface;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngularAspCore.Server.Repositories.Implementation
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
            //new BookData
            var fModel = ConvertToDataModel(bookData);
            await _mDbContext.AddAsync(fModel);
            await _mDbContext.SaveChangesAsync();
            return fModel;
        }
        public Task<List<BookDataModel>> GetBooks()
        {
            return _mDbContext.BookData.ToListAsync();
        }
        public async Task<List<BookDataModel>> GetBooksById(int fId)
        {
            IQueryable<BookDataModel> GetItems = _mDbContext.BookData;
            return await GetItems.Where(book => book.Id == fId).ToListAsync();

        }
        public async Task<ActionResult<BookDataModel>> UpdateBookById(int fId, BookDataModel model)
        {
            var fExist = await _mDbContext.BookData.FindAsync(fId);
            if (fExist is not null)
            {
                fExist.Title = model.Title;
                fExist.Description = model.Description;
                fExist.Author = model.Author;
                fExist.Rate = model.Rate;
                fExist.DateFinish = model.DateFinish;
                fExist.DateStart = model.DateStart;

                await _mDbContext.SaveChangesAsync();
            }
            return fExist;
        }
        public BookDataModel ConvertToDataModel(BookDto bookDto)
        {
            var bookData = new BookDataModel();
            bookData.Title = bookDto.Title;    
            bookData.Description = bookDto.Description;
            bookData.Author = bookDto.Author;
            bookData.Rate = bookDto.Rate;
            bookData.DateStart = DateTime.Parse(bookDto.DateStart);
            bookData.DateFinish = DateTime.Parse(bookDto.DateFinish);
            
            return bookData;
            
        }
        //public ActionResult<Thing> Get(int id) =>     GetThingFromDB() ?? NotFound();
    }
}
