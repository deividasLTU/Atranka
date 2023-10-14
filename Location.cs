using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Atranka
{
    [DataContract]
    internal class Location
    {
        [DataMember] public string Name { get; set; }
        [DataMember] public List<Double> Coordinates { get; set; }

        public Location(string name, List<Double> coordinates)
        {
            this.Name = name;
            this.Coordinates = coordinates;
        }


    }
}
