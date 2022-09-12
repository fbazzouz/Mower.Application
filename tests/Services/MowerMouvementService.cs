using Mower.Application.Models;
using Moq;
using Xunit;
using System;
using System.IO;
using System.Collections.Generic;
using Mower.Application.Helpers;

namespace Mower.Application.Services.Tests
{
    public class MowerMouvementServiceTests
    {
        private MowerMouvementService _mouvementService;

        public MowerMouvementServiceTests()
        {
            _mouvementService = new MowerMouvementService();
        }

        #region services
        [Fact]
        public void TestMouvementServiceMoveMowerWithSuccess()
        {
            //A
            var initialMower = new MowerElement("N", 1, 2);
            initialMower.Commands = MowerInputHelper.getLawnMowerCommands("LFLFLFLFF");
            MowerElement newMowerPosition = _mouvementService.MoverMowerByCommands(initialMower, new Lawn(5,5));
            
            //A
            Assert.NotNull(newMowerPosition);
            Assert.Equal("1 3 N", newMowerPosition.ToString());
        }

        [Fact]
        public void TestMouvementServiceMoveMowerWithSuccessWithDiscardedMouvement()
        {
            //A
            var initialMower = new MowerElement("N", 1, 2);
            initialMower.Commands = MowerInputHelper.getLawnMowerCommands("LFLFLFLFF");
            MowerElement newMowerPosition = _mouvementService.MoverMowerByCommands(initialMower, new Lawn(5,5));

            initialMower = new MowerElement("N", 1, 1);
            initialMower.Commands = MowerInputHelper.getLawnMowerCommands("LFLFLFLFF");
            newMowerPosition = _mouvementService.MoverMowerByCommands(initialMower, new Lawn(5,5));
            
            //A
            Assert.NotNull(newMowerPosition);
            Assert.Equal("1 2  N", newMowerPosition.ToString());
        }
        #endregion services
    }
}