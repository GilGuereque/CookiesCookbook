using CookieCookbook.IngredientsList;
using CookieCookbook.PrintIngredients;
using CookieCookbook.PrintRecipes;
using CookieCookbook.RecipesUserInteraction;
using CookieCookbook.StoreRecipes;


// renaming main class 
var cookiesRecipesApp = new CookiesRecipesApp(
    new RecipesRepository(),
    new RecipesConsoleUserInteraction());
cookiesRecipesApp.Run();
    
public class CookiesRecipesApp
{
    private readonly IRecipesRepository _recipesRepository;
    private readonly IRecipesUserInteraction _recipesUserInteraction;
    
    public CookiesRecipesApp(
        IRecipesRepository recipesRepository,
        IRecipesUserInteraction recipesUserInteraction)
    {
        _recipesRepository = recipesRepository;
        _recipesUserInteraction = recipesUserInteraction;
    }
    public void Run()
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


        // high level design
        if (ingredients.Count > 0)
        {
            var recipes = new Recipe(ingredients);
            allRecipes.Add(recipes);
            _recipesRepository.Write(filePath, allRecipes); // should use the print recipes class actually

            _recipesUserInteraction.ShowMessage("Recipe added:");
            _recipesUserInteraction.ShowMessage(Recipe.ToString());
        }
        else
        {
            _recipesUserInteraction.ShowMessage(
                "No ingredients have been selected. " +
                "Recipe will not be saved.");
        }

        _recipesUserInteraction.Exit();

        // Program exit


    }
}


