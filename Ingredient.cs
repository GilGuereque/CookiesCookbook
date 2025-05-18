
namespace CookieCookbook.IngredientsList
{
    public static class IngredientRepository
    {
        public static List<Ingredient> Ingredients { get; } = new()
        {
            new Ingredient { Id = 1, Name = "Wheat Flour", PreparationInstructions = "Sieve. Add to other ingredients." },
            new Ingredient { Id = 2, Name = "Coconut Flour", PreparationInstructions = "Sieve. Add to other ingredients." },
            new Ingredient { Id = 3, Name = "Butter", PreparationInstructions = "Melt on low heat. Add to other ingredients." },
            new Ingredient { Id = 4, Name = "Chocolate", PreparationInstructions = "Melt in a water bath. Add to other ingredients." },
            new Ingredient { Id = 5, Name = "Sugar", PreparationInstructions = "Add to other ingredients." },
            new Ingredient { Id = 6, Name = "Cardamom", PreparationInstructions = "Take half a teaspoon. Add to other ingredients." },
            new Ingredient { Id = 7, Name = "Cinnamon", PreparationInstructions = "Take half a teaspoon. Add to other ingredients." },
            new Ingredient { Id = 8, Name = "Cocoa powder", PreparationInstructions = "Add to other ingredients. " },
            new Ingredient { Id = 9, Name = "Rice Flour", PreparationInstructions = "Sieve. Add to other ingredients." },
            new Ingredient { Id = 10, Name = "Powdered Sugar", PreparationInstructions = "Sprinkle on top." }
        };
    }

    public class Ingredient
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string PreparationInstructions { get; set; }
    }
}
