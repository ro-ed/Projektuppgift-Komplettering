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
using Logic.Entities;
using Logic.Interfaces;
using Newtonsoft.Json;
using Projektuppgift.GUI.UserControls;
using System.IO;
using System.Linq;
using static Logic.Services.StaticLists;
using static Logic.Entities.Mechanic;
using static Logic.Entities.Errands;
using static GUI.UserControls.MechanicHome;
using static GUI.UserControls.UserControlNewErrand;

namespace GUI.UserControls
{
    /// <summary>
    /// Interaction logic for ErandMechanicDetail.xaml
    /// </summary>
    public partial class ErandMechanicDetail : UserControl
    {
        public static Errands _test;
        public static Mechanic _test2;
        
        public ErandMechanicDetail()
        {
            InitializeComponent();

            string jsonFromFile;
            using (var reader = new StreamReader(mechpath))
            {
                jsonFromFile = reader.ReadToEnd();
            }
            var readFromJson = JsonConvert.DeserializeObject<List<Mechanic>>(jsonFromFile);            
            DataContext = readFromJson;

            Errands errands1 = _selectedErrand;

            Mechanic mechanic = readFromJson.FirstOrDefault(x => x.FirstName == errands1.FirstName);
            Mechanic mechanic1 = readFromJson.FirstOrDefault(x => x.SurName == errands1.LastName);

            Guid currentMechID = mechanic.MechID;

            tboldFirst.Text = mechanic.FirstName;
            tboldSur.Text = mechanic1.SurName;
            tboldBirth.Text = mechanic.DateOfBirth;
            tboldEmploy.Text = mechanic.DateOfEmployment;
            tboldEmployEnd.Text = mechanic.EndDate;
            tboldMechID.Text = currentMechID.ToString();
            tboldCFE.Text = mechanic.CanFixEngines;
            tboldCFT.Text = mechanic.CanFixTires;
            tboldCFB.Text = mechanic.CanFixBrakes;
            tboldCFWS.Text = mechanic.CanFixWindshields;
            tboldCFVB.Text = mechanic.CanFixVehicleBody;
            
        }

        private void EditGoBackButton_Click(object sender, RoutedEventArgs e)
        {
            MechanicViewer.Children.Clear();
            MechanicViewer.Children.Add(new UserControlNewErrand());

        }

        
    }
}
