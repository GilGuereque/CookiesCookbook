using CookieCookbook.IngredientsList;

namespace CookieCookbook.PrintRecipes
{
    public interface IPrintRecipes
    {
        void PrintRecipe()
        {
        }

    }

    public class PrintAvailableRecipes : IPrintRecipes
    {
        private bool RecipesExist;
        public void PrintRecipe()
        {
            if (RecipesExist)
                Console.WriteLine($"Existing recipes are: \n" + "*****{N}*****"); //TODO: Refactor method to print out multiple recipes separated by asterisks and number of recipe
        }
    }

    public class PrintSingleRecipe : IPrintRecipes
    {
        public int NumOfRecipes;
        public void PrintRecipe()
        {
            if (NumOfRecipes == 1)
            {
                Console.WriteLine($"RecipeId. RecipeName. RecipeInstructions."); //TODO: Console output the actual Recipe ID. Name. Instructions.
            }
        }
    }
}
