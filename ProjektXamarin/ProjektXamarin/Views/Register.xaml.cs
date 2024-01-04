using ProjektXamarin.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjektXamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Register : ContentPage
	{
		public Register ()
		{
			InitializeComponent ();

            if(App.Instance.UserId != -1)
            {
                Navigation.PushAsync(new AccountEdit());
            }
            if (App.Instance.CompanyId != -1)
            {
                Navigation.PushAsync(new CompanyEdit());
            }
        }

        private async void CompanyLogin(object s, EventArgs e)
        {
            List<Company> list = new Database().GetCompanies();

            if (!string.IsNullOrWhiteSpace(txtCompanyUsername.Text) && !string.IsNullOrWhiteSpace(pwdCompanyPassword.Text))
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (txtCompanyUsername.Text.ToLower() == list[i].Name.ToLower() && pwdCompanyPassword.Text == list[i].Password)
                    {
                        App.Instance.CompanyId = list[i].Company_id;

                        await Navigation.PushAsync(new FlyoutPage1());
                        await Navigation.PushAsync(new CompanyEdit());
                        break;
                    }
                }

                if (App.Instance.CompanyId == -1)
                {
                    await DisplayAlert("Error", "Konto nie istnieje", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "Uzupełnij dane", "OK");
            }
        }

        private void CompanyRegister(object s, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage(1));
        }

        private async void UserLogin(object s, EventArgs e)
        {
            List<User> list = new Database().GetUsers();

            if (!string.IsNullOrWhiteSpace(txtUserUsername.Text) && !string.IsNullOrWhiteSpace(pwdUserPassword.Text))
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (txtUserUsername.Text.ToLower() == list[i].Email && pwdUserPassword.Text.ToLower() == list[i].Password)
                    {
                        App.Instance.UserId = list[i].User_id;
                        await Navigation.PushAsync(new FlyoutPage1());
                        await Navigation.PushAsync(new AccountEdit());
                        break;
                    }
                }

                if (App.Instance.UserId == -1)
                {
                    await DisplayAlert("Error", "Konto nie istnieje", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "Uzupełnij dane", "OK");
            }
        }

        private void UserRegister(object s, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage(0));
        }
    }
}