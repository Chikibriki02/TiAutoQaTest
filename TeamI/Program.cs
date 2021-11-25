using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamI
{
    class Program
    {

        static double Dlina(double x1, double y1,double x2, double y2) 
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }
        static void Main(string[] args)
        {
            char azb = 'A';
            double x=0, y=0;
            string Equilater = "Equilater";
            string Isosceles = "Isosceles";
            string parametr;
            List<Otrezok> points = new List<Otrezok>();
            for (int i = 0; i < 3; i++)
            {
                
                do
                {
                    try
                    {
                        Console.WriteLine("Enter coordinate X of dote " + azb);
                        x = Convert.ToDouble(Console.ReadLine());
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input format. Please enter an integer number");
                    }
                }
                while (true);

                do
                {
                    try
                    {
                        Console.WriteLine("Enter coordinate Y of dote " + azb);
                        y = Convert.ToDouble(Console.ReadLine());
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input format. Please enter an integer number");
                    }
                }
                while (true);
 
                points.Add(new Otrezok(x,y));
                azb++;
            }
            if (((points[0].x1 == points[1].x1)&&(points[0].y1 == points[1].y1))||((points[0].x1 == points[2].x1)&&(points[0].x1 == points[2].x1))||((points[2].x1 == points[1].x1)&&(points[2].x1 == points[1].x1)))
            {
             Console.WriteLine("Invalid input format. Triangle isn't correct. Please try next time.");
                Console.ReadKey();
                Environment.Exit(0);

            }
            points[0].name = "AB";
            points[1].name = "BC";
            points[2].name = "AC";

            azb = 'A';
            foreach (Otrezok p in points)
            {
                Console.WriteLine("Point " + azb +" with coordinate (" + p.x1 + ";" + p.y1 +")");
                azb++;
            }
             int a = 1;
            foreach (Otrezok p in points)
            {
                if (a == 3)
                {
                    a = 0;
                }
                p.x2 = points[a].x1;
                p.y2 = points[a].y1;               
                a++;
            }

            Console.WriteLine();   

            List<Double> dlina = new List<double>();
            foreach (Otrezok p in points)
            {
                Console.WriteLine("Length Of " + p.name + " is " + Math.Round(p.Dlina(),4));
                dlina.Add(p.Dlina());
            }


            Console.WriteLine();

            if ((dlina[0] == dlina[1]) && (dlina[1] == dlina[2]))
            {
                parametr = "\"Equilater\"";
            }
            else
            {
                parametr = "Not \"Equilater\"";
            }

            Console.WriteLine("Triangle is " + parametr);


            if ((dlina[0] == dlina[1]) || (dlina[1] == dlina[2])||(dlina[0] == dlina[2]))
            {
                parametr = "\"Isosceles\"";
            }
            else
            {
                parametr = "Not \"Isosceles\"";
            }

            Console.WriteLine("Triangle is " + parametr);


            dlina.Sort();

            double delta = 0.004;
            if ((Math.Pow(dlina[2], 2) - (Math.Pow(dlina[0], 2) + Math.Pow(dlina[1], 2)) <= delta) )
            {
                parametr = "\"Right\"";
            }
            else
            {
                parametr = "Not \"Right\"";
            }

            Console.WriteLine("Triangle is " + parametr);
            Console.WriteLine();
            Console.WriteLine("Perimetr = " + dlina.Sum());
            Console.WriteLine();

            Console.WriteLine("Parity numbers in range from 0 to triangle perimetr:");
            for (int i = 0; i < dlina.Sum(); i+=2)
            {
                Console.WriteLine(i);
            }
            System.Console.ReadKey();
        }
    }
}
