using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Diagnostics;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http.Description;
using karhsenasi_server2.Models;


namespace karhsenasi_server2.Controllers.Api
{
    public class TokenController : ApiController
    {
        [HttpPost]
        [ResponseType(typeof(string))]
        public IHttpActionResult GetToken(LoginModel loginModel)
        {
            var users = Repo.GetInstance().Users();
            try
            {
                var matches = users.Where(x => x.FName == loginModel.UserName);
                Debug.WriteLine("Check Ress : ");
                if (matches.Count() < 1)
                {
                    return BadRequest("Didnt Catch That!");
                }
                matches = users.Where(x => x.Pass == loginModel.Password);
                if (matches.Count() < 1)
                {
                    return BadRequest("Didnt Catch That!");
                }

                User Accepted_user = matches.First();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("EXCEP : > > " + ex.Message);
                return BadRequest("Didnt Catch That!");
            }
            ClaimsIdentity identity = new ClaimsIdentity("Khers_Bear");
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("USERNAME", loginModel.UserName);
            dict.Add("PASSWORD", loginModel.Password);
            AuthenticationProperties properties = new AuthenticationProperties(dict);
            AuthenticationTicket authenticationTicket = new AuthenticationTicket(identity, properties);
            authenticationTicket.Properties.ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1);
            string MyToken = Startup.OAuthOptions.AccessTokenFormat.Protect(authenticationTicket);
            Debug.WriteLine("My OWN CRATED TOKEN : " + MyToken);
            //incomingCall.Message = MyToken;
            return Ok(MyToken);
        }


        [HttpPost]
        [ResponseType(typeof(string))]
        public IHttpActionResult GetToken(string username , string pass)
        {
            var users = Repo.GetInstance().Users();
            try
            {
                var matches = users.Where(x => x.FName == username);
                Debug.WriteLine("Check Ress : ");
                if (matches.Count() < 1)
                {
                    return BadRequest("Didnt Catch That!");
                }
                matches = users.Where(x => x.Pass == pass);
                if (matches.Count() < 1)
                {
                    return BadRequest("Didnt Catch That!");
                }

                User Accepted_user = matches.First();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("EXCEP : > > " + ex.Message);
                return BadRequest("Didnt Catch That!");
            }
            ClaimsIdentity identity = new ClaimsIdentity("Khers_Bear");
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("USERNAME", username);
            dict.Add("PASSWORD", pass);
            AuthenticationProperties properties = new AuthenticationProperties(dict);
            AuthenticationTicket authenticationTicket = new AuthenticationTicket(identity, properties);
            authenticationTicket.Properties.ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1);
            string MyToken = Startup.OAuthOptions.AccessTokenFormat.Protect(authenticationTicket);
            Debug.WriteLine("My OWN CRATED TOKEN : " + MyToken);
            //incomingCall.Message = MyToken;
            return Ok(MyToken);
        }

        [HttpGet]
        [ResponseType(typeof(string))]
        public IHttpActionResult Tokem()
        {
            return Ok("job is Don What Do You Think  ?");
        }
    }
}
