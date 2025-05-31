﻿using CookieCookbook.Recipes;

namespace CookieCookbook.App
{
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
    }
}
