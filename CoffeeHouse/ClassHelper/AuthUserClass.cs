using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeHouse.ClassHelper;

namespace CoffeeHouse.ClassHelper
{
    internal class AuthUserClass
    {
      public static DataBase.Emploee authEmploee { get; set; }
      public static DataBase.Guest authGuest { get; set; }
    }
}
