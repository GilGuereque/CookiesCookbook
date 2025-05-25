namespace CookieCookbook.Recipes.Ingredients
{
    public class ChocolateChips : Ingredient
    {
        public override int Id => 10;
        public override string Name => "Chocolate Chips";
        public override string PreparationInstructions =>
            $"Mix into other ingredients.";
    }
}
