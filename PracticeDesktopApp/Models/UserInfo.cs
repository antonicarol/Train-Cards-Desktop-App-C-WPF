using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDesktopApp.Models
{
    class UserInfo
    {
        public static int Id = 0;
        public static String Name = "";
        public static String Email = "";
        public static int FirstTime = 0;
        public static String Gender = "";
        public static String BirthDate = "";

        public static List<Game> Games = new List<Game>();

        public static float Currency { get; internal set; }
    }
}
