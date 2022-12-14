using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FisticularRiskScore
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInPage : ContentPage
    {
        private Regex EmailRegex = new Regex(@"^[a-z,A-Z]{1,10}((-|.)\w+)*@\w+.\w[a-z,A-Z]{1,3}$");
        private const string userEmail = "admin@admin.com";
        private const string userPassword = "Qwe123!";

        public SignInPage()
        {
            InitializeComponent();
            passwordEntry.OnChangedText -= OnPasswordValidation;
            passwordEntry.OnChangedText += OnPasswordValidation;

            mailEntry.OnChangedText -= OnUserValidation;
            mailEntry.OnChangedText += OnUserValidation;
        }

        private async void OnSignUp(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        private async void OnSignIn(object sender, EventArgs e)
        {
            if (userEmail == mailEntry.Text && userPassword == passwordEntry.Text)
            {
                await Navigation.PushAsync(new DashboardPage());
            }
            else
            {
                await DisplayAlert("Attention", "Wrong Email or Password", "Ok");
            }
        }

        private void OnPasswordValidation(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(passwordEntry.Text) && passwordEntry.Text.Length >= 4)
            {
                passwordEntry.TextColor = Color.Black;
                labelPasswordError.Text = "";
                passwordEntry.IsChecked = true;
            }
            else
            {
                passwordEntry.TextColor = Color.Red;
                labelPasswordError.Text = "Invalid Password";
                passwordEntry.IsChecked = false;
            }

            CheckSignInButton();
        }

        private void OnUserValidation(object sender, TextChangedEventArgs e)
        {
            if (EmailRegex.IsMatch(mailEntry.Text) && !string.IsNullOrWhiteSpace(mailEntry.Text))
            {
                mailEntry.TextColor = Color.Black;
                labelMailError.Text = "";
                mailEntry.IsChecked = true;
            }
            else
            {
                mailEntry.TextColor = Color.Red;
                labelMailError.Text = "Invalid Email";
                mailEntry.IsChecked = false;
            }

            CheckSignInButton();
        }

        private void CheckSignInButton()
        {
            if (EmailRegex.IsMatch(mailEntry.Text) && !string.IsNullOrWhiteSpace(passwordEntry.Text))
            {
                buttonSignIn.TextColor = Color.White;
                buttonSignIn.IsEnabled = true;
            }
            else
            {
                buttonSignIn.TextColor = Color.FromHex("#990207");
                buttonSignIn.IsEnabled = false;
            }
        }
    }
}