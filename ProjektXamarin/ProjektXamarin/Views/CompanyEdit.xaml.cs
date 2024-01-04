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
	public partial class CompanyEdit : ContentPage
	{
		public CompanyEdit ()
		{
			InitializeComponent ();

            List<Offer> tmp = new List<Offer>();

            for(int i = 0; i < new Database().GetOffers().Count; i++)
            {
                if(new Database().GetOffers()[i].Company_Id == App.Instance.CompanyId)
                {
                    tmp.Add(new Database().GetOffers()[i]);
                }
            }
            Offertspage.ItemsSource = tmp;

            CompanyContent.BindingContext = new Database().GetCompanies()[App.Instance.CompanyId];
        }
        private void Change(object sender, EventArgs e)
        {
            Company companyTMP = new Database().GetCompanies()[App.Instance.CompanyId];

            companyTMP.Name = name.Text;
            companyTMP.Localization = localization.Text;
            companyTMP.Description = description.Text;

            new Database().EditCompany(companyTMP);

            DisplayAlert("Edycja", "Pomyślnie zmieniono dane konta", "OK");

            CompanyContent.BindingContext = new Database().GetCompanies()[App.Instance.CompanyId];
        }
        private void Logout(object sender, EventArgs e)
        {
            App.Instance.CompanyId = -1;

            DisplayAlert("Wylogowano", "Pomyślnie wylogowano z konta", "OK");
            Navigation.PushAsync(new FlyoutPage1());
        }
        private async void DeleteOffer(object  sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var offer = menuItem.CommandParameter as Offer;

            new Database().DeleteOffer(offer);

            await Navigation.PushAsync(new FlyoutPage1());
        }
        private async void ShowOffer(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var offer = menuItem.CommandParameter as Offer;

            await Navigation.PushAsync(new OfferDetails(offer));
        }
    }
}