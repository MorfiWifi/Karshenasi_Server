using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace karhsenasi_server2.Models
{
    public class User_Cheker
    {
        public User user { set; get; }
        public bool isTrue { set; get; }
        
        public User_Cheker()
        {
            user = new User();
            isTrue = false;
        }

    }
}