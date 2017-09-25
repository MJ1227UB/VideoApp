using System.Collections.Generic;
using VideoAppBLL.BusinessObjects;

namespace genreAppBLL
{
    public interface IGenreService
    {
        //Create
        GenreBO Create(GenreBO genre);
        List<GenreBO> CreateAll(List<GenreBO> genreList);

        //Read
        List<GenreBO> GetAll();
        GenreBO Get(int Id);

        //Update
        GenreBO Update(GenreBO genre);

        //Delete
        GenreBO Delete(int Id);
    }
}