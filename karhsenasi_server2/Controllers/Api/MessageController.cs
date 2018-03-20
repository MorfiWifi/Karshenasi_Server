using karhsenasi_server2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace karhsenasi_server2.Controllers.Api
{
    public class MessageController : ApiController
    {
        Repo Db = Repo.GetInstance();

        [HttpGet]
        [ResponseType(typeof(List<Message>))]
        public IHttpActionResult GetMessages ()
        {
            var req = Request; // Find out Whre is Token (I have Forgot !!)
            User user = null ;


            var messages = Db.Messages(user);
            return Ok(messages);
        }

        [HttpPut]
        [ResponseType(typeof(Message))]
        public IHttpActionResult InsertMessages(Message message)
        {
            var req = Request; // Find out Whre is Token (I have Forgot !!) (Find User From Its Token!!!)
            var sender = "User Gained From Token!";
            // Enhance Message (for Real Sender 
            var messages = Db.AddMessage(message);
            return Ok(messages);
        }

        [HttpPut]
        [ResponseType(typeof(string))]
        public IHttpActionResult DeletMessages(Message message)
        {
            var req = Request; // Find out Whre is Token (I have Forgot !!) (Find User From Its Token!!!)
            //var sender = "User Gained From Token!";
            var messages = Db.RemoveMessage (message);
            return Ok(messages);
        }

        [HttpPut]
        [ResponseType(typeof(string))]
        public IHttpActionResult EditMessages(Message message)
        {
            //Foture Addes !!
            var req = Request; // Find out Whre is Token (I have Forgot !!) (Find User From Its Token!!!)
            //var sender = "User Gained From Token!";
            var messages = Db.UpdateMessage(message);
            return Ok(messages);
        }
    }
}
