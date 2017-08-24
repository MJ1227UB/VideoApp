using VideoAppDAL.Context;
using VideoAppDAL.Repositories;

namespace VideoAppDAL.UOW
{
    public class UnitOfWorkMem : IUnitOfWork
    {
        public IVideoRepository VideoRepository { get; internal set; }
        private InMemoryContext context;

        public UnitOfWorkMem()
        {
            context = new InMemoryContext();
            VideoRepository = new VideoRepositoryEFMemory(context);
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