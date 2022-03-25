using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpInReqRes.DTOs
{
        public class GetListResource
        {
            public long Page { get; set; }
            public long PerPage { get; set; }
            public long Total { get; set; }
            public long TotalPages { get; set; }
            public List<RData> Data { get; set; }
        }

        public partial class RData
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public long Year { get; set; }
            public string Color { get; set; }
            public string PantoneValue { get; set; }
        }
    
}
