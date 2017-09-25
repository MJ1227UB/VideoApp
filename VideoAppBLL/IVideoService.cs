using System.Collections.Generic;
using VideoAppBLL.BusinessObjects;

namespace VideoAppBLL
{
    public interface IVideoService
    {
        //Create
        VideoBO Create(VideoBO video);
        List<VideoBO> CreateAll(List<VideoBO> videoList);

        //Read
        List<VideoBO> GetAll();
        VideoBO Get(int Id);

        //Update
        VideoBO Update(VideoBO video);

        //Delete
        VideoBO Delete(int Id);
    }
}