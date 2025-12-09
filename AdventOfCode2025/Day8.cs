using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025
{
    public class Day8
    {
        public static void SolvePart1(string input)
        {
            var coords = input.TrimEnd().Split('\n').Select(x => new Point3D(x)).ToList();
            var circuits = new List<List<Point3D>>();
            var distances = new List<DistanceEntry>();

            foreach (var a in coords) {
                foreach (var b in coords) { 
                    if (a.X == b.X && a.Y == b.Y && a.Z == b.Z) continue;                    
                    distances.Add(new DistanceEntry()
                    {
                        Distance = Point3D.CalculateDistance(a, b),
                        PointA = a,
                        PointB = b,
                    });
                }
            }
            distances = distances.OrderBy(x => x.Distance).Where((item, index) => index % 2 != 0).ToList();

            foreach (var distance in distances.Take(1000)) {
                if (distance.PointA.Circuit != null && distance.PointB.Circuit == null) distance.PointB.Circuit = distance.PointA.Circuit;
                else if (distance.PointA.Circuit == null && distance.PointB.Circuit != null) distance.PointA.Circuit = distance.PointB.Circuit;
                else if (distance.PointA.Circuit != null && distance.PointB.Circuit != null && distance.PointA.Circuit != distance.PointB.Circuit)
                {
                    var replaceCircuit = distance.PointB.Circuit;
                    var replacementCoords = coords.Where(x => x.Circuit == replaceCircuit);
                    foreach (var replacement in replacementCoords) {
                        replacement.Circuit = distance.PointA.Circuit;
                    }
                }
                else if (distance.PointA.Circuit == null && distance.PointB.Circuit == null)
                {
                    var circuitNumber = coords.Max(x => x.Circuit);
                    if (circuitNumber == null) circuitNumber = 1;
                    else circuitNumber+=1;
                    distance.PointA.Circuit = circuitNumber;
                    distance.PointB.Circuit = circuitNumber;
                }
            }

            var circuitCounts = coords.Where(x => x.Circuit != null).GroupBy(x => x.Circuit).ToList();
            circuitCounts = circuitCounts.OrderByDescending(x => x.Count()).ToList();
            var product = circuitCounts[0].Count() * circuitCounts[1].Count() * circuitCounts[2].Count();

            Console.WriteLine(product);

        }

        public static void SolvePart2(string input)
        {
            var coords = input.TrimEnd().Split('\n').Select(x => new Point3D(x)).ToList();
            var circuits = new List<List<Point3D>>();
            var distances = new List<DistanceEntry>();

            foreach (var a in coords)
            {
                foreach (var b in coords)
                {
                    if (a.X == b.X && a.Y == b.Y && a.Z == b.Z) continue;
                    distances.Add(new DistanceEntry()
                    {
                        Distance = Point3D.CalculateDistance(a, b),
                        PointA = a,
                        PointB = b,
                    });
                }
            }
            distances = distances.OrderBy(x => x.Distance).Where((item, index) => index % 2 != 0).ToList();

            foreach (var distance in distances)
            {
                if (distance.PointA.Circuit != null && distance.PointB.Circuit == null) distance.PointB.Circuit = distance.PointA.Circuit;
                else if (distance.PointA.Circuit == null && distance.PointB.Circuit != null) distance.PointA.Circuit = distance.PointB.Circuit;
                else if (distance.PointA.Circuit != null && distance.PointB.Circuit != null && distance.PointA.Circuit != distance.PointB.Circuit)
                {
                    var replaceCircuit = distance.PointB.Circuit;
                    var replacementCoords = coords.Where(x => x.Circuit == replaceCircuit);
                    foreach (var replacement in replacementCoords)
                    {
                        replacement.Circuit = distance.PointA.Circuit;
                    }
                }
                else if (distance.PointA.Circuit == null && distance.PointB.Circuit == null)
                {
                    var circuitNumber = coords.Max(x => x.Circuit);
                    if (circuitNumber == null) circuitNumber = 1;
                    else circuitNumber += 1;
                    distance.PointA.Circuit = circuitNumber;
                    distance.PointB.Circuit = circuitNumber;
                }
                if (!coords.Any(x => x.Circuit == null))
                {
                    if (coords.GroupBy(x => x.Circuit).Count() == 1)
                    {
                        Console.WriteLine(distance.PointA.X * distance.PointB.X);
                        break;
                    }
                }
            }
        }

        public class DistanceEntry
        {
            public double Distance { get; set; }
            public Point3D PointA { get; set; }
            public Point3D PointB { get; set; }
        }

        public class Point3D
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double Z { get; set; }
            public int? Circuit { get; set; }

            public Point3D(double x, double y, double z)
            {
                X = x;
                Y = y;
                Z = z;
            }

            public Point3D(string coordString)
            {
                var coords = coordString.TrimEnd().Split(',');
                X = double.Parse(coords[0]);
                Y = double.Parse(coords[1]);
                Z = double.Parse(coords[2]);
            }

            public static double CalculateDistance(Point3D p1, Point3D p2)
            {
                double dx = p2.X - p1.X;
                double dy = p2.Y - p1.Y;
                double dz = p2.Z - p1.Z;

                // The formula is: sqrt((x2 - x1)^2 + (y2 - y1)^2 + (z2 - z1)^2)
                var distance = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2) + Math.Pow(dz, 2));
                return distance;
            }
        }

    }
}
