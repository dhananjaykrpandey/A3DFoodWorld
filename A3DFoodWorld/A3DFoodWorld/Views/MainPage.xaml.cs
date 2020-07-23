using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using System.Collections.Generic;
using A3DFoodWorld.Models;
using System.Threading.Tasks;

namespace A3DFoodWorld.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : Xamarin.Forms.MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();
            //On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            //On<Android>().SetBarSelectedItemColor(Color.Red);

            //NavigationPage.SetHasBackButton(this, false);
            //((NavigationPage)Xamarin.Forms.Application.Current.MainPage).BarBackgroundColor = Color.Black;
            //((NavigationPage)Xamarin.Forms.Application.Current.MainPage).BarTextColor = Color.OrangeRed;
            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Home, (NavigationPage)Detail);

            masterPage.listView.ItemSelected += OnItemSelected;

            if (Device.RuntimePlatform == Device.UWP)
            {
                MasterBehavior = MasterBehavior.Popover;
            }
        }
        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as HomeMenuItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterPage.listView.SelectedItem = null;
                IsPresented = false;
            }
        }
        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Home:
                        MenuPages.Add(id, new NavigationPage(new Home()) { Title="Home" } );
                        break;
                    case (int)MenuItemType.FoodMenu:
                        MenuPages.Add(id, new NavigationPage(new Menu()) { Title = "Food Menu" });
                        break;
                    case (int)MenuItemType.Cart:
                        MenuPages.Add(id, new NavigationPage(new Cart()) { Title = "Cart" });
                        break;
                    case (int)MenuItemType.Account:
                        MenuPages.Add(id, new NavigationPage(new Account()) { Title = "Account" });
                        break;
                    case (int)MenuItemType.ForgetPassword:
                        MenuPages.Add(id, new NavigationPage(new ForgetPassword()) { Title = "Forget Password" });
                        break;
                    case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()) { Title = "About Us" });
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}