using AngularAspCore.Database.Data.Models;
using AngularAspCore.Database;
using AngularAspCore.Server.Controllers;
using AngularAspCore.UnitTest.MockingSetups;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;
using AngularAspCore.Database.Data.Models.Dto;
using AngularAspCore.Database.Converters;

namespace AngularAspCore.UnitTest.AngularAspCore.Server.Controllers.Tests
{
    internal class ReadingLogControllerTests
    {
        [TestFixture]
        public class UnitTest1
        {
            private Mock<IRepositoryWraper> 
                _mockIWrapperRepository;

            private ReadingLogController 
                _mockReadingLogController;

            private Mock<IDataConverters> 
                _mockConverters;

            [SetUp]
            public void Setup()
            {
                _mockIWrapperRepository = MockIWrapperRepository.GetMock();
                _mockConverters = new Mock<IDataConverters>();
                _mockConverters.Setup(aCon => aCon.ReadingLogDataModel).Returns(new ReadingLogDataModel()
                {
                    Id = 1,
                    Reader = new ReaderDataModel()
                    {
                        FullName = "Test"
                    },
                    Book = new BookDataModel()
                    {
                        Title = "Test",
                        Author = "Test",
                        Description = "Test",
                    },
                    ReadingStarted = DateTime.Now
                });
                _mockReadingLogController = new ReadingLogController(_mockIWrapperRepository.Object, 
                    _mockConverters.Object);
            }

            [TearDown]
            public void Teardown()
            {
                _mockReadingLogController.Dispose();
            }

            [Test]
            public void ReadingLogController_GetAll_Ok()
            {
                //Act
                var results = _mockReadingLogController.GetReadingLogAsync() as ObjectResult;

                //Assert
                Assert.IsNotNull(results);
                Assert.That(results.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));
                Assert.That(results.Value as IEnumerable<ReadingLogDataModel>, Is.Not.Empty);
            }

            [Test]
            public void ReadingLogController_GetById_Ok()
            {
                //Act
                var results = _mockReadingLogController.GetReadingLog(1);
                var objectResults = results as ObjectResult;

                //Assert
                Assert.IsNotNull(results);
                Assert.That(objectResults.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));
            }

            [Test]
            public void ReadingLogController_GetById_BadRequest_Id_unknown()
            {
                //Act
                var results = _mockReadingLogController.GetReadingLog(10) as StatusCodeResult;

                //Assert
                Assert.IsNotNull(results);
                Assert.That(results.StatusCode, Is.EqualTo((int)HttpStatusCode.NotFound));
            }

            [Test]
            public void ReadingLogController_CreateUser_Ok()
            {
                //Arrange
                var fReadingLog = new ReadingLogDto()
                {
                    ReaderId = new ReaderDataModel()
                    { 
                        FullName = "Test"
                    },
                    BookId = new BookDataModel()
                    {
                        Title = "Test",
                        Author = "Test",
                        Description = "Test",
                    },
                    ReadingStart = DateTime.Now.ToString()
                };

                //Act
                var results = _mockReadingLogController.AddReadingLogAsync(fReadingLog);
                var objectResults = results.Result as ObjectResult;

                //Assert
                Assert.IsNotNull(results);
                Assert.That(objectResults.StatusCode, Is.EqualTo((int)HttpStatusCode.Created));
                Assert.IsAssignableFrom<CreatedAtActionResult>(objectResults);
                Assert.That(results.IsCompletedSuccessfully, Is.True);
            }

            [Test]
            public void ReadingLogController_DeletedUser_Ok()
            {
                //Act
                var results = _mockReadingLogController.DeleteReadingLogAsync(1);
                var objectResults = results.Result as OkResult;

                //Assert
                Assert.IsNotNull(results);
                Assert.That(objectResults.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));
                Assert.That(results.IsCompletedSuccessfully, Is.True);
            }
        }
    }
}
