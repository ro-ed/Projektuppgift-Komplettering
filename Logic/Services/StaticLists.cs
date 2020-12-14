using System;
using System.Collections.Generic;
using System.Text;
using Logic.Entities;

namespace Logic.Services
{
    public class StaticLists
    {
        public static List<Errands> errands = new List<Errands>();

        public const string pathforErrand = @"Errand.json";

        public static List<User> usersList = new List<User>();

        public const string userpath = @"User.json";

        public static List<Mechanic> mechanics = new List<Mechanic>();

        public const string mechpath = @"Mechanic.json";

        public static object stockobject = new object();

        public const string stockpath = @"Stock.json";

    }
    //test
}
