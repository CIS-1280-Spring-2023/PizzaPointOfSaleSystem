﻿using PizzaPointOfSaleSystem.Models;
using PizzaPointOfSaleSystem.Repos;
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

namespace PizzaPointOfSaleSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PizzaRepo pizzaRepo = new PizzaRepo();
        List<Pizza> pizzas;
        public MainWindow()
        {
            InitializeComponent();
            //Get pizzas and add to list box
            pizzas = pizzaRepo.GetAll();
            lbPizzas.ItemsSource = pizzas;       
        }

        private void btnAddPizza_Click(object sender, RoutedEventArgs e)
        {
            PizzaWindow pizzaWindow = new PizzaWindow();
            if(pizzaWindow.ShowDialog()==true)
            {
                //TODO: add the pizza
            }
        }
    }
}
