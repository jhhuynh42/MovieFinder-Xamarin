using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MovieFinder.Model
{
    public class Favs
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public String FavTitle { get; set; }
        [Unique]
        public String imdbID { get; set; }
        public Favs() { }


    }
}
