using Logic.DAL;
using Logic.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static Logic.Services.StaticLists;

namespace Logic.Services
{
    public class LoginService : ILoginService
    {
        private UserDataAccess _db;

        public LoginService()
        {

            _db = new UserDataAccess();
        }

        public User Login(string username, string password)
        {

            List<User> users = _db.GetUsers();

            if(users.Count==0)
            {
                List<User> Userss = new List<User>
                {
                    new User
                    {
                    IsAdmin=true
                    , Password = "Meckarn123"
                    , Username = "Bosse"
                    }

                };

                //_db.Save(Userss);

                usersList.AddRange(Userss);
                
                var jsonToWrite = JsonConvert.SerializeObject(usersList, Formatting.Indented);
                var fs = File.OpenWrite(userpath);
                using (var writer = new StreamWriter(fs))
                {
                     writer.Write(jsonToWrite);

                }


                users = Userss;
            }


            return users.FirstOrDefault(user => user.Username.Equals(username) && user.Password.Equals(password));
            //return users.Exist(user => user.Username.Equals(username) && user.Password.Equals(password));
        }
    }
}
