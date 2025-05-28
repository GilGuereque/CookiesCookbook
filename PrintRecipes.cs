using CookieCookbook.Recipes.Ingredients;
using CookieCookbook.Recipes;

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
        public void PrintRecipe(IEnumerable<Recipe> allRecipes)
        {
            if (allRecipes.Count() > 0)
            {
                Console.WriteLine($"Existing recipes are:" + Environment.NewLine);

                var counter = 1;
                foreach (var recipe in allRecipes)
                {
                    Console.WriteLine($"*****{counter}*****");
                    Console.WriteLine(recipe);
                    Console.WriteLine();
                    ++counter;
                }
            }
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
