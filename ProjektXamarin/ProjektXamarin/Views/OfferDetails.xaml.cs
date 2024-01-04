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
    public partial class OfferDetails : ContentPage
    {
        Offer offer;
        public OfferDetails(Offer offer)
        {
            InitializeComponent();

            Container.BindingContext = offer;

            ShowLists(offer);

            this.offer = offer;
        }
        private void ShowLists(Offer offer)
        {
            StackLayout req = new StackLayout();
            for (int i = 0; i < offer.Requirements.Count; i++)
            {
                StackLayout sp = new StackLayout();
                sp.Margin = new Thickness(0, 20, 0, 0);

                Label textBlock = new Label()
                {
                    Text = "> " + offer.Requirements[i],
                    FontSize = 15,
                };

                sp.Children.Add(textBlock);
                req.Children.Add(sp);
            }
            Requierments.Content = req;
            StackLayout dut = new StackLayout();
            for (int i = 0; i < offer.Duties.Count; i++)
            {
                StackLayout sp = new StackLayout();
                sp.Margin = new Thickness(0, 20, 0, 0);

                Label textBlock = new Label()
                {
                    Text = "> " + offer.Duties[i],
                    FontSize = 15,
                };

                sp.Children.Add(textBlock);
                dut.Children.Add(sp);
            }
            Duties.Content = dut;
            StackLayout ben = new StackLayout();
            for (int i = 0; i < offer.Benefits.Count; i++)
            {
                StackLayout sp = new StackLayout();
                sp.Margin = new Thickness(0, 20, 0, 0);

                Label textBlock = new Label()
                {
                    Text = "> " + offer.Benefits[i],
                    FontSize = 15,
                };

                sp.Children.Add(textBlock);
                ben.Children.Add(sp);
            }
            Benefits.Content = ben;
        }
        private void Apply(object s,EventArgs e)
        {
            if(App.Instance.UserId != -1)
            {
                bool IsCorrect = true;
                for(int i = 0; i < offer.Applications.Count;i++)
                {
                    if(App.Instance.UserId == offer.Applications[i]) IsCorrect = false;
                }
                if(IsCorrect)
                {
                    offer.Applications.Add(App.Instance.UserId);

                    DisplayAlert("Potwierdzenie", "Zaaplikowano pomyslnie", "OK");
                }
                else
                {
                    DisplayAlert("BŁĄD", "Już zaaplikowałeś na tę ofertę", "OK");
                }
            }
            else
            {
                DisplayAlert("BŁĄD", "Najpierw się zaloguj", "OK");
            }
        }
    }
}