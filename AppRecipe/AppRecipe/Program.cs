using System;
using System.Collections.Generic;
using System.Linq;

namespace AppRecipe
{
    class Program
    {
        static int ID()
        {
            Console.WriteLine("Enter the ID");
            return int.Parse(Console.ReadLine());
        }

        static string NAME()
        {
            Console.WriteLine("Enter the name");
            return Console.ReadLine();
        }

        static void Main(string[] args)
        {
            int choice = -1;
            Recipe recipe = new Recipe();
            //(localdb)\MSSQLLocalDB
            do
            {
                Console.WriteLine("_________________________Menu__________________________");
                Console.WriteLine("1)Add new Recipe_______________________________________");
                Console.WriteLine("2)Delete a Recipe______________________________________");
                Console.WriteLine("3)Show All Recipes_____________________________________");
                Console.WriteLine("4)Search Recipe________________________________________");
                Console.WriteLine("5)Exit_________________________________________________");
                Console.WriteLine("Your choice");
                choice = int.Parse(Console.ReadLine());
                switch(choice)
                {
                    case 1: recipe.Id = ID();
                            recipe.Name = NAME();
                            
                            if(insert(recipe))
                            {
                                 Console.WriteLine("Data insrted ");
                            }
                            else
                            {
                                 Console.WriteLine("Error of inserting data");
                            }
                    break;
                    case 2:  
                             
                             if(delete(ID()))
                             {
                                   Console.WriteLine("Data removed");
                             }
                             else
                             {
                                    Console.WriteLine("Error of removing");
                             }
                     break;
                    case 3 : List<Recipe> ListRecipe = new List<Recipe>();
                             ListRecipe = allRecip();
                             foreach (Recipe r in ListRecipe)
                             {
                                   Console.WriteLine("Id : " + r.Id + " Name : " + r.Name);
                             }
                    break;
                    case 4 : Console.WriteLine(search(ID())); 
                    break;
                    case 5 : Console.WriteLine("You exit the application");
                    break;
                }
            } while (choice > 0);
            Console.ReadLine();
        }

        static Recipe search(int id)
        {
            try
            {
                RecipesEntities re = new RecipesEntities();
                Recipe recipe = (Recipe)re.Recipes.Where(r => r.Id == id).First();
                return recipe;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Exception : " + Ex.Message);
                return null;
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
                catch (Exception Ex)
                {
                    Console.WriteLine("Error : " + Ex.Message);
                    return false;
                }
            }
        }

        static Boolean delete(int id)
        {
            try
            {
                RecipesEntities re = new RecipesEntities();
                Recipe recipe = (Recipe)re.Recipes.Where(r => r.Id == id).First();
                re.Recipes.Remove(recipe);
                re.SaveChanges();
                return true;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Exception : " + Ex.Message);
                return false;
            }
        }

        static List<Recipe> allRecip()
        {
            using (var context = new RecipesEntities())
            {
                try
                {
                    return context.Recipes.ToList();
                }
                catch(Exception Ex)
                {
                    Console.WriteLine("Error : " + Ex.Message);
                    return null;
                }
            }
        }

        static Boolean Update(int id , Recipe r)
        {
            return false;
        }
    }
}
