using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

namespace Project
{
    class Fly
    {
        public static int counter = 0;
        public static int id = 0;
        public int Id { get; set; }
        public Button Button;
        public Fly(Canvas canvas, TextBlock textBlock, TextBlock health)
        {
            Id = id;
            id++;
            Button = new Button
            {
                Tag = Id.ToString(),
                Content = "🪰",
                FontSize = 64,
                Background = null,
                Margin = new Thickness(new Random().Next(1000), new Random().Next(1000), new Random().Next(1000), new Random().Next(1000)),
                CommandParameter = Id.ToString(),
                Command = new RelayCommand(() =>
                {
                    foreach (var item in canvas.Children)
                    {
                        if ((item as Button).Tag.ToString() == Id.ToString())
                        {
                            canvas.Children.Remove(item);
                        }
                    }
                    counter++;
                    textBlock.Text = counter.ToString();
                    health.Text = (Convert.ToInt32(health.Text) + 10).ToString();
                })
            };
        }
    }
}
