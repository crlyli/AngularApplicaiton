using AngularAspCore.Database.Repositories.Interface;
using Moq;
using AngularAspCore.Database.Data.Models;

namespace AngularAspCore.UnitTest.MockingSetups
{
    internal class MockIBookRepository
    {
        public static Mock<IBookRepository> GetMock()
        {
            var mock = new Mock<IBookRepository>();
            var books = new List<BookDataModel>()
            {
                new BookDataModel() {
                    Id = 1,
                    Author = "A Author",
                    Title = "A Title",
                    Description = "A description"
                }
            };
            mock.Setup(aRepo => aRepo.GetAll())
                .Returns(books.AsEnumerable);

            mock.Setup(aRepo => aRepo.GetById(It.IsAny<int>()))
                .Returns((int id)=> books.FirstOrDefault(o => o.Id == id));
            
            mock.Setup(aRepo => aRepo.Add(It.IsAny<BookDataModel>()))
                .Callback(() => { return; });
            
            mock.Setup(aRepo => aRepo.Update(It.IsAny<BookDataModel>()))
                .Callback(() => { return; });
            
            mock.Setup(aRepo => aRepo.Delete(It.IsAny<BookDataModel>()))
                .Callback(() => { return; });
            
            mock.Setup(aRepo => aRepo.DeleteById(It.IsAny<int>()))
                .Callback(() => { return; });
            
            return mock;
        }
    }
}
