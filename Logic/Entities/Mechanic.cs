using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Entities
{

    public class Mechanic
    {



        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string DateOfBirth { get; set; }
        public string DateOfEmployment { get; set; }
        public string EndDate { get; set; }
        //public string Id { get; set; } = Guid.NewGuid().ToString();
        public Guid MechID { get; set; }
        public Guid? UserID { get; set; }
        public string CanFixEngines { get; set; }
        public string CanFixTires { get; set; }
        public string CanFixBrakes { get; set; }
        public string CanFixWindshields { get; set; }
        public string CanFixVehicleBody { get; set; }
        public Guid[] ErrandIDArray { get; set; }
        public Guid ErrandIDMech { get; set; }
        public int ActiveErrands { get; set; }
        public int ErrandAmount { get; set; }




        public bool? HasErrands
        {
            get
            {
                try
                {
                   return !(ErrandIDArray[0].Equals(Guid.Empty) && ErrandIDArray[1].Equals(Guid.Empty));

                }
                catch (Exception)
                {

                }
                return false;
                
            }
           
        }
    }
}






