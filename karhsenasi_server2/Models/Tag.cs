using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace karhsenasi_server2.Models
{
    public class Tag
    {
        public string Id { set; get; }
        public int type { set; get; }
        public string Matn { set; get; }

        Tag()
        {
            Id = "10";
            type = 0;
            Matn = "";
        }
    }
}