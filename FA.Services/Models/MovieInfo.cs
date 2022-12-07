using System;
using System.Collections.Generic;
using System.Text;

namespace FA.Services.Models
{
    public class MovieInfo
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string YearOfProduction { get; set; }

        public decimal Rating { get; set; }

        public string Description { get; set; }

        public List<TypeInfo> Type { get; set; }
    }
}
