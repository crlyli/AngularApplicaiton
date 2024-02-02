using AngularAspCore.Server.Data.Models.Domain;
using static System.Reflection.Metadata.BlobBuilder;

namespace AngularAspCore.Server.Data
{
    public interface IData
    {
        List<BookData> BookDataList { get; }
    }
}
