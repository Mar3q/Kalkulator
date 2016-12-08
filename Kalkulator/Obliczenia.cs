using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulator
{
    public class Obliczenia 
    {
        
        public double operand1 = 0;
        public double operand2 = 0;
        
        public char działanie;
        public double licz()
        {
            #region podstawowe działania
            if (działanie == '+')
                return operand1 + operand2;
            if (działanie == '-')
                return operand1 - operand2;
            if (działanie == '*')
                return operand1 * operand2;
            if (działanie == '/')
                return operand1 / operand2;
            if (działanie == '^')
                return Math.Pow(operand1, operand2);
            #endregion
            #region silnia
            if (działanie == '!')
            {
                //algorytm liczenia silni
                long s = 1;
                for (int i = 1; i <= operand1; ++i)
                    s *= i;
                return (double)s;
            }
            #endregion
            #region funkcje okresowe
            if (działanie == 's')
            {
                double degrees = operand1;
                double angle = Math.PI * degrees / 180.0;
                return Math.Sin(angle);
            }
            if (działanie == 'c')
            {
                double degrees = operand1;
                double angle = Math.PI * degrees / 180.0;
                return Math.Cos(angle);
            }
            if (działanie == 't')
            {
                double degrees = operand1;
                double angle = Math.PI * degrees / 180.0;
                return Math.Tan(angle);
            }
            if (działanie == 'g')
            {
                double degrees = operand1;
                double angle = Math.PI * degrees / 180.0;
                return 1/Math.Tan(angle);

            }
            #endregion
            else
                return 0;
        }
    }
}
