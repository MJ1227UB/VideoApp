using VideoAppDAL.Context;
using VideoAppDAL.Repositories;

namespace VideoAppDAL.UOW
{
    public class UnitOfWorkMem : IUnitOfWork
    {
        public IVideoRepository VideoRepository { get; internal set; }
        public IGenreRepository GenreRepository { get; internal set; }
        private VideoAppContext context;
        public UnitOfWorkMem()
        {
            context = new VideoAppContext();
            VideoRepository = new VideoRepository(context);
            GenreRepository = new GenreRepository(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }
        public int Complete()
        {
            return context.SaveChanges();
        }
    }
}