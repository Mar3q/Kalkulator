using System;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    enum Działanie
    {
        brak = 0,
        dodawanie,
        odejmowanie,
        mnozenie,
        dzielenie,
        wynik
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
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
        private Działanie OstatnioWybraneDzialanie = Działanie.brak;

        private void liczba_Click(object oSender, RoutedEventArgs eRoutedEventArgs)
        {
            if (Działanie.wynik == OstatnioWybraneDzialanie)
            {
                Wynik.Text = string.Empty;
                OstatnioWybraneDzialanie = Działanie.brak;
            }
            Button oButton = (Button)oSender;
            Wynik.Text += oButton.Content;
        }

        private void przecinek_Click(object oSender, RoutedEventArgs eRoutedEventArgs)
        {
            if (Działanie.wynik == OstatnioWybraneDzialanie)
            {
                Wynik.Text = string.Empty;
                OstatnioWybraneDzialanie = Działanie.brak;
            }
            if ((Wynik.Text.Contains(',')) ||
                (0 == Wynik.Text.Length))
            {
                return;
            }
            Wynik.Text += ",";
        }

        private void czyszczenie_Click(object oSender, RoutedEventArgs eRoutedEventArgs)
        {
            Wynik.Text = string.Empty;
            Pamiec.Text = string.Empty;
            Operacja.Text = string.Empty;
            OstatnioWybraneDzialanie = Działanie.brak;
        }

        private void działanie_Click(object oSender, RoutedEventArgs eRoutedEventArgs)
        {

            if ((Działanie.brak != OstatnioWybraneDzialanie) || (Działanie.wynik != OstatnioWybraneDzialanie))
            {
                wynik_Click(this, eRoutedEventArgs);
            }
            Button oButton = (Button)oSender;
            switch (oButton.Content.ToString())
            {
                case "+":
                    OstatnioWybraneDzialanie = Działanie.dodawanie;
                    break;
                case "-":
                    OstatnioWybraneDzialanie = Działanie.odejmowanie;
                    break;
                case "*":
                    OstatnioWybraneDzialanie = Działanie.mnozenie;
                    break;
                case "/":
                    OstatnioWybraneDzialanie = Działanie.dzielenie;
                    break;
                default:
                    MessageBox.Show("Nieznana operacja!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
            }
            Pamiec.Text = Wynik.Text;
            Operacja.Text = oButton.Content.ToString();
            Wynik.Text = string.Empty;
        }

        private void wynik_Click(object oSender, RoutedEventArgs eRoutedEventArgs)
        {
            // Nie wykonywano operacji, nie można wyliczyć wyniku
            if ((Działanie.wynik == OstatnioWybraneDzialanie) ||
                (Działanie.brak == OstatnioWybraneDzialanie))
            {
                return;
            }
            if (string.IsNullOrEmpty(Wynik.Text))
            {
                Wynik.Text = "0";
            }
            switch (OstatnioWybraneDzialanie)
            {
                case Działanie.dodawanie:
                    Wynik.Text = (double.Parse(Pamiec.Text) +
                        double.Parse(Wynik.Text)).ToString();
                    break;
                case Działanie.odejmowanie:
                    Wynik.Text = (double.Parse(Pamiec.Text) -
                        double.Parse(Wynik.Text)).ToString();
                    break;
                case Działanie.mnozenie:
                    Wynik.Text = (double.Parse(Pamiec.Text) *
                        double.Parse(Wynik.Text)).ToString();
                    break;
                case Działanie.dzielenie:
                    Wynik.Text = (double.Parse(Pamiec.Text) /
                        double.Parse(Wynik.Text)).ToString();
                    break;
            }
            OstatnioWybraneDzialanie = Działanie.wynik;
            Operacja.Text = string.Empty;
            Pamiec.Text = string.Empty;
        }


    }
}
