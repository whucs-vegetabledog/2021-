using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpHomework2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("请输入一个正整数：");
            int num = int.Parse(Console.ReadLine());
            Test test = new Test();
            Console.Write("该正整数的所有素数因子为：");
            test.getPrimeNum(num);
            Console.ReadKey();
        }
        class Test
        {
            public void getPrimeNum (int Num)
            {
                for (int i = 2;i <= Num;)
                {
                    if (Num % i == 0)
                    {
                        Console.Write(i+" ");
                        i++;
                    }
                    else
                        i++;
                }
            }
        }
    }
}
