﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Console.WriteLine("4)Exit_________________________________________________");
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
                    case 2:  recipe.Id = ID();
                             recipe.Name = NAME();
                             if(delete(recipe))
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
                    case 4 : Console.WriteLine("You exit the application");
                    break;
                }
            } while (choice > 0);
            Console.ReadLine();
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

        static Boolean delete(Recipe r)
        {
            using (RecipesEntities context = new RecipesEntities())
            {
                try
                {
                    context.Recipes.Remove(r);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception Ex)
                {
                    Console.WriteLine("Error :" + Ex.Message);
                    return false;
                }
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
    }
}
