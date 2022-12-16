using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spodaryk.CustomerData
{
    public interface IMovieData
    {
        List<Movie> GetMoviesList();
        Movie GetMovie(int id);
        void AddMovie(Movie movie);
        void DeleteMovie(int id);
        Movie UpdateMovie(Movie movie);

    }
}
