namespace CookieCookbook.Recipes.Ingredients
{
    public class PowderedSugar : Ingredient
    {
        public override int Id => 9;
        public override string Name => "Powdered Sugar";
        public override string PreparationInstructions =>
            $"Sprinkle on top. {base.PreparationInstructions}";
    }
}
