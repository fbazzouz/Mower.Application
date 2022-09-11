using Mower.Application.Controllers;
using Mower.Application.Services;

namespace Mower.Application
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var mowerController  = new MowersController(new MowerFileService(), new MowerMouvementService());
            mowerController.StartSimulation("inputFile.txt");
        }
    }
}