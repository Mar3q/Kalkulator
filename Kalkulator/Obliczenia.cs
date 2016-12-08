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
                return Math.Sin(operand1 * Math.PI / 180); //Zakladamy, że argument będzie podany w radianach.
            }
            if (działanie == 'c')
            {
                return Math.Cos(operand1 * Math.PI / 180); //Zakladamy, że argument będzie podany w radianach.
            }
            #endregion
            else
                return 0;
        }
    }
}
