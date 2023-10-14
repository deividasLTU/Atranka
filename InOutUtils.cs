using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.ConstrainedExecution;
using System.IO;
using Newtonsoft.Json;

namespace Atranka
{
    internal class InOutUtils
    {
        public static List<Area> ReadAreas(string fileName)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Area>));
            string json;

            using (StreamReader reader = new StreamReader(fileName))
            {
                json = reader.ReadToEnd();
            }

            using (MemoryStream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json)))
            {
                List<Area> areas = (List<Area>)serializer.ReadObject(stream);
                return areas;
            }
        }

        public static List<Location> ReadLocations(string fileName)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer (typeof(List<Location>));
            string json;

            using (StreamReader reader = new StreamReader(fileName))
            {
                json = reader.ReadToEnd();
            }

            using (MemoryStream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json)))
            {
                List<Location> locations = (List<Location>)serializer.ReadObject(stream);
                return locations;
            }
        }

        public static void PrintResults(string fileName, List<Match> matches)
        {
            using(MemoryStream stream = new MemoryStream())
            {
                string json = JsonConvert.SerializeObject(matches, Formatting.Indented);
                File.WriteAllText(fileName, json);
            }
        }

    }
}
