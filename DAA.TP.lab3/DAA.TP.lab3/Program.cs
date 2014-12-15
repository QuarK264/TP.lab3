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
        /// <summary>
        /// Рекурсивный расчёт значения функции
        /// </summary>
        /// <param name="n">Порядок функции</param>
        /// <param name="x">Аргумент функции</param>
        /// <returns>Значение функции энного порядка от аргумента x</returns>
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

        /// <summary>
        /// Расчёт значения функции циклом
        /// </summary>
        /// <param name="n">Порядок функции</param>
        /// <param name="x">Аргумент функции</param>
        /// <returns>Значение функции энного порядка от аргумента x</returns>
        private static double FuncBesselCicle(int n, double x)
        {
            double[] FuncBesselCicle = new double[n];
            FuncBesselCicle[0] = x;
            FuncBesselCicle[1] = 2 * x;
            for (int i = 2; i < n; i++)
            {
                FuncBesselCicle[i] = 2.0 * (i - 1) * FuncBesselCicle[i - 1] / x - FuncBesselCicle[i - 2];
            }
            return FuncBesselCicle[n - 1];
        }

        /// <summary>
        /// Точка входа в программу, выводит время работы алгоритмов
        /// </summary>
        static void Main()
        {
            int n = 8;
            double x = 4;
            var RecurMethod = Stopwatch.StartNew();
            Console.WriteLine(FuncBesselRecur(n, x));
            RecurMethod.Stop();
            Console.WriteLine(RecurMethod.ElapsedTicks);

            var CicleMethod = Stopwatch.StartNew();
            Console.WriteLine(FuncBesselCicle(n + 1, x));
            CicleMethod.Stop();
            Console.WriteLine(CicleMethod.ElapsedTicks);

            Console.ReadKey();
        }
    }
}
