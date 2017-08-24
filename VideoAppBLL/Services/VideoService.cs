using System;
using System.Collections.Generic;
using VideoAppDAL;
using VideoAppEntity;

namespace VideoAppBLL.Services
{
    public class VideoService : IVideoService
    {
        private DALFacade facade;

        public VideoService(DALFacade facade)
        {
            this.facade = facade;
        }

        public Video Create(Video video)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVideo = uow.VideoRepository.Create(video);
                uow.Complete();
                return newVideo;
            }
        }

        public List<Video> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepository.GetAll();
            }
        }

        public Video Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepository.Get(Id);
            }
        }

        public Video Update(Video video)
        {
            using (var uow = facade.UnitOfWork)
            {
                var videoFromDB = uow.VideoRepository.Get(video.Id);
                if (videoFromDB == null)
                {
                    throw new InvalidOperationException("Customer not found");
                }
                videoFromDB.Title = video.Title;
                videoFromDB.Director = video.Director;
                uow.Complete();
                return videoFromDB;
            }
        }

        public Video Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVideo= uow.VideoRepository.Delete(Id);
                uow.Complete();
                return newVideo;
            }
        }
    }
}