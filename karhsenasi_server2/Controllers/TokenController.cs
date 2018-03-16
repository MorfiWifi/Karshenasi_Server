using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;
using karhsenasi_server2.Models;

namespace karhsenasi_server2.Controllers
{
    public class TokenController : ApiController
    {
        [System.Web.Http.HttpPost]
        [ResponseType(typeof(string))]
        public IHttpActionResult GetToken(LogInViewModel logInViewModel)
        {
            try
            {

                Debug.WriteLine("Check Ress : ");


                if (!(logInViewModel.UserName == "admin"))
                {
                    return BadRequest("Didnt Catch That!");
                }
                if (logInViewModel == null)
                {
                    return BadRequest("Didnt Catch That!");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("EXCEP : > > " + ex.Message);
                return BadRequest("Didnt Catch That!");
            }
            ClaimsIdentity identity = new ClaimsIdentity("Khers_Bear");
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("USERNAME", logInViewModel.UserName);
            dic.Add("PASSWORD", logInViewModel.Password);
            AuthenticationProperties properties = new AuthenticationProperties(dic);
            AuthenticationTicket authenticationTicket = new AuthenticationTicket(identity, properties);
            authenticationTicket.Properties.ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1);
            //authenticationTicket.Properties.ExpiresUtc.Value.AddDays(1);

            string MyToken = Startup.OAuthOptions.AccessTokenFormat.Protect(authenticationTicket);

            Debug.WriteLine("My OWN CRATED TOKEN : " + MyToken);

            //incomingCall.Message = MyToken;
            return Ok(MyToken);
        }
    }

}