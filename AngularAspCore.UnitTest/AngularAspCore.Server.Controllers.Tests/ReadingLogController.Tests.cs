using AngularAspCore.Database.Data.Models;
using AngularAspCore.Database;
using AngularAspCore.Server.Controllers;
using AngularAspCore.UnitTest.MockingSetups;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace AngularAspCore.UnitTest.AngularAspCore.Server.Controllers.Tests
{
    internal class ReadingLogControllerTests
    {
        [TestFixture]
        public class UnitTest1
        {
            private Mock<IRepositoryWraper> mockIWrapperRepository;
            private ReadingLogController mockReadingLogController;

            [SetUp]
            public void Setup()
            {
                mockIWrapperRepository = MockIWrapperRepository.GetMock();
                mockReadingLogController = new ReadingLogController(mockIWrapperRepository.Object);
            }

            [TearDown]
            public void Teardown()
            {
                mockReadingLogController.Dispose();
            }

            [Test]
            public void ReadingLogController_GetAll_Ok()
            {
                //Act
                var results = mockReadingLogController.GetReadingLogAsync() as ObjectResult;

                //Assert
                Assert.IsNotNull(results);
                Assert.That(results.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));
                Assert.That(results.Value as IEnumerable<ReadingLogDataModel>, Is.Not.Empty);
            }

            [Test]
            public void ReadingLogController_GetById_Ok()
            {
                //Act
                var results = mockReadingLogController.GetReadingLog(1);
                var objectResults = results as ObjectResult;

                //Assert
                Assert.IsNotNull(results);
                Assert.That(objectResults.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));
            }

            [Test]
            public void ReadingLogController_GetById_BadRequest_Id_unknown()
            {
                //Act
                var results = mockReadingLogController.GetReadingLog(10) as StatusCodeResult;

                //Assert
                Assert.IsNotNull(results);
                Assert.That(results.StatusCode, Is.EqualTo((int)HttpStatusCode.NotFound));
            }

            [Test]
            public void ReadingLogController_CreateUser_Ok()
            {
                //Arrange
                var fReadingLog = new Database.Data.Models.Dto.ReadingLogDto()
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
                var results = mockReadingLogController.AddReadingLogAsync(fReadingLog);
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
                var results = mockReadingLogController.DeleteReadingLogAsync(1);
                var objectResults = results.Result as OkResult;

                //Assert
                Assert.IsNotNull(results);
                Assert.That(objectResults.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));
                Assert.That(results.IsCompletedSuccessfully, Is.True);
            }
        }
    }
}
