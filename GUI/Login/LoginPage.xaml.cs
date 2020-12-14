using GUI.Home;
using GUI.UserControls;
using Logic.Entities;
using Logic.Services;
using Microsoft.Windows.Themes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
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
using static Logic.Services.StaticLists;


namespace GUI.Login
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private const string _errorMsg = "Inloggningen misslyckades";

        private ILoginService _loginService;
        public LoginPage()
        {
            InitializeComponent();
           
            _loginService = new LoginService();
            ShowsNavigationUI = false;

            var fsMech = File.OpenWrite(mechpath);
            fsMech.Close();

            var fsErrand = File.OpenWrite(pathforErrand);
            fsErrand.Close();

            var fsStock = File.OpenWrite(stockpath);
            fsStock.Close();

            string jsonFromFileUser;
            var fsUser = File.OpenWrite(userpath);
            fsUser.Close();
            using (var reader = new StreamReader(userpath))
            {
                jsonFromFileUser = reader.ReadToEnd();
            }
            var readFromJsonUser = JsonConvert.DeserializeObject<List<User>>(jsonFromFileUser);
        }

        private void SignIn_Button(object sender, RoutedEventArgs e)
        {
            string username = this.tbUsername.Text;
            string password = this.pbPassword.Password;

            var userLogIn = _loginService.Login(username, password);
            

            if (userLogIn !=null)
            {
                if (userLogIn.IsAdmin)
                {
   
                    BosseHomePage bossesHemsida = new BosseHomePage();
                    this.NavigationService.Navigate(bossesHemsida);



                }
                

                else
                {
                    LoggedInUserService.LoggedInUser = userLogIn;
                    MekanikernasHemsida MekanikernasHemsida = new MekanikernasHemsida();
                    this.NavigationService.Navigate(MekanikernasHemsida);


                }
                
            }
            else
            {

                MessageBox.Show(_errorMsg);
                this.tbUsername.Clear();
                this.pbPassword.Clear();
            }

        }
        private void Close_Button(object sender, RoutedEventArgs e)
        {        
            Application.Current.Shutdown();
        }
        
        
        
    }
}
