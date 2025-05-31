using CookieCookbook;
using CookieCookbook.PrintIngredients;
using CookieCookbook.PrintRecipes;
using CookieCookbook.Recipes;
using CookieCookbook.Recipes.Ingredients;
using CookieCookbook.RecipesUserInteraction;
using CookieCookbook.StoreRecipes;


// Constant to determine file format
const FileFormat Format = FileFormat.Txt;

IStringsRepository stringsRepository = Format == FileFormat.Json ?
    new StringsJsonRepository() :
    new StringsTextualRepository();

// Determine whether the file format will be a json or txt
const string FileName = "recipe";
var fileMetadata = new FileMetaData(FileName, Format);

// Instantiate IngredientsRegister object
var ingredientsRegister = new IngredientsRegister();

// Instantiating cookiesRecipeApp object with all neccessary parameters
var cookiesRecipesApp = new CookiesRecipesApp(
    new RecipesRepository(
        stringsRepository,
        ingredientsRegister),
    new RecipesConsoleUserInteraction(
        ingredientsRegister));

// Run application
cookiesRecipesApp.Run(fileMetadata.ToPath());


public class FileMetaData
{
    public string Name { get; }
    public FileFormat Format { get; }
    public FileMetaData(string name, FileFormat fileFormat)
    {
        Name = name;
        Format = fileFormat;
    }

    public string ToPath() => $"{Name}.{Format.AsFileExtension()}";
}

public static class FileFormatExtensions
{
    public static string AsFileExtension(this FileFormat fileFormat) =>
        fileFormat == FileFormat.Json ? "json" : "txt";
}

public enum FileFormat
{
    Json,
    Txt 
}
    
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
    public void Run(string filePath)
    {
        var allRecipes = _recipesRepository.Read(filePath);
        _recipesUserInteraction.PrintExistingRecipes(allRecipes);

        _recipesUserInteraction.PromptToCreateRecipe();

        var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

        // high level design
        if (ingredients.Count() > 0)
        {
            var recipe = new CookieCookbook.Recipes.Recipe(ingredients);
            allRecipes.Add(recipe);
            _recipesRepository.Write(filePath, allRecipes); // should use the print recipes class actually

            _recipesUserInteraction.ShowMessage("Recipe added:");
            _recipesUserInteraction.ShowMessage(recipe.ToString());
        }
        else
        {
            _recipesUserInteraction.ShowMessage(
                "No ingredients have been selected. " +
                "Recipe will not be saved.");
        }

        _recipesUserInteraction.Exit();
    }

    // FIRST SOLUTION ITERATION
    //Console.WriteLine("Create a new cookie recipe! Available ingredients are:\n");

    //// Call PrintIngredients method to print list to the console
    //PrintAvailableIngredients.PrintIngredients();

    //// Testing Serialization of Recipe object to Json file
    //var store = new StoreRecipesInFile();
    //store.SaveAndReadRecipe();

    //if (File.Exists(store.FullPath))
    //{
    //    Console.WriteLine($"\nExisting recipes are: " + store.FullPath + $"\nFile: \n" + File.ReadAllText(StoreRecipesInFile.FileName));
    //}
}


