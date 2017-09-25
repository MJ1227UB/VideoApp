using System.Collections.Generic;
using VideoAppDAL.Entities;

namespace VideoAppDAL
{
    public interface IGenreRepository
    {
        //Create
        Genre Create(Genre genre);
        List<Genre> CreateAll(List<Genre> genreList);

        //Read
        List<Genre> GetAll();
        Genre Get(int Id);
        
        //Delete
        Genre Delete(int Id);
    }
}