using System.Collections.Generic;
using System.Linq;
using VideoAppDAL.Context;
using VideoAppEntity;

namespace VideoAppDAL.Repositories
{
    public class VideoRepositoryEFMemory : IVideoRepository
    {
        private InMemoryContext _context;
        public VideoRepositoryEFMemory(InMemoryContext context)
        {
            this._context = context;
        }
        public Video Create(Video video)
        {
            _context.Videos.Add(video);
            return video;
        }

        public List<Video> CreateAll(List<Video> videoList)
        {
            throw new System.NotImplementedException();
        }

        public List<Video> GetAll()
        {
            return _context.Videos.ToList();
        }

        public Video Get(int Id)
        {
            return _context.Videos.FirstOrDefault(x => x.Id == Id);
        }

        public Video Update(Video video)
        {
            throw new System.NotImplementedException();
        }

        public Video Delete(int Id)
        {
            var video = Get(Id);
            _context.Videos.Remove(video);
            return video;
        }
    }
}