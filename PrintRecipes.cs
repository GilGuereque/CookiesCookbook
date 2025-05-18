namespace CookieCookbook.PrintRecipes
{
    public interface PrintRecipes
    {
        public static void PrintRecipe()
        {
        }

    }

    public class PrintAvailableRecipes : PrintRecipes
    {
        public static PrintAvailableRecipes Instance = new PrintAvailableRecipes();
    }
}
