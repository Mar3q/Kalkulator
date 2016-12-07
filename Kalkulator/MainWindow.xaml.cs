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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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

    }
}
