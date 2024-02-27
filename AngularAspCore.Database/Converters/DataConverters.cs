using AngularAspCore.Database.Data.Models;
using AngularAspCore.Database.Data.Models.Dto;

namespace AngularAspCore.Database.Converters
{
    /// <summary>
    /// Converts data from Model to Dto or Dto to model
    /// </summary>
    public class DataConverters : IDataConverters
    {
        ///<inheritdoc cref="IDataConverters"/> 
        public ReaderDataModel? ReadingDataModel {get; private set;}

        ///<inheritdoc cref="IDataConverters"/> 
        public BookDataModel? BookDataModel { get; private set; }

        ///<inheritdoc cref="IDataConverters"/> 
        public ReadingLogDataModel? ReadingLogDataModel { get; private set; }

        ///<inheritdoc cref="IDataConverters"/> 
        public BookDataModel ConvertToBookDataModel(BookDto bookDto)
        {
            BookDataModel = new BookDataModel()
            {
                Title = bookDto.Title,
                Description = bookDto.Description,
                Author = bookDto.Author
            };

            return BookDataModel;
        }

        ///<inheritdoc cref="IDataConverters"/> 
        public ReaderDataModel ConvertToReaderDataModel(ReaderDto readerDto)
        {
            ReadingDataModel = new ReaderDataModel()
            {
                FullName = readerDto.FullName,
            };

            return ReadingDataModel;
        }

        ///<inheritdoc cref="IDataConverters"/> 
        public ReadingLogDataModel ConvertToReadingLogDataModel(ReadingLogDto aReaderDto)
        {
            DateTime? fReadingEnd = string.IsNullOrEmpty(aReaderDto.ReadingEnd) ? null : DateTime.Parse(aReaderDto.ReadingEnd);
            DateTime fReadingStart = DateTime.Parse(aReaderDto.ReadingStart);
            ReadingLogDataModel = new ReadingLogDataModel()
            {
                ReaderId = aReaderDto.ReaderId.Id,
                BookId = aReaderDto.BookId.Id,
                ReadingStarted = fReadingStart,
                ReadingEnded = fReadingEnd,
            };
            return ReadingLogDataModel;
        }
    }
}
