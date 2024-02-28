using AngularAspCore.Database.Data.Models;
using AngularAspCore.Database.Repositories.Interface;
using Moq;

namespace AngularAspCore.UnitTest.MockingSetups
{
    internal class MockIReadingLogRepository
    {
        public static Mock<IReadingLogRepository> GetMock()
        {
            var mock = new Mock<IReadingLogRepository>();
            var readingLog = new List<ReadingLogDataModel>()
            {
                new ReadingLogDataModel()
                {
                    Book = new BookDataModel() {
                    Id = 1,
                    Author = "A Author",
                    Title = "A Title",
                    Description = "A description"
                    },
                    Reader = new ReaderDataModel()
                    {
                        Id = 1,
                        FullName = "Full Name"
                    },
                    ReadingStarted = new DateTime(),
                    ReadingEnded = new DateTime(),
                }
            };
            mock.Setup(aRepo => aRepo.GetAllData())
                .Returns(readingLog.AsEnumerable);

            mock.Setup(aRepo => aRepo.GetById(It.IsAny<int>()))
                .Returns((int id) => readingLog.FirstOrDefault(o => o.Id == id));

            mock.Setup(aRepo => aRepo.Add(It.IsAny<ReadingLogDataModel>()))
                .Callback(() => { return; });

            mock.Setup(aRepo => aRepo.Update(It.IsAny<ReadingLogDataModel>()))
                .Callback(() => { return; });

            mock.Setup(aRepo => aRepo.Delete(It.IsAny<ReadingLogDataModel>()))
                .Callback(() => { return; });

            mock.Setup(aRepo => aRepo.DeleteById(It.IsAny<int>()))
                .Callback(() => { return; });
            return mock;
        }
    }
}
