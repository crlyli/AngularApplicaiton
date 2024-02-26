using AngularAspCore.Database;
using AngularAspCore.Database.Data.Models;
using AngularAspCore.Server.Controllers;
using AngularAspCore.UnitTest.MockingSetups;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;



namespace AngularAspCore.UnitTest.AngularAspCore.Server.Controllers.Tests
{
    internal class ReaderControllerUnitTests
    {
        [TestFixture]
        public class UnitTest1
        {
            private Mock<IRepositoryWraper> mockIWrapperRepository;
            private ReaderController mockReaderController;

            [SetUp]
            public void Setup()
            {
                mockIWrapperRepository = MockIWrapperRepository.GetMock();
                mockReaderController = new ReaderController(mockIWrapperRepository.Object);
            }

            [TearDown]
            public void Teardown()
            {
                mockReaderController.Dispose();
            }

            [Test]
            public void ReaderController_GetAll_Ok()
            {
                //Act
                var results = mockReaderController.GetReadersAsync() as ObjectResult;

                //Assert
                Assert.IsNotNull(results);
                Assert.That(results.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));
                Assert.That(results.Value as IEnumerable<ReaderDataModel>, Is.Not.Empty);
            }

            [Test]
            public void ReaderController_GetById_Ok()
            {
                //Act
                var results = mockReaderController.GetReader(1);
                var objectResults = results as ObjectResult;

                //Assert
                Assert.IsNotNull(results);
                Assert.That(objectResults.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));
            }

            [Test]
            public void ReaderController_GetById_BadRequest_Id_unknown()
            {
                //Act
                var results = mockReaderController.GetReader(10) as StatusCodeResult;

                //Assert
                Assert.IsNotNull(results);
                Assert.That(results.StatusCode, Is.EqualTo((int)HttpStatusCode.NotFound));
            }

            [Test]
            public void ReaderController_CreateUser_Ok()
            {
                //Arrange
                var reader = new ReaderDataModel()
                {
                    Id = 2,
                    FullName = "test"
                };

                //Act
                var results = mockReaderController.AddReaderAsync(reader);
                var objectResults = results.Result as ObjectResult;

                //Assert
                Assert.IsNotNull(results);
                Assert.That(objectResults.StatusCode, Is.EqualTo((int)HttpStatusCode.Created));
                Assert.IsAssignableFrom<CreatedAtActionResult>(objectResults);
                Assert.That(results.IsCompletedSuccessfully, Is.True);
            }

            [Test]
            public void ReaderController_DeletedUser_Ok()
            {
                //Act
                var results = mockReaderController.DeleteReaderAsync(1);
                var objectResults = results.Result as OkResult;

                //Assert
                Assert.IsNotNull(results);
                Assert.That(objectResults.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));
                Assert.That(results.IsCompletedSuccessfully, Is.True);
            }
        }
    }
}
