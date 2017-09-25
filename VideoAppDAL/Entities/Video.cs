using System;
using System.Collections.Generic;
using System.Text;

namespace VideoAppDAL.Entities
{
    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double PricePeDay { get; set; }
    }
}