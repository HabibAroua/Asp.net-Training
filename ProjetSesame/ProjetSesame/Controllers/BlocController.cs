using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Data;
using System.Web.Http.Cors;
using web_api_dot_net_Framework.Models;

namespace ProjetSesame.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BlocController : ApiController
    {
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/bloc/all")]
        // GET client/habib
        public List<Bloc> Get()
        {
            using (var context = new dbContext())
            {
                try
                {
                    return context.Blocs.ToList();
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
        [System.Web.Http.Route("api/bloc/insert")]
        public string Post([FromBody]Bloc value)
        {
            using (dbContext context = new dbContext())
            {
                try
                {
                    context.Blocs.Add(value);
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
        [System.Web.Http.Route("api/bloc/update")]
        public string update([FromBody] Bloc b)
        {
            using (dbContext context = new dbContext())
            {
                try
                {
                    Bloc bloc = (Bloc)context.Blocs.Where(r => r.Id == b.Id).First();
                    bloc.Libelle = b.Libelle;
                    bloc.Position = b.Position;
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

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/bloc/delete")]
        public string Delete(Bloc b)
        {
            try
            {
                dbContext re = new dbContext();
                Bloc bloc = (Bloc)re.Blocs.Where(r => r.Id == b.Id).First();
                re.Blocs.Remove(bloc);
                re.SaveChanges();
                return "Admin deleted";
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Exception : " + Ex.Message);
                return "Exception : " + Ex.Message;
            }
        }
    }
}
