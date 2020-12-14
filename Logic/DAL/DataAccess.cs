//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Text;
//using System.Text.Json;

//namespace Logic.DAL
//{
//    public class DataAccess<T> where T : Entities
//    {
//        public void Save(List<T> list)
//        {
//            string fileName = typeof(T).ToString() + ".json";
//            string jsonString = JsonSerializer.Serialize(list);

//            File.WriteAllText(fileName, jsonString);
//        }

//        public List<T> Load()
//        {
//            string fileName = typeof(T).ToString() + "json";

//            if (File.Exists(fileName))
//            {
//                string jsonString = File.ReadAllText(fileName);
//                List<T> list = JsonSerializer.Deserialize<List<T>>(jsonString);

//                return list;
//            }
//            return new List<T>();



//        }

//    }
//}
