using MovieFinder.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using Xamarin.Forms;
using System.Diagnostics;

namespace MovieFinder
{

    public partial class Details : ContentPage
    {
        public NetworkingManager netManager = new NetworkingManager();
        Film contents = new Film();
        string query, type;

        public Details(string Searchquery, string Searchtype)
        {
            query = Searchquery;
            type = Searchtype;

            InitializeComponent();
            
        }

        protected async override void OnAppearing()
        {
            Film contents = new Film();
            
            if (type == "Title")
            {
                Debug.WriteLine("Searchin by Title");
                var result = await netManager.searchForMovie(query);

                if(result.Response == "False")
                {
                    filmTitle.Text = "No Film was found by that name";
                    FavButton.IsEnabled = false;
                }
                contents = result;
                BindingContext = contents;
                
            }
            //Search for movie's ID
            else if (type == "imdbID")
            {
                var result = await netManager.SearchbyID(query);
                contents = result;
                BindingContext = contents;

                FavButton.IsEnabled = true;
            }
        }
        async void FavoriteAdd(object sender, EventArgs e)
        {
            FavButton.IsEnabled = false;
            App.Database.InsertFav(new Favs
            {
                FavTitle = filmTitle.Text,
                imdbID = filmID.Text
            });
        }
    }
}