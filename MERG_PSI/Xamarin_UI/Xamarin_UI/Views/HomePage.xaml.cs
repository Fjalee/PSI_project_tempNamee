using MERG_BackEnd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace Xamarin_UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private readonly Lazy<List<RealEstate>> _listOfRealEstates;
        private List<RealEstate> _filteredList;

        public HomePage()
        {
            InitializeComponent();

            List<RealEstate> getSampleData() => new Data(GetScrapedDataStream()).SampleData;
            _listOfRealEstates = new Lazy<List<RealEstate>> (getSampleData);
        }

        private Stream GetScrapedDataStream()
        {
            var assembly = typeof(HomePage).GetTypeInfo().Assembly;
            return assembly.GetManifestResourceStream("Xamarin_UI.Resources.scrapedData.txt");
        }

        private void MyItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var myValue = e.CurrentSelection.FirstOrDefault() as RealEstate;
            Application.Current.MainPage.Navigation.PushAsync(new MapPage(myValue));
        }

        private void Municipality_TextChanged(object sender, TextChangedEventArgs e)
        {

            ((Entry)sender).Text = e.NewTextValue.Validate();
        }

        private void Microdistrict_TextChanged(object sender, TextChangedEventArgs e)
        {
 
            ((Entry)sender).Text = e.NewTextValue.Validate();
        }

        private void Street_TextChanged(object sender, TextChangedEventArgs e)
        {
            ((Entry)sender).Text = e.NewTextValue.Validate();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var inspection = new Inspection();
            var filtersValues = GetFiltersValue();
            try
            {
                _filteredList = inspection.GetFilteredListOFRealEstate(_listOfRealEstates.Value, filtersValues);
            }
            catch (Exception)
            {
                await DisplayAlert("Dėmesio", "Nepavyko pasiekti duomenis, prašome kreiptis į administraciją", "OK");
            }
            myItem.ItemsSource = _filteredList;
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                var list = _filteredList ?? _listOfRealEstates.Value;
                await Application.Current.MainPage.Navigation.PushAsync(new FullMapPage(list));
            }
            catch (Exception)
            {

                await DisplayAlert("Dėmesio", "Nepavyko pasiekti duomenis, prašome kreiptis į administraciją", "OK");
            }
        }

        private FiltersValue GetFiltersValue()
        {
            return new FiltersValue(municipality: municipality.Text, microdistrict: microdistrict.Text, street: street.Text,
               priceFrom: priceFrom.Text.ConvertToInt(), priceTo: priceTo.Text.ConvertToInt(),
              areaFrom: areaFrom.Text.ConvertToInt(), areaTo: areaTo.Text.ConvertToInt(),
              buildYearFrom: buildYearFrom.Text.ConvertToInt(), buildYearTo: buildYearTo.Text.ConvertToInt(),
              numberOfRoomsFrom: numberOfRoomsFrom.Text.ConvertToInt(), numberOfRoomsTo: numberOfRoomsTo.Text.ConvertToInt(),
              pricePerSqMFrom: pricePerSqMFrom.Text.ConvertToInt(), pricePerSqMTo: pricePerSqMTo.Text.ConvertToInt(),
              noBuildYearInfo: noInfoBuildYear.IsChecked, noNumberOfRoomsInfo: noInfoRoomNumber.IsChecked);
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            if(filtersDisplay.IsVisible)
            {
                filtersDisplay.IsVisible = false;
                buttonExpand.Text = "Išskleisti";
                return;
            }
            filtersDisplay.IsVisible = true;
            buttonExpand.Text = "Suskleisti";
        }
    }
    
}
