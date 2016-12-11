using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulator
{
    public class Obliczenia : IDisposable  //IDisposable zwalniania zaalokowane zasoby
    {
        #region Zmienne
        protected internal double operand1 = 0;//zmienne na których będziemy wykonywać operacje
        protected internal double operand2 = 0;

        public char działanie; //zmienna przechowująca "typ" działania

        private bool m_bIsDisposed = false; //zmienna informujaca czy proces zwalniania zasobów został już wcześniej wywołany 


        public Obliczenia()
        {
        } //konstruktor domyślny
        #endregion
        #region Metoda wykonujaca obliczenia
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
                if (operand1 > 20) //wiekszy zakres nie jest obsługiwany
                    return 0;
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
        #endregion
        #region Zalecana przez Microsoft implementacja interfejsu IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~Obliczenia()
        {
            Dispose(false);
        }
        protected virtual void Dispose(bool bDisposing)
        {
            if (m_bIsDisposed)
            {
                return;
            }
            if (bDisposing)
            {
                // Zwalnianie zasobów zarządzanych
            }
            // Zwalnianie zasobów nierządzanych
            m_bIsDisposed = true;
        }
        #endregion
    }
}