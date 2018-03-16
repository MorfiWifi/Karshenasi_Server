using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace karhsenasi_server2.Models
{
    public class User
    {
        public string id { set; get; }
        public string FName { set; get; }
        public string LName { set; get; }
        public string Pass { set; get; }
        public string Pass_hash { set; get; }
        public string Kaet_meli { set; get; }

        public kind Type { set; get; }

        public User()
        {
            id = "0";
            FName = "";
            LName = "";
            Pass = "";
            Pass_hash = "";
            Kaet_meli = "";
        }
    }

    public enum kind {Student , Master , Technical , Site_Master , Self_Service , Admin }
}