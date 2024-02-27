using AngularAspCore.Database.Data.Models;
using AngularAspCore.Database.Repositories.DbContextData;
using AngularAspCore.Database.Repositories.Implementation;
using AngularAspCore.UnitTest.Helpers;

namespace AngularAspCore.UnitTest.AngularAspCore.Database.Tests
{
    internal class BookRepositoryUnitTests
    {
        private ApplicationDbContext 
            _context;

        [SetUp]
        public void Setup()
        {
            _context = ApplicationDbContextHelper.CreateDbContext();
        }

        [TearDown]
        public void Teardown()
        {
            _context.Dispose();
        }

        [Test]
        public async Task BookRepsotioy_AddsBookAsync_success()
        {
            //Arrange

            var repo = new BookRepository(_context);
            var fBook =
                new BookDataModel()
                {
                    Id = 1,
                    Title = "Test",
                    Author = "Test",
                    Description = "Test",
                };

            //Act
            var results = await repo.Add(fBook);

            //Assert
            Assert.IsTrue(results == fBook);
            ;
        }

        [Test]
        public void ReaderRepsotioy_UpdateReader_expecedUpdate()
        {
            //Arrange
            var fBook =
                 new BookDataModel()
                 {
                     Id = 1,
                     Title = "Test",
                     Author = "Test",
                     Description = "Test",
                 };
            var fUpdatedBook =
                new BookDataModel()
                {
                    Id = 1,
                    Title = "A New Title",
                    Author = "Test",
                    Description = "Test",
                };
            var repo = new BookRepository(_context);
            var results = repo.Add(fBook);

            //Act
            results.Result.Title = fUpdatedBook.Title;
            repo.Update(results.Result).Wait();

            //Assert
            Assert.That(results.Result.Title, Is.EqualTo(fUpdatedBook.Title));
        }

        [Test]
        public void ReaderRepository_DeleteReader_success()
        {
            //Arrange
            var repo = new BookRepository(_context);
            var fBook =
                 new BookDataModel()
                 {
                     Id = 1,
                     Title = "Test",
                     Author = "Test",
                     Description = "Test",
                 };
            repo.Add(fBook).Wait();

            //Actf
            repo.Delete(fBook).Wait();
            var isExist = _context.BookData.Any(x => x == fBook);

            //Assert
            Assert.That(isExist, Is.False);
        }
    }
}
