using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Calculation
    {
        public double first { get; set; }
        public double second { get; set; }
        public string operations { get; set; }

        public Calculation(){}

        public Calculation(double first_, double second_, string operation_)
        {
            first = first_;
            second = second_;
            operations = operation_;
        }

        public double Calculate()
        {
            double result;

            switch (operations)
            {
                case "+":
                    result = first + second;
                    break;
                case "-":
                    result = first - second;
                    break;
                case "*":
                    result = first * second;
                    break;
                case "/":
                    result = first / second;
                    break;
                default:
                    result = 0;
                    break;
            }

            return result;
        }
    }
}
