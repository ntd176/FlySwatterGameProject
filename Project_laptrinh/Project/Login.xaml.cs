using System;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Project
{
    public sealed partial class Login : Page
    {
        // Đặt email và mật khẩu cần kiểm tra
        private const string ExpectedEmail = "Flygame";
        private const string ExpectedPassword = "Fetel@123";

        public Login()
        {
            this.InitializeComponent();
        }

        private void GotoFace(object sender, RoutedEventArgs e)
        {
            // Kiểm tra email và mật khẩu khi nhấn nút LOGIN
            string enteredEmail = EmailTextBox.Text.Trim();
            string enteredPassword = PasswordBox.Password.Trim();

            if (enteredEmail == ExpectedEmail && enteredPassword == ExpectedPassword)
            {
                Frame.Navigate(typeof(Face));
                PlaySound();
            }
            else
            {
                // Hiển thị thông báo yêu cầu nhập lại
                ShowInvalidCredentialsDialog();
            }
        }

        private async void ShowInvalidCredentialsDialog()
        {
            var dialog = new ContentDialog
            {
                Title = "Invalid Credentials",
                Content = "Email hoặc mật khẩu bạn nhập không đúng. Vui lòng thử lại.",
                CloseButtonText = "OK"
            };

            await dialog.ShowAsync();
        }

        private void PlaySound()
        {
            // Chơi âm thanh khi nhấn nút LOGIN thành công
            MediaPlayer mediaPlayer = new MediaPlayer();
            mediaPlayer.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Media/click_effect-86995.mp3"));
            mediaPlayer.Play();
        }
    }
}
