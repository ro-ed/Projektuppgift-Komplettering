using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Entities
{
    public abstract class Vehicle
    {
        public string ModelName { get; set; }
        public string RegistrationNumber { get; set; }
        public int Odometer { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Propellant { get; set; }
       


    }
}
