using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("введите ax^3");
            string a1;
            a1 = Console.ReadLine();
            Console.WriteLine("введите bx^2");
            string b1;
            b1 = Console.ReadLine();
            Console.WriteLine("введите cx");
            string c1;
            c1 = Console.ReadLine();
            Console.WriteLine("решаем");
            Console.WriteLine(a1 + "x^3+" + b1 + "x^2+" + c1 + "x=0");
            double a = double.Parse(a1);
            double b = double.Parse(b1);
            double c = double.Parse(c1);
            Console.WriteLine("ответ");
            Console.WriteLine(GetRootsOfCubicEquations(a, b, c));
            Console.Read();
        }
        public static List<double> GetRootsOfCubicEquations(double a, double b, double c)
        {
            var q = (Math.Pow(a, 2) - 3 * b) / 9;
            var r = (2 * Math.Pow(a, 3) - 9 * a * b + 27 * c) / 54;

            if (Math.Pow(r, 2) < Math.Pow(q, 3))
            {
                var t = Math.Acos(r / Math.Sqrt(Math.Pow(q, 3))) / 3;
                var x1 = -2 * Math.Sqrt(q) * Math.Cos(t) - a / 3;
                var x2 = -2 * Math.Sqrt(q) * Math.Cos(t + (2 * Math.PI / 3)) - a / 3;
                var x3 = -2 * Math.Sqrt(q) * Math.Cos(t - (2 * Math.PI / 3)) - a / 3;
                return new List<double> { Math.Abs(x1), Math.Abs(x2), Math.Abs(x3) };
            }
            else
            {
                var A = -Math.Sign(r) * Math.Pow(Math.Abs(r) + Math.Sqrt(Math.Pow(r, 2) - Math.Pow(q, 3)), (1.0 / 3.0));
                var B = (A == 0) ? 0.0 : q / A;

                var x1 = (A + B) - a / 3;

                if (A == B)
                {
                    var x2 = -A - a / 3;
                    return new List<double> { Math.Abs(x1), Math.Abs(x2) };
                }
                return new List<double> { Math.Abs(x1) };
            }
        }
    }
}