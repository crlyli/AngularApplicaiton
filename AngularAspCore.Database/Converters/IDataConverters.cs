using AngularAspCore.Database.Data.Models.Dto;
using AngularAspCore.Database.Data.Models;

namespace AngularAspCore.Database.Converters
{
    public interface IDataConverters
    {
        /// <summary>
        /// Convert to Book Data Model
        /// </summary>
        /// <param name="bookDto">Dto</param>
        /// <returns>BookDataModel</returns>
        BookDataModel ConvertToBookDataModel(BookDto bookDto);

        /// <summary>
        /// Converts Dto to Reader Data Model
        /// </summary>
        /// <param name="readerDto">Reader Dto Object</param>
        /// <returns>Reader Data Model</returns>
        ReaderDataModel ConvertToReaderDataModel(ReaderDto readerDto);

        /// <summary>
        /// Converts Dto to Reading Log Data Model
        /// </summary>
        /// <param name="aReaderDto">Reader Dto object</param>
        /// <returns>Reader Log Data Model</returns>
        ReadingLogDataModel ConvertToReadingLogDataModel(ReadingLogDto aReaderDto);

        /// <summary>
        /// Reading Log Data Model 
        /// </summary>
        ReadingLogDataModel? ReadingLogDataModel { get; }

        /// <summary>
        /// Reader Data Model
        /// </summary>
        ReaderDataModel? ReadingDataModel { get; }

        /// <summary>
        /// Book Data Model
        /// </summary>
        BookDataModel? BookDataModel { get; }
    }
}
