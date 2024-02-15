using AngularAspCore.Database.Data.Models.Dto;

namespace AngularAspCore.Database.Data.Models
{
    /// <summary>
    /// Converts data from Model to Dto or Dto to model
    /// </summary>
    public class DataConverters
    {
        /// <summary>
        /// Converts BookDto to BookDataModel
        /// </summary>
        /// <param name="bookDto">Book Dto object</param>
        /// <returns>Book Data Model</returns>
        public static BookDataModel ConvertToBookDataModel(BookDto bookDto)
        {
            var bookData = new BookDataModel()
            {
                Title = bookDto.Title,
                Description = bookDto.Description,
                Author = bookDto.Author
            };

            return bookData;
        }
        /// <summary>
        /// Converts Dto to Reader Data Model
        /// </summary>
        /// <param name="readerDto">Reader Dto Object</param>
        /// <returns>Reader Data Model</returns>
        public static ReaderDataModel ConvertToReaderDataModel(ReaderDto readerDto)
        {
            var readerData = new ReaderDataModel()
            {
                FullName = readerDto.FullName,
            };

            return readerData;
        }

        /// <summary>
        /// Converts Dto to Reading Log Data Model
        /// </summary>
        /// <param name="aReaderDto">Reader Dto object</param>
        /// <returns>Reader Log Data Model</returns>
        public static ReadingLogDataModel ConvertToReadingLogDataModel(ReadingLogDto aReaderDto)
        {
            DateTime? fReadingEnd = string.IsNullOrEmpty(aReaderDto.ReadingEnd) ? null : DateTime.Parse(aReaderDto.ReadingEnd);
            DateTime fReadingStart = DateTime.Parse(aReaderDto.ReadingStart);
            var readerData = new ReadingLogDataModel()
            {
                ReaderId = aReaderDto.ReaderId.Id,
                BookId = aReaderDto.BookId.Id,
                ReadingStarted = fReadingStart,
                ReadingEnded = fReadingEnd,
            };

            return readerData;
        }
    }
}
