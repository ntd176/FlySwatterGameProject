using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Project
{
    public sealed partial class Game : Page
    {
        private int currentScore = 0; // Điểm hiện tại trong trò chơi
        private int highScore = 0; // Điểm kỷ lục
        private bool isGameActive = true; // Trạng thái trò chơi

        public Game()
        {
            this.InitializeComponent();

            // Tạo một MediaPlayer mới
            MediaPlayer MediaGame = new MediaPlayer();

            // Đặt nguồn âm thanh (thay "Assets/your-sound-file.mp3" bằng đường dẫn đúng của file âm thanh)
            MediaGame.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Media/game-music-loop-7-145285.mp3"));

            // Kích hoạt chế độ lặp lại
            MediaGame.IsLoopingEnabled = true;

            MediaGame.Play();

            LoadHighScore(); // Tải điểm kỷ lục khi trang được khởi tạo
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            health.Text = "100";
            counter.Text = "0";
            Fly.counter = 0;
            currentScore = 0; // Khởi tạo điểm hiện tại
            isGameActive = true;
            AddFly();
        }

        private async void AddFly()
        {
            var randomSpawnTime = new Random();
            while (isGameActive)
            {
                await Task.Delay(randomSpawnTime.Next(500, 1000));
                rootCanvas.Children.Add(new Fly(rootCanvas, counter, health).Button);
                health.Text = (Convert.ToInt32(health.Text) - 10).ToString();
                currentScore = Fly.counter; // Cập nhật điểm hiện tại
                UpdateScoreTextBlocks();
                if (Convert.ToInt32(health.Text) <= 0)
                {
                    EndGame();
                    break;
                }
            }
        }

        private void LoadHighScore()
        {
            // Tải điểm kỷ lục từ local storage
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey("HighScore"))
            {
                highScore = (int)ApplicationData.Current.LocalSettings.Values["HighScore"];
            }
            UpdateScoreTextBlocks();
        }

        private void SaveHighScore()
        {
            // Lưu điểm kỷ lục vào local storage
            ApplicationData.Current.LocalSettings.Values["HighScore"] = highScore;
        }

        private void UpdateScoreTextBlocks()
        {
            // Cập nhật hiển thị điểm hiện tại và điểm kỷ lục
            CurrentScoreTextBlock.Text = $"Current Score: {currentScore}";
            HighScoreTextBlock.Text = $"High Score: {highScore}";
        }

        private async void EndGame()
        {
            isGameActive = false;

            if (currentScore > highScore)
            {
                highScore = currentScore;
                SaveHighScore();
            }
            UpdateScoreTextBlocks();

            var cd = new ContentDialog
            {
                Title = "GAME OVER",
                Content = new TextBlock
                {
                    Text = $"You Swatted: {Fly.counter} Flies 🪰🪰🪰",
                    FontSize = 32
                },
                CloseButtonText = "Exit",
                CloseButtonCommand = new RelayCommand(() => Frame.Navigate(typeof(Face)))
            };
            await cd.ShowAsync();
        }

        private void EndGameButton_Click(object sender, RoutedEventArgs e)
        {
            EndGame();
        }
    }
}
