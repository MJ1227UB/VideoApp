using System;
using System.Collections.Generic;
using System.Text;
using VideoAppBLL.BusinessObjects;
using VideoAppDAL.Entities;

namespace VideoAppBLL.Converter
{
    class VideoConverter
    {
        internal Video Convert(VideoBO video)
        {
            if (video == null) { return null; }
            return new Video()
            {
                Title = video.Title,
                Id = video.Id,
                PricePeDay = video.PricePeDay
            };
        }

        internal VideoBO Convert(Video video)
        {
            if (video == null) { return null; }
            return new VideoBO()
            {
                Title = video.Title,
                Id = video.Id,
                PricePeDay = video.PricePeDay
            };
        }
    }
}
