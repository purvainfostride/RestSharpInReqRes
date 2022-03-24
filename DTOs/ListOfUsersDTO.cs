using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpInReqRes.DTOs
{
    public class ListOfUsersDTO
    {
        public long Page { get; set; }
        public long PerPage { get; set; }
        public long Total { get; set; }
        public long TotalPages { get; set; }
        public List<Data> Data { get; set; }

    }

    public class Data
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public Uri Avatar { get; set; }
    }
}
