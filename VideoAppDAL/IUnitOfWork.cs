using System;

namespace VideoAppDAL
{
    public interface IUnitOfWork : IDisposable
    {
        IVideoRepository VideoRepository { get; }
        IGenreRepository GenreRepository { get; }
        int Complete();
    }
}