using genreAppBLL;
using VideoAppBLL.Services;
using VideoAppDAL;

namespace VideoAppBLL
{
    public class BLLFacade
    {
        public IVideoService VideoService
        {
            get { return new VideoService(new DALFacade()); }
        }

        public IGenreService GenreRepository
        {
            get { return new GenreService(new DALFacade()); }
        }
    }
}