using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Entities
{
    public class Errands
    {
        public string ErrandName { get; set; }
        public string ErrandStartDate { get; set; }
        public string ErrandEndDate { get; set; }
        public string ErrandStatus { get; set; }
        public bool Finished { get; set; }
        public Guid ErrandID { get; set; }
        //public Guid MechID { get; set; }

        public string ComponentsNeeded { get; set; }
        public string TypeOfVehicle { get; set; }
        public string TypOfCar { get; set; }
        public string ModelName { get; set; }
        public string RegistrationNumber { get; set; }
        public int Odometer { get; set; }
        public string RegistrationDate { get; set; }
        public string Propellant { get; set; }
        public int MaxLoad { get; set; }
        public string HasTowbar { get; set; }
        public int MaxNrPassengers { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }

        public int Amount { get; set; }
        public string Competence { get; set; }




    }
}
