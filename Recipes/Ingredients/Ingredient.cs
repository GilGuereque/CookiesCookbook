namespace CookieCookbook.Recipes
{
    public abstract class Ingredient : Ingredients
    {
    }
    public abstract class Ingredients
    {
        public abstract int Id { get; }
        public abstract string Name { get; }
        public virtual string PreparationInstructions =>
            "Add to other ingredients.";
    }
}