using VideoAppBLL.Services;
using VideoAppDAL;

namespace VideoAppBLL
{
    public class BLLFacade
    {
        public IVideoService VideoService
        {
            get { return new VideoService(new DALFacade()); }
        }
    }
}