using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SQLite;

namespace MovieFinder.Model
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Favs>().Wait();
        }

        async public Task<ObservableCollection<Favs>> GetFavFilms()
        {
            await _database.CreateTableAsync<Favs>();
            var FilmsList = await _database.Table<Favs>().ToListAsync();
            var AllFilms = new ObservableCollection<Favs>(FilmsList);
            return AllFilms;
        }

        public void InsertFav(Favs nfilm)
        {
            _database.InsertAsync(nfilm);
        }

        public void deleteFilm(Favs oFilm)
        {
            _database.DeleteAsync(oFilm);
        }

        public bool duplicateCheck(string id)
        {

            return false;
        }

        public void ClearFilms()
        {

        }
    }
}
