using Task1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task1
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
            Console.WriteLine(message);
        }
        public void Error(string message)
        {
            Console.WriteLine(message);
        }
    }
    public interface ISum
    {
        void Sum(int num1, int num2)
        {
            int result = num1 + num2;
            Console.WriteLine(result);
        }
    }
    public class Summation : ISum
    {
        ILogger logger { get; }
        public Summation()
        {}
        public Summation (ILogger logger)
        {
            this.logger = logger;
        }
        public void Sum(int num1,int num2)
        {
            int result=num1+num2;
            Console.BackgroundColor = ConsoleColor.Blue;   
            logger.Event("Расчет произведен, сумма чисел равна:");
            Console.WriteLine(result);
        }
    }
    internal class Program
    {
        static void Main()
        {
            try
            {
                ILogger Logger;
                Logger=new Logger();
                Console.WriteLine("Please enter two numbers");

                int num1;
                bool res= int.TryParse(Console.ReadLine(), out num1);

                int num2;
                bool res1 = int.TryParse(Console.ReadLine(), out num2);

                if (res == false|| res1==false)
                {
                    throw new UserException("The number input invalid format");
                }
                ISum sum = new Summation(Logger);

                sum.Sum(num1,num2);

                Console.ReadKey();
            }
            catch (ArgumentException e) 
            {
                Console.WriteLine(e.Message);
            }
            
        }

    }
}