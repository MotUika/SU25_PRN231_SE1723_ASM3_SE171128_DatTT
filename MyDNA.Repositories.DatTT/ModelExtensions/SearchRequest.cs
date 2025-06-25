using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDNA.Repositories.DatTT.ModelExtensions
{
    public class SearchRequest
    {
        public int? CurrentPage { get; set; } = 1;
        public int? PageSize { get; set; } = 10;
    }
    public class SearchFeedBackRatingRequest : SearchRequest 
    {
        public string? title { get; set; }
        public decimal? amount { get; set; }
        public string? serviceName { get; set; }
    }
}
