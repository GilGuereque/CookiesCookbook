using CookieCookbook.IngredientsList;
using CookieCookbook.PrintIngredients;

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

            // Program exit
            Console.WriteLine("\nPress any key to exit");
            Console.ReadKey();

        }
    }
}


