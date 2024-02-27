using AngularAspCore.Database.Data.Models;
using AngularAspCore.Database.Repositories.DbContextData;
using AngularAspCore.Database.Repositories.Implementation;
using AngularAspCore.UnitTest.Helpers;

namespace AngularAspCore.UnitTest.AngularAspCore.Database.Tests
{
    internal class ReadingLogRepositoryUnitTests
    {
        private ApplicationDbContext 
            _context;

        private ReadingLogRepository 
            _readingLogRepository;

        [SetUp]
        public void Setup()
        {
            _context = ApplicationDbContextHelper.CreateDbContext();
            _readingLogRepository = new ReadingLogRepository( _context );
        }

        [TearDown]
        public void Teardown()
        {
            _context.Dispose();
        }

        [Test]
        public async Task ReadingLogRepository_AddsReaderAsync_success()
        {
            //Arrange
            var fReadingLog =
                new ReadingLogDataModel()
                {
                    Id = 1,
                    Reader = new ReaderDataModel()
                    {
                        Id = 1,
                        FullName = "A Name"
                    },
                    Book = new BookDataModel()
                    {
                        Id = 2,
                        Author = "A Author",
                        Title = "Title",
                        Description = "Description",
                    },
                    ReadingStarted = new DateTime()
                };
            

            //Act
            var results = await _readingLogRepository.Add(fReadingLog);

            //Assert
            Assert.IsTrue(results == fReadingLog);
        }

        [Test]
        public void ReadingLogRepository_UpdateReader_expecedUpdate()
        {
            //Arrange
            var fReadingLog =
                new ReadingLogDataModel()
                {
                    Id = 1,
                    Reader = new ReaderDataModel()
                    {
                        Id = 1,
                        FullName = "A Name"
                    },
                    Book = new BookDataModel()
                    {
                        Id = 2,
                        Author = "A Author",
                        Title = "Title",
                        Description = "Description",
                    },
                    ReadingStarted = new DateTime()
                };

            var fUpdateReadingLog =
                new ReadingLogDataModel()
                {
                    Id = 1,
                    Reader = new ReaderDataModel()
                    {
                        Id = 1,
                        FullName = "A Name"
                    },
                    Book = new BookDataModel()
                    {
                        Id = 2,
                        Author = "A Author",
                        Title = "Title",
                        Description = "Description",
                    },
                    ReadingStarted = new DateTime().AddDays(3)
                };
            var results = _readingLogRepository.Add(fReadingLog);

            //Act
            results.Result.ReadingStarted = fUpdateReadingLog.ReadingStarted;
            _readingLogRepository.Update(results.Result).Wait();

            //Assert
            Assert.That(results.Result.ReadingStarted, Is.EqualTo(fUpdateReadingLog.ReadingStarted));
        }

        [Test]
        public void ReadingLogRepository_DeleteReader_success()
        {
            //Arrange
            var fReadingLog =
                new ReadingLogDataModel()
                {
                    Id = 1,
                    Reader = new ReaderDataModel()
                    {
                        Id = 7,
                        FullName = "A Name"
                    },
                    Book = new BookDataModel()
                    {
                        Id = 7,
                        Author = "A Author",
                        Title = "Title",
                        Description = "Description",
                    },
                    ReadingStarted = new DateTime()
                };

            _readingLogRepository.Add(fReadingLog).Wait();

            //Act
            _readingLogRepository.Delete(fReadingLog).Wait();
            var isExist = _context.Reader.Any(x => x.Id == fReadingLog.Id);

            //Assert
            Assert.That(isExist, Is.False);
        }
    }
}
