using System.Collections.Generic;
using VideoAppEntity;

namespace VideoAppDAL
{
    public interface IVideoRepository
    {
        //Create
        Video Create(Video video);

        //Read
        List<Video> GetAll();
        Video Get(int Id);

        //Update
        Video Update(Video video);

        //Delete
        Video Delete(int Id);
    }
}