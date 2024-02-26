using AngularAspCore.Database.Data.Models;
using Ninject.MockingKernel.Moq;
using AngularAspCore.Database.Repositories.Implementation;
using AngularAspCore.Database.Repositories.DbContextData;
using Microsoft.EntityFrameworkCore;
using Ninject;
using AngularAspCore.Database.Repositories.Interface;

namespace AngularAspCore.UnitTest
{
    [TestFixture]
    public class UnitTest1
    {
        private MoqMockingKernel
            kernel;

        private ApplicationDbContext
            applicationDbContext;

        //private ReaderRepository repository;

        [SetUp]
        public void Setup()
        {
            kernel = new MoqMockingKernel();
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("SportAreteMemoryDb")
                .EnableSensitiveDataLogging()
                .Options;


            applicationDbContext = new ApplicationDbContext(contextOptions);

            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();

            var repository = new ReaderRepository(applicationDbContext);
            kernel.Bind<IReaderRepository>().ToConstant(repository);
        }

        [TearDown]
        public void Teardown()
        {
            kernel.Dispose();
            applicationDbContext.Dispose();
        }

        [Test]
        public void ReaderRepsotioy_GetAll_AddsUser()
        {
            //Arrange
            var fReaders =
                new ReaderDataModel()
                {
                    Id = 1,
                    FullName = "A Name"
                };

            //Act
            var fRepo = kernel.Get<IReaderRepository>();
            fRepo.Add(fReaders);
            //repository.Add(fReaders);
            applicationDbContext.SaveChangesAsync().Wait();
            var results = fRepo.GetAll().ToList();

            //Assert
            Assert.That(results[0].FullName, Is.EqualTo(fReaders.FullName));
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

            //Act
            //var fRepo = kernel.Get<IReaderRepository>();
            var fRepo = CreateNewReaderRepository();
            fRepo.Add(fReaders).Wait();
            applicationDbContext.SaveChangesAsync().Wait();
            var fNewRepo = CreateNewReaderRepository();
            fRepo.Update(fUpdatedReader).Wait();

            //Assert
            Assert.That(applicationDbContext.Reader.Contains(fUpdatedReader));
        }
        public ReaderRepository CreateNewReaderRepository()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;


            applicationDbContext = new ApplicationDbContext(contextOptions);

            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();

            var repository = new ReaderRepository(applicationDbContext);
            return repository;
            //kernel.Bind<IReaderRepository>().ToConstant(repository);
        }
    }
}