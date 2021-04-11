using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieFinder.Model;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovieFinder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Favorites : ContentPage
    {

        ObservableCollection<Favs> allFavs;
        public Favorites()
        {
            InitializeComponent();

            allFavs = null;
        }
        protected override async void OnAppearing()
        {

            allFavs = await App.Database.GetFavFilms();
            FavList.ItemsSource = allFavs;
            base.OnAppearing();
        }
        async public void OnDetails(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var Picked = menuItem.CommandParameter as Favs;
            await Navigation.PushModalAsync(new Details("i="+ Picked.imdbID, "imdbID"));
        }

        void onDelete(System.Object sender, System.EventArgs e)
        {
            var toDelete = ((sender as MenuItem).CommandParameter as Favs);
            allFavs.Remove(toDelete);
            App.Database.deleteFilm(toDelete);
        }



    }
}