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
                    return 2.0 * x;
                }
                else
                {
                    return 2.0 * (n - 1) * FuncBesselRecur(n - 1, x) / x - FuncBesselRecur(n - 2, x);
                }
            }
        }

        private static double FuncBesselCicle1(int n, double x, double[] FuncBesselCicle)
        {
            FuncBesselCicle[0] = x;
            FuncBesselCicle[1] = 2 * x;
            for (int i = 2; i < n; i++)
            {
                FuncBesselCicle[i] = 2.0 * (i - 1) * FuncBesselCicle[i - 1] / x - FuncBesselCicle[i - 2];
            }
            return FuncBesselCicle[n - 1];
        }

        //ещё 1 вариант расчёта через цикл, для отладки
        //private static double FuncBesselCicle2(int n, double x, double[] FuncBesselCicle)
        //{
        //    for (int i = 0; i < n; i++)
        //    {
        //        FuncBesselCicle[i] = FuncBesselRecur(i, x);
        //    }
        //    return FuncBesselCicle[n - 1];
        //}

        //это была отладка программы
        //private static string FuncBesselDirect(double x, double[] FuncBesselCicle)
        //{
        //    FuncBesselCicle[0] = x;
        //    FuncBesselCicle[1] = 2.0 * x;
        //    return (2.0 / x * FuncBesselCicle[1] - FuncBesselCicle[0]).ToString();
        //}

        static void Main()
        {
            int n = 9;
            int nRecur = n - 1;
            double x = 4;
            var RecurMethod = Stopwatch.StartNew();
            Console.WriteLine(FuncBesselRecur(nRecur, x));
            RecurMethod.Stop();
            Console.WriteLine(RecurMethod.Elapsed);

            double[] FuncBesselCicleMass = new double[n];
            var CicleMethod1 = Stopwatch.StartNew();
            Console.WriteLine(FuncBesselCicle1(n, x, FuncBesselCicleMass));
            CicleMethod1.Stop();
            Console.WriteLine(CicleMethod1.Elapsed);

            //for (int i = 0; i < n; i++)
            //{
            //    FuncBesselCicleMass[i] = 0;
            //}        
            //var CicleMethod2 = Stopwatch.StartNew();
            //Console.WriteLine(FuncBesselCicle2(n, x, FuncBesselCicleMass));
            //CicleMethod2.Stop();
            //Console.WriteLine(CicleMethod2.Elapsed);

            //for (int i = 0; i < n; i++)
            //{
            //    FuncBesselCicleMass[i] = 0;
            //}    
            //var DirectMethod = Stopwatch.StartNew();
            //Console.WriteLine(FuncBesselDirect(x, FuncBesselCicleMass));
            //DirectMethod.Stop();
            //Console.WriteLine(DirectMethod.Elapsed);

            Console.ReadLine();
        }
    }
}
