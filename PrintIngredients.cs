using CookieCookbook.IngredientsList;

namespace CookieCookbook.PrintIngredients
{
    public class PrintAvailableIngredients
    {
        public PrintAvailableIngredients()
        {
        }

        public static void PrintIngredients()
        {
            // Print list of ingredients to the console
            foreach (var ingredient in IngredientRepository.Ingredients)
            {
                Console.WriteLine($"{ingredient.Id}. {ingredient.Name}");
            }
        }
    }
}   
