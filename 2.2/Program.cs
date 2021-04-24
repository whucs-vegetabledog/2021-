using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpHomework2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入数组长度：");
            int length = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[length];
            Console.WriteLine("请依次输入数组中的每个元素：");
            for(int i = 0; i < length; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }
            Test test = new Test();
            Console.WriteLine("该数组中元素最大值为：");
            test.getMax(array);
            Console.WriteLine("该数组中元素最小值为：");
            test.getMin(array);
            Console.WriteLine("该数组的元素平均值为：");
            test.getAve(array);
            Console.WriteLine("该数组的元素和为：");
            test.getSum(array);
            Console.ReadKey();
        }
        class Test
        {
            public void getMax(int[] array)
            {
                int max = array[0];
                for (int n = 0;n<array.Length;n++)
                {
                    if (max<array[n])
                    {
                        max = array[n];
                    }
                }
                Console.WriteLine(max);
            }
            public void getMin(int[] array)
            {
                int min = array[0];
                for (int n = 0;n<array.Length;n++)
                {
                    if (min>array[n])
                    {
                        min = array[n];
                    }
                }
                Console.WriteLine(min);
            }
            public void getAve(int[] array)
            {
                int sum = 0;
                long ave = 0;
                for(int n = 0; n < array.Length; n++)
                {
                    sum = sum + array[n];
                }
                ave = sum / array.Length;
                Console.WriteLine(ave);
            }
            public void getSum(int[] array)
            {
                int sum = 0;
                for (int n = 0; n < array.Length; n++)
                {
                    sum = sum + array[n];
                }
                Console.WriteLine(sum);
            }
        }
    }
}
