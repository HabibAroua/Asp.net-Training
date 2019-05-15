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

    public class ProduitController : ApiController
    {
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/produit/all")]
        // GET client/habib
        public List<Produit> Get()
        {
            using (var context = new dbContext())
            {
                try
                {
                    return context.Produits.ToList();
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
        [System.Web.Http.Route("api/produit/insert")]
        public string Post([FromBody]Produit value)
        {
            using (dbContext context = new dbContext())
            {
                try
                {
                    context.Produits.Add(value);
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
        [System.Web.Http.Route("api/produit/update")]
        public string update([FromBody] Produit p)
        {
            using (dbContext context = new dbContext())
            {
                try
                {
                    Produit produit = (Produit)context.Produits.Where(r => r.Id == p.Id).First();
                    //client.name = c.name;
                    produit.Libelle = p.Libelle;
                    produit.Prix = p.Prix;
                    produit.Couleur = p.Couleur;
                    context.SaveChanges();
                    return "Produit updated";
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
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/produit/delete")]
        public string Delete(Produit p)
        {
            try
            {
                dbContext re = new dbContext();
                Produit produit = (Produit)re.Produits.Where(r => r.Id == p.Id).First();
                re.Produits.Remove(produit);
                re.SaveChanges();
                return "Produit deleted";
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Exception : " + Ex.Message);
                return "Exception : " + Ex.Message;
            }
        }
    }
}

