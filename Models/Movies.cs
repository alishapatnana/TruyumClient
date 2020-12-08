using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace truYumClient.Models
{
    public class Movies
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public bool Active { get; set; }
        public int Price { get; set; }
        public DateTime DateOfLaunch { get; set; }
        public string GenreType { get; set; }
        public bool HasTeaser { get; set; }
    }
}
