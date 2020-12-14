using static Logic.DAL.GenericClass;
using Logic.Entities;
using Logic.Interfaces;
using Newtonsoft.Json;
using Projektuppgift.GUI.UserControls;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using static Logic.Services.StaticLists;


namespace GUI.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlMechanicHome.xaml
    /// </summary>
    public partial class MechanicHome : UserControl, ILogic
    {
        //public ObservableCollection<Mechanic> listToRead = new ObservableCollection<Mechanic>();

        public static Mechanic _selectedMechanic;
        public MechanicHome()
        {
            InitializeComponent();
            //Läser från JSON.
            string jsonFromFile;
            using (var reader = new StreamReader(mechpath))
            {
                jsonFromFile = reader.ReadToEnd();
            }
            var readFromJson = JsonConvert.DeserializeObject<List<Mechanic>>(jsonFromFile);
            mechanics = readFromJson;
            //// Lägger till i listan.
            //mechanics.AddRange(readFromJson);

            //var orderList = mechanics.OrderBy(x => x.FirstName).ToList();
            //DataContext = orderList;
            //lv_data.ItemsSource = orderList;

            if (mechanics != null)
            {
                var orderList = mechanics.OrderBy(x => x.FirstName).ToList();
                DataContext = orderList;
                lv_data.ItemsSource = orderList;
            }

            
        }

        private void ChangeToAdd_Click(object sender, RoutedEventArgs e)
        {                   
                MechanicView.Children.Clear();
                MechanicView.Children.Add(new AddMechanic());        
        }

        private void DeleteMech_Click(object sender, RoutedEventArgs e)
        {
            Mechanic selectedMechanic = lv_data.SelectedItem as Mechanic;
            if (selectedMechanic != null)
            {
                if (MessageBox.Show("Sure ??", "DELETE", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                {
                    if (selectedMechanic != null)
                    {
                        mechanics.Remove(selectedMechanic);
                    }
                    Overrite<Mechanic>(mechpath, mechanics);
                    MechanicView.Children.Clear();
                    MechanicView.Children.Add(new MechanicHome());

                }
            }
        }
        private void ChangeToEdit_Click(object sender, RoutedEventArgs e)
        {
            Mechanic selectedMechanic = lv_data.SelectedItem as Mechanic;
            _selectedMechanic = selectedMechanic;
            if (selectedMechanic != null)
            {
                MechanicView.Children.Clear();
                var child = new EditMechanic();
                child.DataContext = selectedMechanic;
                MechanicView.Children.Add(child);
            }

        }

        private void lv_data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Mechanic m = (Mechanic)lv_data.SelectedItem;
            
            
        }

       


    }
}
