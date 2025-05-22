using CookieCookbook.IngredientsList;
using CookieCookbook.PrintIngredients;
using CookieCookbook.PrintRecipes;
using CookieCookbook.StoreRecipes;

// Main application flow
namespace CookieCookbook
{
    //// renaming main class 
    //var cookiesRecipesApp = new CookiesRecipesApp();
    //cookiesRecipesApp.Run();
    
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

            if (File.Exists(store.FullPath))
            {
                Console.WriteLine($"\nExisting recipes are: " + store.FullPath + $"\nFile: \n" + File.ReadAllText(StoreRecipesInFile.FileName));
            }


            //// high level design
            //if (ingredients.Count > 0)
            //{
            //    var recipes = new Recipe(ingredients);
            //    allRecipes.Add(recipes);
            //    _recipesRepository.Write(filePath, allRecipes);

            //    _recipesUserInteraction.ShowMessage("Recipe added:");
            //    _recipesUserInteraction.ShowMessage(Recipe.ToString());
            //}
            //else
            //{
            //    _recipesUserInteraction.ShowMessage(
            //        "No ingredients have been selected. " +
            //        "Recipe will not be saved.");
            //}

            //_recipesUserInteraction.Exit();

                // Program exit
                Console.WriteLine("\nPress any key to exit");
            Console.ReadKey();

        }
    }
}


