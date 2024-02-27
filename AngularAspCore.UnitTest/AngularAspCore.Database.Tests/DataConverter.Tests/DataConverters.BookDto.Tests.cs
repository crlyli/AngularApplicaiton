using AngularAspCore.Database.Data.Models.Dto;
using AngularAspCore.Database.Data.Models;
using AngularAspCore.Database.Converters;

namespace AngularAspCore.UnitTest.AngularAspCore.Database.Tests.DataConverter.Tests
{
    internal class DataConvertersUnitTests
    {
        private DataConverters
            fDataConverter;

        [SetUp]
        public void Setup()
        {
            fDataConverter = new DataConverters();
        }

        [TearDown]
        public void Teardown()
        {
        }

        [Test]
        public void DataConverter_ReaderDtoToDataModel_success()
        {
            //Arrange
            var fReaderDto = new ReaderDto()
            {
                FullName = "Reader FullName"
            };

            //Act
            var fReaderDataModel = fDataConverter.ConvertToReaderDataModel(fReaderDto);

            //Assert
            Assert.IsNotNull(fReaderDataModel);
            Assert.That(fReaderDataModel.FullName, Is.EqualTo(fReaderDto.FullName));
            Assert.IsNotNull(fReaderDataModel.Id);
            Assert.That(fDataConverter.ReadingDataModel, Is.EqualTo(fReaderDataModel));
        }

        [Test]
        public void DataConverter_BookDtoToDataModel_success()
        {
            //Arrange
            var fBookDto = new BookDto()
            {
                Title = "A Book Title",
                Author = "Author Name",
                Description = "Description",
            };

            //Act
            var fBookDataModel = fDataConverter.ConvertToBookDataModel(fBookDto);

            //Assert
            Assert.IsNotNull(fBookDataModel);
            Assert.That(fBookDataModel.Title, Is.EqualTo(fBookDto.Title));
            Assert.IsNotNull(fBookDataModel.Id);
            Assert.That(fDataConverter.BookDataModel, Is.EqualTo(fBookDataModel));
        }
        [Test]
        public void DataConverter_ReadingLogToDataModel_success()
        {
            //Arrange
            var fReadingLogDto = new ReadingLogDto()
            {
                BookId = new BookDataModel()
                {
                    Title = "A Book Title",
                    Author = "Author Name",
                    Description = "Description",
                },
                ReaderId = new ReaderDataModel()
                {
                    FullName = "Reader FullName"
                },
                ReadingStart = DateTime.Now.ToShortDateString(),
            };

            //Act
            var fReadingLogDataModel = fDataConverter.ConvertToReadingLogDataModel(fReadingLogDto);

            //Assert
            Assert.IsNotNull(fReadingLogDataModel);
            Assert.IsNotNull(fReadingLogDataModel.Id);
            Assert.That(fDataConverter.ReadingLogDataModel, Is.EqualTo(fReadingLogDataModel));
        }
    }
}