using System.Collections.Generic;
using VideoAppDAL.Entities;

namespace VideoAppDAL
{
    public interface IVideoRepository
    {
        //Create
        Video Create(Video video);
        List<Video> CreateAll(List<Video> videoList);

        //Read
        List<Video> GetAll();
        Video Get(int Id);
        
        //Delete
        Video Delete(int Id);
    }
}