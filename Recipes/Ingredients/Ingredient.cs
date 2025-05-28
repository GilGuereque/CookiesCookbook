namespace CookieCookbook.Recipes.Ingredients
{
    public abstract class Ingredients //might have to swap Ingredients with Ingredient
    {
        public abstract int Id { get; }
        public abstract string Name { get; }
        public virtual string PreparationInstructions =>
            "Add to other ingredients.";
    }
    public abstract class Ingredient : Ingredients
    {
    }
}