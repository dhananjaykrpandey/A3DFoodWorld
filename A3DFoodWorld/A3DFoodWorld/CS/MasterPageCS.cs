using A3DFoodWorld.CS;
using A3DFoodWorld.Models;
using A3DFoodWorld.Views;
using System.Collections.Generic;
using Xamarin.Forms;

namespace A3DFoodWorld
{
    public class MasterPageCS : ContentPage
    {
        public ListView ListView { get { return listView; } }

        ListView listView;

        public MasterPageCS()
        {
            var masterPageItems = new List<HomeMenuItem>();
            masterPageItems.Add(new HomeMenuItem
            {
                Title = "Home",
                IconSource = "contacts.png",
                TargetType = typeof(HomeCS)
            });
            masterPageItems.Add(new HomeMenuItem
            {
                Title = "Food Menu",
                IconSource = "todo.png",
                TargetType = typeof(MenuCS)
            });
            masterPageItems.Add(new HomeMenuItem
            {
                Title = "Cart",
                IconSource = "reminders.png",
                TargetType = typeof(CartCS)
            });
            masterPageItems.Add(new HomeMenuItem
            {
                Title = "Account",
                IconSource = "reminders.png",
                TargetType = typeof(AccountCS)
            });
            masterPageItems.Add(new HomeMenuItem
            {
                Title = "Forget Password",
                IconSource = "reminders.png",
                TargetType = typeof(ForgetPasswordCS)
            });
       
            listView = new ListView
            {
                ItemsSource = masterPageItems,
                ItemTemplate = new DataTemplate(() =>
                {
                    var grid = new Grid { Padding = new Thickness(5, 10) };
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(30) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

                    var image = new Image();
                    image.SetBinding(Image.SourceProperty, "IconSource");
                    var label = new Label { VerticalOptions = LayoutOptions.FillAndExpand };
                    label.SetBinding(Label.TextProperty, "Title");

                    grid.Children.Add(image);
                    grid.Children.Add(label, 1, 0);

                    return new ViewCell { View = grid };
                }),
                SeparatorVisibility = SeparatorVisibility.None
            };

            IconImageSource = "hamburger.png";
            Title = "Personal Organiser";
            Padding = new Thickness(0, 40, 0, 0);
            Content = new StackLayout
            {
                Children = { listView }
            };
        }
    }
}
