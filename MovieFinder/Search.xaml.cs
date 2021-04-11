using MovieFinder.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovieFinder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Search : ContentPage
    {
        public NetworkingManager netManager = new NetworkingManager();
        ObservableCollection<SearchList> downloadedList = new ObservableCollection<SearchList>();
        string query;
        public Search(String line)
        {
            BindingContext = this;
            query = line;
            InitializeComponent();

        }
        protected async override void OnAppearing()
        {
            Debug.WriteLine("Log: Searching for " + query.Substring(2));
            SearchParm.Text = "Search Results for " + query.Substring(2);
            searchList.ItemsSource = null;
            //searchList.ItemsSource = await netManager.SearchMedia(query);

            var sList = await netManager.SearchMedia(query);
            downloadedList = new ObservableCollection<SearchList>(sList);
        
            searchList.ItemsSource = downloadedList;

            base.OnAppearing();
        }

        async public void searchList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Picked = e.SelectedItem as SearchList;
            Debug.WriteLine("Picked.imdbID is " + Picked.imdbID);
            await Navigation.PushModalAsync(new Details("i=" + Picked.imdbID, "imdbID"));
        }
    }
}