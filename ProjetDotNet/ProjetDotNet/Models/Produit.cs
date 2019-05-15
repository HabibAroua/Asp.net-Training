using System.ComponentModel.DataAnnotations;

namespace web_api_dot_net_Framework.Models
{
    public class Produit
    {
        [Key]
        public int Id
        {
            get;
            set;
        }

        public string Libelle
        {
            get;
            set;

        }

        public double Prix
        {
            get;
            set;
        }

        public string Couleur
        {
            get;
            set;
        }
    }
}