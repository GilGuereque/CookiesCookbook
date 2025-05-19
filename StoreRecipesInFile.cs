using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace CookieCookbook.StoreRecipes
{
    public class Recipe
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Instructions { get; set; }
    }

    public class StoreRecipesInFile
    {
        public StoreRecipesInFile() { }

        private Recipe recipe = new Recipe
        {
            Id = 1,
            Name = "Butter",
            Instructions = "This is a test recipe. Add to other ingredients"
        };

        public const string FileName = "Recipe.json";

        public void SaveAndReadRecipe()
        {
            // Serialize the recipe object to JSON and save it to a file
            string jsonString = JsonSerializer.Serialize(recipe);
            File.WriteAllText(FileName, jsonString);

            // Read the content of the file and print it to the console
            Console.WriteLine(File.ReadAllText(FileName));
        }
    }
}
