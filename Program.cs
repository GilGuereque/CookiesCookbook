using CookieCookbook.App;
using CookieCookbook.DataAccess;
using CookieCookbook.FileAccess;
using CookieCookbook.Recipes;
using CookieCookbook.Recipes.Ingredients;
using CookieCookbook.PrintIngredients;
using CookieCookbook.PrintRecipes;
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


