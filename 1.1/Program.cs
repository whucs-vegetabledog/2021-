﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpHomework1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入第一个数:");
            double num1 = double.Parse(Console.ReadLine());//将用户输入的第一个数存储为num1
            Console.WriteLine("请输入第二个数:");
            double num2 = double.Parse(Console.ReadLine());//将用户输入的第二个数存储为num2
            Console.WriteLine("请输入运算符号:+、-、*、/、%");
            string symbol = Console.ReadLine();//将用户输入的运算符号存储为symbol
            Homework test = new Homework();
            test.calculator(num1, num2, symbol);
            Console.ReadKey();//暂停当前程序，按任意键继续进行，防止程序计算出结果后直接退出
        }
            class Homework
        {
            public void calculator(double Num1, double Num2, string Symbol)//三个形参
            {
                double result = 0;
                switch (Symbol)
                {
                    case "+":
                        result = Num1 + Num2;
                        Console.WriteLine($"这两个数之和为:{result}");
                        break;
                    case "-":
                        result = Num1 - Num2;
                        Console.WriteLine($"这两个数之差为:{result}");
                        break;
                    case "*":
                        result = Num1 * Num2;
                        Console.WriteLine($"这两个数之积为:{result}");
                        break;
                    case "/":
                        switch (Num2)//当符号为/的时候,判断输入的第二个数是否为0,如果为0,则重新输入第二个数(不为0);反则正常运行除法运算
                        {
                            case 0:
                                Console.WriteLine("请重新输入第二个数(不等于0)");
                                double rNum2 = double.Parse(Console.ReadLine());
                                result = Num1 / rNum2;
                                Console.WriteLine($"这两个数的商为:{result}");
                                break;
                            default:
                                result = Num1 / Num2;
                                Console.WriteLine($"这两个数的商为:{result}");
                                break;
                        }
                        break;
                    case "%":
                        switch (Num2)//当符号为%的时候,判断输入的第二个数是否为0,如果为0,则重新输入第二个数(不为0);反则正常运行取余运算
                        {
                            case 0:
                                Console.WriteLine("请重新输入第二个数(不等于0)");
                                double rNum2 = double.Parse(Console.ReadLine());
                                result = Num1 % rNum2;
                                Console.WriteLine($"这两个数取余为:{result}");
                                break;
                            default:
                                result = Num1 % Num2;
                                Console.WriteLine($"这两个数取余为:{result}");
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("请输入正确的运算符号:");
                        string rFuhao = Console.ReadLine();
                        switch (rFuhao)
                        {
                            case "+":
                                result = Num1 + Num2;
                                Console.WriteLine($"这两个数之和为:{result}");
                                break;
                            case "-":
                                result = Num1 - Num2;
                                Console.WriteLine($"这两个数之差为:{result}");
                                break;
                            case "*":
                                result = Num1 * Num2;
                                Console.WriteLine($"这两个数之积为:{result}");
                                break;
                            case "/":
                                switch (Num2)
                                {
                                    case 0:
                                        Console.WriteLine("请重新输入第二个数(不等于0)");
                                        double rNum2 = double.Parse(Console.ReadLine());
                                        result = Num1 / rNum2;
                                        Console.WriteLine($"这两个数的商为:{result}");
                                        break;
                                    default:
                                        result = Num1 / Num2;
                                        Console.WriteLine($"这两个数的商为:{result}");
                                        break;
                                }
                                break;
                            case "%":
                                switch (Num2)
                                {
                                    case 0:
                                        Console.WriteLine("请重新输入第二个数(不等于0)");
                                        double rNum2 = double.Parse(Console.ReadLine());
                                        result = Num1 % rNum2;
                                        Console.WriteLine($"这两个数取余为:{result}");
                                        break;
                                    default:
                                        result = Num1 % Num2;
                                        Console.WriteLine($"这两个数取余为:{result}");
                                        break;
                                }
                                break;
                        }
                        break;
                }
            }
        }
    }
}

