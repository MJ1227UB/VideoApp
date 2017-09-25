using System;
using System.Collections.Generic;
using System.Linq;
using VideoAppBLL.BusinessObjects;
using VideoAppBLL.Converter;
using VideoAppDAL;

namespace VideoAppBLL.Services
{
    public class VideoService : IVideoService
    {
        VideoConverter converter = new VideoConverter();
        private DALFacade facade;

        public VideoService(DALFacade facade)
        {
            this.facade = facade;
        }

        public VideoBO Create(VideoBO video)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVideo = uow.VideoRepository.Create(converter.Convert(video));
                uow.Complete();
                return converter.Convert(newVideo);
            }
        }

        public List<VideoBO> CreateAll(List<VideoBO> videoList)
        {
            throw new NotImplementedException();
        }

        public List<VideoBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepository.GetAll().Select(converter.Convert).ToList();
            }
        }

        public VideoBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return converter.Convert(uow.VideoRepository.Get(Id));
            }
        }

        public VideoBO Update(VideoBO video)
        {
            using (var uow = facade.UnitOfWork)
            {
                var videoFromDB = uow.VideoRepository.Get(video.Id);
                if (videoFromDB == null)
                {
                    throw new InvalidOperationException("Video not found");
                }
                videoFromDB.Title = video.Title;
                videoFromDB.Id = video.Id;
                videoFromDB.PricePeDay = video.PricePeDay;
                uow.Complete();
                return converter.Convert(videoFromDB);
            }
        }

        public VideoBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVideo = uow.VideoRepository.Delete(Id);
                uow.Complete();
                return converter.Convert(newVideo);
            }
        }
    }
}