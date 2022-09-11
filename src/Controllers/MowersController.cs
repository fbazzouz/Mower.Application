using Mower.Application.Models;
using Mower.Application.Services;

namespace Mower.Application.Controllers
{
    public class MowersController
    {
        private MowerFileService _mowerFileService;
        private MowerMouvementService _mowerMouvementService;


        public MowersController(
            MowerFileService mowerFileService,
            MowerMouvementService mowerMouvementService
        )
        {
            _mowerFileService = mowerFileService;
            _mowerMouvementService = mowerMouvementService;
        }

        public void StartSimulation(string fileAbsolutePath)
        {
            Lawn lawnGrid = _mowerFileService.LoadLawnGridFromFile(fileAbsolutePath);
            List<MowerElement> mowers = _mowerFileService.LoadMowersFromList(fileAbsolutePath);

            foreach(var mower in mowers) {
                Console.WriteLine(_mowerMouvementService.MoverMowerByCommands(mower, lawnGrid).ToString());
            }
        }
    }
}