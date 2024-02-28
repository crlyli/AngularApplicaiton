using AngularAspCore.Database;
using Moq;

namespace AngularAspCore.UnitTest.MockingSetups
{
    internal class MockIWrapperRepository
    {
        public static Mock<IRepositoryWraper> GetMock()
        {
            var mock = new Mock<IRepositoryWraper>();
            var readerRepoMock = MockIReaderRepository.GetMock();
            var bookRepoMock = MockIBookRepository.GetMock();
            var logRepoMock = MockIReadingLogRepository.GetMock();
            mock.Setup(m => m.ReaderRepository)
                .Returns(readerRepoMock.Object);
            mock.Setup(m => m.BookRepository).
                Returns(bookRepoMock.Object);
            mock.Setup(m => m.ReadingLogRepository).
                Returns(logRepoMock.Object);
            mock.Setup(m => m.SaveAsync())
                .Callback(() => { return; });

            return mock;
        }
    }
}
