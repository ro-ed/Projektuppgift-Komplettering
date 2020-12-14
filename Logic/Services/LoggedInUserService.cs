using Logic.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Services
{
    public static class LoggedInUserService
    {
        public static User LoggedInUser { get; set; }
        public static Mechanic LoggedInMechanic { get; set; }
    }
}
