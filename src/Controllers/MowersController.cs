using System.Collections.Concurrent;
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

            // Use Dictionary to conserve the input order elements even with threads functions
            // Concurrent dictionary is used to support adding elements inside threads 
            var resultMap = new ConcurrentDictionary<int, string>();

            Parallel.For(0, mowers.Count, i => {
                resultMap.TryAdd(i, _mowerMouvementService.MoverMowerByCommands(mowers[i], lawnGrid).ToString());
            });
            
            resultMap.OrderBy(x => x.Key).ToList().ForEach(x => Console.WriteLine(x.Value));
        }
    }
}