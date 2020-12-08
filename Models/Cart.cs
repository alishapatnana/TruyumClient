using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace truYumClient.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public List<Movies> Movies { get; set; }
    }
}
