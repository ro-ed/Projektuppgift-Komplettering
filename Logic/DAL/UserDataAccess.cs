using Logic.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static Logic.Services.StaticLists;

namespace Logic.DAL
{
    public class UserDataAccess
    {
        private const string path = @"User.json";

        /// <summary>
        /// https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-how-to
        /// </summary>
        /// <returns></returns>

        
        public List<User> GetUsers()
        {

            string jsonString = File.ReadAllText(userpath);
            if (jsonString == "")
            {
                return new List<User>();
            }
            List<User> users = JsonSerializer.Deserialize<List<User>>(jsonString);
            
            return users;
        }

        internal void Save(List<User> userss)
        {
            throw new NotImplementedException();
        }


        //internal void Save(List<User> tmpUsers)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
