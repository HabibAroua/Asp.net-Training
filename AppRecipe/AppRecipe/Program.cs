using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRecipe
{
    class Program
    {
        static void Main(string[] args)
        {
            //(localdb)\MSSQLLocalDB
            Recipe r = new Recipe();
            Console.WriteLine("Donnez l'id");
            r.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Donnez le nom");
            r.Name = Console.ReadLine();
            Boolean Test=insert(r);
            if(Test)
            {
                Console.WriteLine("Data inserted");
            }
            else
            {
                Console.WriteLine("Error no data inserted");
            }
        }

        static Boolean insert(Recipe r)
        {
            using (RecipesEntities context = new RecipesEntities())
            {
                try
                {
                    context.Recipes.Add(r);
                    context.SaveChanges();
                    return true;
                }
                catch(Exception Ex)
                {
                    Console.WriteLine("Error : " + Ex.Message);
                    return false;
                }
            }
        }
    }
}
