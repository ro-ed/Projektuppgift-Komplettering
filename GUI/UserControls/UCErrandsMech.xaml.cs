using Logic.Entities;
using Logic.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using static Logic.DAL.GenericClass;

namespace GUI.UserControls
{
    /// <summary>
    /// Interaction logic for UCErrandsMech.xaml
    /// </summary>
    public partial class UCErrandsMech : UserControl
    {
        public static Errands _selectedErrand;
        public UCErrandsMech()
        {
            InitializeComponent();

            string jsonFromFile;
            using (var reader = new StreamReader(pathforErrand))
            {
                jsonFromFile = reader.ReadToEnd();
            }
            var readFromJson = JsonConvert.DeserializeObject<List<Errands>>(jsonFromFile);
            errands = readFromJson;

            string jsonFromFile2;
            using (var reader = new StreamReader(mechpath))
            {
                jsonFromFile2 = reader.ReadToEnd();
            }

            var readFromJson2 = JsonConvert.DeserializeObject<List<Mechanic>>(jsonFromFile2);
            mechanics = readFromJson2;

            Mechanic mechanic = readFromJson2.FirstOrDefault(x => x.UserID == LoggedInUserService.LoggedInUser.UserID);

            List<Errands> errandsOfMech = new List<Errands>();

            foreach (var id in mechanic.ErrandIDArray)
            {

                Errands errand = readFromJson.FirstOrDefault(e => e.ErrandID == id);

                if (errand != null)
                {
                    errandsOfMech.Add(errand);
                }
            }



            DataContext = errandsOfMech;
            MechListView.ItemsSource = errandsOfMech;
        }


        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }

        private void ChangeStatus_Click(object sender, RoutedEventArgs e)
        {
            Errands errand = MechListView.SelectedItem as Errands;

            errand.Finished = true;

            errand.ErrandStatus = errand.Finished ? "Finished" : "OnGoing";


            Overrite<Errands>(pathforErrand, errands);
            MessageBox.Show("Errand Finished!");

            ErrandMechanic.Children.Clear();
            ErrandMechanic.Children.Add(new UCErrandsMech());



        }
    }
}



