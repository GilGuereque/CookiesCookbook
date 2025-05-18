using CookieCookbook.IngredientsList;
using CookieCookbook.PrintIngredients;

// Main application flow
namespace CookieCookbook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            
            // Call PrintIngredients method to print list to the console
            PrintAvailableIngredients.PrintIngredients();

            // Program exit
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

        }
    }
}


