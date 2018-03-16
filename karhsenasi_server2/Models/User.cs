using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace karhsenasi_server2.Models
{
    public class User
    {
        string id { set; get; }
        string FName { set; get; }
        string LName { set; get; }
        string Pass { set; get; }
        string Pass_hash { set; get; }
        string Kaet_meli { set; get; }

        kind Type { set; get; }
    }

    public enum kind {Student , Master , Technical , Site_Master , Self_Service , Admin }
}