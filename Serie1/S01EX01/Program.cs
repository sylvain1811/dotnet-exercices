﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S01EX01
{
    class Program
    {
        struct Point3D
        {
            public double X, Y, Z;
            public Point3D(double X, double Y, double Z)
            {
                this.X = X;
                this.Y = Y;
                this.Z = Z;
            }
            public double DistanceToOrigin()
            {
                return Math.Sqrt(X * X + Y * Y + Z * Z);
            }
        }


        static void SwapPoints(ref Point3D a, ref Point3D b)
        {
            Point3D tmp = new Point3D(a.X, a.Y, a.Z);
            a.X = b.X;
            a.Y = b.Y;
            a.Z = b.Z;

            b.X = tmp.X;
            b.Y = tmp.Y;
            b.Z = tmp.Z;
        }

        static void Main(string[] args)
        {
            Point3D a = new Point3D(1.1, 2.2, 3.3);
            Point3D b = new Point3D(4.4, 5.5, 6.6);

            Console.WriteLine("A (" + a.X + ";" + a.Y + ";" + a.Z + "), Distance O : " + a.DistanceToOrigin());
            Console.WriteLine("B (" + b.X + ";" + b.Y + ";" + b.Z + "), Distance O : " + b.DistanceToOrigin());

            SwapPoints(ref a, ref b);

            Console.WriteLine("A (" + a.X + ";" + a.Y + ";" + a.Z + "), Distance O : " + a.DistanceToOrigin());
            Console.WriteLine("B (" + b.X + ";" + b.Y + ";" + b.Z + "), Distance O : " + b.DistanceToOrigin());
            Console.ReadKey();
        }
    }
}