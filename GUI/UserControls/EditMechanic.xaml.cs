using System.Windows.Controls;
using System.Data;
using System.IO;
using Newtonsoft.Json;
using static Logic.Services.StaticLists;
using Logic.Entities;
using System.Collections.Generic;
using static GUI.UserControls.MechanicHome;
using System;
using System.Windows;
using static Logic.DAL.GenericClass;
using Logic.Exceptions;
using System.Text.RegularExpressions;

namespace GUI.UserControls
{
    /// <summary>
    /// Interaction logic for EditMechanic.xaml
    /// </summary>
    public partial class EditMechanic : UserControl
    {
        private const string EditMessage = "You have edited a mechanic!";
        public EditMechanic()
        {
            InitializeComponent();
            //Läser från JSON.
            string jsonFromFile;
            using (var reader = new StreamReader(mechpath))
            {
                jsonFromFile = reader.ReadToEnd();
            }
            var readFromJson = JsonConvert.DeserializeObject<List<Mechanic>>(jsonFromFile);
            //// Lägger till i listan.
            //mechanics.AddRange(readFromJson);



        }

        private async void EditMechanicButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if(tbFirstName2.Text == null || tbFirstName2.Text == "")
            {
                MessageBox.Show("Ange namn.");
                return;
            }
            if (tbSurName2.Text == null || tbSurName2.Text == "")
            {
                MessageBox.Show("Ange efternamn.");
                return;
            }
            if (tbSurName2.Text == null || tbSurName2.Text == "")
            {
                MessageBox.Show("Ange efternamn.");
                return;
            }
            if (!Regex.IsMatch(tbDateOfBirth2.Text, @"^\d{4}-((0\d)|(1[012]))-(([012]\d)|3[01])$"))
            {
                MessageBox.Show("Ange gilltigt födelsedatum. YYYY-MM-DD");
                return;
            }

            if (!Regex.IsMatch(tbDateOfEmployment2.Text, @"^\d{4}-((0\d)|(1[012]))-(([012]\d)|3[01])$"))
            {
                MessageBox.Show("Ange gilltigt datum för ärende start. YYYY-MM-DD");
                return;
            }

            if (!Regex.IsMatch(tbEmploymentEnds2.Text, @"^\d{4}-((0\d)|(1[012]))-(([012]\d)|3[01])$"))
            {
                MessageBox.Show("Ange gilltigt datum för ärende slut. YYYY-MM-DD");
                return;
            }
            
            Mechanic selectedMechanic = _selectedMechanic;

            Guid CurrentMechID = selectedMechanic.MechID;

            Guid[] CurrentErrandIDArray = selectedMechanic.ErrandIDArray;

            int CurrentActiveErrands = selectedMechanic.ActiveErrands;

            var findIndexOfMechanic = mechanics.FindIndex(x => x.MechID == selectedMechanic.MechID);

            mechanics[findIndexOfMechanic] = selectedMechanic;

         
            mechanics.Remove(selectedMechanic);
            File.WriteAllText(mechpath, string.Empty);

            string firstName = this.tbFirstName2.Text;
            string surName = this.tbSurName2.Text;         
            string dateOfBirth = this.tbDateOfBirth2.Text;
            string dateOfEmployment = this.tbDateOfEmployment2.Text;            
            string employmentEnds = this.tbEmploymentEnds2.Text;           
            string EnginesAreChecked = ((bool)cbEnginesYes2.IsChecked) ? "Yes" : "No";
            string TiresAreChecked = ((bool)cbTiresYes2.IsChecked) ? "Yes" : "No";
            string BrakesAreChecked = ((bool)cbBrakesYes2.IsChecked) ? "Yes" : "No";
            string WindshieldsAreChecked = ((bool)cbWindshieldsYes2.IsChecked) ? "Yes" : "No";
            string VehicleBodyIsChecked = ((bool)cbVehicleBodyYes2.IsChecked) ? "Yes" : "No";




            Mechanic mechanic = new Mechanic
            {
                FirstName = firstName,
                SurName = surName,
                DateOfBirth = dateOfBirth,
                DateOfEmployment = dateOfEmployment,
                EndDate = employmentEnds,
                MechID = CurrentMechID,
                CanFixEngines = EnginesAreChecked,
                CanFixTires = TiresAreChecked,
                CanFixBrakes = BrakesAreChecked,
                CanFixWindshields = WindshieldsAreChecked,
                CanFixVehicleBody = VehicleBodyIsChecked,
                ErrandIDArray = CurrentErrandIDArray,
                ActiveErrands = CurrentActiveErrands
                
                
                

            };

          
                mechanics.Add(mechanic);
                var jsonToWrite = JsonConvert.SerializeObject(mechanics, Formatting.Indented);
                var fs = File.OpenWrite(mechpath);
                using (var writer = new StreamWriter(fs))
                {
                   await writer.WriteAsync(jsonToWrite);

                }

            
            EditMechanicView.Children.Clear();
            EditMechanicView.Children.Add(new MechanicHome());

            MessageBox.Show(EditMessage);
        }

        private void EditGoBackButton_Click(object sender, RoutedEventArgs e)
        {
            EditMechanicView.Children.Clear();
            EditMechanicView.Children.Add(new MechanicHome());
        }

       
    }
}
