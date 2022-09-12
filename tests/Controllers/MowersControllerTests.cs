using Mower.Application.Models;
using Mower.Application.Services;
using Moq;
using Xunit;
using System;
using System.IO;
using System.Collections.Generic;

namespace Mower.Application.Controllers.Tests
{
    public class MowersControllerTests
    {
        private Mock<MowerFileService> _mowerFileService;
        private Mock<MowerMouvementService> _mowerMouvementService;
        private MowersController _controller;

        public MowersControllerTests()
        {
            _mowerFileService = new Mock<MowerFileService>();
            _mowerMouvementService = new Mock<MowerMouvementService>();
            _controller = new MowersController( _mowerFileService.Object, _mowerMouvementService.Object);
        }

        #region controller
        [Fact]
        public void TestStartSimulationSuccess()
        {
            //A
            _mowerFileService.Setup(x => x.LoadMowersFromList(It.IsAny<string>())).Returns(() => new List<MowerElement> { new MowerElement(
                "N", 1, 3
            )});

            _mowerMouvementService.Setup(x => x.MoverMowerByCommands(It.IsAny<MowerElement>(), It.IsAny<Lawn>())).Returns(() => "1 3 N");

            _controller.StartSimulation("testpath");
            //A
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            
            //A
            Assert.Equal("1 3 N", stringWriter.ToString()); 
        }

        [Fact]
        public void TestStartSimulationDoesNotWriteOnConsole()
        {
            //A
            _mowerFileService.Setup(x => x.LoadMowersFromList(It.IsAny<string>())).Returns(() => new List<MowerElement> {});
            _controller.StartSimulation("testpath");
            //A
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            
            //A
            Assert.Equal("", stringWriter.ToString()); 
        }
        #endregion controller
    }
}