using CookieCookbook.IngredientsList;
using CookieCookbook.PrintIngredients;
using CookieCookbook.StoreRecipes;

// Main application flow
namespace CookieCookbook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Create a new cookie recipe! Available ingredients are:\n");
            
            // Call PrintIngredients method to print list to the console
            PrintAvailableIngredients.PrintIngredients();

            // Testing Serialization of Recipe object to Json file
            var store = new StoreRecipesInFile();
            store.SaveAndReadRecipe();

            // Program exit
            Console.WriteLine("\nPress any key to exit");
            Console.ReadKey();

        }
    }
}


