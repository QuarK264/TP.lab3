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

        private static double FuncBesselCicle1(int n, double x, double[] FuncBesselCicle)
        {
            FuncBesselCicle[0] = x;
            FuncBesselCicle[1] = 2 * x;
            for (int i = 2; i < n; i++)
            {
                FuncBesselCicle[i] = 2 * (i - 1) * FuncBesselCicle[i - 1] / x - FuncBesselCicle[i - 2];
            }
            return FuncBesselCicle[n - 1];
        }

        private static double FuncBesselCicle2(int n, double x, double[] FuncBesselCicle)
        {
            for (int i = 0; i < n; i++)
            {
                FuncBesselCicle[i] = FuncBesselRecur(i, x);
            }
            return FuncBesselCicle[n - 1];
        }

        private static string FuncBesselDirect(double x, double[] FuncBesselCicle)
        {
            FuncBesselCicle[0] = x;
            FuncBesselCicle[1] = 2.0 * x;
            FuncBesselCicle[2] = 3.0 / x * FuncBesselCicle[1] - FuncBesselCicle[0];
            return (6 / x * FuncBesselCicle[2] - FuncBesselCicle[1]).ToString();
        }

        static void Main()
        {
            int n = 4;
            var x = 4;
            var RecurMethod = Stopwatch.StartNew();
            Console.WriteLine(FuncBesselRecur(n, x));
            RecurMethod.Stop();
            Console.WriteLine(RecurMethod.Elapsed);

            double[] FuncBesselCicle = new double[n];
            var CicleMethod1 = Stopwatch.StartNew();
            Console.WriteLine(FuncBesselCicle1(n, x, FuncBesselCicle));
            CicleMethod1.Stop();
            Console.WriteLine(CicleMethod1.Elapsed);
                       
            var CicleMethod2 = Stopwatch.StartNew();
            Console.WriteLine(FuncBesselCicle2(n, x, FuncBesselCicle));
            CicleMethod2.Stop();
            Console.WriteLine(CicleMethod2.Elapsed);

            var DirectMethod = Stopwatch.StartNew();
            Console.WriteLine(FuncBesselDirect(x, FuncBesselCicle));
            DirectMethod.Stop();

            Console.ReadLine();
        }
    }
}
