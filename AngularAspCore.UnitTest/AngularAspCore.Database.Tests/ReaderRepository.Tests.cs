using AngularAspCore.Database.Data.Models;
using AngularAspCore.Database.Repositories.Implementation;
using AngularAspCore.Database.Repositories.DbContextData;
using AngularAspCore.UnitTest.Helpers;

namespace AngularAspCore.UnitTest.AngularAspCore.Database.Tests
{
    [TestFixture]
    public class ReaderRepositoryUnitTests
    {
        private ApplicationDbContext 
            _context;

        private ReaderRepository 
            _readerRepository;

        [SetUp]
        public void Setup()
        {
            _context = ApplicationDbContextHelper.CreateDbContext();
            _readerRepository = new ReaderRepository( _context );
        }

        [TearDown]
        public void Teardown()
        {
            _context.Dispose();
        }

        [Test]
        public async Task ReaderRepsotioy_AddsReaderAsync_success()
        {
            //Arrange
            var fReaders =
                new ReaderDataModel()
                {
                    Id = 1,
                    FullName = "A Name"
                };

            //Act
            var results = await _readerRepository.Add(fReaders);

            //Assert
            Assert.IsTrue(results.FullName == fReaders.FullName);
        }

        [Test]
        public void ReaderRepsotioy_UpdateReader_expecedUpdate()
        {
            //Arrange
            var fReaders =
                new ReaderDataModel()
                {
                    Id = 2,
                    FullName = "First Last"
                };
            var fUpdatedReader = new ReaderDataModel()
            {
                Id = 2,
                FullName = "Rename Last"
            };

            var results = _readerRepository.Add(fReaders);

            //Act
            results.Result.FullName = fUpdatedReader.FullName;
            _readerRepository.Update(results.Result).Wait();

            //Assert
            Assert.That(results.Result.FullName, Is.EqualTo(fUpdatedReader.FullName));
        }

        [Test]
        public void ReaderRepository_DeleteReader_success()
        {
            //Arrange
            var fReaders =
                new ReaderDataModel()
                {
                    Id = 2,
                    FullName = "First Last"
                };

            _readerRepository.Add(fReaders).Wait();

            //Act
            _readerRepository.Delete(fReaders).Wait();
            var isExist = _context.Reader.Any(x => x == fReaders);

            //Assert
            Assert.That(isExist, Is.False);
        }
    }
}