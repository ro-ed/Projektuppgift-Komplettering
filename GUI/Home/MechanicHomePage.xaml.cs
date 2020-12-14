using GUI.UserControls;
using Logic.Entities;
using Newtonsoft.Json;
using Projektuppgift.GUI.UserControls;
using System;
using System.Collections.Generic;
using System.IO;
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
using static Logic.Services.StaticLists;


namespace GUI.Home
{
    /// <summary>
    /// Interaction logic for MekanikernasHemsida.xaml
    /// </summary>
    public partial class MekanikernasHemsida : Page
    {
        public MekanikernasHemsida()
        {
            InitializeComponent();

            ShowsNavigationUI = false;
            string jsonFromFile;
            using (var reader = new StreamReader(mechpath))
            {
                jsonFromFile = reader.ReadToEnd();
            }
            var readFromJson = JsonConvert.DeserializeObject<List<Mechanic>>(jsonFromFile);
        }

        private void SignOutButton_Click(object sender, RoutedEventArgs e)
        {
            Login.LoginPage loginPage = new Login.LoginPage();
            this.NavigationService.Navigate(loginPage);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {          
            Application.Current.Shutdown();
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);

            switch (index)
            {
                case 0:
                    MainViewGrid.Children.Clear();
                    MainViewGrid.Children.Add(new UCHomeMech());
                    break;
                case 1:
                    MainViewGrid.Children.Clear();
                    MainViewGrid.Children.Add(new UCErrandsMech());
                    break;
                case 2:
                    MainViewGrid.Children.Clear();
                    MainViewGrid.Children.Add(new UserControlCompetenceMech());
                    break;
                case 3:
                    Login.LoginPage loginPage = new Login.LoginPage();
                    this.NavigationService.Navigate(loginPage);
                    break;


                default:
                    break;
            }
        }
        private void MoveCursorMenu(int index)
        {
            TransitionContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (170 + (60 * index)), 0, 0);
        }

        private void CloseButton_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }             
    
}

