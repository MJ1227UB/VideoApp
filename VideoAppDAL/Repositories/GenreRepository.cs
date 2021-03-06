﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoAppDAL.Context;
using VideoAppDAL.Entities;

namespace VideoAppDAL.Repositories
{
    class GenreRepository : IGenreRepository
    {
        private VideoAppContext _context;

        public GenreRepository(VideoAppContext context)
        {
            _context = context;
        }
        public Genre Create(Genre genre)
        {
            _context.Genres.Add(genre);
            return genre;
        }

        public List<Genre> CreateAll(List<Genre> genreList)
        {
            throw new NotImplementedException();
        }

        public List<Genre> GetAll()
        {
            return _context.Genres.ToList();
        }

        public Genre Get(int Id)
        {
            return _context.Genres.FirstOrDefault(g => g.Id == Id);
        }
        
        public Genre Delete(int Id)
        {
            var genre = Get(Id);
            _context.Genres.Remove(genre);
            return genre;
        }
    }
}
