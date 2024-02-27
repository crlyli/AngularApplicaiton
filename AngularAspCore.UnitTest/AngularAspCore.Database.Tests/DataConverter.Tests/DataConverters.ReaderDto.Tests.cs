using AngularAspCore.Database.Converters;
using AngularAspCore.Database.Data.Models;
using AngularAspCore.Database.Data.Models.Dto;
namespace AngularAspCore.UnitTest.AngularAspCore.Database.Tests.DataConverter
{
    internal class ReaderDataConvertersUnitTests
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
    }
}
