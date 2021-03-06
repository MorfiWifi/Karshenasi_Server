﻿using System;
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

           // var p = Startup.OAuthOptions;
           // var mm = p.AccessTokenFormat;
            
            //var tok = Startup.OAuthOptions.AccessTokenFormat.Protect(authenticationTicket);
            string MyToken = Startup.OAuthOptions.AccessTokenFormat.Protect(authenticationTicket);
            Debug.WriteLine("My OWN CRATED TOKEN : " + MyToken);
            //incomingCall.Message = MyToken;
            return Ok(MyToken);
        }



        public static User_Cheker CheckToken(string Token)
        {
            var ch = new User_Cheker();
            try
            {
                AuthenticationTicket ticket = Startup.OAuthOptions.AccessTokenFormat.Unprotect(Token);
                string UserName = ticket.Properties.Dictionary["USERNAME"];
                string Pass = ticket.Properties.Dictionary["PASSWORD"];
                if (ticket.Properties.ExpiresUtc < DateTimeOffset.UtcNow)
                    return ch;
                Debug.WriteLine("I GOT USERNAME : " + UserName);
                Debug.WriteLine("I GOT PASS : " + Pass);
                var users = Repo.GetInstance().Users().Where(x => x.FName == UserName);
                users.Where(x => x.Pass == Pass);
                //ApplicationUser user = db.Users.Where(x => x.UserName == UserName).First();
                if (users != null )
                {
                    ch.user = users.First();
                    ch.isTrue = true;
                    return ch;
                }
            }
            catch (Exception)
            {
                ch.isTrue = false;
                return ch;
            }
            ch.isTrue = false;
            return ch;
        }


        [HttpGet]
        [ResponseType(typeof(string))]
        public IHttpActionResult Tokem()
        {
            return Ok("job is Don What Do You Think  ?");
        }
    }
}
