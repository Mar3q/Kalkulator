﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kalkulator
{
    public partial class MainWindow : Window
    {
        Obliczenia obliczenia = new Obliczenia();
        bool czyWpisac = false;         //zmienna pomocnicza do sprawdzania prawidlowosci wprowadzonych danych
        bool CzyscOknoWyniku = true;    //zmienna pomocnicza do czyszczenia okna po wyjsciu z danego zdarzenia, w zaleznosci od przyjmowanej wartosci
        #region Okienko
        public MainWindow()
        {
            InitializeComponent();
        }
        // funkcja ktora umozliwa "ruch" okienkiem
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void zamykanie(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void minimalizacja(object sender, EventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void info(object sender, EventArgs e)
        {
            MessageBox.Show("Nazwa programu: Kalkulator \nAutorzy: Mariusz Bubrowski i Marek Dąbrowski");
        }
        private void obsluga(object sender, EventArgs e)
        {
            MessageBox.Show("W pierwszej kolejności wpisujemy liczby, następnie interesującą nas funkcje");
        }
        #endregion
        private void liczba_Click(object sender, RoutedEventArgs e)
        {
            if (CzyscOknoWyniku)
                Wynik.Text = (sender as Button).Content.ToString();
            else
                Wynik.Text += (sender as Button).Content.ToString();
            CzyscOknoWyniku = false;
        }
        private void działanie_Click(object sender, RoutedEventArgs e)
        {
            obliczenia.działanie = (sender as Button).Content.ToString()[0];
            CzyscOknoWyniku = true; //czyścimy pasek tekstowy
            czyWpisac = false;
        }
        private void silnia_Click(object sender, RoutedEventArgs e)
        {
            obliczenia.działanie = '!';
            czyWpisac = true;
            obliczenia.operand1 = obliczenia.licz();
            Wynik.Text = obliczenia.operand1.ToString(); //wyświetlamy wynik
            CzyscOknoWyniku = true;
        }
        private void systemBinarny_Click(object sender, RoutedEventArgs e)
        {
            Wynik.Text = Convert.ToString((int)obliczenia.operand1, 2);
        }
        private void przecinek_Click(object sender, RoutedEventArgs e)
        {
            if (CzyscOknoWyniku)
                Wynik.Text = "0,";
            else
                Wynik.Text += ",";
            CzyscOknoWyniku = false;
        }
        private void czyszczenie_Click(object sender, RoutedEventArgs e)
        {
            //obliczenia.operand1 = obliczenia.operand2 = 0;
            //obliczenia.działanie = ' ';
            Wynik.Text = "";
            //CzyscOknoWyniku = false;
            //czyWpisac = true;
        }
        private void wynik_Click(object sender, RoutedEventArgs e)
        {
            czyWpisac = true;
            obliczenia.operand1 = obliczenia.licz();
            Wynik.Text = obliczenia.operand1.ToString();//wyświetlamy wynik
            CzyscOknoWyniku = true;
        }
        private void Wynik_TextChanged(object sender, TextChangedEventArgs e)
        {   
            try
            {
                if (czyWpisac)
                    obliczenia.operand1 = double.Parse(Wynik.Text);
                else
                    obliczenia.operand2 = double.Parse(Wynik.Text);
            }
            catch (FormatException wyjątek) //jeśli wprowadzono błędnie liczbę wykonuje poniższy kod
            {
                if (Wynik.Text != "")
                    MessageBox.Show("Nie wpisano prawidłowo liczby", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);//komunikat o błędzie, ale tylko, jeśli pole nie jest puste
            }
        }
        #region funkcje okresowe
        private void sin_Click(object sender, RoutedEventArgs e)
        {
            obliczenia.działanie = 's';
            czyWpisac = true;
            obliczenia.operand1 = obliczenia.licz();
            Wynik.Text = obliczenia.operand1.ToString();//wyświetlamy wynik
            CzyscOknoWyniku = true;

        }
        private void cos_Click(object sender, RoutedEventArgs e)
        {
            obliczenia.działanie = 'c';
            czyWpisac = true;
            obliczenia.operand1 = obliczenia.licz();
            Wynik.Text = obliczenia.operand1.ToString();//wyświetlamy wynik
            CzyscOknoWyniku = true;

        }
        private void tan_Click(object sender, RoutedEventArgs e)
        {
            czyWpisac = true;
            if (Wynik.Text.Length > 0)
            {
                if ((double.Parse(Wynik.Text)) % 90 != 0) //dla tg dziedzina nie zawiera k*90 stopni, dla k=0,1..
                    Wynik.Text = Math.Tan(double.Parse(Wynik.Text) * Math.PI / 180).ToString(); //Zakladamy, że argument będzie podany w radianach.
                else
                    Wynik.Text = "Error! Incorrect value!";
            }
            CzyscOknoWyniku = true;
        }
        private void ctan_Click(object sender, RoutedEventArgs e)
        {
            czyWpisac = true;
            if (Wynik.Text.Length > 0)
            {
                if ((double.Parse(Wynik.Text)) % 180 != 0) //dla ctg dziedzina nie zawiera k*180 stopni, dla k=0,1..
                    Wynik.Text = (1 / Math.Tan(double.Parse(Wynik.Text) * Math.PI / 180)).ToString();// bo ctg=1/tg
                else
                    Wynik.Text = "Error! Incorrect value!";
            }
            CzyscOknoWyniku = true;
        }
        #endregion

    }
}