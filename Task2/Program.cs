using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Task2
{
    public interface ILogger
    {
        void Event(string message);
        void Error(string message);
    }
    public class Logger : ILogger
    {
        public void Event(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
        }
        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
        }
    }
    public interface ISumCalculate
    {
        double Num1 { get; set; }
        double Num2 { get; set; }
        void Sum();
    }
    public class SumCalculate : ISumCalculate
    {
        ILogger Logger { get; }
        public double Num1 { get; set; }
        public double Num2 { get; set; }
        public SumCalculate(double num1, double num2, ILogger logger)
        {
            Num1 = num1;
            Num2 = num2;
            Logger = logger;
        }
        public void Sum()
        {
            Logger.Event("Вычисления выполнены:");
            Console.WriteLine($"{Num1} + {Num2} = {Num1 + Num2}"); 
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new Logger();
            double num1;
            double num2;
            string again = "да";
            while (again != "нет")
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Введите первое число");
                    num1 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Введите второе число");
                    num2 = Convert.ToDouble(Console.ReadLine());
                    SumCalculate sumCalculate = new SumCalculate(num1, num2, logger);
                    sumCalculate.Sum();
                }
                catch (Exception)
                {
                    logger.Error("Возникла ошибка ввода.");
                    Console.WriteLine("Возможно вы ввели не число " +
                        "или точку вместо запятой для отделения дробной части числа.");
                    Console.WriteLine("Попробуйте снова.");
                    
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Хотите продолжить работу с калькулятором?");
                Console.WriteLine("Для продолжения введите любой символ. Для выхода введите \"нет\".");
                again = (Console.ReadLine()).ToLower();
            }            
        }
    }    
}
