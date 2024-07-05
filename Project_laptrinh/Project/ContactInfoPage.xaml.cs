using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Project
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ContactInfoPage : Page
    {
        public ContactInfoPage()
        {
            this.InitializeComponent();
        }

        // Override the OnNavigatedTo method to handle the navigation
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // Check if the parameter passed is of type Information
            if (e.Parameter is AddFriendPage.Information info)
            {
                // Display the information
                InforTextBlock.Text = $"Name: {info.Name}\nEmail: {info.Email}\nPhone: {info.PhoneNumber}";
            }
        }
    }
}
