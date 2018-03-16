using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace karhsenasi_server2.Models
{
        public class LogInViewModel
        {
            [Display(Name = "نام کاربری")]
            public string UserName { get; set; }

            [Display(Name = "رمز عبور")]
            public string Password { get; set; }
        }
}