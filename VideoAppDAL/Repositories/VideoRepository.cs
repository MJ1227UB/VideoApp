using System.Collections.Generic;
using System.Linq;
using VideoAppDAL.Context;
using VideoAppDAL.Entities;

namespace VideoAppDAL.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private VideoAppContext _context;
        public VideoRepository(VideoAppContext context)
        {
            _context = context;
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
            return _context.Videos.FirstOrDefault(v => v.Id == Id);
        }

        public Video Delete(int Id)
        {
            var video = Get(Id);
            _context.Videos.Remove(video);
            return video;
        }
    }
}