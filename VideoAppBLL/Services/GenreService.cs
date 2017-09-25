using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using genreAppBLL;
using VideoAppBLL.BusinessObjects;
using VideoAppBLL.Converter;
using VideoAppDAL;

namespace VideoAppBLL.Services
{
    public class GenreService : IGenreService
    {
        private DALFacade facade;
        private GenreConverter converter = new GenreConverter();

        public GenreService(DALFacade facade)
        {
            this.facade = facade;
        }
        public GenreBO Create(GenreBO genre)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVideo = uow.GenreRepository.Create(converter.Convert(genre));
                uow.Complete();
                return converter.Convert(newVideo);
            }
        }

        public List<GenreBO> CreateAll(List<GenreBO> genreList)
        {
            throw new NotImplementedException();
        }

        public List<GenreBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.GenreRepository.GetAll().Select(converter.Convert).ToList();
            }
        }

        public GenreBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return converter.Convert(uow.GenreRepository.Get(Id));
            }
        }

        public GenreBO Update(GenreBO genre)
        {
            throw new NotImplementedException();
        }

        public GenreBO Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
