namespace ProjetSesame
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using web_api_dot_net_Framework.Models;

    public class dbContext : DbContext
    {
        // Votre contexte a été configuré pour utiliser une chaîne de connexion « dbContext » du fichier 
        // de configuration de votre application (App.config ou Web.config). Par défaut, cette chaîne de connexion cible 
        // la base de données « ProjetSesame.dbContext » sur votre instance LocalDb. 
        // 
        // Pour cibler une autre base de données et/ou un autre fournisseur de base de données, modifiez 
        // la chaîne de connexion « dbContext » dans le fichier de configuration de l'application.
        public dbContext()
            : base("name=dbContext")
        {
        }

        // Ajoutez un DbSet pour chaque type d'entité à inclure dans votre modèle. Pour plus d'informations 
        // sur la configuration et l'utilisation du modèle Code First, consultez http://go.microsoft.com/fwlink/?LinkId=390109.
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Bloc> Blocs { get; set; }
        public virtual DbSet<Casier> Casiers { get; set; }
        public virtual DbSet<Categorie> Categories { get; set; }
        public virtual DbSet<Employer> Employers { get; set; }
        public virtual DbSet<Fournisseur> Fournisseurs { get; set; }
        public virtual DbSet<Produit> Produits { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}