using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MovieFinder
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        protected void OnSleep()
        {
            Debug.WriteLine("OnSleep");
        }
        protected void OnStart()
        {
            Debug.WriteLine("OnStart");
            SearchTitle.Text = "";
            Warning.Text = "";
        }
        protected void OnResume()
        {
            Debug.WriteLine("OnResume");
            SearchTitle.Text = "";
            Warning.Text = "";
        }

        async public void Search_clicked(object sender, EventArgs e)
        {
            //check if searchTitle is not empty
            if (!(String.IsNullOrWhiteSpace(SearchTitle.Text)))
            {
                var search = "t=" + SearchTitle.Text;
                await Navigation.PushModalAsync(new Details(search, "Title"));
                SearchTitle.Text = "";
                Warning.Text = "";
            }
            else
                Warning.Text = "Enter a movie title";
        }

        async public void Search(object sender, EventArgs e)
        {
            Debug.WriteLine("Log: Search");
            //check if searchTitle is not empty
            if (!(String.IsNullOrWhiteSpace(SearchTitle.Text)))
            {
                var search = "s=" + SearchTitle.Text;
                await Navigation.PushModalAsync(new Search(search));
                SearchTitle.Text = "";
                Warning.Text = "";
            }
            else
                Warning.Text = "Enter a movie title";
        }

        async public void Favorite_Clicked(object sender, EventArgs e)
        {
            SearchTitle.Text = "";
            Warning.Text = "";
            await Navigation.PushModalAsync(new Favorites());
        }

    }
}
