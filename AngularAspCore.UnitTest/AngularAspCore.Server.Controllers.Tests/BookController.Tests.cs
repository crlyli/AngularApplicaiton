using AngularAspCore.Database.Data.Models;
using AngularAspCore.Database;
using AngularAspCore.Server.Controllers;
using AngularAspCore.UnitTest.MockingSetups;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace AngularAspCore.UnitTest.AngularAspCore.Server.Controllers.Tests
{
    internal class BookController
    {
        [TestFixture]
        public class BooksControllerUnitTests
        {
            private Mock<IRepositoryWraper> mockIWrapperRepository;
            private BooksController mockBookController;

            [SetUp]
            public void Setup()
            {
                mockIWrapperRepository = MockIWrapperRepository.GetMock();
                mockBookController = new BooksController(mockIWrapperRepository.Object);
            }

            [TearDown]
            public void Teardown()
            {
                mockBookController.Dispose();
            }

            [Test]
            public void BooksController_GetAll_Ok()
            {
                //Act
                var results = mockBookController.GetBooksAsync() as ObjectResult;

                //Assert
                Assert.IsNotNull(results);
                Assert.That(results.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));
                Assert.That(results.Value as IEnumerable<BookDataModel>, Is.Not.Empty);
            }

            [Test]
            public void BooksController_GetById_Ok()
            {
                //Act
                var results = mockBookController.GetBook(1);
                var objectResults = results as ObjectResult;

                //Assert
                Assert.IsNotNull(results);
                Assert.That(objectResults.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));
            }

            [Test]
            public void BooksController_GetById_BadRequest_Id_unknown()
            {
                //Act
                var results = mockBookController.GetBook(10) as StatusCodeResult;

                //Assert
                Assert.IsNotNull(results);
                Assert.That(results.StatusCode, Is.EqualTo((int)HttpStatusCode.NotFound));
            }

            [Test]
            public void BooksController_CreateUser_Ok()
            {
                //Arrange
                var book = new BookDataModel()
                {
                    Id = 3,
                    Author = "Another Author",
                    Title = "Another Title",
                    Description = "Another Description"
                };

                //Act
                var results = mockBookController.AddBookAsync(book);
                var objectResults = results.Result as ObjectResult;

                //Assert
                Assert.IsNotNull(results);
                Assert.That(objectResults.StatusCode, Is.EqualTo((int)HttpStatusCode.Created));
                Assert.IsAssignableFrom<CreatedAtActionResult>(objectResults);
                Assert.That(results.IsCompletedSuccessfully, Is.True);
            }

            [Test]
            public void BooksController_DeletedUser_Ok()
            {
                //Act
                var results = mockBookController.DeleteBookAsync(1);
                var objectResults = results.Result as OkResult;

                //Assert
                Assert.IsNotNull(results);
                Assert.That(objectResults.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));
                Assert.That(results.IsCompletedSuccessfully, Is.True);
            }
        }
    }
}
