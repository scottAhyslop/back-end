using back_end.Controllers;
using back_end.Models;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace back_end.Tests { 

    public class DevicesControllerTests
    {
        //private readonly DeviceContext _context;
        [Fact]
        public async Task GetDevices_Returns_All_Devices()
        {
            //Arrange
            int count = 0;
            var fake_Devices = A.CollectionOfDummy<Device>(count).AsEnumerable();
            var db_context =  A.Fake<DeviceContext>();
            A.CallTo(() => db_context.Devices).AssignsOutAndRefParameters(fake_Devices);
            DevicesController? controller = new DevicesController(db_context);

            //Returns(Task.FromResult(fake_Devices));   //FromResult());
            //Act
            //var actionResult = await controller.GetDevices().AsEnumerable();
            //Assert
            //var result = await actionResult.Result as OkObjectResult;     ;
        }
    }
}//end namespace
