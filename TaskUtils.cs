using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atranka
{
    internal class TaskUtils
    {
        public static List<Match> MatchLocations(List<Area> areas, List<Location> locations)
        {
            List<Match> matches = new List<Match>();
            for (int i = 0; i < areas.Count(); i++)
            {
                Area area = areas[i];
                Match match = new Match();
                match.RegionName = area.Name;
                for (int j = 0; j < locations.Count(); j++)
                {
                    Point point = new Point(locations[j].Coordinates[0], locations[j].Coordinates[1]);
                    if(isInside(area, point))
                    {
                        match.Locations.Add(locations[j].Name);
                    }
                }
                matches.Add(match);
            }
            return matches;
        }



        private static bool isInside(Area area, Point point)
        {
            int counter = 0;

            for (int j = 0; j < area.Coordinates.Count(); j++)
            {
                for (int i = 0; i < area.Coordinates[j].Count() - 1; i++)
                {
                    double v1x = area.Coordinates[j][i][0];
                    double v1y = area.Coordinates[j][i][1];

                    double v2x = area.Coordinates[j][i + 1][0];
                    double v2y = area.Coordinates[j][i + 1][1];

                    Point v1 = new Point(v1x, v1y);
                    Point v2 = new Point(v2x, v2y);

                    if (isInline(v1, v2, point))
                    {
                        return true;
                    }
                    if (((v1.Y > point.Y) != (v2.Y > point.Y)) && (point.X < (v2.X - v1.X) * (point.Y - v1.Y) / (v2.Y - v1.Y) + v1.X))
                    {
                        counter++;
                    }
                }
                if (counter % 2 == 1)
                {
                    return true;
                }
                counter = 0;
            }
            return false;
            
        }

        private static bool isInline(Point A, Point B, Point C)
        {
            bool isInline = false;
            double AB = Math.Sqrt(Math.Pow(B.X - A.X, 2) + Math.Pow(B.Y - A.Y, 2));
            double AP = Math.Sqrt(Math.Pow(C.X - A.X, 2) + Math.Pow(C.Y - A.Y, 2));
            double PB = Math.Sqrt(Math.Pow(B.X - C.X, 2) + Math.Pow(B.Y - C.Y, 2));
            if(AB == AP + PB)
            {
                isInline = true;
            }
            return isInline;
        }

    }
}
