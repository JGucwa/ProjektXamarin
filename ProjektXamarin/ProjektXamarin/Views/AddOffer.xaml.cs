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
	public partial class AddOffer : ContentPage
	{
        List<string> ReqList = new List<string>();
        List<Entry> ReqListTB = new List<Entry>();
        List<string> DutList = new List<string>();
        List<Entry> DutListTB = new List<Entry>();
        List<string> BenList = new List<string>();
        List<Entry> BenListTB = new List<Entry>();

        public AddOffer()
        {
            if(App.Instance.CompanyId != -1)
            {
                InitializeComponent();


                ReqListTB.Add(req0);
                DutListTB.Add(dut0);
                BenListTB.Add(ben0);
            }
            else
            {
                DisplayAlert("ERROR", "Zaloguj się jako firma", "OK");
                Navigation.PushAsync(new FlyoutPage1());
            }
            
        }

        public void RequirmentAdd(object sender, EventArgs e)
        {
            Entry reqtmp = new Entry
            {
                Placeholder = "Wymaganie",
                FontSize = 18,
                WidthRequest = 300,
                HeightRequest = 40,
                Margin = new Thickness(0, 5, 0, 0),
            };

            ReqListTB.Add(reqtmp);
            requirments.Children.Add(reqtmp);
            requirments.Children.Remove(req0);
            requirments.Children.Add(req0);
        }

        public void DutiesAdd(object sender, EventArgs e)
        {
            Entry duttmp = new Entry
            {
                Placeholder = "Obowiazek",
                FontSize = 18,
                WidthRequest = 300,
                HeightRequest = 40,
                Margin = new Thickness(0, 5, 0, 0),
            };

            DutListTB.Add(duttmp);
            duties.Children.Add(duttmp);
            duties.Children.Remove(dut0);
            duties.Children.Add(dut0);
        }

        public void BenefitsAdd(object sender, EventArgs e)
        {
            Entry bentmp = new Entry
            {
                Placeholder = "Benefit",
                FontSize = 18,
                WidthRequest = 300,
                HeightRequest = 40,
                Margin = new Thickness(0, 5, 0, 0),
            };

            
            BenListTB.Add(bentmp);
            benefits.Children.Add(bentmp);
            benefits.Children.Remove(ben0);
            benefits.Children.Add(ben0);
        }

        public async void SubmitOffer(object sender, EventArgs e)
        {
            Offer oo = new Offer();

            if (!string.IsNullOrWhiteSpace(Category.SelectedItem?.ToString()) &&
                !string.IsNullOrWhiteSpace(description.Text) &&
                !string.IsNullOrWhiteSpace(TitleTextBox.Text) &&
                !string.IsNullOrWhiteSpace(Position_name.Text) &&
                ReqListTB.Count > 0 && DutListTB.Count > 0 && BenListTB.Count > 0)
            {
                oo.Company_Id = App.Instance.CompanyId;
                oo.Category = Category.SelectedIndex;
                oo.Description = description.Text;
                oo.Title = TitleTextBox.Text;
                oo.Position_name = Position_name.Text;
                oo.Position_level = Position_level.Text;
                oo.Type_of_contract = TypeofContract.SelectedItem.ToString();
                oo.Type_of_Job = TypeofJob.SelectedItem.ToString();
                oo.Employment = Employment.SelectedItem.ToString();
                oo.Expired = expired.Date;
                oo.Salary = (SalaryFrom.Text + "-" + SalaryTo.Text + " PLN").ToString();

                oo.Applications = new List<int>();


                for (int i = 0; i < ReqListTB.Count; i++)
                {
                    ReqList.Add(ReqListTB[i].Text);
                }

                for (int i = 0; i < DutListTB.Count; i++)
                {
                    DutList.Add(DutListTB[i].Text);
                }

                for (int i = 0; i < BenListTB.Count; i++)
                {
                    BenList.Add(BenListTB[i].Text);
                }

                oo.Duties = DutList;
                oo.Requirements = ReqList;
                oo.Benefits = BenList;

                await DisplayAlert("", "Dodano ofertę", "OK");

                new Database().AddOffer(oo);

                await Navigation.PushAsync(new FlyoutPage1());


            }
            else
            {
                await DisplayAlert("Error", "Uzupełnij wszystkie pola", "OK");
            }
        }
    }
}