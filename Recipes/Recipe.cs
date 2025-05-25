namespace CookieCookbook.Recipes
{
   public class Recipe
    {
        public IEnumerable<Recipe> Ingredients { get; }

        public Recipe(IEnumerable<Recipe> ingredients)
        {
            Ingredients = ingredients;
        }
    }
}
