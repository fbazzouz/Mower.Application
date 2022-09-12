using Mower.Application.Models;
using Moq;
using Xunit;
using System;
using System.IO;
using System.Collections.Generic;
using Mower.Application.Helpers;

namespace Mower.Application.Services.Tests
{
    public class MowerFileServiceTests
    {
        private MowerFileService _fileService;

        public MowerFileServiceTests()
        {
            _fileService = new MowerFileService();
        }

        #region services
        [Fact]
        public void TestFileServiceReadLawnTopCorner()
        {
            //A
            Lawn lawn = _fileService.LoadLawnGridFromFile("inputFile.txt");
            
            //A
            Assert.NotNull(lawn);
            Assert.Equal(5, lawn.RightMaxCoordinate);
        }

        [Fact]
        public void TestFileServiceReadMowers()
        {
            //A
            List<MowerElement> mowers = _fileService.LoadMowersFromList("inputFile.txt");
            
            //A
            Assert.NotEmpty(mowers);
            Assert.Equal(2, mowers.Count);
        }
        #endregion services
    }
}