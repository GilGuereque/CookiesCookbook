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
    List<Recipe> Read(string FilePath);
}

    public class RecipesRepository : IRecipesRepository
    {
        public List<Recipe> Read(string FilePath)
        {
            return new List<Recipe>
            {
                new Recipe(new List<Ingredient>
                {
                    new WheatFlour(),
                    new Butter(),
                    new Sugar()
                }),
                new Recipe(new List<Ingredient>
                {
                    new CocoaPowder(),
                    new SpeltFlour(),
                    new Cinnamon()
                })
            };
        }
    }
}
