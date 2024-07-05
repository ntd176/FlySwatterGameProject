using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Project
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Face : Page
    {
        public Face()
        {
            this.InitializeComponent();
            
        }

        private void Button_Play(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Game));
            PlaySound();
        }

        private void Button_Member(object sender, RoutedEventArgs e)
        {
            PlaySound();
        }

        private void PlaySound()
        {
            MediaPlayer mediaPlayer = new MediaPlayer();
            mediaPlayer.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Media/click_effect-86995.mp3"));
            mediaPlayer.Play();
        }
    }
}
