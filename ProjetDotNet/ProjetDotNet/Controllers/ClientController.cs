using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.Text;
using System.Web;
using System.Web.Http.Cors;
using web_api_dot_net_Framework.Models;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace ProjetDotNet.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ClientController : ApiController
    {
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/client/aa")]
        // GET client/habib
        public List<Client> Get()
        {
            using (var context = new MyContext())
            {
                try
                {
                    return context.Clients.ToList();
                }
                catch (Exception Ex)
                {
                    Console.WriteLine("Error : " + Ex.Message);
                    return null;
                }
            }
            //var json = JsonConvert.SerializeObject(myList);
            //return myList;
        }
        [System.Web.Http.Route("api/all")]
        public IHttpActionResult All()
        {
            return Ok("Hello world");
        }
        // GET api/values/5
        public string Get(int id)
        {
            return "Cleint";
        }

        // POST api/values
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/client/values")]
        public string Post([FromBody]Client value)
        {
            using (MyContext context = new MyContext())
            {
                try
                {
                    context.Clients.Add(value);
                    context.SaveChanges();
                    return "Element inserted ...";
                }
                catch (Exception Ex)
                {
                    Console.WriteLine("Error : " + Ex.Message);
                    return "Error : " + Ex.Message;
                }
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/client/update")]
        public string update([FromBody] Client c)
        {
            using (MyContext context = new MyContext())
            {
                try
                {
                    Client client = (Client)context.Clients.Where(r => r.Id == c.Id).First();
                    client.Nom = c.Nom;
                    context.SaveChanges();
                    return "Data updated";
                }
                catch (Exception Ex)
                {
                    Console.WriteLine("Error : " + Ex.Message);
                    return "Error " + Ex.Message;
                }
            }
        }
        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            Ok(value);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {

        }
    }
}