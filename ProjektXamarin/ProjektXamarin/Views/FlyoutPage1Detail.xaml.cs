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
    public partial class FlyoutPage1Detail : ContentPage
    {
        List<Offer> offerList = new List<Offer>();
        public FlyoutPage1Detail()
        {
            InitializeComponent();           

            Offertspage.ItemsSource = new Database().GetOffers();

        }
        public async void OpenDetails(object sender, ItemTappedEventArgs e)
        {
            Offer offerTMP = Offertspage.SelectedItem as Offer;
            await Navigation.PushAsync(new OfferDetails(offerTMP));
        }
        public void Search(object sender,EventArgs e)
        {
            List<Offer> tmp = new List<Offer>();

            string text = Keyword.Text;
            
            for (int i = 0; i < new Database().GetOffers().Count; i++)
            {
                if (new Database().GetOffers()[i].Title.ToLower().Contains(text.ToLower()))
                {
                    if(Category.SelectedIndex > 0)
                    {
                        if(tmp[i].Category == Category.SelectedIndex)
                        {
                            tmp.Add(new Database().GetOffers()[i]);
                        }
                    }
                    else
                    {
                        tmp.Add(new Database().GetOffers()[i]);
                    }
                }
            }        
            Offertspage.ItemsSource = tmp;
        }
    }
}