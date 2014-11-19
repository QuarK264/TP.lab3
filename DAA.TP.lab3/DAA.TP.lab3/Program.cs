namespace DAA.TP.lab3
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        private static double FuncBessel(int n, double x)
        {
            if (n == 0)
            {
                return x;
            }
            if (n == 1)
            {
                return 2 * x;
            }
            return 2 * (n - 1) * FuncBessel(n - 1, x) / x - FuncBessel(n - 2, x);
        }
        static void Main()
        {
            int n = 8;
            var x = 2;
            var RecurMethod = Stopwatch.StartNew();
            Console.WriteLine(FuncBessel(n, x));
            RecurMethod.Stop();
            Console.WriteLine(RecurMethod.ElapsedTicks);
            Console.ReadLine();
        }
    }
}
