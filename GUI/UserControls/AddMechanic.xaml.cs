using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Logic.Entities;
using System.IO;
using Newtonsoft.Json;
using static Logic.Services.StaticLists;
using GUI.UserControls;
using System.Text.RegularExpressions;
using Logic.Exceptions;

namespace Projektuppgift.GUI.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlAddMechanic.xaml
    /// </summary>
    public partial class AddMechanic : UserControl
    {
        private const string AddMessage = "You have added a mechanic!";
        public AddMechanic()
        {
            InitializeComponent();
 
            

        }

        public async void AddMechanicButton_Click(object sender, RoutedEventArgs e)
        {


            string someString = tbDateOfBirth.Text;
            DateTime DateOfBirth;
            DateTime.Now.ToString("yyyy-MM-dd");

            try
            {
                DateOfBirth = DateTime.Parse(someString);


            }
            catch (FormatException)
            {
                throw new DateTimeException();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }






            if (!Regex.IsMatch(tbDateOfEmployment.Text, @"^\d{4}-((0\d)|(1[012]))-(([012]\d)|3[01])$"))
            {
                MessageBox.Show("Enter a valid date for Date of Employment. YYYY-MM-DD");
                return;
            }

            if (!Regex.IsMatch(tbEmploymentEnds.Text, @"^\d{4}-((0\d)|(1[012]))-(([012]\d)|3[01])$"))
            {
                MessageBox.Show("Enter a valid date for Employment Ends. YYYY-MM-DD");
                return;
            }


            string firstName = this.tbFirstName.Text;
            string surName = this.tbSurName.Text;
            string dateOfBirth = this.tbDateOfBirth.Text;
            string dateOfEmployment = this.tbDateOfEmployment.Text;
            string employmentEnds = this.tbEmploymentEnds.Text;
            string EnginesAreChecked = ((bool)cbEnginesYes.IsChecked) ? "Yes" : "No";
            string TiresAreChecked = ((bool)cbTiresYes.IsChecked) ? "Yes" : "No";
            string BrakesAreChecked = ((bool)cbBrakesYes.IsChecked) ? "Yes" : "No";
            string WindshieldsAreChecked = ((bool)cbWindshieldsYes.IsChecked) ? "Yes" : "No";
            string VehicleBodyIsChecked = ((bool)cbVehicleBodyYes.IsChecked) ? "Yes" : "No";


            Mechanic mechanic = new Mechanic
            {
                FirstName = firstName,
                SurName = surName,
                DateOfBirth = dateOfBirth,
                DateOfEmployment = dateOfEmployment,
                EndDate = employmentEnds,
                MechID = Guid.NewGuid(),
                CanFixEngines = EnginesAreChecked,
                CanFixTires = TiresAreChecked,
                CanFixBrakes = BrakesAreChecked,
                CanFixWindshields = WindshieldsAreChecked,
                CanFixVehicleBody = VehicleBodyIsChecked,
                ErrandIDArray = new Guid[2],
                ActiveErrands = 0

            };
            //hej
            string jsonFromFile1;
            using (var reader = new StreamReader(mechpath))
            {
                jsonFromFile1 = reader.ReadToEnd();
            }
            List<Mechanic> mechanics1;
            if (jsonFromFile1 == "")
            {
                mechanics1 = new List<Mechanic>();
                mechanics = mechanics1;
            }
            else
            {
                mechanics1 = JsonConvert.DeserializeObject<List<Mechanic>>(jsonFromFile1);
            }


            if (mechanics != null)
            {


                //READ
                if (mechanics.Count >= 1)
                {
                    string jsonFromFile;
                    using (var reader = new StreamReader(mechpath))
                    {
                        jsonFromFile = reader.ReadToEnd();
                    }
                    var readFromJson = JsonConvert.DeserializeObject<List<Mechanic>>(jsonFromFile);
                    mechanics.Add(mechanic);
                    var jsonToWrite = JsonConvert.SerializeObject(mechanics, Formatting.Indented);
                    using (var writer = new StreamWriter(mechpath))
                    {
                        await writer.WriteAsync(jsonToWrite);

                    }
                }
                //ADD
                else
                {
                    mechanics.Add(mechanic);
                    var jsonToWrite = JsonConvert.SerializeObject(mechanics, Formatting.Indented);
                    var fs = File.OpenWrite(mechpath);
                    using (var writer = new StreamWriter(fs))
                    {
                        await writer.WriteAsync(jsonToWrite);

                    }
                }
                AddMechView.Children.Clear();
                AddMechView.Children.Add(new AddMechanic());

                MessageBox.Show(AddMessage);
            }
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            AddMechView.Children.Clear();
            AddMechView.Children.Add(new MechanicHome());

        }
    }
}     

  

