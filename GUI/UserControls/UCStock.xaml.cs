using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Newtonsoft.Json;
using static Logic.Services.StaticLists;
using Logic.Entities;

namespace GUI.UserControls
{
    /// <summary>
    /// Interaction logic for UCStock.xaml
    /// </summary>
    public partial class UCStock : UserControl
    {
        private const string AddStockMessage = "You have added items!"; 
        public int _selectedIndex = 0;
        public UCStock()
        {
            InitializeComponent();

            //AddStockManually();

            // Läser från JSON.
            string jsonFromFile;
            using (var reader = new StreamReader(stockpath))
            {
                jsonFromFile = reader.ReadToEnd();
            }
            var stockread = JsonConvert.DeserializeObject<Stock>(jsonFromFile);
           
            DataContext = stockread;    
        }
        private void lv_stockdata_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

        }

        private void StockAdd_Click(object sender, RoutedEventArgs e)
        {
            string jsonFromFile;
            using (var reader = new StreamReader(stockpath))
            {
                jsonFromFile = reader.ReadToEnd();
            }
            Stock stock;
            if (jsonFromFile == "")
            {
                stock = new Stock();
                stockobject = stock;
            }
            else
            {
                stock = JsonConvert.DeserializeObject<Stock>(jsonFromFile);
            }

            if (tbAmount.Text == "" || tbAmount.Text == null)
            {
                MessageBox.Show("Du angav inget i antal komponenter.");
                return;
            }

            switch (_selectedIndex)
            {
                
                case 0:
                    stock.CarTires += int.Parse(tbAmount.Text);
                    break;
                case 1:
                    stock.CarBrakes += int.Parse(tbAmount.Text);
                    break;
                case 2:
                    stock.CarEngines += int.Parse(tbAmount.Text);
                    break;
                case 3:
                    stock.CarWindshields += int.Parse(tbAmount.Text);
                    break;
                case 4:
                    stock.CarVehicleBodies += int.Parse(tbAmount.Text);
                    break;
                case 5:
                    stock.MCTires += int.Parse(tbAmount.Text);
                    break;
                case 6:
                    stock.MCBrakes += int.Parse(tbAmount.Text);
                    break;
                case 7:
                    stock.MCEngines += int.Parse(tbAmount.Text);
                    break;
                case 8:
                    stock.MCWindshields += int.Parse(tbAmount.Text);
                    break;
                case 9:
                    stock.MCVehicleBodies += int.Parse(tbAmount.Text);
                    break;
                case 10:
                    stock.BusTires += int.Parse(tbAmount.Text);
                    break;
                case 11:
                    stock.BusBrakes += int.Parse(tbAmount.Text);
                    break;
                case 12:
                    stock.BusEngines += int.Parse(tbAmount.Text);
                    break;
                case 13:
                    stock.BusWindshields += int.Parse(tbAmount.Text);
                    break;
                case 14:
                    stock.BusVehicleBodies += int.Parse(tbAmount.Text);
                    break;
                case 15:
                    stock.TruckTires += int.Parse(tbAmount.Text);
                    break;
                case 16:
                    stock.TruckBrakes += int.Parse(tbAmount.Text);
                    break;
                case 17:
                    stock.TruckEngines += int.Parse(tbAmount.Text);
                    break;
                case 18:
                    stock.TruckWindshields += int.Parse(tbAmount.Text);
                    break;
                case 19:
                    stock.TruckVehicleBodies += int.Parse(tbAmount.Text);
                    break;

            }

            File.WriteAllText(stockpath, JsonConvert.SerializeObject(stock));

            MessageBox.Show(AddStockMessage);

            StockView.Children.Clear();
            StockView.Children.Add(new UCStock());

        }

        private void InvComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InvComboBox = sender as ComboBox;
            int selectedIndex = InvComboBox.SelectedIndex;
            _selectedIndex += selectedIndex;
        }
        
    }
}

