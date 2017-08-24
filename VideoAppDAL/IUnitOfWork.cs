using System;

namespace VideoAppDAL
{
    public interface IUnitOfWork : IDisposable
    {
        IVideoRepository VideoRepository { get; }

        int Complete();
    }
}