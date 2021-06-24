using System;

namespace WorkWithInterfaceses
{
    public interface ISumCalculate
    {
        double Num1 { get; set; }
        double Num2 { get; set; }
        void Sum();
    }
    public class SumCalculate : ISumCalculate
    {
        public double Num1 { get; set; }
        public double Num2 { get; set; }
        public SumCalculate(double num1, double num2)
        {
            this.Num1 = num1;
            this.Num2 = num2;
        }
        public void Sum()
        {
            Console.WriteLine($"{Num1} + {Num2} = {Num1 + Num2}"); 
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            double num1;
            double num2;
            string again = "да";
            while (again != "нет")
            {
                try
                {
                    Console.WriteLine("Введите первое число");
                    num1 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Введите второе число");
                    num2 = Convert.ToDouble(Console.ReadLine());
                    SumCalculate sumCalculate = new SumCalculate(num1, num2);
                    sumCalculate.Sum();
                }
                catch (Exception)
                {
                    Console.WriteLine("Возникла ошибка ввода.");
                    Console.WriteLine("Возможно вы ввели не число " +
                        "или точку вместо запятой для отделения дробной части числа.");
                    Console.WriteLine("Попробуйте снова.");
                }
                Console.WriteLine("Хотите продолжить работу с калькулятором?");
                Console.WriteLine("Для продолжения введите любой символ. Для выхода введите \"нет\".");
                again = (Console.ReadLine()).ToLower();
            }
        }        
    }
}
