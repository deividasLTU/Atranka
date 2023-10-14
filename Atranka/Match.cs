using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Atranka
{
    internal class Match
    {
        public string RegionName { get; set; }
        public List<string> Locations { get; set; }

        public Match()
        {
            this.Locations = new List<string>();
        }


    }
}
