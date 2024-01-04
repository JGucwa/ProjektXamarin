using ProjektXamarin.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjektXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountEdit : ContentPage
    {
        public AccountEdit()
        {
            InitializeComponent();

            UserContent.BindingContext = new Database().GetUsers()[App.Instance.UserId];
        }
        private void Change(object sender, EventArgs e)
        {
            User userTMP = new Database().GetUsers()[App.Instance.UserId];

            userTMP.Firstname = firstname.Text;
            userTMP.Surname = surname.Text;
            userTMP.Email = email.Text;
            userTMP.Number = int.Parse(number.Text);
            userTMP.Birth_Date = birthdate.Date;
            userTMP.Address = address.Text;
            userTMP.Actual_position = Actual_Position.Text;
            userTMP.Position_description = Position_Description.Text;

            new Database().EditUser(userTMP);

            DisplayAlert("Edycja", "Pomyślnie zmieniono dane konta", "OK");

            UserContent.BindingContext = new Database().GetUsers()[App.Instance.UserId];
        }
        private void Logout(object sender, EventArgs e)
        {
            App.Instance.UserId = -1;

            DisplayAlert("Wylogowano", "Pomyślnie wylogowano z konta", "OK");
            Navigation.PushAsync(new FlyoutPage1());
        }

    }
}