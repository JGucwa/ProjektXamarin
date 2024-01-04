using ProjektXamarin.Base;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjektXamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
	{
        int mode = -1;
        public RegisterPage(int mode)
        {
            InitializeComponent();

            this.mode = mode;

            if (mode == 0)
            {
                name.Text = "Email";
            }
            else
            {
                name.Text = "Nazwa Firmy";
            }
        }    

        async void Register(object sender, EventArgs e)
        {
            if (mode == 1)
            {
                var list = new Database().GetCompanies();

                if (!string.IsNullOrWhiteSpace(txtUsername.Text) && !string.IsNullOrWhiteSpace(pwdPassword.Text) &&
                    !string.IsNullOrWhiteSpace(pwdPassword2.Text) && pwdPassword2.Text == pwdPassword.Text &&
                    pwdPassword.Text.Length > 7)
                {
                    if (list.Any(company => txtUsername.Text == company.Name))
                    {
                        await DisplayAlert("Alert", "Konto istnieje", "OK");
                    }
                    else
                    {
                        new Database().AddCompany(new Company {Name = txtUsername.Text, Password = pwdPassword.Text });
                        await DisplayAlert("Alert", "Konto utworzone", "OK");

                        list = new Database().GetCompanies();

                        App.Instance.CompanyId = list[list.Count-1].Company_id;

                        await Navigation.PushAsync(new CompanyEdit());
                    }
                }
                else
                {
                    await DisplayAlert("Alert", "Uzupełnij poprawnie dane", "OK");
                }
            }
            else
            {
                var pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                var list = new Database().GetUsers();

                if (!string.IsNullOrWhiteSpace(txtUsername.Text) && !string.IsNullOrWhiteSpace(pwdPassword.Text) &&
                    !string.IsNullOrWhiteSpace(pwdPassword2.Text) && pwdPassword2.Text == pwdPassword.Text &&
                    pwdPassword.Text.Length > 7 && Regex.IsMatch(txtUsername.Text, pattern))
                {
                    if (list.Any(user => txtUsername.Text == user.Email && pwdPassword.Text == user.Password))
                    {
                        await DisplayAlert("Alert", "Konto istnieje", "OK");
                    }
                    else
                    {
                        new Database().AddUser(new User { Email = txtUsername.Text, Password = pwdPassword.Text });
                        await DisplayAlert("Alert", "Konto utworzone", "OK");

                        list = new Database().GetUsers();

                        App.Instance.UserId = list[list.Count - 1].User_id;

                        await Navigation.PushAsync(new AccountEdit());
                    }
                }
                else
                {
                    await DisplayAlert("Alert", "Uzupełnij poprawnie dane", "OK");
                }
            }
        }
    }
}