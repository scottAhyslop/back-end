//using back_end.Controllers;
//using back_end.Models;
//using FakeItEasy;
//using FluentAssertions;
//using Microsoft.AspNetCore.Mvc;
//using Moq;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Xunit;

//namespace back_end.Tests
//{

//    public class DevicesControllerTests
//    {
//        private readonly DeviceContext _context;

//        private readonly DevicesController _controller;

//        #region Get By DeviceId Tests

//        [Fact]
//        public async void Task_GetDeviceById_Returns_OkResult()
//        {

//            //Arrange
//            var controller = new DevicesController(_context);
//            var deviceId = 2;

//            //Act
//            var device = await controller.GetDevice(deviceId);

//            //Assert
//            Assert.IsType<OkObjectResult>(device);
//        }
//        [Fact]
//        public async void Task_GetDevicesById_Return_NotFoundResult()
//        {

//            //Arrange
//            var controller = new DevicesController(_context);
//            var deviceId = 4;

//            //Act
//            var device = await controller.GetDevice(deviceId);

//            //Assert
//            Assert.IsType<NotFoundResult>(device);
//        }
//        [Fact]
//        public async void Task_GetDeviceById_Returns_BadRequestResult()
//        {

//            //Arrange
//            var controller = new DevicesController(_context);
//            int deviceId = 0;

//            //Act
//            var device = await controller.GetDevice(deviceId);

//            //Assert
//            Assert.IsType<BadRequestResult>(device);
//        }


//        #endregion

//        #region Get All Devices Tests

//        [Fact]
//        public void Task_GetDevices_Return_OkResult()
//        {

//            //Arrange
//            var controller = new DevicesController(_context);


//            //Act
//            var devices = controller.GetDevices();

//            //Assert
//            Assert.IsType<OkObjectResult>(devices);
//        }
//        [Fact]
//        public void Task_GetDevices_Return_BadRequestResult()
//        {

//            //Arrange
//            var controller = new DevicesController(_context);
           
//            //Act
//            var device =  controller.GetDevices();
//            device=null;

//            //Assert
//            if (device !=null)
//            {
//                Assert.IsType<BadRequestResult>(device);
//            }
            
//        }
//        [Fact]
//        public void Task_GetDevices_MatchResult()
//        {

//            //Arrange
//            var controller = new DevicesController(_context);
            
//            //Act
//            var device = controller.GetDevices();

//            //Assert
//            Assert.IsType<OkObjectResult>(device);

//            var okResult = device.Should().BeOfType<OkObjectResult>().Subject;
//            var postDevice = okResult.Value.Should().BeAssignableTo<List<OkObjectResult>>().Subject;

//            Assert.Equal("Device Title", postDevice[0].ToString());
//            Assert.Equal("Device Description", postDevice[0].ToString());
//            Assert.Equal("Device Title 2", postDevice[1].ToString());
//            Assert.Equal("Device Description 2", postDevice[1].ToString());
            
//        }
        
//        #endregion
//    }
//}//end namespace
