using AngularAspCore.Server.Data.Models.Domain;
using System.Collections.Generic;

namespace AngularAspCore.Server.Data
{
    public class Data : IData
    {
        public List<BookData> Books { get; set; } = new List<BookData>()
        {
            new BookData()
            {
                Id = 1,
                Title = "A book title",
                Description = "A description about a book. Plus some more about the book",
                Author = "fNameA lNameA",
                Rate = 4.9,
                DateStart = new DateTime(2019, 01, 20),
                DateRead = null
            },
            new BookData()
            {
                Id = 2,
                Title = "B book title",
                Description = "A description about a book. Plus some more about the book",
                Author = "fNameB lNameB",
                Rate = 4.9,
                DateStart = new DateTime(2019, 01, 20),
                DateRead = DateTime.Today
            },
            new BookData()
            {
                Id = 3,
                Title = "C book title",
                Description = "A description about a book. Plus some more about the book",
                Author = "fNameC lNameC",
                Rate = 4.9,
                DateStart = new DateTime(2019, 02, 20),
                DateRead = null
            },
            new BookData()
            {
                Id = 4,
                Title = "D book title",
                Description = "A description about a book. Plus some more about the book",
                Author = "fNameD lNameD",
                Rate = 4.9,
                DateStart = new DateTime(2019, 01, 20),
                DateRead = new DateTime(2019, 01,31)
            }
        };

        public List<BookData> BookDataList => Books;
    }
}
