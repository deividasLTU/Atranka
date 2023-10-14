using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Atranka
{
    [DataContract]
    internal class Area
    {
        [DataMember] public string Name { get; set; }
        [DataMember] public List<List<List<double>>> Coordinates { get; set; }


        public Area(string name, List<List<List<Double>>> coordinates)
        {
            this.Name = name;
            this.Coordinates = coordinates;
        }

    }
}
