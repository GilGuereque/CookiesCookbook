using System;
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
        // FullPath is now a public property, initialized in the constructor
        public string FullPath { get; private set; }

        private Recipe recipe = new Recipe
        {
            Id = 1,
            Name = "Butter",
            Instructions = "This is a test recipe. Add to other ingredients"
        };

        public const string FileName = "Recipe.json";
        public const string Folder = @"C:\Users\prakt\source\repos\CSharp\CookieCookbook";

        public StoreRecipesInFile()
        {
            // 1) Where is our exe running?
            string exeFolder = AppContext.BaseDirectory;
            // exeFolder is like …\CookieCookbook\bin\Debug\net8.0\

            // 2) Walk up three levels to reach the project root
            string projectRoot = Path.GetFullPath(
                Path.Combine(exeFolder, "..", "..", "..")
            );
            // now projectRoot is …\CookieCookbook\

            // 3) Build the full path to Recipe.json in the project folder
            FullPath = Path.Combine(projectRoot, FileName);

            //// Create full file path
            //string FullPath = Path.Combine(Folder, FileName);
        }

        public void SaveAndReadRecipe()
        {
            // Pretty Print the JSON:
            // 4) Serialize + save
            string jsonString = JsonSerializer.Serialize(recipe, new JsonSerializerOptions { WriteIndented = true });

            // Serialize the recipe object to JSON and save it to a file
            //string jsonString = JsonSerializer.Serialize(recipe);
            File.WriteAllText(FullPath, jsonString);

            // 5) Read it back and display output & folder path
            Console.WriteLine($"Saved recipe to: {FullPath}\n");
            Console.WriteLine(File.ReadAllText(FullPath));

            //// Read the content of the file and print it to the console
            //Console.WriteLine(File.ReadAllText(FileName));
        }
    }
}
