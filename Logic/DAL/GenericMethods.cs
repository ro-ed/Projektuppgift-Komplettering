using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static Logic.Services.StaticLists;
using Logic.Entities;
using Logic.Interfaces;
using Logic.Exceptions;

namespace Logic.DAL
{
    public partial class GenericClass : ILogic
    {
        public static void Overrite<T>(string path, List<T> list)
        {

            File.WriteAllText(path, JsonConvert.SerializeObject(list));
            string jsonFromFile;

            using (var reader = new StreamReader(path))
            {
                jsonFromFile = reader.ReadToEnd();
            }
            var readFromJson = JsonConvert.DeserializeObject<List<T>>(jsonFromFile);
            list = readFromJson;
        }










    }
}


