using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Atranka
{
    class Program
    {
        static public void Main(string[] args) {
            string areaspath = @"areas.json";
            string locationspath = @"locations.json";

            List<Area> areas = InOutUtils.ReadAreas(areaspath);
            List<Location> locations = InOutUtils.ReadLocations(locationspath);

            List<Match> matches = TaskUtils.MatchLocations(areas, locations);

            InOutUtils.PrintResults("results.json", matches);

            Console.ReadKey();
        }
    }
}
