using System.Collections.Generic;
using System.Linq.Expressions;
using VideoAppEntity;

namespace VideoAppBLL
{
    public interface IVideoService
    {
        //Create
        Video Create(Video video);
        List<Video> CreateAll(List<Video> videoList);

        //Read
        List<Video> GetAll();
        Video Get(int Id);

        //Update
        Video Update(Video video);

        //Delete
        Video Delete(int Id);
    }
}