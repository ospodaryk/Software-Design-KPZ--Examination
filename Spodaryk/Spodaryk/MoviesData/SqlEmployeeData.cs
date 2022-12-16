using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spodaryk.CustomerData
{
    public class SqlEmployeeData : IMovieData
    {
        SpodarykPz34Context dataContext;
        public SqlEmployeeData(SpodarykPz34Context ctx)
        {
            dataContext = ctx;
        }
        public void AddMovie(Movie movie)
        {
            dataContext.Movies.Add(movie);
            dataContext.SaveChanges();
        }

        public void DeleteMovie(int id)
        {
            dataContext.Remove(dataContext.Movies.FirstOrDefault(x => x.IdMovie == id));
            dataContext.SaveChanges();
        }

        public Movie UpdateMovie(Movie movie)
        {
            Movie m = dataContext.Movies.FirstOrDefault(x => x.IdMovie == movie.IdMovie);           
           
            m.Name = movie.Name;
            m.Path = movie.Path;
            m.Comments = movie.Comments;
            m.Recomendation = movie.Recomendation;
            dataContext.SaveChanges();
            return m;
        }

        public Movie GetMovie(int id)
        {
            return dataContext.Movies.SingleOrDefault(x => x.IdMovie == id);
        }

        public List<Movie> GetMoviesList()
        {
            return dataContext.Movies.ToList();
        }
    }
}
