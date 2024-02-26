using AngularAspCore.Database.Data.Models;
using AngularAspCore.Database.Repositories.Implementation;
using AngularAspCore.Database.Repositories.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace AngularAspCore.UnitTest.MockingSetups
{
    internal class MockIReaderRepository
    {
        public static Mock<IReaderRepository> GetMock()
        {
            var mock = new Mock<IReaderRepository>();
            var readers = new List<ReaderDataModel>
                {
                    new ReaderDataModel
                    {
                        Id = 1,
                    FullName = "MyFullName"
                    },
                }.AsEnumerable();

            mock.Setup(aRepo => aRepo.GetAll()).Returns(readers);
            mock.Setup(aRepo => aRepo.GetById(It.IsAny<int>()))
                .Returns((int id) => readers.FirstOrDefault(o => o.Id == id));

            mock.Setup(aRepo => aRepo.Add(It.IsAny<ReaderDataModel>()))
                .Callback(() => { return; });

            mock.Setup(aRepo => aRepo.Update(It.IsAny<ReaderDataModel>()))
                .Callback(() => { return; });

            mock.Setup(aRepo => aRepo.Delete(It.IsAny<ReaderDataModel>()))
                .Callback(() => { return; });

            mock.Setup(aRepo => aRepo.DeleteById(It.IsAny<int>()))
                .Callback(() => { return; });

            return mock;
        }
    }
}
