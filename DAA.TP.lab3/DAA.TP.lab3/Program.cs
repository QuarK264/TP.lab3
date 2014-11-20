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
        private static double FuncBesselRecur(int n, double x)
        {
            if (n == 0)
            {
                return x;
            }
            else
            {
                if (n == 1)
                {
                    return 2 * x;
                }
                else
                {
                    return 2 * (n - 1) * FuncBesselRecur(n - 1, x) / x - FuncBesselRecur(n - 2, x);
                }
            }
        }
        static void Main()
        {
            int n = 4;
            var x = 4;
            var RecurMethod = Stopwatch.StartNew();
            Console.WriteLine(FuncBesselRecur(n, x));
            RecurMethod.Stop();
            Console.WriteLine(RecurMethod.Elapsed);

            var CicleMethod = Stopwatch.StartNew();
            double[] FuncBesselCicle = new double[n + 1];
            //FuncBesselCicle[0] = x;
            //FuncBesselCicle[1] = 2 * x;
            //for (int i = 2; i < n; i++)
            //{
            //    FuncBesselCicle[i] = 2 * (i - 1) * FuncBesselCicle[i - 1] / x - FuncBesselCicle[i - 2];                
            //}
            for (int i = 0; i < n; i++)
            {
                FuncBesselCicle[i] = FuncBesselRecur(i, x);
            }
            Console.WriteLine(FuncBesselCicle[n - 1]);
            CicleMethod.Stop();
            Console.WriteLine(CicleMethod.Elapsed);

            Console.ReadLine();
        }
    }
}
