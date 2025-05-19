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
        public const string Folder = @"C:\Users\prakt\source\repos\CSharp\CookieCookbook";


        public void SaveAndReadRecipe()
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
            string FullPath = Path.Combine(projectRoot, FileName);


            //// Create full file path
            //string FullPath = Path.Combine(Folder, FileName);

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
