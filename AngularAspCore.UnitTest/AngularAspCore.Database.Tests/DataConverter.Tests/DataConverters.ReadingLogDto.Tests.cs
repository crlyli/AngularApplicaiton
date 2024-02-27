using AngularAspCore.Database.Converters;
using AngularAspCore.Database.Data.Models;
using AngularAspCore.Database.Data.Models.Dto;

namespace AngularAspCore.UnitTest.AngularAspCore.Database.Tests.DataConverter.Tests
{
    internal class ReadingLogDataConvertersUnitTests
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
