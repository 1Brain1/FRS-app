using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FisticularRiskScore
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInPage : ContentPage
    {
        private Regex EmailRegex = new Regex(@"^[a-z,A-Z]{1,10}((-|.)\w+)*@\w+.\w[a-z,A-Z]{1,3}$");

        public SignInPage()
        {
            InitializeComponent();
        }

        private async void OnSignUp(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        private void OnPasswordValidation(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(passwordEntry.Text))
            {
                passwordEntry.TextColor = Color.Default;
                labelPasswordError.Text = "";
            }
            else
            {
                passwordEntry.TextColor = Color.Red;
                labelPasswordError.Text = "Invalid Password";
            }

            CheckSignInButton();
        }

        private void OnUserValidation(object sender, TextChangedEventArgs e)
        {
            if (EmailRegex.IsMatch(mailEntry.Text) && !string.IsNullOrWhiteSpace(mailEntry.Text))
            {
                mailEntry.TextColor = Color.Default;
                labelMailError.Text = "";
            }
            else
            {
                mailEntry.TextColor = Color.Red;
                labelMailError.Text = "Invalid Email";
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