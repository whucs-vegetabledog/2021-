using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpHomework2._3
{
    class PrimeApp
    {
        const int N = 100;

        static void Main(string[] args)
        {
            bool[] primes = new bool[N + 1]; //i是素数时，primes[i]为true
            for (int i = 2; i < N + 1; i++)
            {
                primes[i] = true;
            }

            Filter(primes);
            for (int num = 2; num < N + 1; num++)
            {
                if (primes[num])
                {
                    Console.Write($"\t{num}");
                }
            }
            Console.ReadKey();
        }

        // 在数组中过滤出素数
        private static void Filter(bool[] primes)
        {
            if (primes == null || primes.Length == 0) return;

            for (int num = 2; num * num < primes.Length; num++)
            { //循环到sqrt(prims.Length)
                if (!primes[num]) continue; //非素数的倍数不用再次过滤
                for (int nonprime = 2 * num; nonprime < primes.Length; nonprime += num)
                {//筛掉num的2倍、3倍、4倍...
                    primes[nonprime] = false;
                }
            }
        }
    }
}
