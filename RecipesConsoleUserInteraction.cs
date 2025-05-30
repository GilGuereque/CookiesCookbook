using CookieCookbook.Recipes;
using CookieCookbook.Recipes.Ingredients;

namespace CookieCookbook.RecipesUserInteraction
{
    public interface IRecipesUserInteraction
    {
        void ShowMessage(string message);
        void Exit();
        void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
        void PromptToCreateRecipe();
        IEnumerable<Ingredient> ReadIngredientsFromUser();
    }

    public class IngredientsRegister
    {
        public IEnumerable<Ingredient> All { get; } = new List<Ingredient>
        {
            new WheatFlour(),
            new SpeltFlour(),
            new Butter(),
            new Chocolate(),
            new Sugar(),
            new Cardamom(),
            new Cinnamon(),
            new CocoaPowder(),
            new PowderedSugar(),
            new ChocolateChips()
        };

        public Ingredient GetById(int id)
        {
            foreach(var ingredient in All)
            {
                if(ingredient.Id == id)
                {
                    return ingredient;
                }
            }

            return null;
        }
    }
    
    public class RecipesConsoleUserInteraction : IRecipesUserInteraction
    {
        private readonly IngredientsRegister _ingredientsRegister;

        public RecipesConsoleUserInteraction(
            IngredientsRegister ingredientsRegister)
        {
            _ingredientsRegister = ingredientsRegister;
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
        
        public void Exit()
        {
            Console.WriteLine("\nPress any key to exit");
            Console.ReadKey();
        }

        public void PrintExistingRecipes(IEnumerable<Recipe> allRecipes)
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

        public void PromptToCreateRecipe()
        {
            Console.WriteLine("Create a new cookie recipe! " +
                "Available ingredients are:");

            foreach(var ingredient in _ingredientsRegister.All)
            {
                Console.WriteLine(ingredient);
            }
        }

        public IEnumerable<Ingredient> ReadIngredientsFromUser()
        {
            bool shallStop = false;
            var ingredients = new List<Ingredient>();

            while(!shallStop)
            {
                Console.WriteLine("Add an ingredient by its ID, " +
                    "or type anything else if finished.");

                var userInput = Console.ReadLine();
                
                if(int.TryParse(userInput, out int id))
                {
                    var selectedIngredient = _ingredientsRegister.GetById(id);
                    if(selectedIngredient is not null)
                    {
                        ingredients.Add(selectedIngredient);
                    }
                }
                else
                {
                    shallStop = true;
                }
            }

            return ingredients;
        }
    }

public interface IRecipesRepository
{
    List<Recipe> Read(string filePath);
    void Write(string filePath, List<Recipe> allRecipes);
}

public class RecipesRepository : IRecipesRepository
{
    private readonly IStringsRepository _stringsRepository;
    private readonly IngredientsRegister _ingredientsRegister;
    private const string Separator = ",";

    public RecipesRepository(
        IStringsRepository stringsRepository,
        IngredientsRegister ingredientsRegister)
    {
        _stringsRepository = stringsRepository;
        _ingredientsRegister = ingredientsRegister;
    }

    public List<Recipe> Read(string filePath)
    {
        List<string> recipesFromFile = _stringsRepository.Read(filePath);
        var recipes = new List<Recipe>();

        foreach(var recipeFromFile in recipesFromFile)
        {
            var recipe = RecipeFromString(recipeFromFile);
            recipes.Add(recipe);
        }

        return recipes;
    }

    private Recipe RecipeFromString(string recipeFromFile)
    {
        var textualIds = recipeFromFile.Split(Separator);
        var ingredients = new List<Ingredient>();

        foreach(var textualId in textualIds)
        {
            var id = int.Parse(textualId);
            //?
        }
    }

    public void Write(string filePath, List<Recipe> allRecipes)
    {
        var recipesAsStrings = new List<string>();
        foreach(var recipe in allRecipes)
        {
            var allIds = new List<int>();
            foreach(var ingredient in recipe.Ingredients)
            {
                allIds.Add(ingredient.Id);
            }
            recipesAsStrings.Add(string.Join(Separator, allIds));
        }

        _stringsRepository.Write(filePath, recipesAsStrings);
    }
}
}
