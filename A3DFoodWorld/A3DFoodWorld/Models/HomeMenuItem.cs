using System;
using System.Collections.Generic;
using System.Text;

namespace A3DFoodWorld.Models
{
    public enum MenuItemType
    {
        Home,
        FoodMenu,
        Cart,
        Account,
        ForgetPassword,
        About,
        Logout
    }
    public class HomeMenuItem
    {
        public string Title { get; set; }

        public string IconSource { get; set; }

        public Type TargetType { get; set; }
    }
}
