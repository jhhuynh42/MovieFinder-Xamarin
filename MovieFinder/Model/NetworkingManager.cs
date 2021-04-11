using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Diagnostics;

namespace MovieFinder.Model
{
    public class NetworkingManager
    {
        private string api = "?apikey=6dc45f81&";
        private string ApiUrl = "https://www.omdbapi.com/";
       

        private HttpClient client = new HttpClient();

        public NetworkingManager()
        {
        }

        public async Task<List<SearchList>> SearchMedia(string line)
        {
            var url = ApiUrl + api + line;
            Debug.WriteLine("Log: Url is : " + url);
            var response = await client.GetAsync(url);
            if (response.StatusCode == HttpStatusCode.NotFound)
                return new List<SearchList>();

            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ListContent>(stringResponse);
            Debug.WriteLine("Log1: " + result.Search.ToList());
            return result.Search.ToList();

        }

        public async Task<Film> searchForMovie(string query)
        {
            var url = ApiUrl + api + query;
            Debug.WriteLine("Log: Url is : " + url);
            var response = await client.GetAsync(url);
            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            var stringResponse = await response.Content.ReadAsStringAsync();
            var FilmOne = JsonConvert.DeserializeObject<Film>(stringResponse);
            return FilmOne;
            
        }


        public async Task<Film> SearchbyID(string id)
        {
            var url = ApiUrl + api + id;
            var response = await client.GetAsync(url);

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            var stringResponse = await response.Content.ReadAsStringAsync();
            var FilmOne = JsonConvert.DeserializeObject<Film>(stringResponse);

            return FilmOne;
        }
            /*Test parameters*/
            /*Search for Avengers foe movie details*/
            public async Task<Film> SearchForAvengers()
        {
            var url = "https://www.omdbapi.com/?apikey=6dc45f81&t=Avengers";
            var response = await client.GetAsync(url);

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            var stringResponse = await response.Content.ReadAsStringAsync();
             return JsonConvert.DeserializeObject<Film>(stringResponse);

        }

    }
}
