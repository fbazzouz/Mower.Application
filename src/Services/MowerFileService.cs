using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Mower.Application.Models;

namespace Mower.Application.Services
{
    public class MowerFileService
    {
        public List<MowerElement> LoadMowersFromFile(string fileAbsolutePath)
        {
            using (var fileStream = new FileStream(fileAbsolutePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
               fileStream
            }
        }
    }
}