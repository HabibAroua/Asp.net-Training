using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Data;
using web_api_dot_net_Framework.Models;
using System.Web.Http.Cors;

namespace ProjetSesame.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class ClientController : ApiController
    {

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/client/all")]
        // GET client/habib
        public List<Client> Get()
        {
            using (var context = new dbContext())
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


        // GET api/values/5
        public string Get(int id)
        {
            return "Cleint";
        }

        // POST api/values
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/client/insert")]
        public string Post([FromBody]Client value)
        {
            using (dbContext context = new dbContext())
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
            using (dbContext context = new dbContext())
            {
                try
                {
                    Client client = (Client)context.Clients.Where(r => r.Id == c.Id).First();
                    client.Nom = c.Nom;
                    client.Prenom = c.Prenom;
                    client.Login = c.Login;
                    client.Password = c.Password;
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

        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/client/delete")]
        public string Delete(Client c)
        {
            try
            {
                dbContext re = new dbContext();
                Client client = (Client)re.Clients.Where(r => r.Id == c.Id).First();
                re.Clients.Remove(client);
                re.SaveChanges();
                return "Client deleted";
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Exception : " + Ex.Message);
                return "Exception : " + Ex.Message;
            }
        }
    }
}
