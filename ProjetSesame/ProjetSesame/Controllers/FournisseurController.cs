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

    public class FournisseurController : ApiController
    {

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/fournisseur/all")]
        // GET client/habib
        public List<Fournisseur> Get()
        {
            using (var context = new dbContext())
            {
                try
                {
                    return context.Fournisseurs.ToList();
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
        [System.Web.Http.Route("api/fournisseur/insert")]
        public string Post([FromBody]Fournisseur value)
        {
            using (dbContext context = new dbContext())
            {
                try
                {
                    context.Fournisseurs.Add(value);
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
        [System.Web.Http.Route("api/fournisseur/update")]
        public string update([FromBody] Fournisseur f)
        {
            using (dbContext context = new dbContext())
            {
                try
                {
                    Fournisseur fournisseur = (Fournisseur)context.Fournisseurs.Where(r => r.Id == f.Id).First();
                    fournisseur.Nom = f.Nom;
                    fournisseur.Prenom = f.Prenom;
                    fournisseur.Email = f.Email;
                    fournisseur.Password = f.Password;
                    context.SaveChanges();
                    return "Fournisseur updated";
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
        [System.Web.Http.Route("api/fournisseur/delete")]
        public string Delete(Fournisseur f)
        {
            try
            {
                dbContext re = new dbContext();
                Fournisseur fournisseur = (Fournisseur)re.Fournisseurs.Where(r => r.Id == f.Id).First();
                re.Fournisseurs.Remove(fournisseur);
                re.SaveChanges();
                return "Employer deleted";
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Exception : " + Ex.Message);
                return "Exception : " + Ex.Message;
            }
        }
    }
}

